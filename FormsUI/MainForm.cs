using System;
using System.Windows.Forms;

namespace FormsUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            bookForm.Show();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            MemberForm memberForm = new MemberForm();
            memberForm.Show();
        }

        private void btnLoans_Click(object sender, EventArgs e)
        {
            LoanForm loanForm = new LoanForm();
            loanForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // İstenirse başlangıçta bir işlem yapılabilir
        }
    }
}
