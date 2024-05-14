using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLCanBoCA
{
    public partial class fAccount : Form
    {
        public fAccount()
        {
            InitializeComponent();
        }
        #region Design
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                button1.BringToFront();
                txtPass.PasswordChar = '\0';
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '\0')
            {
                button2.BringToFront();
                txtPass.PasswordChar = '*';
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (txtNewPass.PasswordChar == '*')
            {
                button3.BringToFront();
                txtNewPass.PasswordChar = '\0';
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNewPass.PasswordChar == '\0')
            {
                button4.BringToFront();
                txtNewPass.PasswordChar = '*';
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (txtPassRetype.PasswordChar == '*')
            {
                button5.BringToFront();
                txtPassRetype.PasswordChar = '\0';
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (txtPassRetype.PasswordChar == '\0')
            {
                button6.BringToFront();
                txtPassRetype.PasswordChar = '*';
            }
        }
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        AccountDTO acc = BUS.AccountBUS.account(AccountGUI.getUserAccount());
        public  void loadAcc()
        {
            txtUser.Text = AccountGUI.getUserAccount();
            txtDisplayUser.Text = acc.Name;
        }
        private void fAccount_Load(object sender, EventArgs e)
        {
            loadAcc();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "")
            {
                MessageBox.Show("Bạn chưa điền tên hiển thị");
            }
            else
            {
                if (txtPass.Text == AccountGUI.getPassAccount())
                {
                    if (txtNewPass.Text == txtPassRetype.Text)
                    {
                        acc.Name = txtName.Text;
                        acc.Password = txtNewPass.Text;
                        BUS.AccountBUS.UpdateAccount(acc.User, acc.Name, acc.Password, acc.idType);
                        MessageBox.Show("Cập nhập tài khoản thành công");
                        txtName.Clear();
                        txtPass.Clear();
                        txtNewPass.Clear();
                        txtPassRetype.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới nhập lại không khớp");
                    }
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu");
                }
                loadAcc();
            }
        }
    }
}
