using System;

namespace Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime LoanDate { get; set; }

        // Null olabilmesi için ? ekledik
        public DateTime? ReturnDate { get; set; }

        // Ceza alanı
        public decimal Penalty { get; set; }
    }
}
