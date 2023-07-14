namespace MyFirstEfCoreApp.Data.Entities
{
    public class Book
    {
        public int BookId { get; set; } // Holds the primary key
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public bool SoftDeleted { get; set; }

        // -------------------- relationships
        public PriceOffer Promotion { get; set; } // Link to optional one-to-one PriceOffer relationship 
        public ICollection<Review> Reviews { get; set; } // There can be zero to many reviews of the book
        public ICollection<Tag> Tags { get; set; } // Ef Core's automatic many-to-many relationship to the Tag entity class
        public ICollection<BookAuthor> AuthorsLink { get; set; } // Provides a link to the many-to-many linking table that links to the Authors of this book
     
    }
}
