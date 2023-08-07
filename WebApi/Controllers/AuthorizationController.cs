using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger<AuthorizationController> logger;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AuthorizationController(ILogger<AuthorizationController> logger, RoleManager<Role> roleManager, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            this.logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(string userName)
        {
            bool roleExist = await roleManager.RoleExistsAsync("admin");
            if (!roleExist)
            {
                Role role = new Role { Name = "Admin",Id = Guid.NewGuid().ToString() };
                var r = await roleManager.CreateAsync(role);
                if (!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }
            }
            User user = await this.userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new User {Id = Guid.NewGuid().ToString(), UserName = userName, Email = $"{userName}@gmail.com", EmailConfirmed = true };
                var r = await userManager.CreateAsync(user, "123456");
                if (!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }
                r = await userManager.AddToRoleAsync(user, "admin");
                if (!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginUser req)
        {
            string userName = req.UserName;
            string password = req.Password;
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                if (webHostEnvironment.IsDevelopment())//是否为开发环境
                {
                    return NotFound($"用户名不存在{userName}");
                }
                else
                {
                    return BadRequest();
                }
            }
            if (await userManager.IsLockedOutAsync(user))//是否被锁定
            {
                return BadRequest("LockedOut");
            }
            var success = await userManager.CheckPasswordAsync(user, password);//检查用户名、密码是否正确
            if (success)
            {
                await userManager.ResetAccessFailedCountAsync(user); //重置统计登陆失败的计数。
                return Ok("Success");
            }
            else
            {
                var r = await userManager.AccessFailedAsync(user); //统计登陆失败的次数。
                if (!r.Succeeded)
                {
                    return BadRequest("AccessFailed failed");
                }
                return BadRequest("Failed");
            }
        }

        [HttpPost("SendResetPasswordToken")]
        [AllowAnonymous]//匿名访问特性，不需要认证。
        public async Task<IActionResult> SendResetPasswordToken(
                    SendResetPasswordTokenRequest req)
        {
            string email = req.Email;
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"邮箱不存在{email}");
            }
            string token = await userManager.GeneratePasswordResetTokenAsync(user);
            logger.LogInformation($"向邮箱{user.Email}发送Token={token}");
            return Ok();
        }
    }

    public record SendResetPasswordTokenRequest(string Email);

    public record LoginUser(string UserName,string Password);
}
