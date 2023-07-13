using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MyFirstEfCoreApp.Data;
using MyFirstEfCoreApp.Data.Entities;

namespace MyFirstEfCoreApp
{
    public static class Commands
    {
        //public static void ListAll()
        //{
        //    using(var db  = new ApplicationDbContext()) //Create the app's DbContext through which all database access is done
        //    {
        //        foreach(var book in db.Books.AsNoTracking() /// This reads all the books. AsNoTracking() says this is a read-only access
        //            .Include(book => book.Author)) // The include causes the Author information to be 'eagerly' loaded with each book.
        //        {
        //            var webUrl = book.Author.WebUrl ?? "- no web url given -";
        //            Console.WriteLine($"{book.Title} by {book.Author.Name}");
        //            Console.WriteLine("   Published on " +
        //                                $"{book.PublishedOn:dd-MMM-yyyy}. {webUrl}"
        //                );
        //        }
        //    }
        //}

        //public static void ChangeWebUrl()
        //{
        //    Console.Write("New Quantum Networking WebUrl > ");
        //    var newWebUrl = Console.ReadLine();

        //    using(var db = new ApplicationDbContext())
        //    {
                
        //        var singleBook = db.Books
        //            .Include(book => book.Author) // Make sure the author information is 'eager' loaded with the book
        //            .Single(book => book.Title == "Quantum Networking"); // Select only the book with this title

        //        singleBook.Author.WebUrl = newWebUrl; // Update value in this column
        //        db.SaveChanges(); //  The SaveChanges() tell EF Core to check for any changes to the data that has been read in and write out those changes to the database
        //        Console.WriteLine("... SaveChanges called.");

        //    }

        //    ListAll(); // List all the book information
        //}

        ///// <summary>
        ///// This will wipe and create a new database - this may take some time
        ///// </summary>
        ///// <param name="onlyIfNoDatabase">If true, it will do nothong if the database was created</param>
        ///// <returns>returns true if database was created</returns>
        //public static bool WipeCreateSeed(bool onlyIfNoDatabase)
        //{
        //    using var db = new ApplicationDbContext();
        //    if (onlyIfNoDatabase && (db.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
        //        return false;
            
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();
        //    if (!db.Books.Any())
        //    {
        //        WriteTestData(db);
        //        Console.WriteLine("Seeded database");
        //    }

        //    return true;
        //}

        //private static void WriteTestData(this ApplicationDbContext db)
        //{
        //    var Simon = new Author
        //    {
        //        Name = "Simon Maina",
        //        WebUrl = "https://smaina.com/"
        //    };

        //    var books = new List<Book>
        //    {
        //        new Book
        //        {
        //            Title = "Refactoring",
        //            Description = "Improving the design of existing code",
        //            PublishedOn = new DateTime(1999, 7, 8),
        //            Author = Simon
        //        },
        //        new Book
        //        {
        //            Title = "Patterns of Enterprise Application Architecture",
        //            Description = "Written in direct response to the stiff challenges",
        //            PublishedOn = new DateTime(2002, 11, 15),
        //            Author = Simon
        //        },
        //        new Book
        //        {
        //            Title = "Domain-Driven Design",
        //            Description = "Linking business needs to software design",
        //            PublishedOn = new DateTime(2003, 8, 30),
        //            Author = new Author {Name = "Eric Evans", WebUrl = "http://domainlanguage.com/"}
        //        },
        //        new Book
        //        {
        //            Title = "Quantum Networking",
        //            Description = "Entangled quantum networking provides faster-than-light data communications",
        //            PublishedOn = new DateTime(2057, 1, 1),
        //            Author = new Author {Name = "Future Person"}
        //        }
        //    };

        //    db.Books.AddRange(books);
        //    db.SaveChanges();
        //}
    }
}
