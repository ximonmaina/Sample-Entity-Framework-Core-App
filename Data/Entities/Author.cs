namespace MyFirstEfCoreApp.Data.Entities
{
    public class Author
    {
        public int AuthorId { get; set; } // Hold the primary key of the Author Row in the database
        public string Name { get; set; } = null!;
        public string? WebUrl { get; set; }

    }
}
