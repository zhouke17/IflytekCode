using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/Auth/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        private readonly UserManager<User> userManager;
        public AuthenticateController(IConfiguration configuration, UserManager<User> userManager)
        {
            Configuration = configuration;
            this.userManager = userManager;
        }
   
        [HttpPost(Name = nameof(GenerateToken))]
        public async Task<IActionResult> GenerateToken(LoginUser loginUser)
        {
            var user = await userManager.FindByNameAsync(loginUser.UserName);
            if (user == null)
            {
                return Unauthorized();
            }
            var success = await userManager.CheckPasswordAsync(user,loginUser.Password);
            if (!success)
            {
                return BadRequest("用户名或密码错误！");
            }

            //负载信息
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub,loginUser.UserName)
        };
            //密钥
            var tokenConfigSection = Configuration.GetSection("Security:Token");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigSection["Key"]));

            //头部
            var signCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: signCredential);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                expiration = TimeZoneInfo.ConvertTimeFromUtc(jwtToken.ValidTo, TimeZoneInfo.Local)
            });
        }
    }
}
