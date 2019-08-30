using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmKiemKho : Form
    {
        int actionKKTP = 0;
        int actionKKNL = 0;
        int actionKKBanTP = 0;
        string congdoan = "BAN CONG DOAN";
        string bophan = "";
        string usernhap = "";
        public FrmKiemKho()
        {
            InitializeComponent();
            dtgKKTP.Dock = DockStyle.Fill;
            dtgNL.Dock = DockStyle.Fill;
            dtgbanTP.Dock = DockStyle.Fill;
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FrmMain"];
            usernhap = ((FrmMain)f).tbTenDN.Text.ToString();
            getthanhpham();
            getkiemkhonl();
            GetNguyenLieu();
            getbanthanhpham();
            dtpGiacongTP.Value = DateTime.Now;
            dtpKiemTP.Value = DateTime.Now;
            dtpNgayKiemFilter.Value = DateTime.Now;
            dtpngaykiemNL.Value = DateTime.Now;
            dtpngaykiemNLFilter.Value = DateTime.Now;
            dtpngaykiembantp.Value = DateTime.Now;
            dtpngaykiembantpfil.Value = DateTime.Now;
        }
        void getthanhpham()
        {
            DataTable data = Import_Manager.Instance.getkiemkhotp("THANH PHAM", tbMSQLTPFilter.Text, dtpNgayKiemFilter.Value);
            dtgKKTP.DataSource = data;
        }

        void getbanthanhpham()
        {
            if (bophan == "Sản Xuất")
            {
                DataTable data = Import_Manager.Instance.getkiemkhotp("BAN CONG DOAN", tbmsqlbantpfil.Text, dtpngaykiembantpfil.Value);
                dtgbanTP.DataSource = data;
            }
            
            else if(bophan == "Chất Lượng")
            {
                DataTable data = Import_Manager.Instance.getkiemkhotp("TRUOC KIEM", tbmsqlbantpfil.Text, dtpngaykiembantpfil.Value);
                dtgbanTP.DataSource = data;
            }
            else
            {
                DataTable data = Import_Manager.Instance.getkiemkhotp("", tbmsqlbantpfil.Text, dtpngaykiembantpfil.Value);
                dtgbanTP.DataSource = data;
            }
        }
       
        void getkiemkhonl()
        {
            DataTable data = Import_Manager.Instance.getkiemkhonl(tbFilterNL.Text, dtpngaykiemNLFilter.Value);
            dtgNL.DataSource = data;
        }
        void GetNguyenLieu()
        {
            DataTable data = Import_Manager.Instance.LoadDM_NL(tbFilterNL.Text);
            dtgNL.DataSource = data;
            cbMaNL.DataSource = data;
            cbMaNL.DisplayMember = "TEN_NL"; 
        }
        void getsanphamtheomsql()
        {
            DataTable data = Import_Manager.Instance.getmasptheomsql(tbMSQLTP.Text);
            cbMaTP.DisplayMember = "MA_SP";
            cbMaTP.DataSource = data;


            DataTable bantp = Import_Manager.Instance.getmasptheomsql(tbmsqlbantp.Text);
            cbmaspbantp.DisplayMember = "MA_SP";
            cbmaspbantp.DataSource = bantp;
        }
        void enablecontrol(int action, Panel pan, Panel panentry)
        {
            if (action == 0)
            {
                foreach (Control c in pan.Controls)
                {
                    if (c.Text == "New") c.Enabled = true;
                    if (c.Text == "Edit") c.Enabled = true;
                    if (c.Text == "Delete") c.Enabled = true;
                    if (c.Text == "Save") c.Enabled = false;
                    if (c.Text == "Cancel") c.Enabled = false;
                }
                panentry.Visible = false;
            }
            else
            {
                foreach (Control c in pan.Controls)
                {
                    if (c.Text == "New") c.Enabled = false;
                    if (c.Text == "Edit") c.Enabled = false;
                    if (c.Text == "Delete") c.Enabled = false;
                    if (c.Text == "Save") c.Enabled = true;
                    if (c.Text == "Cancel") c.Enabled = true;
                }
                panentry.Visible = true;
            }
        }
        void newentry(Panel pan)
        {
            foreach(Control c in pan.Controls)
            {
                if (c.GetType().Name == "TextBox" && c.Tag == null) c.Text = "";
            }
        }
        int current_row(int act, DataGridView dtg)
        {
            int currow = 0;
            if (act == 2)
                currow = dtg.CurrentRow.Index;
            else if (act == 1)
                currow = dtg.Rows.Count - 1;
            else
                currow = 0;
            return currow;
        }
        private void btnEditTP_Click(object sender, EventArgs e)
        {
            actionKKTP = 2;
            if (dtgKKTP.CurrentRow != null)
            {
                tbMSQLTP.Text = dtgKKTP.CurrentRow.Cells[0].Value.ToString();
                cbMaTP.Text = dtgKKTP.CurrentRow.Cells[1].Value.ToString();
                tbsolotTP.Text = dtgKKTP.CurrentRow.Cells[4].Value.ToString();
                tbsothungTP.Text = dtgKKTP.CurrentRow.Cells[5].Value.ToString();
                dtpGiacongTP.Value = DateTime.Parse(dtgKKTP.CurrentRow.Cells[6].Value.ToString());
                numTonTP.Text = dtgKKTP.CurrentRow.Cells[7].Value.ToString();
                dtpKiemTP.Value = DateTime.Parse(dtgKKTP.CurrentRow.Cells[8].Value.ToString());
                tbnguoikiemTP.Text = dtgKKTP.CurrentRow.Cells[9].Value.ToString();
                tbghichuTP.Text = dtgKKTP.CurrentRow.Cells[10].Value.ToString();

            }
            enablecontrol(actionKKTP, panTP, panelTP);
        }

        private void btnNewSP_Click(object sender, EventArgs e)
        {
            actionKKTP = 1;
            newentry(panelTP);
            enablecontrol(actionKKTP, panTP, panelTP);
        }

        private void btnCancelSP_Click(object sender, EventArgs e)
        {
            actionKKTP = 0;
            enablecontrol(actionKKTP, panTP, panelTP);
        }

        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionKKTP, dtgKKTP);
            int id = 0;
            if (actionKKTP != 1) id = (int)dtgKKTP.CurrentRow.Cells[11].Value;
            try
            {

                int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKTP, id, tbMSQLTP.Text, tbsolotTP.Text, tbsothungTP.Text, dtpGiacongTP.Value, float.Parse(numTonTP.Value.ToString()), dtpKiemTP.Value, tbnguoikiemTP.Text, tbghichuTP.Text, "THANH PHAM");
                getthanhpham();
                dtgKKTP.CurrentCell = dtgKKTP.Rows[currow].Cells[0];
                actionKKTP = 0;
                enablecontrol(actionKKTP, panTP, panelTP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            actionKKTP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKTP, (int)dtgKKTP.CurrentRow.Cells[11].Value, tbMSQLTP.Text, tbsolotTP.Text, tbsothungTP.Text, dtpGiacongTP.Value, 0, dtpKiemTP.Value, tbnguoikiemTP.Text, tbghichuTP.Text,"");
                actionKKTP = 0;
                enablecontrol(actionKKTP, panTP, panelTP);
                getthanhpham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbMSQLTPFilter_TextChanged(object sender, EventArgs e)
        {
            getthanhpham();
        }

        private void dtpNgayKiemFilter_ValueChanged(object sender, EventArgs e)
        {
            getthanhpham();
        }

        private void tbFilterNL_TextChanged(object sender, EventArgs e)
        {
            getkiemkhonl();
        }

        private void dtpngaykiemNLFilter_ValueChanged(object sender, EventArgs e)
        {
            getkiemkhonl();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            actionKKNL = 1;
            newentry(panelNL);
            enablecontrol(actionKKNL, panNL, panelNL);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            actionKKNL = 0;
            enablecontrol(actionKKNL, panNL, panelNL);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            actionKKNL = 2;
            if(dtgNL.CurrentRow != null)
            {
                cbMaNL.Text = dtgNL.CurrentRow.Cells[1].Value.ToString();
                tbsolotNL.Text = dtgNL.CurrentRow.Cells[3].Value.ToString();
                tbsocuon.Text = dtgNL.CurrentRow.Cells[4].Value.ToString();
                tbcuonme.Text = dtgNL.CurrentRow.Cells[5].Value.ToString();
                numtonNL.Text = dtgNL.CurrentRow.Cells[6].Value.ToString();
                dtpngaykiemNL.Value = DateTime.Parse(dtgNL.CurrentRow.Cells[7].Value.ToString());
                tbnguoikiemNL.Text = dtgNL.CurrentRow.Cells[8].Value.ToString();
                tbghichuNL.Text = dtgNL.CurrentRow.Cells[9].Value.ToString();
            }
            enablecontrol(actionKKNL, panNL, panelNL);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionKKNL, dtgNL);
            int id = 0;
            if (actionKKNL != 1) id = (int)dtgNL.CurrentRow.Cells[0].Value;
            try
            {

                int results = Import_Manager.Instance.UpdateKiemKhoNL(actionKKNL, id, cbMaNL.Text, tbsolotNL.Text, tbsocuon.Text, tbcuonme.Text, numtonNL.Value, dtpngaykiemNL.Value, tbnguoikiemNL.Text, tbghichuNL.Text);
                getkiemkhonl();
                dtgNL.CurrentCell = dtgNL.Rows[currow].Cells[0];
                actionKKNL = 0;
                enablecontrol(actionKKNL, panNL, panelNL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            actionKKNL = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKiemKhoNL(actionKKNL, (int)dtgNL.CurrentRow.Cells[0].Value, cbMaNL.Text, tbsolotNL.Text, tbsocuon.Text, tbcuonme.Text, numtonNL.Value, dtpngaykiemNL.Value, tbnguoikiemNL.Text, tbghichuNL.Text);
                actionKKNL = 0;
                enablecontrol(actionKKNL, panNL, panelNL);
                getkiemkhonl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbMSQLTP_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
        }

        private void btnNewDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 1;
            enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
            newentry(panelBanTP);
        }

        private void btnEditDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 2;
            if (dtgbanTP.CurrentRow != null)
            {
                tbmsqlbantp.Text = dtgbanTP.CurrentRow.Cells[0].Value.ToString();
                cbmaspbantp.Text = dtgbanTP.CurrentRow.Cells[1].Value.ToString();
                tbsolotbantp.Text = dtgbanTP.CurrentRow.Cells[4].Value.ToString();
                tbsothungbantp.Text = dtgbanTP.CurrentRow.Cells[5].Value.ToString();
                dtpngaygiacongbantp.Value = DateTime.Parse(dtgbanTP.CurrentRow.Cells[6].Value.ToString());
                numtonbantp.Text = dtgbanTP.CurrentRow.Cells[7].Value.ToString();
                dtpngaykiembantp.Value = DateTime.Parse(dtgbanTP.CurrentRow.Cells[8].Value.ToString());
                tbngkiembantp.Text = dtgbanTP.CurrentRow.Cells[9].Value.ToString();
                tbghichubantp.Text = dtgbanTP.CurrentRow.Cells[10].Value.ToString();
            }
            enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
        }

        private void btnDeleteDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKBanTP, (int)dtgbanTP.CurrentRow.Cells[11].Value, "", "", "", dtpngaygiacongbantp.Value, 0, dtpngaykiembantp.Value, "", "","");
                actionKKBanTP = 0;
                enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
                getbanthanhpham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveDM_Click(object sender, EventArgs e)
        {
            int currow = current_row(actionKKBanTP, dtgKKTP);
            int id = 0;
            if (actionKKBanTP != 1) id = (int)dtgbanTP.CurrentRow.Cells[11].Value;
            try
            {
                int results = Import_Manager.Instance.UpdateKiemKhoTP(actionKKBanTP, id, tbmsqlbantp.Text, tbsolotbantp.Text, tbsothungbantp.Text, dtpngaygiacongbantp.Value, float.Parse(numtonbantp.Value.ToString()), dtpngaykiembantp.Value, tbngkiembantp.Text, tbghichubantp.Text, congdoan);
                getbanthanhpham();
                dtgbanTP.CurrentCell = dtgbanTP.Rows[currow].Cells[0];
                actionKKBanTP = 0;
                enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbmsqlbantpfil_TextChanged(object sender, EventArgs e)
        {
            getbanthanhpham();
        }

        private void dtpngaykiembantpfil_ValueChanged(object sender, EventArgs e)
        {
            getbanthanhpham();
        }

        private void btnCancelDM_Click(object sender, EventArgs e)
        {
            actionKKBanTP = 0;
            enablecontrol(actionKKBanTP, panbanTP, panelBanTP);
        }

        private void tbmsqlbantp_TextChanged(object sender, EventArgs e)
        {
            getsanphamtheomsql();
        }
    }
}
