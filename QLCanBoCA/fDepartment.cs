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
    public partial class fDepartment : Form
    {
        public fDepartment()
        {
            InitializeComponent();
        }
        #region Method
        public void loadDepartment()
        {
            List<DepartmentDTO> departments = BUS.DepartmentBUS.GetDepartments();
            dgvDepartment.DataSource = departments;
        }
        public void Reload()
        {
            txtID.Clear();
            txtName.Clear();
            loadDepartment();
        }    
        #endregion
        private void fDepartment_Load(object sender, EventArgs e)
        {
            loadDepartment();
        }
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDepartment.CurrentCell.RowIndex;
            txtID.Text = dgvDepartment.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dgvDepartment.Rows[i].Cells[1].Value.ToString();
        }
        private void btnReload_Click_1(object sender, EventArgs e)
        {
            Reload();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Chưa nhập thông tin");
            }
            else
            {
                int id = Convert.ToInt32(txtID.Text);
                string name = txtName.Text;
                if (BUS.DepartmentBUS.TestDepartment(id))
                {
                    MessageBox.Show("Mã trùng");
                }
                else
                {
                    BUS.DepartmentBUS.InsertDepartment(id, name);
                    MessageBox.Show("Đã thêm thành công");
                    Reload();
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phòng ban");
            }   
            else
            {
                int ID;
                int i = dgvDepartment.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        ID = Convert.ToInt32(dgvDepartment.Rows[i].Cells[0].Value.ToString());
                        BUS.DepartmentBUS.DeleteDepartment(ID);
                        MessageBox.Show("Đã xóa thành công");
                        Reload();
                    }
                }
            }    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn phòng");
            }    
            else
            {
                int id = Convert.ToInt32(txtID.Text);
                string name = txtName.Text;
                {
                    BUS.DepartmentBUS.UpdateDepartment(id, name);
                    MessageBox.Show("Đã sửa thành công");
                    Reload();
                }    
            }    
        }
    }
}
