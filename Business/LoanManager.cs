using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using DataAccess;

namespace Business
{
    public class LoanManager
    {
        private readonly string _filePath = "loans.json";
        private List<Loan> _loans;

        public LoanManager()
        {
            _loans = FileHelper<Loan>.LoadFromFile(_filePath);
        }

        public List<Loan> GetAll()
        {
            return _loans;
        }

        public void Add(Loan loan)
        {
            // Aynı kitap iade edilmeden tekrar ödünç verilemez
            if (_loans.Any(l => l.BookId == loan.BookId && l.ReturnDate == null))
                throw new Exception("Bu kitap şu anda başka bir üyede.");

            _loans.Add(loan);
            Save();
        }

        public void ReturnBook(int loanId)
        {
            var loan = _loans.FirstOrDefault(l => l.Id == loanId);
            if (loan != null)
            {
                loan.ReturnDate = DateTime.Now;

                // Ceza hesaplama
                var daysLate = (loan.ReturnDate.Value - loan.LoanDate).TotalDays - 15;
                if (daysLate > 0)
                {
                    loan.Penalty = (decimal)daysLate * 10m; // 10 TL/gün
                }
                else
                {
                    loan.Penalty = 0;
                }

                Save();
            }
        }

        public void Remove(int loanId)
        {
            var loan = _loans.FirstOrDefault(l => l.Id == loanId);
            if (loan != null)
            {
                _loans.Remove(loan);
                Save();
            }
        }

        private void Save()
        {
            FileHelper<Loan>.SaveToFile(_loans, _filePath);
        }
    }
}
