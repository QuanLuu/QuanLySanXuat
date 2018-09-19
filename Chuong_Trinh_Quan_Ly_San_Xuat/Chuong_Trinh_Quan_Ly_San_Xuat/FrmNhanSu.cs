using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmNhanSu : Form
    {
        int action = 0;
        public FrmNhanSu()
        {
            InitializeComponent();
            dtgDSNV.Dock = DockStyle.Fill;
            dtgNghiPhep.Dock = DockStyle.Fill;
            dtgHopDong.Dock = DockStyle.Fill;

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
           BindingFlags.Instance | BindingFlags.SetProperty, null,
           dtgDSNV, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgHopDong, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgNghiPhep, new object[] { true });

            danhsachnhanvien();
            gethopdong();
            DataTable data = Import_Manager.Instance.getbophan();
            cbbophan.DataSource = data;
            cbbophan.DisplayMember = "TEN";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            action = 1;
            enablecontrol();
        }
        void LoadDSNhanVien()
        {
            DataTable nhanvien = Import_Manager.Instance.LoadNhanVien();
            cbMaNV.DataSource = nhanvien;
            cbMaNV.DisplayMember = "NV";


        }
        void danhsachnhanvien()
        {
            DataTable data = Import_Manager.Instance.danhsachnv(tbDSNVFilter.Text);
            dtgDSNV.DataSource = data;
        }

        private void tbDSNVFilter_TextChanged(object sender, EventArgs e)
        {
            danhsachnhanvien();
        }
        void enablecontrol()
        {
            if (action == 0)
            {
                btnNew.Enabled = true;
                BtnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                if (tabNhanVien.SelectedIndex == 0) panelDSNV.Visible = false;
                if (tabNhanVien.SelectedIndex == 2) panelNghiPhep.Visible = false;
                if (tabNhanVien.SelectedIndex == 1) panelHopDong.Visible = false;
               
            }
            else
            {
                btnNew.Enabled = false;
                BtnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                if (tabNhanVien.SelectedIndex == 0) panelDSNV.Visible = true;
                if (tabNhanVien.SelectedIndex == 2) panelNghiPhep.Visible = true;
                if (tabNhanVien.SelectedIndex == 1) panelHopDong.Visible = true;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            action = 2;
            enablecontrol();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                if (tabNhanVien.SelectedIndex ==0)
                {
                    int results = Import_Manager.Instance.UpdateDSNV(action, (int)dtgDSNV.CurrentRow.Cells[0].Value, tbTenNV.Text, cbGioiTinh.Text, dtpNgaySinh.Value, tbCMTND.Text, dtpNgayCapCMT.Value, tbSoBHXH.Text, tbTrinhDoVH.Text, tbDiaChi.Text);
                    danhsachnhanvien();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            action = 0;
            enablecontrol();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            action = 0;
            enablecontrol();
        }

        private void tabNhanVien_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (action != 0)
            { 
                MessageBox.Show("Bạn chưa lưu dữ liệu, vui lòng chọn Save hoặc Cancel");
                e.Cancel = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currow = 0;
            int id = 0;
            try
            {
                if (tabNhanVien.SelectedIndex == 0)
            {
                    if (dtgDSNV.Rows.Count > 1 && dtgDSNV.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgDSNV.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgDSNV.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgDSNV.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.UpdateDSNV(action, id, tbTenNV.Text, cbGioiTinh.Text, dtpNgaySinh.Value, tbCMTND.Text, dtpNgayCapCMT.Value, tbSoBHXH.Text, tbTrinhDoVH.Text, tbDiaChi.Text);
                    danhsachnhanvien();
                    dtgDSNV.CurrentCell = dtgDSNV.Rows[currow].Cells[0];
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            action = 0;
            enablecontrol();
        }
        void gethopdong()
        {
            DataTable data = Import_Manager.Instance.getHopDong(tbHDFilter.Text);
            dtgHopDong.DataSource = data;
        }

        private void tbHDFilter_TextChanged(object sender, EventArgs e)
        {
            gethopdong();
        }
    }
}
