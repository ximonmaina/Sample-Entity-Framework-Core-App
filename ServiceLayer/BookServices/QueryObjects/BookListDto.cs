namespace MyFirstEfCoreApp.Services.BookServices.QueryObjects
{
    public class BookListDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedOn { get; set; }
        // The normal selling price of the book
        public decimal Price { get; set; }
        // Selling price - either the normal price or the promotional.NewPrice if present
        public decimal ActualPrice { get; set; }
        // To show whether there is a new price
        public string PromotionPromotionalText { get; set; }
        // String to hold comma-delimited author names
        public string AuthorsOrdered { get; set; }
        // No. of people who reviewed the book
        public int ReviewsCount { get; set; }
        // Average of all the votes, null if no votes
        public double? ReviewsAverageVotes { get; set; }
        // Categories for this book
        public string[] TagStrings { get; set; }

    }
}
