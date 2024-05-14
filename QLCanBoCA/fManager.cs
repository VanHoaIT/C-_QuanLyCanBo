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
    public partial class fManager : Form
    {
        public fManager()
        {
            InitializeComponent();
        }
        #region Method
        //load thông tin các staff từ BUS
        public void LoadStaff()
        {
            List<StaffDTO> staffDTOs = BUS.StaffBUS.GetDSStaffs();
            dgvStaff.DataSource = staffDTOs;
        }
        //load combobox phòng ban
        public void loadDepartment()
        {
            List <DepartmentDTO> departmentDTOs = BUS.DepartmentBUS.GetDepartments();
            cbbDepartment.DataSource = departmentDTOs;
            cbbDepartment.DisplayMember = "name";
            cbbDepartment.ValueMember = "id";
        }
        //load combobox cấp bậc
        public void loadRank()
        {
            List<RankDTO> rankDTOs = BUS.RankBUS.GetRanks();
            cbbRank.DataSource = rankDTOs;
            cbbRank.DisplayMember = "name";
            cbbRank.ValueMember = "id";
        }
        #endregion
        #region ToolStripMenuItem
        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccount fAccount = new fAccount();
            fAccount.ShowDialog();
            this.Show();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BUS.AccountBUS.Admin(AccountGUI.getUserAccount()))
            {
                fADAccount fADAccount = new fADAccount();
                fADAccount.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Chỉ Admin mới xem được");
        }
        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BUS.AccountBUS.Admin(AccountGUI.getUserAccount()))
            {
                fDepartment fDepartment = new fDepartment();
                fDepartment.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Chỉ Admin mới xem được");
        }
        #endregion
        private void fManager_Load(object sender, EventArgs e)
        {
            LoadStaff();
            loadDepartment();
            loadRank();
            btnEdit.Enabled = false;
        }
        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvStaff.CurrentCell.RowIndex;
            txtID.Text = dgvStaff.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dgvStaff.Rows[i].Cells[1].Value.ToString();
            dateTimePicker1.Text =  dgvStaff.Rows[i].Cells[2].Value.ToString();
            string gender = dgvStaff.Rows[i].Cells[3].Value.ToString();
            if (gender == "Male")
            {
                rdrMale.Checked = true;
            }
            else
                rdrFemale.Checked = true;
            txtAddress.Text = dgvStaff.Rows[i].Cells[4].Value.ToString();
            cbbDepartment.SelectedValue = dgvStaff.Rows[i].Cells[5].Value.ToString();
            cbbRank.SelectedValue = dgvStaff.Rows[i].Cells[6].Value.ToString();
            btnEdit.Enabled = true;
            txtID.Enabled = false;
        }
        public void Clear()
        {
            txtID.Clear();
            txtName.Clear();
            txtAddress.Clear();
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            Clear();
            LoadStaff();
            btnEdit.Enabled=false;
            txtID.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtID.Text == "" || txtAddress.Text == "" ||
                rdrFemale.Checked == false && rdrMale.Checked == false )
            {
                MessageBox.Show("Chưa nhập thông tin");
            }    
            else
            {
                string id = txtID.Text;
                string name = txtName.Text;
                DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                string gender = "";
                if (rdrMale.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string addr = txtAddress.Text;
                int idDepartment = (int)cbbDepartment.SelectedValue;
                int idRank = (int)cbbRank.SelectedValue;
                if (BUS.StaffBUS.TestStaff(id))
                {
                    MessageBox.Show("Mã trùng");
                }
                else
                {
                    BUS.StaffBUS.InsertStaff(id, name, date, gender, addr, idDepartment, idRank);
                    MessageBox.Show("Đã thêm thành công");
                    Clear();
                    LoadStaff();
                }
            }    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtID.Text == "" || txtAddress.Text == "" ||
                rdrFemale.Checked == false && rdrMale.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn cán bộ");
            }
            else
            {
                string id = txtID.Text;
                string name = txtName.Text;
                DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                string gender = "";
                if (rdrMale.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string addr = txtAddress.Text;
                int idDepartment = (int)cbbDepartment.SelectedValue;
                int idRank = (int)cbbRank.SelectedValue;
                BUS.StaffBUS.UpdateStaff(id, name, date, gender, addr, idDepartment, idRank);
                MessageBox.Show("Đã sửa thành công");
                Clear();
                LoadStaff();  
            }   
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn cán bộ");
            }
            else
            {
                string ID;
                int i = dgvStaff.CurrentCell.RowIndex;
                if (i >= 0)
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.OK)
                    {
                        ID = dgvStaff.Rows[i].Cells[0].Value.ToString();
                        BUS.StaffBUS.DeleteStaff(ID);
                        MessageBox.Show("Đã xóa thành công");
                        LoadStaff();
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã cán bộ cần tìm");
            }
            else
            {
                string id = txtSearch.Text;
                dgvStaff.DataSource = BUS.StaffBUS.SearchDSStaffs(id);
            }
        }
    }
}
