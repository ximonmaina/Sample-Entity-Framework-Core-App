namespace MyFirstEfCoreApp.Data.Entities
{
    public class BookLazy
    {
        public int BookLazyId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public virtual PriceOffer Promotion { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<BookAuthor> AuthorsLink { get; set; }
    }
}
