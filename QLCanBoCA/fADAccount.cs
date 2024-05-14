using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QLCanBoCA
{
    public partial class fADAccount : Form
    {
        public fADAccount()
        {
            InitializeComponent();
        }
        #region Method
        public void LoadAccount()
        {
            List<AccountDTO> accountDTOs = BUS.AccountBUS.GetDSAccount();
            dgvAccount.DataSource = accountDTOs;
        }
        public void loadType()
        {
            List<AccountTypeDTO> accountTypeDTOs = BUS.AccountTypeBUS.GetDSAccountTypes();
            cbbType.DataSource = accountTypeDTOs;
            cbbType.DisplayMember = "name";
            cbbType.ValueMember = "id";
        }
        public void Clear()
        {
            txtUser.Clear();
            txtName.Clear();
            txtPass.Clear();
        }
        #endregion
        private void fADAccount_Load(object sender, EventArgs e)
        {
            LoadAccount();
            loadType();
            btnEdit.Enabled = false;
        }
        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvAccount.CurrentCell.RowIndex;
            txtUser.Text = dgvAccount.Rows[i].Cells[0].Value.ToString();
            txtPass.Text = dgvAccount.Rows[i].Cells[1].Value.ToString();
            txtName.Text = dgvAccount.Rows[i].Cells[2].Value.ToString();
            cbbType.SelectedValue = dgvAccount.Rows[i].Cells[3].Value.ToString();
            btnEdit.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin");
            }
            else
            {
                string user = txtUser.Text;
                string pass = txtPass.Text;
                string name = txtName.Text;
                int type = (int)cbbType.SelectedValue;
                if (BUS.AccountBUS.TestAccount(user))
                {
                    MessageBox.Show("Tên đăng nhập trùng");
                }
                else
                {
                    BUS.AccountBUS.InsertAccount(user, name, pass, type);
                    MessageBox.Show("Đã thêm thành công");
                    LoadAccount();
                    Clear();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "" || txtName.Text == "" ||txtPass.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tài khoản");
            }   
            else
            {
                string user = txtUser.Text;
                string pass = txtPass.Text;
                string name = txtName.Text;
                int type = (int)cbbType.SelectedValue;
                BUS.AccountBUS.UpdateAccount(user, name, pass, type);
                MessageBox.Show("Đã sửa thành công");
                LoadAccount();
                Clear();
            }    
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("Bạn chưa tài khoản");
            }
            else
            {
                string ID;
                int i = dgvAccount.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        ID = dgvAccount.Rows[i].Cells[0].Value.ToString();
                        BUS.AccountBUS.DeleteAccount(ID);
                        LoadAccount();
                        Clear();
                    }
                }
            }
        }
    }
}
