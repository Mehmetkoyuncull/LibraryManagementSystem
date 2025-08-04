using System;
using System.Windows.Forms;
using Business;
using Entities;

namespace FormsUI
{
    public partial class MemberForm : Form
    {
        private MemberManager _memberManager;

        public MemberForm()
        {
            InitializeComponent();
            _memberManager = new MemberManager();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            // Form açıldığında liste otomatik dolmayacak
            dgvMembers.DataSource = null;
        }

        private void LoadMembers()
        {
            dgvMembers.DataSource = null;
            dgvMembers.DataSource = _memberManager.GetAll();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            LoadMembers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                    string.IsNullOrWhiteSpace(txtTCNo.Text))
                {
                    MessageBox.Show("Ad Soyad ve TC No zorunludur!");
                    return;
                }

                Member member = new Member
                {
                    FullName = txtFullName.Text,
                    TCNo = txtTCNo.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text
                };

                _memberManager.Add(member);
                MessageBox.Show("Üye eklendi. Listeyi görmek için 'Listele'ye basın.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                var selectedMember = (Member)dgvMembers.SelectedRows[0].DataBoundItem;
                _memberManager.Remove(selectedMember.Id);
                MessageBox.Show("Üye silindi. Listeyi görmek için 'Listele'ye basın.");
            }
            else
            {
                MessageBox.Show("Silmek için bir üye seçin.");
            }
        }
    }
}
