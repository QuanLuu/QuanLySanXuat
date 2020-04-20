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
    public partial class frmDoiMK : Form
    {
        public frmDoiMK()
        {
            InitializeComponent();
        }
        void doimk()
        {
            if (tbPass.Text == "") return;
            try
            {
                DataTable data = Import_Manager.Instance.CheckLogin(tbTenDN.Text, tbPass.Text);
                int kqcheck = data.Rows.Count;
                if (kqcheck > 0)
                {
                    int res = Import_Manager.Instance.updatematkhau(tbTenDN.Text, tbpassmoi.Text);
                    MessageBox.Show("Đổi thành công!");
                    this.Close();
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

        private void btnDoi_Click(object sender, EventArgs e)
        {
            doimk();
        }
    }
}
