using System.ComponentModel.DataAnnotations;

namespace MyFirstEfCoreApp.Data.Entities
{
    public class Author
    {
        public int AuthorId { get; set; } // Hold the primary key of the Author Row in the database
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        // Relationships
        public ICollection<BookAuthor> BooksLink { get; set; }
        

    }
}
