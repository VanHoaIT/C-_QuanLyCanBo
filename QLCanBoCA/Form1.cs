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

namespace QLCanBoCA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button3_Click(object sender, EventArgs e)
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
                button3.BringToFront();
                txtPass.PasswordChar = '*';
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lấy tọa độ của label
            int x = label3.Location.X;
            x--;
            label3.Location = new Point(x, label3.Location.Y);

            //x == 0 chạy xong dòng sẽ chạy lại
            if(x+label3.Size.Width == 0)
            {
                Form1 fr = new Form1();
                x = fr.Size.Width;
                label3.Location = new Point(x, label3.Location.Y);
            }  
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;
            if (BUS.AccountBUS.Login(user, pass))
            {
                AccountGUI.setUserAccount(user);
                AccountGUI.setPassAccount(pass);
                fManager fManager = new fManager();
                this.Hide();
                fManager.ShowDialog();
                this.Show();
                txtUser.Clear();
                txtPass.Clear();
            }
            else
                MessageBox.Show("Tài khoản không chính xác");
        }
    }
}
