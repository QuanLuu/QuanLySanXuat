using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmNhanSu : Form
    {
        int action = 0;
        string langue_ge;
        ResourceManager res_man;
        string temp = "";
        public FrmNhanSu()
        {
            InitializeComponent();
            dtgDSNV.Dock = DockStyle.Fill;
            dtgNghiPhep.Dock = DockStyle.Fill;
            dtgHopDong.Dock = DockStyle.Fill;
            dtgCalv.Dock = DockStyle.Fill;

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
           BindingFlags.Instance | BindingFlags.SetProperty, null,
           dtgDSNV, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgHopDong, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dtgNghiPhep, new object[] { true });

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
           BindingFlags.Instance | BindingFlags.SetProperty, null,
           dtgCalv, new object[] { true });
            
            System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["FrmMain"];
            langue_ge = ((FrmMain)f).languege_set;
            setlangue();
            danhsachnhanvien();
            gethopdong();
            DataTable data = Import_Manager.Instance.getbophan();
            cbbophanhd.DataSource = data;
            cbbophanhd.DisplayMember = "TEN";
            //loadtennhanvienhd();
            cbnghilam.Checked = false;
            dtpNghiTuNgay.Value = DateTime.Now;
            dtpNghiDenNgay.Value = DateTime.Now;
            getnghiphep();
            getcalamviec();

            setlangforallgridview();
            //getallcomponettext(this);
            //tbcalvfil.Text = temp;
            dtgCalv.Columns[0].Width = 0;
            dtgDSNV.Columns[0].Width = 0;
            dtgHopDong.Columns[0].Width = 0;
            dtgNghiPhep.Columns[0].Width = 0;
        }
        void getallcomponettext(Control par)
        {
            foreach (Control c in par.Controls)
            {
                temp += "," + c.Text;
                getallcomponettext(c);
            }
        }


        void setlangue()
        {
            string res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_vi";
            if (langue_ge == "Japan") res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_ja";
            res_man = new ResourceManager(res_file, Assembly.GetExecutingAssembly());
            setlangforlabel(this);
        }
        void setlangforlabel(Control par)
        {
            foreach (Control c in par.Controls)
            {
                //    if (c.GetType().Name == "Label")
                //    {
                if (res_man.GetString(c.Text) != null)
                    c.Text = res_man.GetString(c.Text);
                //}

                setlangforlabel(c);
            }

        }
        void setlangforheader(DataGridView dtg)
        {
            string headername = "";
            for (int i = 0; i < dtg.Columns.Count; i++)
            {
                headername = dtg.Columns[i].HeaderText;
                dtg.Columns[i].HeaderText = res_man.GetString(headername);
            }
        }
        void setlangforallgridview()
        {
            if (langue_ge == "Japan")
            {
                setlangforheader(dtgCalv);
                setlangforheader(dtgDSNV);
                setlangforheader(dtgHopDong);
                setlangforheader(dtgNghiPhep);
         

            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            action = 1;
            if (tabNhanVien.SelectedIndex == 0)
            {
                tbmanv.Text = "";
                tbTenNV.Text = "";
                cbGioiTinh.Text = "";              
                tbCMTND.Text = "";
                tbSoBHXH.Text = "";                       
            }
            if (tabNhanVien.SelectedIndex == 1)
            {
                tbmanvhopdong.Text = "";           
            }
            if (tabNhanVien.SelectedIndex == 2)
            {
                tbmanvnghiphep.Text = "";
                tbLyDonghi.Text = "";
            }
            if (tabNhanVien.SelectedIndex == 3)
            {
                tbmanvcalv.Text = "";               
            }
            enablecontrol();
        }
        void LoadDSNhanVien()
        {
            DataTable nhanvien = Import_Manager.Instance.LoadNhanVien();
            cbtennvnghiphep.DataSource = nhanvien;
            cbtennvnghiphep.DisplayMember = "NV";

        }
        void danhsachnhanvien()
        {
            DataTable data = Import_Manager.Instance.danhsachnv(tbmanvfilter.Text , tbDSNVFilter.Text);
            dtgDSNV.DataSource = data;
            
        }
        void getcalamviec()
        {
            DataTable data = Import_Manager.Instance.getnhanviencalv(tbmanvcalvfil.Text, tbtennvcalvfil.Text, tbcalvfil.Text);
            dtgCalv.DataSource = data;
           
        }
        void getnghiphep()
        {
            DataTable data = Import_Manager.Instance.GetNhatKyNghiPhep(tbmanvnghifil.Text, tbtennvnghifil.Text);
            dtgNghiPhep.DataSource = data;
            
        }
        void loadtennhanvienhd()
        {
            DataTable data = Import_Manager.Instance.getnhanvienhd();
            cbtennvhopdong.DisplayMember = "NHAN_VIEN";
            cbtennvhopdong.ValueMember = "ID";
            cbtennvhopdong.DataSource = data;
        }
        void loadtennhanvienfromanv(string manv)
        {
            DataTable data = Import_Manager.Instance.gettennvfrommanv(manv);
            cbtennvnghiphep.DisplayMember = "TEN_NHAN_VIEN";
            cbtennvnghiphep.DataSource = data;


            cbtennvhopdong.DisplayMember = "TEN_NHAN_VIEN";
            cbtennvhopdong.ValueMember = "ID";
            cbtennvhopdong.DataSource = data;

            cbtennvnghiphep.DisplayMember = "TEN_NHAN_VIEN";
            cbtennvnghiphep.ValueMember = "ID";
            cbtennvnghiphep.DataSource = data;

            cbtennvcalv.DisplayMember = "TEN_NHAN_VIEN";
            cbtennvcalv.ValueMember = "ID";
            cbtennvcalv.DataSource = data;
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
                if (tabNhanVien.SelectedIndex == 3) panelcalv.Visible = false;

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
                if (tabNhanVien.SelectedIndex == 3) panelcalv.Visible = true;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            action = 2;
            enablecontrol();
            if (tabNhanVien.SelectedIndex == 0)
            {
                tbmanv.Text = dtgDSNV.CurrentRow.Cells[1].Value.ToString();
                tbTenNV.Text = dtgDSNV.CurrentRow.Cells[2].Value.ToString();
                cbGioiTinh.Text = dtgDSNV.CurrentRow.Cells[3].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(dtgDSNV.CurrentRow.Cells[4].Value.ToString());
                tbCMTND.Text = dtgDSNV.CurrentRow.Cells[5].Value.ToString();
                dtpNgayCapCMT.Value = DateTime.Parse(dtgDSNV.CurrentRow.Cells[6].Value.ToString());
                tbSoBHXH.Text = dtgDSNV.CurrentRow.Cells[7].Value.ToString();
                tbTrinhDoVH.Text = dtgDSNV.CurrentRow.Cells[8].Value.ToString();
                tbDiaChi.Text = dtgDSNV.CurrentRow.Cells[9].Value.ToString();
            }
            if (tabNhanVien.SelectedIndex == 1)
            {
                tbmanvhopdong.Text = dtgHopDong.CurrentRow.Cells[1].Value.ToString();
                cbtennvhopdong.Text = dtgHopDong.CurrentRow.Cells[2].Value.ToString();
                cbbophanhd.Text = dtgHopDong.CurrentRow.Cells[3].Value.ToString();
                tbchucvuhd.Text = dtgHopDong.CurrentRow.Cells[4].Value.ToString();
                if (dtgHopDong.CurrentRow.Cells[5].Value.ToString() != "" && dtgHopDong.CurrentRow.Cells[5].Value.ToString() != null) dtpngaylamviechopdong.Value = DateTime.Parse(dtgHopDong.CurrentRow.Cells[5].Value.ToString());
                if (dtgHopDong.CurrentRow.Cells[6].Value.ToString() != "" && dtgHopDong.CurrentRow.Cells[6].Value.ToString() != null) dtpngaykyhd.Value = DateTime.Parse(dtgHopDong.CurrentRow.Cells[6].Value.ToString());
                if (dtgHopDong.CurrentRow.Cells[7].Value.ToString() != "" && dtgHopDong.CurrentRow.Cells[7].Value.ToString() != null)
                {
                    cbnghilam.Checked = true;
                    dtpngaynghihd.Value = DateTime.Parse(dtgHopDong.CurrentRow.Cells[7].Value.ToString());
                }
                else
                {
                    cbnghilam.Checked = false;
                }

            }
            if (tabNhanVien.SelectedIndex == 2)
            {
                string hinhthucnghi;
                tbmanvnghiphep.Text = dtgNghiPhep.CurrentRow.Cells[1].Value.ToString();
                cbtennvnghiphep.Text = dtgNghiPhep.CurrentRow.Cells[2].Value.ToString();
                dtpNghiTuNgay.Value = DateTime.Parse(dtgNghiPhep.CurrentRow.Cells[3].Value.ToString());
                dtpNghiDenNgay.Value = DateTime.Parse(dtgNghiPhep.CurrentRow.Cells[4].Value.ToString());
                hinhthucnghi = dtgNghiPhep.CurrentRow.Cells[5].Value.ToString();
                if (rbcophep.Text == hinhthucnghi) rbcophep.Checked = true;
                if (rbkophep.Text == hinhthucnghi) rbkophep.Checked = true;
                if (rbdacbiet.Text == hinhthucnghi) rbdacbiet.Checked = true;
                if (rbditre.Text == hinhthucnghi) rbditre.Checked = true;
                if (rbvesom.Text == hinhthucnghi) rbvesom.Checked = true;
                if (dtgNghiPhep.CurrentRow.Cells[6].Value.ToString() == "1")
                    chbnghilienlac.Checked = true;
                else
                    chbnghilienlac.Checked = false;
                tbthoigiannghi.Text = dtgNghiPhep.CurrentRow.Cells[7].Value.ToString();
                tbLyDonghi.Text = dtgNghiPhep.CurrentRow.Cells[8].Value.ToString();
            }
            if (tabNhanVien.SelectedIndex == 3)
            {
                tbmanvcalv.Text = dtgCalv.CurrentRow.Cells[1].Value.ToString();
                cbtennvcalv.Text = dtgCalv.CurrentRow.Cells[2].Value.ToString();
                dtpngaycalv.Value = DateTime.Parse(dtgCalv.CurrentRow.Cells[3].Value.ToString());
                cbcalv.Text = dtgCalv.CurrentRow.Cells[4].Value.ToString();    
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            action = 3;
            if (MessageBox.Show("Are you sure to delete?", "Information", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
            try
            {
                if (tabNhanVien.SelectedIndex ==0)
                {
                    int results = Import_Manager.Instance.UpdateDSNV(action, (int)dtgDSNV.CurrentRow.Cells[0].Value, tbTenNV.Text, cbGioiTinh.Text, dtpNgaySinh.Value, tbCMTND.Text, dtpNgayCapCMT.Value, tbSoBHXH.Text, tbTrinhDoVH.Text, tbDiaChi.Text, tbmanv.Text);
                    danhsachnhanvien();
                }
                else if (tabNhanVien.SelectedIndex == 1)
                {
                   
                    int results = Import_Manager.Instance.updatehopdong(action, (int)dtgHopDong.CurrentRow.Cells[0].Value, 1, cbbophanhd.Text, tbchucvuhd.Text, dtpngaylamviechopdong.Value, dtpngaykyhd.Value, 1, dtpngaynghihd.Value);
                    gethopdong();
                }
                else if (tabNhanVien.SelectedIndex == 3)
                {

                    int results = Import_Manager.Instance.Updatenhanviencalv(action, (int)dtgCalv.CurrentRow.Cells[0].Value, 1, dtpngaycalv.Value, cbcalv.Text);
                    getcalamviec();
                }
                else
                {
                    int results = Import_Manager.Instance.UpdateNghiPhep(action, (int)dtgNghiPhep.CurrentRow.Cells[0].Value, 1, dtpNghiTuNgay.Value, dtpNghiDenNgay.Value, "", 1, tbthoigiannghi.Text, tbLyDonghi.Text);
                    getnghiphep();
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
            int isnghi = 0;
            int islienlac = 0;
            string hinhthucnghi = "";
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
                    int results = Import_Manager.Instance.UpdateDSNV(action, id, tbTenNV.Text, cbGioiTinh.Text, dtpNgaySinh.Value, tbCMTND.Text, dtpNgayCapCMT.Value, tbSoBHXH.Text, tbTrinhDoVH.Text, tbDiaChi.Text, tbmanv.Text);
                    danhsachnhanvien();
                    dtgDSNV.CurrentCell = dtgDSNV.Rows[currow].Cells[0];
                }
                else if (tabNhanVien.SelectedIndex == 1)
                {
                    if (dtgHopDong.Rows.Count > 1 && dtgHopDong.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgHopDong.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgHopDong.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgHopDong.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    if (cbnghilam.Checked) isnghi = 1;
                    int results = Import_Manager.Instance.updatehopdong(action, id, Int32.Parse(cbtennvhopdong.SelectedValue.ToString()), cbbophanhd.Text, tbchucvuhd.Text, dtpngaylamviechopdong.Value, dtpngaykyhd.Value,isnghi, dtpngaynghihd.Value);
                    gethopdong();
                    dtgHopDong.CurrentCell = dtgHopDong.Rows[currow].Cells[0];
                }
                else if (tabNhanVien.SelectedIndex == 3)
                {
                    if (dtgCalv.Rows.Count > 1 && dtgCalv.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgCalv.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgCalv.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgCalv.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    int results = Import_Manager.Instance.Updatenhanviencalv(action, id, Int32.Parse(cbtennvcalv.SelectedValue.ToString()), dtpngaycalv.Value, cbcalv.Text);
                    getcalamviec();
                    dtgCalv.CurrentCell = dtgCalv.Rows[currow].Cells[0];
                }
                else
                {
                    if (dtgNghiPhep.Rows.Count > 1 && dtgNghiPhep.CurrentRow.Cells[0].Value.ToString() != "") id = (int)dtgNghiPhep.CurrentRow.Cells[0].Value;
                    if (action == 2)
                    { currow = dtgNghiPhep.CurrentRow.Index; }
                    else if (action == 1)
                    { currow = dtgNghiPhep.Rows.Count - 1; }
                    else
                    { currow = 0; }
                    if (chbnghilienlac.Checked) islienlac = 1;
                    if(rbcophep.Checked)
                    {
                        hinhthucnghi = rbcophep.Text;
                    }
                    else if(rbkophep.Checked)
                    {
                        hinhthucnghi = rbkophep.Text;
                    }
                    else if (rbdacbiet.Checked)
                    {
                        hinhthucnghi = rbdacbiet.Text;
                    }
                    else if (rbditre.Checked)
                    {
                        hinhthucnghi = rbditre.Text;
                    }
                    else
                    {
                        hinhthucnghi = rbvesom.Text;
                    }
                    int results = Import_Manager.Instance.UpdateNghiPhep(action, id, Int32.Parse(cbtennvnghiphep.SelectedValue.ToString()), dtpNghiTuNgay.Value, dtpNghiDenNgay.Value, hinhthucnghi, islienlac, tbthoigiannghi.Text, tbLyDonghi.Text);
                    getnghiphep();
                    dtgNghiPhep.CurrentCell = dtgNghiPhep.Rows[currow].Cells[0];
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
            DataTable data = Import_Manager.Instance.getHopDong(tbmanvhdfil.Text, tbHDFilter.Text);
            dtgHopDong.DataSource = data;
            
        }

        private void tbHDFilter_TextChanged(object sender, EventArgs e)
        {
            gethopdong();
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void tbLyDo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbmanvnghiphep_TextChanged(object sender, EventArgs e)
        {
            loadtennhanvienfromanv(tbmanvnghiphep.Text);
        }

        private void tbmanvhdfil_TextChanged(object sender, EventArgs e)
        {
            gethopdong();
        }

        private void cbnghilam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbnghilam.Checked)
            {
                dtpngaynghihd.Visible = true;
                lbnghilam.Visible = true;
            }
            else
            {
                dtpngaynghihd.Visible = false;
                lbnghilam.Visible = false;
            }
        }

        private void tbmanvhopdong_TextChanged(object sender, EventArgs e)
        {
            loadtennhanvienfromanv(tbmanvhopdong.Text);
        }

        private void tbmanvfilter_TextChanged(object sender, EventArgs e)
        {
            danhsachnhanvien();
        }

        private void tbmanvnghifil_TextChanged(object sender, EventArgs e)
        {
            getnghiphep();
        }

        private void tbtennvnghifil_TextChanged(object sender, EventArgs e)
        {
            getnghiphep();
        }

        private void tbmanvcalvfil_TextChanged(object sender, EventArgs e)
        {
            getcalamviec();
        }

        private void tbtennvcalvfil_TextChanged(object sender, EventArgs e)
        {
            getcalamviec();
        }

        private void tbcalvfil_TextChanged(object sender, EventArgs e)
        {
            getcalamviec();
        }

        private void tbmanvcalv_TextChanged(object sender, EventArgs e)
        {
            loadtennhanvienfromanv(tbmanvcalv.Text);
        }
    }
}
