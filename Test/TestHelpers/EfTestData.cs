﻿using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp.Test.TestHelpers
{
    public static class EfTestData
    {
        public static readonly DateTime DummyBookStartDate = new DateTime(2010, 1, 1);

        public static void SeedDatabaseDummyBooks(this ApplicationDbContext context, int numBooks = 10)
        {
            context.Books.AddRange(CreateDummyBooks(numBooks));
            context.SaveChanges();
        }

        public static Book CreateDummyBookOneAuthor()
        {
            var book = new Book
            {
                Title = "Book Title",
                Description = "Book Description",
                Price = 123,
                PublishedOn = DummyBookStartDate
            };

            var author = new Author { Name = "Test Author" };

            book.AuthorsLink = new List<BookAuthor>
            {
                new BookAuthor {Book = book, Author = author}
            };

            return book;
        }

        public static List<Book> CreateDummyBooks(int numBooks = 10, bool stepByYears = false, bool setBookId = true)
        {
            var result = new List<Book>();
            var commonAuthor = new Author { Name = "CommonAuthor" };

            for (int i = 0; i < numBooks; i++)
            {
                var reviews = new List<Review>();
                for (int j = 0; j < i; j++)
                {
                    reviews.Add(new Review { VoterName = j.ToString(), NumStars = (j % 5) + 1 });
                }

                var book = new Book
                {
                    BookId = setBookId ? i + 1 : 0,
                    Title = $"Book{i:D4} Title",
                    Description = $"Book{i:D4} Description",
                    Price = (short)(i + 1),
                    ImageUrl = $"Image{i:D4}",
                    PublishedOn = stepByYears ? DummyBookStartDate.AddYears(i) : DummyBookStartDate.AddDays(i),
                    Reviews = reviews
                };

                var author = new Author { Name = $"Author{i:D4}" };
                book.AuthorsLink = new List<BookAuthor>
                {
                    new BookAuthor {Book = book, Author = author, Order = 0},
                    new BookAuthor {Book = book, Author = commonAuthor, Order = 1}
                };

                result.Add(book);
            }

            return result;
        }


        public async static Task<List<Book>> SeedDatabaseFourBooksAsync(this ApplicationDbContext context)
        {
            var books = CreateFourBooks();
            context.Books.AddRange(books);
            await context.SaveChangesAsync();
            return books;
        }

        public static List<Book> CreateFourBooks()
        {
            var editorsChoice = new Tag { TagId = "Editor's Choice" };
            var architectureTag = new Tag { TagId = "Architecture" };
            var refactoring = new Tag { TagId = "Refactoring" };

            var simonMaina = new Author
            {
                Name = "Simon Maina"
            };

            var books = new List<Book>();

            var book1 = new Book
            {
                Title = "Refactoring",
                Description = "Improving the design of existing code",
                PublishedOn = new DateTime(1999, 7, 8),
                Publisher = "Manning Publishers",
                ImageUrl = "Image0001",
                Price = 40,
                Tags = new List<Tag> { editorsChoice, refactoring }
            };

            book1.AuthorsLink = new List<BookAuthor> { new BookAuthor { Book = book1, Author = simonMaina } };
            books.Add(book1);

            var book2 = new Book
            {
                Title = "Patterns of Enterprise Application Architecture",
                Description = "Written in direct response to the stiff challenges",
                PublishedOn = new DateTime(2002, 11, 15),
                Publisher = "Manning Publishers",
                ImageUrl = "Image0001",
                Price = 53,
                Tags = new List<Tag> { architectureTag }
            };
            book2.AuthorsLink = new List<BookAuthor> { new BookAuthor { Author = simonMaina, Book = book2 } };
            books.Add(book2);

            var book3 = new Book
            {
                Title = "Domain-Driven Design",
                Description = "Linking business needs to software design",
                PublishedOn = new DateTime(2003, 8, 30),
                Publisher = "Manning Publishers",
                ImageUrl = "Image0001",
                Price = 56,
                Tags = new List<Tag> { architectureTag, editorsChoice }
            };
            book3.AuthorsLink = new List<BookAuthor>
                {new BookAuthor {Author = new Author {Name = "Eric Evans"}, Book = book3}};
            books.Add(book3);

            var book4 = new Book
            {
                Title = "Quantum Networking",
                Description = "Entangled quantum networking provides faster-than-light data communications",
                PublishedOn = new DateTime(2057, 1, 1),
                Publisher = "Manning Publishers",
                ImageUrl = "Image0001",
                Price = 220,
                Tags = new List<Tag> { new Tag { TagId = "Quantum Entanglement" } }
            };
            book4.AuthorsLink = new List<BookAuthor>
                {new BookAuthor {Author = new Author {Name = "Future Person"}, Book = book4}};
            book4.Reviews = new List<Review>
            {
                new Review
                {
                    VoterName = "Jon P Smith", NumStars = 5,
                    Comment = "I look forward to reading this book, if I am still alive!"
                },
                new Review
                {
                    VoterName = "Albert Einstein", NumStars = 5, Comment = "I write this book if I was still alive!"
                }
            };
            book4.Promotion = new PriceOffer { NewPrice = 219, PromotionalText = "Save $1 if you order 40 years ahead!" };
            books.Add(book4);

            return books;

        }


    }
}
