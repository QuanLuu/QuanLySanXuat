﻿using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using Pabo.Calendar;
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
    public partial class FrmMain : Form
    {
        public string quyensudung;
        public string casx;
        double app_ver = 1.0; 
        public string languege_set;      
        public FrmMain()
        {
            InitializeComponent();
            cblanguege.Text = "VietNamese";
            EventKhiLoadForm(this.panelMain);
            getusername();
            panelMain.Enabled = true;
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
                if (c.Tag == null) { c.Visible = false; }
                else
                {
                    if (capquyen.Contains(c.Tag.ToString()))
                    { c.Visible = true; }
                    else { c.Visible = false; }
                }
            }
        }
        void fullview()
        {
            foreach (Control c in panelMain.Controls)
            {
                c.Visible = true;             
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
        void showPOForecast()
        {
            FrmPO frm = new FrmPO();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }
        void showKiemKho()
        {
            FrmKiemKho frm = new FrmKiemKho();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }

        void showBaocaoinan()
        {
            FrmReportView frm = new FrmReportView();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }
        void showformkehoach()
        {
            FrmKeHoach frm = new FrmKeHoach();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }
        void showcalendar()
        {
            CalendarHolidays frm = new CalendarHolidays();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;

        }
        void showformAdmin()
        {
            FrmAdmin frm = new FrmAdmin();
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
        void changelaguege(string lang)
        {
            string res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_vi";
            if (languege_set == "Japan")
            {
                res_file = "Chuong_Trinh_Quan_Ly_San_Xuat.lang_ja";
                label1.Text = "SANYO SEISAKUSHO VIETNAM CO., LTD";
                label5.Text = "SSVNの生産管理システム";
                ResourceManager res_man = new ResourceManager(res_file, Assembly.GetExecutingAssembly());
                lbDanhMuc.Text = res_man.GetString("danhmuc");
                lbnhapxuat.Text = res_man.GetString("nhapxuat");
                lbbaocao.Text = res_man.GetString("baocao");
                lbnhansu.Text = res_man.GetString("nhansu");
                lbkiemkho.Text = res_man.GetString("kiemkho");
                lbpo.Text = res_man.GetString("PO");
                lbctsx.Text = res_man.GetString("ctsx");
            }

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
                    if (quyencap != "Full" && quyencap != "Full;")
                        enablecontrol(quyencap, this.panelMain);
                    else
                        fullview();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            showBaocaoinan();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            showPOForecast();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            showPOForecast();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            showformAdmin();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            showformAdmin();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            showKiemKho();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            showKiemKho();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            languege_set = cblanguege.Text.Replace("Japanese","Japan");
            changelaguege(languege_set);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            showcalendar();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            showcalendar();
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            frmDoiMK frm = new Chuong_Trinh_Quan_Ly_San_Xuat.frmDoiMK();
            this.Hide();
            frm.Show();
            frm.FormClosing += main_close;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            showformkehoach();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            showformkehoach();
        }
    }
}
