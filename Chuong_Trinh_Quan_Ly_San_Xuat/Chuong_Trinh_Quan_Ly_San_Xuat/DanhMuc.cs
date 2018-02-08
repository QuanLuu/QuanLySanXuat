using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmDanhMuc : Form
    {
        int actionNL = 0;
        int actionSP = 0;
        int actionKH = 0;
        int actionDM = 0;
        public FrmDanhMuc()
        {
            InitializeComponent();
            dtgNL.Dock = DockStyle.Fill;
            dtgSP.Dock = DockStyle.Fill;
            dtgKH.Dock = DockStyle.Fill;
            dtgDM.Dock = DockStyle.Fill;
            GetNguyenLieu();
            enablecontrolNL();
            enablecontrolSP();
            GetSanPham();
            GetKhachHang();
            enablecontrolKH();
            GetDinhMuc();
            enablecontrolDM();
        }
        void GetNguyenLieu()
        {
            DataTable data = Import_Manager.Instance.LoadDM_NL(tbFilterNL.Text);
            dtgNL.DataSource = data;
            cbTenNL.DataSource = data;
            cbTenNL.DisplayMember = "TEN_NL";
        }

        void GetSanPham()
        {
            DataTable data = Import_Manager.Instance.LoadDM_SP(tbFilterSP.Text);
            dtgSP.DataSource = data;
            cbMaSPDM.DataSource = data;
            cbMaSPDM.DisplayMember = "MA_SP";
        }

        void GetKhachHang()
        {
            DataTable data = Import_Manager.Instance.LoadKH(tbFilterKH.Text);
            dtgKH.DataSource = data;
            cbMaKH.DataSource = data;
            cbMaKH.DisplayMember = "MA_KH";
            cbMaSPDM.DataSource = data;
            cbMaSPDM.DisplayMember = "MA_KH";
        }
        void GetDinhMuc()
        {
            DataTable data = Import_Manager.Instance.LoadDM(tbfilterMaSPDM.Text);
            dtgDM.DataSource = data;
        }

        private void tbFilterNL_TextChanged(object sender, EventArgs e)
        {
            GetNguyenLieu();
        }

        private void dtgNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTenNL.Text = dtgNL.CurrentRow.Cells[1].Value.ToString();
            tbKichCo.Text = dtgNL.CurrentRow.Cells[2].Value.ToString();
            if(dtgNL.CurrentRow.Cells[3].Value.ToString() != "") numNL.Value = Convert.ToDecimal(dtgNL.CurrentRow.Cells[3].Value.ToString());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tbTenNL.Text = "";
            tbKichCo.Text = "";
            numNL.Value = 0;
            actionNL = 1;
            enablecontrolNL();
        }
        void enablecontrolNL()
        {
            if (actionNL ==0)
            {
                btnNew.Enabled = true;
                BtnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                panelNL.Enabled = false;
            }
            else
            {
                btnNew.Enabled = false;
                BtnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                panelNL.Enabled = true;
            }

        }

        void enablecontrolDM()
        {
            if (actionDM == 0)
            {
                btnNewDM.Enabled = true;
                btnEditDM.Enabled = true;
                btnDeleteDM.Enabled = true;
                btnSaveDM.Enabled = false;
                btnCancelDM.Enabled = false;
                panelDM.Enabled = false;
            }
            else
            {
                btnNewDM.Enabled = false;
                btnEditDM.Enabled = false;
                btnDeleteDM.Enabled = false;
                btnSaveDM.Enabled = true;
                btnCancelDM.Enabled = true;
                panelDM.Enabled = true;
            }

        }
        void enablecontrolKH()
        {
            if (actionKH == 0)
            {
                btnNewKH.Enabled = true;
                btnEditKH.Enabled = true;
                btnDeleteKH.Enabled = true;
                btnSaveKH.Enabled = false;
                btnCancelKH.Enabled = false;
                panelKH.Enabled = false;
            }
            else
            {
                btnNewKH.Enabled = false;
                btnEditKH.Enabled = false;
                btnDeleteKH.Enabled = false;
                btnSaveKH.Enabled = true;
                btnCancelKH.Enabled = true;
                panelKH.Enabled = true;
            }

        }
        void enablecontrolSP()
        {
            if (actionSP == 0)
            {
                btnNewSP.Enabled = true;
                btnEditSP.Enabled = true;
                btnDeleteSP.Enabled = true;
                btnSaveSP.Enabled = false;
                btnCancelSP.Enabled = false;
                panelSP.Enabled = false;
            }
            else
            {
                btnNewSP.Enabled = false;
                btnEditSP.Enabled = false;
                btnDeleteSP.Enabled = false;
                btnSaveSP.Enabled = true;
                btnCancelSP.Enabled = true;
                panelSP.Enabled = true;
            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            actionNL = 2;
            enablecontrolNL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionNL == 2)
                { currow = dtgNL.CurrentRow.Index; }
                else if (actionNL == 1)
                { currow = dtgNL.Rows.Count - 1; }
                else
                { currow = 0; }
                int results = Import_Manager.Instance.UpdateNL(actionNL, (int)dtgNL.CurrentRow.Cells[0].Value, tbTenNL.Text, tbKichCo.Text, numNL.Value);
                GetNguyenLieu();
                dtgNL.CurrentCell = dtgNL.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionNL = 0;
            enablecontrolNL();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            actionNL = 0;
            enablecontrolNL();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            actionNL = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateNL(actionNL, (int)dtgNL.CurrentRow.Cells[0].Value, tbTenNL.Text, tbKichCo.Text, numNL.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionNL = 0;
            enablecontrolNL();
            GetNguyenLieu();
        }

        private void btnNewSP_Click(object sender, EventArgs e)
        {
            tbMaSP.Text = "";
            tbTenSP.Text = "";
            numSP.Value = 0;
            cbTenNL.Text = "";
            cbMaKH.Text = "";
            actionSP = 1;
            enablecontrolSP();
        }

        private void btnEditSP_Click(object sender, EventArgs e)
        {

            actionSP = 2;
            enablecontrolSP();
        }

        private void btnCancelSP_Click(object sender, EventArgs e)
        {

            actionSP = 0;
            enablecontrolSP();
        }

        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionSP == 2)
                { currow = dtgSP.CurrentRow.Index; }
                else if (actionSP == 1)
                { currow = dtgSP.Rows.Count - 1; }
                else
                { currow = 0; }

                int results = Import_Manager.Instance.UpdateSP(actionSP, (int)dtgSP.CurrentRow.Cells[0].Value, tbMaSP.Text, tbTenSP.Text, cbTenNL.Text, cbMaKH.Text, numSP.Value);
                GetSanPham();
                dtgSP.CurrentCell = dtgSP.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSP = 0;
            enablecontrolSP();
        }

        private void tbFilterSP_TextChanged(object sender, EventArgs e)
        {
            GetSanPham();
        }

        private void dtgSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaSP.Text = dtgSP.CurrentRow.Cells[1].Value.ToString();
            tbTenSP.Text = dtgSP.CurrentRow.Cells[2].Value.ToString();
            cbTenNL.Text = dtgSP.CurrentRow.Cells[3].Value.ToString();
            cbMaKH.Text = dtgSP.CurrentRow.Cells[4].Value.ToString();
            if (dtgSP.CurrentRow.Cells[5].Value.ToString() != "") numSP.Value = Convert.ToDecimal(dtgSP.CurrentRow.Cells[5].Value.ToString());
        }

        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            actionSP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateSP(actionSP, (int)dtgSP.CurrentRow.Cells[0].Value, tbMaSP.Text, tbTenSP.Text, cbTenNL.Text, cbMaKH.Text, numSP.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionSP = 0;
            enablecontrolSP();
            GetSanPham();
        }

        private void btnNewKH_Click(object sender, EventArgs e)
        {
            actionKH = 1;
            enablecontrolKH();
            tbMaKH.Text = "";
            tbKH.Text = "";
            tbNguoiLienHe.Text = "";
            tbBoPhan.Text = "";
            tbDiaChi.Text = "";
            tbEmail.Text = "";
            tbSdt.Text = ""; 
        }

        private void dtgKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaKH.Text = dtgKH.CurrentRow.Cells[1].Value.ToString();
            tbKH.Text = dtgKH.CurrentRow.Cells[2].Value.ToString();
            tbNguoiLienHe.Text = dtgKH.CurrentRow.Cells[3].Value.ToString();
            tbBoPhan.Text = dtgKH.CurrentRow.Cells[4].Value.ToString();
            tbDiaChi.Text = dtgKH.CurrentRow.Cells[7].Value.ToString();
            tbEmail.Text = dtgKH.CurrentRow.Cells[6].Value.ToString();
            tbSdt.Text = dtgKH.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEditKH_Click(object sender, EventArgs e)
        {
            actionKH = 2;
            enablecontrolKH();
        }

        private void btnCancelKH_Click(object sender, EventArgs e)
        {
            actionKH = 0;
            enablecontrolKH();
        }

        private void btnDeleteKH_Click(object sender, EventArgs e)
        {
            actionKH = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKH(actionKH, (int)dtgKH.CurrentRow.Cells[0].Value, tbMaKH.Text, tbKH.Text, tbNguoiLienHe.Text, tbBoPhan.Text, tbSdt.Text, tbEmail.Text, tbDiaChi.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionKH = 0;
            enablecontrolKH();
            GetKhachHang();
        }

        private void btnSaveKH_Click(object sender, EventArgs e)
        {
            int currow = 0;
            try
            {
                if (actionKH == 2)
                { currow = dtgKH.CurrentRow.Index; }
                else if (actionKH == 1)
                { currow = dtgKH.Rows.Count - 1; }
                else
                { currow = 0; }

                int results = Import_Manager.Instance.UpdateKH(actionKH, (int)dtgKH.CurrentRow.Cells[0].Value, tbMaKH.Text, tbKH.Text, tbNguoiLienHe.Text, tbBoPhan.Text, tbSdt.Text, tbEmail.Text, tbDiaChi.Text);
                GetKhachHang();
                dtgKH.CurrentCell = dtgKH.Rows[currow].Cells[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            actionKH = 0;
            enablecontrolKH();
        }
    }
}
