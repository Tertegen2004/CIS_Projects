using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_cis.classes
{
     public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
