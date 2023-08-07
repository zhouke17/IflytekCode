using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Author
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required,MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
