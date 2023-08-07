using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Services;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    var scheme = new OpenApiSecurityScheme()
    {
        Description = "Authorization header. \r\nExample: 'Bearer 12345abcdef'",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Authorization"
        },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    };
    c.AddSecurityDefinition("Authorization", scheme);
    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    c.AddSecurityRequirement(requirement);
}));
builder.Services.AddMemoryCache();
//DbContext
builder.Services.AddDbContext<LibraryDbContext>(config =>
{
    string connStr = builder.Configuration.GetConnectionString("DefaultConnection");
    config.UseMySql(connStr,ServerVersion.AutoDetect(connStr));
});
//仓储模式一
//builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
//builder.Services.AddScoped<IBookRepository, BookRepository>();

//仓储模式二
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(LibraryMappingProfile));

//Identity
builder.Services.AddDataProtection();
builder.Services.AddIdentityCore<User>(options => 
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
});
IdentityBuilder identity = new IdentityBuilder(typeof(User),typeof(Role),builder.Services);
identity.AddEntityFrameworkStores<LibraryDbContext>()
    .AddDefaultTokenProviders()
    .AddUserManager<UserManager<User>>()
    .AddRoleManager<RoleManager<Role>>();


//JWT认证
var tokenSection = builder.Configuration.GetSection("Security:Token");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSection["Key"]))
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseResponseCaching();

app.MapControllers();

app.Run();
