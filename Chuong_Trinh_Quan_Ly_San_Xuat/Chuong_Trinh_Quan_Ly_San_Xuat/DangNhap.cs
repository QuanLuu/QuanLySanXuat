using Chuong_Trinh_Quan_Ly_San_Xuat.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chuong_Trinh_Quan_Ly_San_Xuat
{
    public partial class DangNhap : Form
    {
        public string quyensudung;
        public DangNhap()
        {
            InitializeComponent();
            getusername();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data = Import_Manager.Instance.CheckLogin(cbName.Text, tbPass.Text);
            int kqcheck = Int32.Parse(data.Rows[0][2].ToString());
            quyensudung = data.Rows[0][1].ToString();
            if (kqcheck > 0)
            {
                FrmChiThiSX f = new Chuong_Trinh_Quan_Ly_San_Xuat.FrmChiThiSX();
                this.Visible = false;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không đúng mật khẩu");
            }
        }
        void getusername()
        {
            DataTable tendn = Import_Manager.Instance.GetTenDangNhap();
            cbName.DataSource = tendn;
            cbName.DisplayMember = "USER_LOG_IN";
        }
      
    }
}
