using Microsoft.AspNetCore.Identity;

namespace WebApi.Entities
{
    public class User:IdentityUser<string>
    {
        public DateTime CreationTime { get; set; }
        public string? NickName { get; set; }
    }
}
