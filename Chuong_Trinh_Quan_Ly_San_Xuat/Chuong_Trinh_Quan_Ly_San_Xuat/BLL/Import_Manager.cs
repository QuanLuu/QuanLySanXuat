using Chuong_Trinh_Quan_Ly_San_Xuat.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuong_Trinh_Quan_Ly_San_Xuat.BLL
{
    public class Import_Manager
    {
        private static Import_Manager instance;

        public static Import_Manager Instance
        {
            get
            {
                if (instance == null) instance = new Import_Manager();
                return Import_Manager.instance;
            }

            private set
            {
                Import_Manager.instance = value;
            }
        }

        private Import_Manager() { }

        public DataTable LoadDM_NL(string TenNL)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DM_NGUYEN_LIEU   @TEN_NL", new object[] { TenNL });
        }

        public DataTable LoadDM_SP(string TenSP)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_SAN_PHAM   @TENSP", new object[] { TenSP });
        }
        public DataTable LoadKH(string TenKH)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_KHACH_HANG   @TENKH", new object[] { TenKH });
        }
        public DataTable LoadDM(string masp)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DINH_MUC   @TENKH", new object[] { masp });
        }

        public int UpdateNL(int action, int id, string tenNL, string kichthuoc, decimal dauky)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DM_NGUYEN_LIEU] @ACTION , @ID , @TENNL , @KICHCO , @DAUKY", new object[] { action, id, tenNL, kichthuoc, dauky });
        }

        public int UpdateSP(int action, int id, string MaSP, string TenSP, string TenNL, string MaKH, decimal dauky)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DM_SAN_PHAM] @ACTION , @ID , @MASP , @TENSP , @TENNL , @MAKH , @DAUKY", new object[] { action, id, MaSP, TenSP, TenNL, MaKH, dauky});
        }

        public int UpdateKH(int action, int id, string MaKH, string TenKH, string TenNLH, string bophan, string dienthoai, string email, string diachi)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_KHACH_HANG] @ACTION , @ID , @MAKH , @TENKH , @NGUOILIENHE , @BOPHAN , @DIENTHOAI , @EMAIL , @DIACHI", new object[] { action, id, MaKH, TenKH, TenNLH, bophan, dienthoai, email, diachi });
        }
    }
}
