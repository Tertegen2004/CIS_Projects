using Microsoft.EntityFrameworkCore;
using task_cis.classes;

namespace task_cis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {

                var author = new Author { Name = "Robert C. Martin", BirthDate = new DateTime(1952, 12, 5) };
                context.Authors.Add(author);
                context.SaveChanges();

                var book = new Book { Title = "C#", AuthorId = author.Id, PublishedYear = 2008, Genre = "Programming" };
                context.Books.Add(book);
                context.SaveChanges();

                var borrower = new Borrower { Name = "Ahmed Gamal", Email = "ahmed@example.com" };
                context.Borrowers.Add(borrower);
                context.SaveChanges();

                var borrowRecord = new BorrowedBook
                {
                    BookId = book.Id,
                    BorrowerId = borrower.Id,
                    BorrowedDate = DateTime.Now.AddDays(-20),
                    DueDate = DateTime.Now.AddDays(-6)
                };
                context.BorrowedBooks.Add(borrowRecord);
                context.SaveChanges();

                borrowRecord.ReturnedDate = DateTime.Now.AddDays(-2);
                context.SaveChanges();

                context.Reviews.Add(new Review
                {
                    BookId = book.Id,
                    BorrowerId = borrower.Id,
                    Rating = 5,
                    Comment = "Great book!",
                    ReviewDate = DateTime.Now
                });
                context.SaveChanges();

                var overdue = context.BorrowedBooks
                    .Where(bb => bb.ReturnedDate == null && bb.DueDate < DateTime.Now)
                    .Include(bb => bb.Book)
                    .Include(bb => bb.Borrower)
                    .Select(bb => new { bb.Book.Title, bb.Borrower.Name, bb.DueDate })
                    .ToList();

                Console.WriteLine("\n[1] Overdue Books:");
                overdue.ForEach(o => Console.WriteLine($"{o.Title} - {o.Name} (Due {o.DueDate:d})"));

                var top3 = context.Reviews
                    .GroupBy(r => r.Book)
                    .Select(g => new { g.Key.Title, Avg = g.Average(r => r.Rating) })
                    .OrderByDescending(x => x.Avg)
                    .Take(3)
                    .ToList();

                Console.WriteLine("\n[2] Top 3 Books by Avg Rating:");
                top3.ForEach(t => Console.WriteLine($"{t.Title} - {t.Avg:F1}"));

                var booksByGenreAuthor = context.Books
                    .Include(b => b.Author)
                    .Select(b => new { b.Title, b.Genre, Author = b.Author.Name })
                    .ToList();

                Console.WriteLine("\n[3] Books (Genre & Author):");
                booksByGenreAuthor.ForEach(b => Console.WriteLine($"{b.Title} ({b.Genre}) - {b.Author}"));

                var punctualBorrowers = context.Borrowers
                    .Where(b => !b.BorrowedBooks.Any(bb => bb.ReturnedDate > bb.DueDate))
                    .Select(b => b.Name)
                    .ToList();

                Console.WriteLine("\n[4] Borrowers who never returned late:");
                punctualBorrowers.ForEach(Console.WriteLine);

                var reviewsForBook = context.Reviews
                    .Where(r => r.BookId == book.Id)
                    .Include(r => r.Borrower)
                    .Select(r => new { r.Borrower.Name, r.Rating, r.Comment })
                    .ToList();

                Console.WriteLine($"\n[5] Reviews for '{book.Title}':");
                reviewsForBook.ForEach(r => Console.WriteLine($"{r.Name}: {r.Rating}/5 - {r.Comment}"));

                var neverBorrowed = context.Books
                    .Where(b => !b.BorrowedBooks.Any())
                    .Select(b => b.Title)
                    .ToList();

                Console.WriteLine("\n[6] Books never borrowed:");
                neverBorrowed.ForEach(Console.WriteLine);

                var noReviews = context.Books
                    .Where(b => !b.Reviews.Any())
                    .Select(b => b.Title)
                    .ToList();

                Console.WriteLine("\n[7] Books with no reviews:");
                noReviews.ForEach(Console.WriteLine);

                var avgGenre = context.Books
                    .GroupBy(b => b.Genre)
                    .Select(g => new
                    {
                        Genre = g.Key,
                        Avg = g.SelectMany(b => b.Reviews).Average(r => (double?)r.Rating) ?? 0
                    })
                    .ToList();

                Console.WriteLine("\n[8] Average Rating per Genre:");
                avgGenre.ForEach(g => Console.WriteLine($"{g.Genre}: {g.Avg:F1}"));

                var activeReviewers = context.Borrowers
                    .Where(b => b.Reviews.Count() > 3)
                    .Select(b => new { b.Name, ReviewCount = b.Reviews.Count })
                    .ToList();

                Console.WriteLine("\n[9] Borrowers who reviewed > 3 books:");
                activeReviewers.ForEach(ar => Console.WriteLine($"{ar.Name} ({ar.ReviewCount})"));

                var oneYearAgo = DateTime.Now.AddYears(-1);
                var mostBorrowed = context.BorrowedBooks
                    .Where(bb => bb.BorrowedDate >= oneYearAgo)
                    .GroupBy(bb => bb.Book)
                    .Select(g => new { g.Key.Title, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                Console.WriteLine("\n[10] Most borrowed books in last year:");
                mostBorrowed.ForEach(mb => Console.WriteLine($"{mb.Title} ({mb.Count})"));

                var topAuthor = context.Authors
                    .OrderByDescending(a => a.Books.Count())
                    .FirstOrDefault();

                Console.WriteLine($"\n[11] Author with most books: {topAuthor?.Name} ({topAuthor?.Books.Count})");

                var authorsNoReviews = context.Authors
                    .Where(a => a.Books.All(b => !b.Reviews.Any()))
                    .Select(a => a.Name)
                    .ToList();

                Console.WriteLine("\n[12] Authors whose books never reviewed:");
                authorsNoReviews.ForEach(Console.WriteLine);
            }
        }
    }
}
    
