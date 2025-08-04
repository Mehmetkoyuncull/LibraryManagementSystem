using System;
using System.Linq;
using System.Windows.Forms;
using Business;
using Entities;

namespace FormsUI
{
    public partial class LoanForm : Form
    {
        private LoanManager _loanManager;
        private BookManager _bookManager;
        private MemberManager _memberManager;

        public LoanForm()
        {
            InitializeComponent();
            _loanManager = new LoanManager();
            _bookManager = new BookManager();
            _memberManager = new MemberManager();
        }

        private void LoanForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMembers();
        }

        private void LoadBooks()
        {
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = _bookManager.GetAll();
        }

        private void LoadMembers()
        {
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = _memberManager.GetAll();
        }

        private void btnListLoans_Click(object sender, EventArgs e)
        {
            dgvLoans.DataSource = null;
            dgvLoans.DataSource = _loanManager.GetAll();
        }

        private void btnAddLoan_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0 || dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kitap ve bir üye seçiniz.");
                return;
            }

            var selectedBook = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
            var selectedMember = (Member)dgvMembers.SelectedRows[0].DataBoundItem;

            try
            {
                Loan loan = new Loan
                {
                    Id = _loanManager.GetAll().Count > 0 ? _loanManager.GetAll().Max(l => l.Id) + 1 : 1,
                    BookId = selectedBook.Id,
                    MemberId = selectedMember.Id,
                    LoanDate = DateTime.Now,
                    ReturnDate = null,
                    Penalty = 0
                };

                _loanManager.Add(loan);
                MessageBox.Show("Ödünç verme işlemi başarılı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iade edilecek ödünç kaydını seçiniz.");
                return;
            }

            var selectedLoan = (Loan)dgvLoans.SelectedRows[0].DataBoundItem;
            _loanManager.ReturnBook(selectedLoan.Id);

            // Ceza mesajı
            var updatedLoan = _loanManager.GetAll().FirstOrDefault(l => l.Id == selectedLoan.Id);
            if (updatedLoan != null && updatedLoan.Penalty > 0)
            {
                MessageBox.Show($"Kitap iade edildi. Gecikme cezası: {updatedLoan.Penalty}₺");
            }
            else
            {
                MessageBox.Show("Kitap iade edildi. Ceza bulunmamaktadır.");
            }

            btnListLoans_Click(sender, e); // listeyi yenile
        }
    }
}
