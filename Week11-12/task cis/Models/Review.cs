namespace task_cis.classes
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public Book Book { get; set; }
        public Borrower Borrower { get; set; }
    }
}