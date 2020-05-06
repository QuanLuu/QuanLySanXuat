using Chuong_Trinh_Quan_Ly_San_Xuat.ADO;
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
        //SANYO_SERVER//MRDBA
        private Import_Manager() { }

        public DataTable LoadDM_NL(string TenNL)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DM_NGUYEN_LIEU @TEN_NL", new object[] { TenNL });
        }
        public DataTable getsopofromkhmsql(string kh, string msql, DateTime ngayxuat)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_PO_NO_FROM_KH_MSQL @kh , @msql , @ngayxuat", new object[] { kh, msql, ngayxuat });
        }
        public DataTable dutoannl(int year, int month)
        {
            return DataProvider.Instance.ExecuteQuery("PP_DU_TOAN_NGUYEN_LIEU @YEAR , @MONTH", new object[] { year, month });
        }
        public DataTable getmasptheoNL(string TenNL)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_MASP_THEO_NL @TEN_NL", new object[] { TenNL });
        }

        public DataTable LoadDM_SP(string msql, string masp, string nvl)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_SAN_PHAM @MSQL , @MA_SP , @NVL", new object[] { msql, masp, nvl });
        }
        public DataTable LoadKH(string TenKH)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_KHACH_HANG @TENKH", new object[] { TenKH });
        }
        public DataTable LoadKHFromSP(string msql, string kh)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_KH_FROM_SP @MSQL , @KH", new object[] { msql, kh });
        }
        public DataTable LoadDM(string msql, string masp)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DINH_MUC @MSQL , @MA_SP", new object[] {msql, masp });
        }
        public DataTable GetMAxIDImport()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_GET_MAX_IMPORT_FILE", new object[] { });
        }
        public DataTable GetErrormport()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_IMPORT_ERROR", new object[] { });
        }

        public DataTable LoadDongia(string masp, string msql)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_DON_GIA @MA_SP , @MSQL", new object[] { masp, msql });
        }
        public DataTable GetBaoCaoSXThang(int year, int month)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC [PP_BAO_CAO_SAN_XUAT_THANG] @year , @month", new object[] { year, month });
        }
        public DataTable Getthepnxt(int year, int month)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC [PP_BAO_CAO_NXT_NVL_THANG] @year , @month", new object[] { year, month });
        }
        public DataTable getnhanviencalv(string manv, string tennv, string ca)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC [PP_UI_GET_CA_LAM_VIEC] @ma , @ten , @ca", new object[] { manv, tennv, ca });
        }

        public DataTable LoadMaSP()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT MA_SP FROM DM_SAN_PHAM", new object[] { });
        }

        public DataTable LoadNhanVien()
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_SHORT_NHAN_VIEN", new object[] {});
        }

        public DataTable checkmanl(string manl)
        {
            return DataProvider.Instance.ExecuteQuery("PP_CHECK_MA_NL @NL", new object[] {manl });
        }
        public DataTable checkmasp(string masp)
        {
            return DataProvider.Instance.ExecuteQuery("PP_CHECK_MA_SP @SP", new object[] {masp});
        }
        public DataTable GetMayMocTheoCD(string macd)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_MAY_MOC_THEO_CONG_DOAN @MA_CD", new object[] {macd });
        }

        public DataTable Loadcongdoantheomsql(string msql, string masp)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_MA_CONG_DOAN_THEO_MSQL @MSQL , @masp", new object[] { msql, masp });
        }

        public DataTable getcongdoantheomsqlvatencd(string msql, string tencd)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_MA_CONG_DOAN_THEO_MSQL_TEN_CD @MSQL , @TENCD", new object[] { msql , tencd});
        }
        public DataTable getmasptheomsql(string msql)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_MA_SP_THEO_MSQL @MSQL", new object[] { msql });
        }

        public DataTable GetMayMocCDSP()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_MAY_MOC", new object[] { });
        }
        public DataTable GetMayMoc()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM MAY_MOC_SAN_XUAT", new object[] { });
        }

        public DataTable danhsachnv(string manv,string tennv)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_NHAN_VIEN @manv , @TEN_NHAN_VIEN", new object[] {manv, tennv });
        }

        public DataTable GetChiThiSanXuat(DateTime tungay, DateTime denngay, string msql, string masp, string soct, int currententry, string nguoinhap)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_CHI_THI_SX @TU_NGAY , @DEN_NGAY , @MSLQ , @masp , @soct , @current , @nguoinhap", new object[] {tungay, denngay, msql, masp, soct, currententry, nguoinhap });
        }
        public DataTable GetTenDangNhap()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM USER_LOGIN", new object[] {});
        }
        public DataTable checklocksoct(string soct)
        {
            return DataProvider.Instance.ExecuteQuery("PP_CHECK_LOCK_SO_CT @soct", new object[] { soct});
        }
        public DataTable CheckLogin(string tendn, string pas)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_LOG_IN @USER_LOG_IN , @PASSWORD", new object[] { tendn, pas });
        }
        public DataTable getSPCongDoan(String msql , string masp)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_SP_CONG_DOAN @MSQL , @MA_SP", new object[] {msql, masp });
        }

        public DataTable loadcomboMAQL()
        {
            return DataProvider.Instance.ExecuteQuery(" SELECT ID, MSQL + ' - ' + MA_SP AS MSQL FROM DM_SAN_PHAM ", new object[] { });
        }

        public DataTable getHopDong(string manv,string tennv)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_HOP_DONG @manv , @TENNV", new object[] {manv, tennv });
        }

        public DataTable getnhanvienhd()
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_NHAN_VIEN_HOP_DONG", new object[] {  });
        }
        public DataTable gettennvfrommanv(string manv)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC PP_UI_GET_NHAN_VIEN_FROM_MANV @manv", new object[] { manv});
        }
        public DataTable getNhatKyNhapNL(string manl, DateTime from, DateTime to, string invoice, string solot)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC [PP_UI_GET_NHAT_KY_NHAP_NL] @MA_NL , @DATE_FROM , @DATE_TO , @INV , @lot", new object[] { manl, from, to, invoice, solot });
        }
        public DataTable getbophan()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT TEN FROM BO_PHAN", new object[] { });
        }

        public DataTable getnhatkyxuatNL(string tennl, DateTime from, DateTime to, string solot)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_NHAT_KY_XUAT_NL @TEN_NL , @DATE_FROM , @DATE_TO , @lot", new object[] { tennl , from, to, solot});
        }

        public DataTable getkiemkhotp(string congdoan, string msql, DateTime ngaykiem, DateTime ngaykiemto, string masp)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_KIEM_KHO_TP @CD , @MSQL , @NGAY_KIEM , @NGAY_KIEM_TO , @masp", new object[] {congdoan, msql, ngaykiem , ngaykiemto, masp});
        }
        public DataTable getkiemkhonl(string manl, DateTime ngaykiem, DateTime ngaykiemto)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_KIEM_KHO_NL @manl , @NGAY_KIEM , @ngay_to", new object[] { manl, ngaykiem, ngaykiemto });
        }
        public DataTable getnhatkyxuatSP(string msql, string masp, DateTime from, DateTime to, string invoice, String kh, string solot, string sopo)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_NHAT_KY_XUAT_SP @msql , @MA_SP , @DATE_FROM , @DATE_TO , @INV , @KH , @lot , @sopo", new object[] {msql, masp, from, to, invoice, kh, solot, sopo });
        }

        public DataTable CheckSoluongcdsxtrc(int idcdsx)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_CHECK_SL_CD @ID_CD_TRC", new object[] { idcdsx });
        }
        //
        public DataTable getpoall(string khachhang, string msql, DateTime datefrom, DateTime dateto, string masp)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_PO_ALL @KH , @MSQL , @DATEFROM , @DATETO , @masp", new object[] { khachhang, msql, datefrom, dateto, masp });
        }
        public DataTable getpopass(string khachhang, string msql, DateTime datefrom, DateTime dateto, string masp)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_PO_PASS @KH , @MSQL , @DATEFROM , @DATETO , @masp", new object[] { khachhang, msql, datefrom, dateto, masp });
        }
        public DataTable getForecast(string khachhang, string msql, DateTime datefrom, DateTime dateto, string masp)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_FORECAST @KH , @MSQL , @DATEFROM , @DATETO , @masp", new object[] { khachhang, msql, datefrom, dateto, masp });
        }
        public DataTable getlisttime(string msql)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_LIST_TIME @MSQL", new object[] { msql });
        }
        public DataTable GetKhvamasp(string makh, string msql)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_KH_MASP @MAKH , @MSL", new object[] { makh , msql});
        }
        public DataTable GetUser()
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_USERS", new object[] {});
        }
        public DataTable GetBox(string boxtype)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_BOX @BOX_TYPE", new object[] { boxtype });
        }
        public DataTable GetSPSNP(string msql, String masp)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_SAN_PHAM_SNP @MSQL , @MASP", new object[] { msql, masp });
        }

        public DataTable printPO(string kh, DateTime ngaypo, string msql, int ngaydukien)
        {
            return DataProvider.Instance.ExecuteQuery("PP_DS_PRINT_PO_MSQL @KH , @NGAY_PO , @MSQL , @NGAY_DU_KIEN", new object[] { kh, ngaypo, msql, ngaydukien });
        }
        public DataTable Getloaithung()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT DISTINCT LOAI_THUNG FROM BOX_SAN_PHAM ", new object[] { });
        }

        public DataTable getuserinfor(string username)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_USER_INFOR @USER ", new object[] { username});
        }

        public DataTable getbaocaosx(DateTime datefrom, DateTime dateto)
        {
            return DataProvider.Instance.ExecuteQuery("PP_BAO_CAO_SAN_XUAT @FROM , @TO ", new object[] { datefrom, dateto});
        }

        public DataTable gettencongdoanbantp(string bophan)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_TEN_CONG_DOAN_BAN_TP @BP", new object[] {bophan });
        }
        public DataTable getholiday(int year)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_HOLIDAY @year", new object[] { year });
        }

        public DataTable baocaotiendo(int tunam, int tuthang, int dennam, int denthang, string msql, string macd)
        {
            return DataProvider.Instance.ExecuteQuery("PP_BAO_CAO_TIEN_DO @TU_NAM , @TU_THANG , @DEN_NAM , @DEN_THANG , @MSQL , @MA_CD", new object[] { tunam, tuthang, dennam, denthang, msql, macd });
        }
        public DataTable baocaotiendongay(string msql, string macd, int nam, int thang)
        {
            return DataProvider.Instance.ExecuteQuery("PP_BAO_CAO_TIEN_DO_NGAY_TRONG_THANG @MSQL , @MA_CD , @NAM , @THANG", new object[] {  msql, macd, nam, thang });
        }
        public DataTable GetNVL_NCC(string nvl, string ncc)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_NGUYEN_LIEU_NCC @NVL , @NCC", new object[] { nvl, ncc});
        }
        public DataTable GetNVL_From_NCC(string ncc)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_NVL_FROM_NCC @NCC", new object[] { ncc });
        }
        public DataTable inCTSX(string msql, string masp, int year, int month)
        {
            return DataProvider.Instance.ExecuteQuery("PP_DS_IN_CHI_THI_SAN_XUAT @MSQL , @MASP , @YEAR , @MONTH ", new object[] {msql, masp, year, month });
        }

        public DataTable reportInvoice(string kh, int year, int month, string soinv, DateTime ngayinvoice)
        {
            return DataProvider.Instance.ExecuteQuery("[PP_DS_INVOICE] @KH , @YEAR , @MONTH , @INVOICE , @DATE_INVOICE", new object[] { kh, year, month, soinv, ngayinvoice });
        }

        public DataTable getxuatgiacong(string msql, string masp, DateTime from, DateTime to, string cty)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_XUAT_GIA_CONG @MSQL , @SP , @DATE_FROM , @DATE_TO , @CTY", new object[] {msql, masp, from, to, cty });
        }
        public DataTable getnhapgiacong(string msql,string masp, DateTime from, DateTime to, string cty)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_NHAP_GIA_CONG @MSQL , @SP , @DATE_FROM , @DATE_TO , @CTY", new object[] {msql, masp, from, to, cty });
        }

        public DataTable getnxtnvl( DateTime from, DateTime to)
        {
            return DataProvider.Instance.ExecuteQuery("PP_BAO_CAO_NXT_NVL @DATE_FROM , @DATE_TO", new object[] {from, to });
        }
        public DataTable GetNhatKyNghiPhep(string manv, string tennv)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_NGHI_PHEP @manv , @tennv", new object[] { manv, tennv });
        }
        public DataTable GetKehoachnxgiacong(string msql, string nhapxuat)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_KH_NHAP_XUAT_GIA_CONG @msql , @nx", new object[] { msql, nhapxuat });
        }
        public DataTable getDMAll(string msql, string masp, string manl, string makh, string macd, string maymoc, string loaithung)
        {
            return DataProvider.Instance.ExecuteQuery("PP_UI_GET_ALL_DANH_MUC @msql , @masp , @manl , @makh , @macd , @may , @thung", new object[] { msql, masp, manl, makh, macd, maymoc, loaithung });
        }
        public DataTable getnxtsp(DateTime from, DateTime to)
        {
            return DataProvider.Instance.ExecuteQuery("PP_BAO_CAO_NXT_SP @DATE_FROM , @DATE_TO", new object[] { from, to });
        }

        public DataTable GetTienDoGiaCong(string msql, int year, int month, string nhapxuat)
        {
            return DataProvider.Instance.ExecuteQuery("PP_TIEN_DO_GIA_CONG_NGAY @msql , @year , @month , @nhapxuat", new object[] { msql, year, month, nhapxuat });
        }
        public DataTable GetTienDoGiaCongThang(string msql, int year, int month, int year_to, int month_to, string nhapxuat)
        {
            return DataProvider.Instance.ExecuteQuery("PP_TIEN_DO_GIA_CONG_THANG @msql , @year , @month , @year_to , @month_to , @nhapxuat", new object[] { msql, year, month, year_to, month_to, nhapxuat });
        }
        public DataTable phieuktnl(DateTime tungay, DateTime denngay, string spec, string sizea, string nhanvien)
        {
            return DataProvider.Instance.ExecuteQuery("PP_PHIEU_KIEM_TRA_NL @tungay , @denngay , @spec , @size , @nhavien", new object[] { tungay, denngay, spec, sizea, nhanvien });
        }
        //PP_PHIEU_KIEM_TRA_NL
        public int UpdateSPCongDoan(int action, int id, string macd, string tencd, int idmay, int idmsql, int congdoanso, float spm, float tgcbtc)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_SP_CONG_DOAN] @ACTION , @ID , @MA_CONG_DOAN , @TEN_CONG_DOAN , @ID_MAY , @ID_MSQL , @CD_SO , @SPM , @TGCBTC", new object[] { action, id, macd, tencd, idmay, idmsql, congdoanso, spm, tgcbtc});
        }
        //
        public int UpdateKiemKhoTP(int ACTION ,int ID ,string MSQL ,string LOT ,string THUNG ,DateTime NGAY_GIA_CONG ,float TON ,DateTime NGAY_KIEM ,string NGUOI_KIEM ,string GHICHU, String CONGDOAN)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_KIEM_KHO_TP] @ACTION , @ID , @MSQL , @LOT , @THUNG , @NGAY_GIA_CONG , @TON , @NGAY_KIEM , @NGUOI_KIEM , @GHICHU , @CD", new object[] { ACTION, ID, MSQL, LOT, THUNG, NGAY_GIA_CONG, TON, NGAY_KIEM, NGUOI_KIEM, GHICHU, CONGDOAN });
        }

        public int UpdateKiemKhoNL(int ACTION ,int ID ,string MANL ,string LOT ,string CUON ,string CUONME ,decimal TON ,DateTime NGAY_KIEM ,string NGUOI_KIEM ,string GHICHU)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_KIEM_KHO_NL] @ACTION , @ID , @MANL , @LOT , @CUON , @CUONME , @TON , @NGAY_KIEM , @NGUOI_KIEM , @GHICHU", new object[] { ACTION, ID, MANL, LOT, CUON, CUONME, TON, NGAY_KIEM, NGUOI_KIEM, GHICHU });
        }
        public int updateholidays(int ACTION, int ID, DateTime ngaynghi, string mota)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_HOLIDAY] @ACTION , @ID , @ngay , @mota", new object[] { ACTION, ID, ngaynghi, mota});
        }
        public int UpdateNL(int action, int id, string tenNL, string kichthuoc, decimal dauky, decimal tonantoan)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DM_NGUYEN_LIEU] @ACTION , @ID , @TENNL , @KICHCO , @DAUKY , @TONANTOAN", new object[] { action, id, tenNL, kichthuoc, dauky, tonantoan });
        }
        public int updatematkhau(string user, string mk)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_MAT_KHAU] @user , @mk", new object[] { user, mk });
        }
        public int UpdateSP(int action, int id, string msql, string MaSP, string TenSP, string TenNL, decimal dauky, decimal tonantoan)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DM_SAN_PHAM] @ACTION , @ID , @MSQL , @MASP , @TENSP , @TENNL , @DAUKY , @TONANTOAN", new object[] { action, id, msql, MaSP, TenSP, TenNL, dauky, tonantoan });
        }

        public int UpdateKH(int action, int id, string MaKH, string TenKH, string TenNLH, string bophan, string dienthoai, string email, string diachi)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_KHACH_HANG] @ACTION , @ID , @MAKH , @TENKH , @NGUOILIENHE , @BOPHAN , @DIENTHOAI , @EMAIL , @DIACHI", new object[] { action, id, MaKH, TenKH, TenNLH, bophan, dienthoai, email, diachi });
        }

        public int UpdateDinhMuc(int action, int id, DateTime datefrom, string masp, decimal dinhmuc)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DINH_MUC] @ACTION , @ID , @DATE_FROM , @MA_SP , @DINH_MUC", new object[] { action, id, datefrom, masp, dinhmuc  });
        }

        public int UpdateDongia(int action, int id, DateTime datefrom, string masp, decimal DONGIA, string kh)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_DON_GIA] @ACTION , @ID , @DATE_FROM , @MA_SP , @DON_GIA , @KH", new object[] { action, id, datefrom, masp, DONGIA, kh });
        }
        public int UpdateChiThiSX(int action, int id, string macd, int idmaymoc, DateTime ngaysx, string casx, int soluong, string solot, int tgsx, int tgchuabi, int tgsua, int tgchaole, int tgdaotao, int tgchokhuon, int suoc, int mop, int set, int biendang, int hongkhac, int baoluu, int xima, int nhiet,  int idhopdong, string ghichu, string userinsert, int vs6s, int mopbaoluu, int ngkiemtra, string soct, decimal kehoach, decimal luyke, int islock)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_CHI_THI_SX] @ACTION , @ID , @MA_CONG_DOAN , @ID_MAY_MOC , @NGAY_SX , @CA_SX , @SO_LUONG , @SO_LOT , @TG_SX , @TG_CHUAN_BI , @TG_SUA , @TG_CHAO_LE , @TG_DAO_TAO , @TG_CHO_KHUON , @SUOC , @MOP , @SET , @BIEN_DANG , @HONG_KHAC , @BAO_LUU , @NG_XI_MA , @NG_NHIET , @ID_HOP_DONG , @GHI_CHU , @USER_INSERTED , @VE_SINH_6S , @MOP_BAO_LUU , @NG_KIEM_TRA , @soct , @kh , @lk , @lock", new object[] { action, id, macd, idmaymoc,ngaysx, casx, soluong, solot, tgsx, tgchuabi, tgsua, tgchaole, tgdaotao, tgchokhuon, suoc, mop, set, biendang, hongkhac, baoluu, xima, nhiet, idhopdong, ghichu, userinsert, vs6s, mopbaoluu, ngkiemtra, soct, kehoach, luyke, islock });
        }

        public int UpdateMaymoc(int action, int id, string tenmay, string somay, string mamay)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_MAY_SAN_XUAT] @ACTION , @ID , @TEN_MAY , @SO_MAY , @MA_MAY", new object[] { action, id, tenmay, somay, mamay});
        }

        public int UpdateDSNV(int action, int id, string tennv, string gioitinh, DateTime ngaysinh, string cmtnd, DateTime ngaycap, string bhxh, string vanhoa, string diachi, string manv)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_NHAN_VIEN] @ACTION , @ID , @TEN_NHAN_VIEN , @GIOI_TINH , @NGAY_SINH , @SO_CMND , @NGAY_CAP , @SO_BHXH , @VAN_HOA , @DIA_CHI , @MANV", new object[] { action, id, tennv, gioitinh, ngaysinh, cmtnd, ngaycap, bhxh, vanhoa, diachi, manv});
        }

        public int UpdatenhatkynhapNL(int ACTION, int ID, string MA_NL, DateTime  NGAY_NHAP, string NCC, string SO_LOT, string SO_PO, string SO_INVOICE, DateTime NGAY_INVOICE, string SO_CO, DateTime NGAY_CO, int SO_CUON, decimal KHOI_LUONG, string GHI_CHU, int idnv)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_NHAT_KY_NHAP_NL] @ACTION , @ID , @MA_NL , @NGAY_NHAP , @NCC , @SO_LOT , @SO_PO , @SO_INVOICE , @NGAY_INVOICE , @SO_CO , @NGAY_CO , @SO_CUON , @KHOI_LUONG , @GHI_CHU , @idnv", new object[] { ACTION, ID, MA_NL, NGAY_NHAP, NCC, SO_LOT, SO_PO, SO_INVOICE, NGAY_INVOICE, SO_CO, NGAY_CO, SO_CUON, KHOI_LUONG, GHI_CHU, idnv});
        }

        public int UpdatenhatkyxuatNL(int ACTION, int ID, string TEN_NL,string masp, DateTime NGAY_XUAT,string SO_LOT,int SO_CUON,decimal KHOI_LUONG,string GHI_CHU, string ca, int idnv)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_NHAT_KY_XUAT_NL] @ACTION , @ID , @TEN_NL , @MA_SP , @NGAY_XUAT , @SO_LOT , @SO_CUON , @KHOI_LUONG , @GHI_CHU , @CA , @idnv", new object[] { ACTION, ID, TEN_NL, masp, NGAY_XUAT, SO_LOT, SO_CUON, KHOI_LUONG, GHI_CHU, ca, idnv });
        }

        public int updatenhatkyxuatSP(int ACTION, int ID, string masp, DateTime NGAY_XUAT, string SO_LOT, string sopo, string soinvoice, string sotokhai, DateTime ngaytokhai, int sothung, int soluong, string GHI_CHU, string kh, int idnv)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_NHAT_KY_XUAT_SP] @ACTION , @ID , @MA_SP , @NGAY_XUAT , @SO_LOT , @SO_PO , @SO_INVOICE , @SO_TO_KHAI , @NGAY_TO_KHAI , @SO_THUNG , @SO_LUONG , @GHI_CHU , @KH , @idnv", new object[] { ACTION, ID, masp, NGAY_XUAT, SO_LOT, sopo, soinvoice,sotokhai, ngaytokhai, sothung, soluong, GHI_CHU, kh, idnv });
        }
        public int ImportFile()
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_IMPORT_FILE", new object[] { });
        }
        public int UpdatePO(int ACTION, int ID,string MaKH, string masp, DateTime ngaypo, string sopo, DateTime etd, DateTime eta, int soluong, decimal dongia, DateTime ngaygiao, string GHI_CHU)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_PO_ALL] @ACTION , @ID , @MA_KH , @MASP , @NGAY_PO , @SO_PO , @ETA , @ETD , @SO_LUONG , @DON_GIA , @NGAY_GIAO_DU_KIEN , @GHI_CHU", new object[] { ACTION, ID, MaKH, masp, ngaypo, sopo, etd, eta, soluong, dongia, ngaygiao, GHI_CHU });
        }
        public int Updateforecast(int ACTION, int ID, string masp, DateTime ngayorecast, DateTime ngaydulien, int soluong, string GHI_CHU, string makh,string forecastno, DateTime eta, DateTime etd)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_FORECAST_ALL] @ACTION , @ID , @MASP , @NGAY_FORECAST , @NGAY_DU_KIEN , @SO_LUONG , @GHI_CHU , @MA_KH , @forecastno , @eta , @etd", new object[] { ACTION, ID, masp, ngayorecast, ngaydulien, soluong, GHI_CHU, makh, forecastno,eta, etd });
        }
        public int updatelisttime(int action, int id, string macongdoan, int listtime)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec [PP_UI_UPDATE_LIST_TIME] @ACTION , @ID , @MA_CD , @LIST_TIMEY", new object[] { action, id, macongdoan, listtime });
        }
        public DataTable LoadDataTypeTable()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM IMPORT_DATATYPE", new object[] { });
        }

        public DataTable LoadDataTypeSheetTable(string datatype)
        {
            return DataProvider.Instance.ExecuteQuery("exec PP_UI_GET_IMPORT_DATATYPE_SHEET @data_type", new object[] { datatype });
        }

        public int UpdateDataType(int action, int ignore, string name, int schedule, string kindfile, string delimiter, string sourcepath, string despath, string filter, int idtype)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_IMPORT_DATATYPE @ACTION , @IGNORE , @NAME , @SCHEDULE_TYPE , @KIND_FILE , @SPLIT_DELIMITER , @SOURCEPATH , @DESTINATION , @FILTER , @ID", new object[] { action, ignore, name, schedule, kindfile, delimiter, sourcepath, despath, filter, idtype });
        }
        public int UpdateDataTypeSheet(int ACTION, int ID_DATATYPE, int IGNORE, int PIVOT_TABLE, int MAX_COLUMN, String NAME, String DATATYPE_NAME, String BUFFER_TABLE, int ID)
        {
            return DataProvider.Instance.ExecuteNonQuery("exec PP_UI_UPDATE_IMPORT_DATATYPE_SHEET @ACTION , @ID_DATATYPE , @IGNORE , @PIVOT_TABLE , @MAX_COLUMN , @NAME , @DATATYPE_NAME , @BUFFER_TABLE , @ID", new object[] { ACTION, ID_DATATYPE, IGNORE, PIVOT_TABLE, MAX_COLUMN, NAME, DATATYPE_NAME, BUFFER_TABLE, ID });
        }
        public int UpdateDuLieu(int maxidimport)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UPDATE_DU_LIEU @ID", new object[] { maxidimport });
        }
        public int UpdateUsers(int action, int id, string ten, string pas, string capquyen, string casx, string bophan)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_USERS @ACTION , @ID , @TEN , @PAS , @CAP_QUYEN , @CA_SX , @BOPHAN", new object[] { action, id, ten, pas, capquyen, casx, bophan});
        }
        public int UpdateBOX(int action, int id, string loaithung, string kichthuoc, string loaicase)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_BOX_SAN_PHAM @ACTION , @ID , @LOAI_THUNG , @KICH_THUOC , @CASE", new object[] { action, id, loaithung, kichthuoc, loaicase });
        }
        public int UpdateKHSP(int action, int id, string MAKH, string MASP)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_KHACH_HANG_SAN_PHAM @ACTION , @ID , @MA_KH , @MA_SP", new object[] { action, id, MAKH, MASP });
        }
        public int UpdateSanphamSNP(int action, int id, string masp, int snp,string loaithung, string kichthuoc, string loaicase)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_SAN_PHAM_SNP_BOX @ACTION , @ID , @MA_SP , @SNP , @LOAI_THUNG , @KICH_THUOC , @CASE", new object[] { action, id, masp, snp, loaithung, kichthuoc, loaicase });
        }
        public int UpdateXUATGIACONG(int ACTION, int ID, string MASP, DateTime NGAY, int SL, string PALLET, string THUNG, string TOKHAI, string SO_HD, string KH, String GHI_CHU, int idnv)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_XUAT_GIA_CONG @ACTION , @ID , @MASP , @NGAY , @SL , @PALLET , @THUNG , @TOKHAI , @SO_HD , @KH , @GHI_CHU , @idnv", new object[] { ACTION,    ID,     MASP,   NGAY,   SL,     PALLET,     THUNG,  TOKHAI,     SO_HD,  KH, GHI_CHU, idnv});
        }

        public int UpdateNHAPGIACONG(int ACTION, int ID, string MASP, DateTime NGAY, int SL, int slng, int slngkt, string TOKHAI, string SO_HD, string KH, String GHI_CHU, int idnv)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_NHAP_GIA_CONG @ACTION , @ID , @MASP , @NGAY , @SL , @SL_NG , @SL_NG_KT , @TOKHAI , @SO_HD , @KH , @GHI_CHU , @idnv", new object[] { ACTION, ID, MASP, NGAY, SL, slng, slngkt, TOKHAI, SO_HD, KH, GHI_CHU, idnv });
        }

        public int UpdateNVL_NCC(int ACTION, int ID, string nvl, string ncc)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_NVL_NCC @ACTION , @ID , @NVL , @NCC", new object[] { ACTION, ID, nvl, ncc});
        }
        public int updatehopdong(int ACTION, int ID, int idnv, string bophan, string chucvu, DateTime ngaylv, DateTime ngayky, int isnghi, DateTime ngaynghi)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_HOP_DONG @ACTION , @ID , @idnv , @bophan , @chucvu , @ngaylam , @ngayky , @isnghi , @ngaynghi", new object[] { ACTION, ID, idnv, bophan, chucvu, ngaylv, ngayky, isnghi, ngaynghi });

        }
       public int UpdateNghiPhep (int ACTION, int ID, int idnv, DateTime nghitu, DateTime nghiden, string hinhthuc, int lienlac, string thoigian, string lydo)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_NGHI_PHEP @ACTION , @ID , @idnv , @nghitu , @nghiden , @hinhthuc , @lienlac , @thoigian , @lydo", new object[] { ACTION, ID, idnv, nghitu, nghiden, hinhthuc, lienlac, thoigian, lydo});
        }
        public int Updatenhanviencalv(int ACTION, int ID, int idnv, DateTime ngaybd, string ca)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UPDATE_NHAN_VIEN_CA_LAM @ACTION , @ID , @idnv , @ngaybd , @ca", new object[] { ACTION, ID, idnv, ngaybd, ca});
        }
        public int Updatekehoachnxgiacong(int ACTION, int ID, int idsp, DateTime ngaykh, float soluong, string nhapxuat)
        {
            return DataProvider.Instance.ExecuteNonQuery("EXEC PP_UI_UPDATE_KH_NHAP_XUAT_GIA_CONG @ACTION , @ID , @idsp , @ngaykh , @sl , @nhapxuat", new object[] { ACTION, ID, idsp, ngaykh, soluong, nhapxuat });
        }
        public int cleanupkhsx(int month)
        {
            return DataProvider.Instance.ExecuteNonQuery("PP_CLEAN_UP_KHSX @MONTH", new object[] {month});
        }
        //PP_UI_UPDATE_HOP_DONG
    }
}
