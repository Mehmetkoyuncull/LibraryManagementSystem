namespace FormsUI
{
    partial class BookForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtPageCount = new System.Windows.Forms.TextBox();
            this.txtPublishYear = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.lblPublishYear = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // Labels
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Kitap Adı:";

            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(20, 60);
            this.lblAuthor.Text = "Yazar:";

            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(20, 100);
            this.lblISBN.Text = "ISBN:";

            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Location = new System.Drawing.Point(20, 140);
            this.lblPageCount.Text = "Sayfa Sayısı:";

            this.lblPublishYear.AutoSize = true;
            this.lblPublishYear.Location = new System.Drawing.Point(20, 180);
            this.lblPublishYear.Text = "Basım Yılı:";
            // 
            // TextBoxes
            // 
            this.txtTitle.Location = new System.Drawing.Point(120, 20);
            this.txtAuthor.Location = new System.Drawing.Point(120, 60);
            this.txtISBN.Location = new System.Drawing.Point(120, 100);
            this.txtPageCount.Location = new System.Drawing.Point(120, 140);
            this.txtPublishYear.Location = new System.Drawing.Point(120, 180);
            // 
            // Buttons
            // 
            this.btnAdd.Location = new System.Drawing.Point(300, 20);
            this.btnAdd.Text = "Ekle";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Location = new System.Drawing.Point(300, 60);
            this.btnDelete.Text = "Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnList.Location = new System.Drawing.Point(300, 100);
            this.btnList.Text = "Listele";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // DataGridView
            // 
            this.dgvBooks.Location = new System.Drawing.Point(20, 230);
            this.dgvBooks.Size = new System.Drawing.Size(500, 200);
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // BookForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblPageCount);
            this.Controls.Add(this.lblPublishYear);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtPageCount);
            this.Controls.Add(this.txtPublishYear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.dgvBooks);
            this.Text = "Kitap İşlemleri";
            this.Load += new System.EventHandler(this.BookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtPageCount;
        private System.Windows.Forms.TextBox txtPublishYear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label lblPublishYear;
    }
}
