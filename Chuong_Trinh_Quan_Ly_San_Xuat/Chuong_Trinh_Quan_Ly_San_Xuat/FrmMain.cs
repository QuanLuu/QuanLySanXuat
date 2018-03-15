using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class FrmMain : Form
    {
        public string quyensudung;
        public string casx;
        double app_ver = 1.0;
        public FrmMain()
        {
            InitializeComponent();
            EventKhiLoadForm(this.panelMain);
            getusername();
            panelMain.Enabled = false;
            this.Text = "Quản Lý Sản Xuất - Version " + app_ver.ToString();
        }
        void HieuUngChon(Control col)
        {
            if (col.GetType().Name == "Label") col.BackColor = Color.White;
            if (col.GetType().Name == "PictureBox") col.BackColor = Color.White;
        }

        void BoHieuUng(Control col)
        {
            if (col.GetType().Name == "Label") col.BackColor = Color.LightBlue;
            if (col.GetType().Name == "PictureBox") col.BackColor = Color.LightBlue;
        }
        void EventKhiLoadForm(Control col)
        {
            foreach (Control c in col.Controls)
            {
                if (c.GetType().Name == "Label") c.MouseHover += hieung;
                if (c.GetType().Name == "PictureBox") c.MouseHover += hieung;
                if (c.GetType().Name == "Label") c.MouseLeave += bohieung;
                if (c.GetType().Name == "PictureBox") c.MouseLeave += bohieung;
                EventKhiLoadForm(c);
            }
        }

        private void bohieung(object sender, EventArgs e)
        {
            BoHieuUng((Control)sender);
        }

        private void hieung(object sender, EventArgs e)
        {
            HieuUngChon((Control)sender);
        }

        private void toolStripbtnDangNhap_Click(object sender, EventArgs e)
        {
           
        }
        void enablecontrol(string capquyen, Control col)
        {
            foreach (Control c in col.Controls)
            {
                if (c.Tag == null) { c.Enabled = false; }
                else
                {
                    if (capquyen.Contains(c.Tag.ToString()))
                    { c.Enabled = true; }
                    else { c.Enabled = false; }
                }
            }
        }
        void getusername()
        {
            //DataTable tendn = Import_Manager.Instance.GetTenDangNhap();
            //for (int i = 0; i < tendn.Rows.Count; i++)
            //{
            //    cbName.Items.Add(tendn.Rows[i][1].ToString());
            //}

        }
        void showdanhmuc()
        {
            FrmDanhMuc danhmuc = new FrmDanhMuc();
            this.Hide();
            danhmuc.Show();
            danhmuc.ShowInTaskbar = true;
            danhmuc.FormClosing += main_close;

        }

        void showchithisx()
        {
            FrmChiThiSX chithisx = new FrmChiThiSX();
            this.Hide();
            chithisx.Show();
            chithisx.ShowInTaskbar = true;
            chithisx.FormClosing += main_close;

        }

        void shownhansu()
        {
            FrmNhanSu frm = new FrmNhanSu();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }

        void shownhapxuat()
        {
            FrmNhapXuat frm = new FrmNhapXuat();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }

        private void main_close(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            showdanhmuc();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            showchithisx();
        }

        private void lbDanhMuc_Click(object sender, EventArgs e)
        {
            showdanhmuc();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            showchithisx();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dangnhap();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            shownhansu();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            shownhansu();
        }

        private void tbPass_Enter(object sender, EventArgs e)
        {
           
        }
        void dangnhap()
        {
            if (tbPass.Text == "") return;
            try
            {
                DataTable data = Import_Manager.Instance.CheckLogin(tbTenDN.Text, tbPass.Text);
                int kqcheck = data.Rows.Count;
                if (kqcheck > 0)
                {
                    panelMain.Enabled = true;
                    string quyencap = data.Rows[0][2].ToString();
                    quyensudung = data.Rows[0][3].ToString();
                    casx = data.Rows[0][5].ToString();
                    if (quyencap != "Full") enablecontrol(quyencap, this.panelMain);
                    panelLogin.Visible = false;
                }
                else
                {
                    MessageBox.Show("Không đúng mật khẩu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) dangnhap();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            shownhapxuat();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            shownhapxuat();
        }
    }
}
