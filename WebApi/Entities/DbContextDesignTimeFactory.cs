using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApi.Entities
{
    /// <summary>
    /// 用于解决使用Identity框架时EFCore框架无法识别DbContext的问题。
    /// </summary>
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        //private readonly IConfiguration configuration;
        //public DbContextDesignTimeFactory(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        public LibraryDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<LibraryDbContext> contextOptionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();
            //var connStr = configuration.GetConnectionString("DefaultConnection");
            var connStr = "server=127.0.0.1;uid=root;pwd=123456;port=3306;database=EFcoreDb;";
            contextOptionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
            return new LibraryDbContext(contextOptionsBuilder.Options);
        }
    }
}
