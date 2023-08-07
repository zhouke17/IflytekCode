using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Entities
{
    public class LibraryDbContext: IdentityDbContext<User, Role, string>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options):base(options)
        {}

    }
}
