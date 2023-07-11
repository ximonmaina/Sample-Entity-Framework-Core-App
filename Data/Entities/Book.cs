namespace MyFirstEfCoreApp.Data.Entities
{
    public class Book
    {
        public int BookId { get; set; } // Holds the primary key
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public int AuthorId { get; set; } // Holds the foreign key to the row holding the author
        public Author Author { get; set; } = null!; // EF Core will create a link to the Author class using the AuthorId foreign key
    }
}
