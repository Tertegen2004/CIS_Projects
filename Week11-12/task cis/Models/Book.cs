namespace task_cis.classes
{
    public class Book
    {
       
            public int Id { get; set; }
            public string Title { get; set; }
            public int AuthorId { get; set; }
            public int PublishedYear { get; set; }
            public string Genre { get; set; }

            public Author Author { get; set; }
            public ICollection<Review> Reviews { get; set; }
            public ICollection<BorrowedBook> BorrowedBooks { get; set; }
        }
    }
