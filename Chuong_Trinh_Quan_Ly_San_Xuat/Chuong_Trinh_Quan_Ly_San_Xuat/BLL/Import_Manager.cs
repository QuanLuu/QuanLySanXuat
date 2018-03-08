﻿using Chuong_Trinh_Quan_Ly_San_Xuat.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

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
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DINH_MUC   @MA_SP", new object[] { masp });
        }

        public DataTable LoadNhanVien()
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_SHORT_NHAN_VIEN", new object[] {});
        }


        public DataTable GetMayMocTheoCD(string macd)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_MAY_MOC_THEO_CONG_DOAN @MA_CD", new object[] {macd });
        }

        public DataTable Loadcongdoantheomsql(string msql)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_MA_CONG_DOAN_THEO_MSQL @MSQL", new object[] { msql });
        }

        public DataTable GetMayMocCDSP()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_MAY_MOC", new object[] { });
        }
        public DataTable GetMayMoc()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM MAY_MOC_SAN_XUAT", new object[] { });
        }

        public DataTable danhsachnv(string tennv)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_NHAN_VIEN @TEN_NHAN_VIEN", new object[] {tennv });
        }

        public DataTable GetChiThiSanXuat(DateTime tungay, DateTime denngay, string msql)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_CHI_THI_SX @TU_NGAY , @DEN_NGAY , @MSLQ", new object[] {tungay, denngay, msql });
        }
        public DataTable GetTenDangNhap()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM USER_LOGIN", new object[] {});
        }
        public DataTable CheckLogin(string tendn, string pas)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_LOG_IN @USER_LOG_IN , @PASSWORD", new object[] { tendn, pas });
        }
        public DataTable getSPCongDoan(string masp)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_SP_CONG_DOAN @MA_SP", new object[] { masp });
        }

        public DataTable loadcomboMAQL()
        {
            return DataProvider.Instance.ExecuteQuery(" SELECT ID, MSQL + ' - ' + MA_SP AS MSQL FROM DM_SAN_PHAM ", new object[] { });
        }

        public DataTable getHopDong(string tennv)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_HOP_DONG @TENNV", new object[] { tennv });
        }

        public DataTable getbophan()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT TEN FROM BO_PHAN", new object[] { });
        }

        public int UpdateSPCongDoan(int action, int id, string macd, string tencd, int idmay, int idmsql)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_SP_CONG_DOAN] @ACTION , @ID , @MA_CONG_DOAN , @TEN_CONG_DOAN , @ID_MAY , @ID_MSQL", new object[] { action, id, macd, tencd, idmay, idmsql});
        }

        public int UpdateNL(int action, int id, string tenNL, string kichthuoc, decimal dauky)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DM_NGUYEN_LIEU] @ACTION , @ID , @TENNL , @KICHCO , @DAUKY", new object[] { action, id, tenNL, kichthuoc, dauky });
        }

        public int UpdateSP(int action, int id, string msql, string MaSP, string TenSP, string TenNL, string MaKH, decimal dauky)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DM_SAN_PHAM] @ACTION , @ID , @MSQL , @MASP , @TENSP , @TENNL , @MAKH , @DAUKY", new object[] { action, id, msql, MaSP, TenSP, TenNL, MaKH, dauky});
        }

        public int UpdateKH(int action, int id, string MaKH, string TenKH, string TenNLH, string bophan, string dienthoai, string email, string diachi)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_KHACH_HANG] @ACTION , @ID , @MAKH , @TENKH , @NGUOILIENHE , @BOPHAN , @DIENTHOAI , @EMAIL , @DIACHI", new object[] { action, id, MaKH, TenKH, TenNLH, bophan, dienthoai, email, diachi });
        }

        public int UpdateDinhMuc(int action, int id, DateTime datefrom, DateTime dateto, string masp, decimal dinhmuc)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DINH_MUC] @ACTION , @ID , @DATE_FROM , @DATE_TO , @MA_SP , @DINH_MUC", new object[] { action, id, datefrom, dateto, masp, dinhmuc  });
        }
        public int UpdateChiThiSX(int action, int id, string macd, DateTime ngaysx, string casx, int soluong, string solot, int tgsx, int tgchuabi, int tgsua, int tgchaole, int tgdaotao, int tgchokhuon, int suoc, int mop, int set, int biendang, int hongkhac, int baoluu, int xima, int nhiet, string ghichu, string userinsert)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_CHI_THI_SX] @ACTION , @ID , @MA_CONG_DOAN , @NGAY_SX , @CA_SX , @SO_LUONG , @SO_LOT , @TG_SX , @TG_CHUAN_BI , @TG_SUA , @TG_CHAO_LE , @TG_DAO_TAO , @TG_CHO_KHUON , @SUOC , @MOP , @SET , @BIEN_DANG , @HONG_KHAC , @BAO_LUU , @NG_XI_MA , @NG_NHIET , @GHI_CHU , @USER_INSERTED", new object[] { action, id, macd, ngaysx, casx, soluong, solot, tgsx, tgchuabi, tgsua, tgchaole, tgdaotao, tgchokhuon, suoc, mop, set, biendang, hongkhac, baoluu, xima, nhiet, ghichu, userinsert });
        }

        public int UpdateMaymoc(int action, int id, string tenmay, string somay, string mamay)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_MAY_SAN_XUAT] @ACTION , @ID , @TEN_MAY , @SO_MAY , @MA_MAY", new object[] { action, id, tenmay, somay, mamay});
        }

        public int UpdateDSNV(int action, int id, string tennv, string gioitinh, DateTime ngaysinh, string cmtnd, DateTime ngaycap, string bhxh, string vanhoa, string diachi)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_NHAN_VIEN] @ACTION , @ID , @TEN_NHAN_VIEN , @GIOI_TINH , @NGAY_SINH , @SO_CMND , @NGAY_CAP , @SO_BHXH , @VAN_HOA , @DIA_CHI", new object[] { action, id, tennv, gioitinh, ngaysinh, cmtnd, ngaycap, bhxh, vanhoa, diachi});
        }

    }
}
