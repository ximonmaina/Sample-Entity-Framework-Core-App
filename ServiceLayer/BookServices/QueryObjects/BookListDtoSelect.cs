using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp.Services.BookServices.QueryObjects
{
    public static class BookListDtoSelect
    {
        // This method uses the Query Object pattern.
        // It takes in IQueryable<T> and returns IQueryable<T>
        // This allows you to encapsulate a query, or part of a query.
        // This makes it easier to find, debug, and performance-tune
        // This pattern can be used for sort, filter, and paging parts of the query
        // This method is also an extension method allowing you to chain Query Objects together
        public static IQueryable<BookListDto> MapBookToDto(this IQueryable<Book> books)
        {
            return books.Select(book => new BookListDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Price = book.Price,
                PublishedOn = book.PublishedOn,
                ActualPrice = book.Promotion == null ? book.Price : book.Promotion.NewPrice,
                PromotionPromotionalText = book.Promotion == null ? null : book.Promotion.PromotionalText,
                AuthorsOrdered = String.Join(",",
                                book.AuthorsLink
                                    .OrderBy(ba => ba.Order)
                                    .Select(ba => ba.Author.Name)),
                ReviewsCount = book.Reviews.Count,
                ReviewsAverageVotes = book.Reviews.Select(review => (double?)review.NumStars).Average(),
                TagStrings = book.Tags.Select(x => x.TagId).ToArray()
            });
        }
    }
}
