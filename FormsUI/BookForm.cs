using System;
using System.Windows.Forms;
using Business;
using Entities;

namespace FormsUI
{
    public partial class BookForm : Form
    {
        private BookManager _bookManager;

        public BookForm()
        {
            InitializeComponent();
            _bookManager = new BookManager();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            // Form açıldığında liste otomatik gelmez
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("Kitap Adı, Yazar ve ISBN zorunludur!");
                return;
            }

            try
            {
                Book newBook = new Book
                {
                    Id = _bookManager.GetNextId(),
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    ISBN = txtISBN.Text,
                    PageCount = int.TryParse(txtPageCount.Text, out int page) ? page : 0,
                    PublishYear = int.TryParse(txtPublishYear.Text, out int year) ? year : 0
                };

                _bookManager.Add(newBook);
                MessageBox.Show("Kitap eklendi.");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var selectedBook = (Book)dgvBooks.SelectedRows[0].DataBoundItem;
                _bookManager.Remove(selectedBook.Id);
                MessageBox.Show("Kitap silindi.");
                LoadBooks();
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kitap seçin.");
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = _bookManager.GetAll();
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtISBN.Clear();
            txtPageCount.Clear();
            txtPublishYear.Clear();
        }
    }
}
