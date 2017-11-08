using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInClient.Model.Booklet;
using TinhGiaInClient.View;

namespace TinhGiaInClient.Presenter
{
    public class TinhGiaPresenter
    {
        IViewTinhGiaIn View;
        TinhGiaIn TinhGia;
        public TinhGiaPresenter(IViewTinhGiaIn view)
        {
            View = view;
            TinhGia = new TinhGiaIn();
        }
        public void NoiDungBanDau()
        {
            View.NgayTinhGia = DateTime.Today;
            
          
        }
        public Dictionary<int, string> HangKhachHangS()
        {
            var hangKHTheoUser = NguoiDung.DocTheoTenDangNhap(View.TenNhanVien.Trim().ToLower()).ChoHangKhachHang.Trim().Split(';');
            var nguonHangKH = HangKhachHang.LayTatCa().Where(x => hangKHTheoUser.Contains(x.MaHieu.Trim())).ToList();
            //var so = nguonHangKH.Count();

            //var so = nguonHangKH.Count();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            foreach (HangKhachHang hkh in nguonHangKH)
            {
                dict.Add(hkh.ID, hkh.Ten);

            }
            return dict;
        }
        public int IdHangKH()
        {
            return this.HangKhachHangS().FirstOrDefault(x => x.Value == View.TenHangKH).Key;
        }
        public string DienGiaiHangKH() //
        {
            return HangKhachHang.LayTheoId(this.IdHangKH()).DienGiai;
        }

        //phần không lưu data
        #region Phần Bài in: thêm sửa, xóa bài in

        public List<BaiIn> DanhSachBaiIn()
        {
            return TinhGia.KetQuaBaiInS;
        }
        public bool DuocGopTrangInTheoBaiIn()
        {
            //Xem xét được gộp không
            //Còn quyết định gộp sẽ cung cấp cho classs TinhGia
            //Để gộp
            return this.TinhGia.ChoTinhGopTrangIn();
        }

        public void Them_BaiIn(BaiIn baiIn)
        {
            TinhGia.ThemBaiIn(baiIn);
        }
        /* public void Sua_KQBaiIn(KetQuaBaiIn baiIn)
         {
             var baiInSua = this.DanhSachBaiIn.Find(x => x.ID == baiIn.ID);
             baiInSua.TieuDe = baiIn.TieuDe;
             baiInSua.DienGiai = baiIn.DienGiai;
             baiInSua.SoLuong = baiIn.SoLuong;
             baiInSua.DonVi = baiIn.DonVi;
             baiInSua.IdHangKH = baiIn.IdHangKH;
             baiInSua.TenHangKH = baiIn.TenHangKH;
             baiInSua.GiayDeInIn = baiIn.GiayDeInIn;
             baiInSua.CauHinhSP = baiIn.CauHinhSP;
             baiInSua.GiaInS = baiIn.GiaInS;
             baiInSua.ThanhPhamS = baiIn.ThanhPhamS;            
         }*/
        public void Xoa_BaiIn(BaiIn baiIn)
        {
            TinhGia.XoaBaiIn(baiIn);
        }
        public BaiIn DocBaiInTheoID(int idBaiIn)
        {
            return TinhGia.DocBaiInTheoID(idBaiIn);
        }
        public void XoaTatCa_BaiIn()
        {
            TinhGia.XoaTatCaKetQuaBaiIn();
        }
        public Dictionary<int, List<string>> TrinhBayKetQuaBaiInS()
        {
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (BaiIn bIn in this.DanhSachBaiIn())
            {
                var lst = new List<string>();
                lst.Add(bIn.TieuDe);
                lst.Add(bIn.DienGiai);
                lst.Add(bIn.SoLuong.ToString());
                lst.Add(bIn.DonVi);

                lst.Add(string.Format("{0:0,0.00}đ", bIn.TriGiaBaiIn()));
                dict.Add(bIn.ID, lst);//hoàn tất tại đây
            }
            return dict;
        }

        public void CapNhatQuyetDinhGopGia()
        {
            this.TinhGia.QuyetDinhGopTrangInBaiIn = View.QuyetDinhGopTrangIn;
        }
        #endregion
        #region Phần Danh Thiếp: thêm sửa, xóa bài in

        public List<BaiInDanhThiep> DanhSachDanhThiep()
        {
            return TinhGia.BaiInDanhThiepS;
        }

        public void Them_DanhThiep(BaiInDanhThiep baiIn)
        {
            TinhGia.ThemDanhThiep(baiIn);
        }
        /* public void Sua_DanhThiep(KetQuaBaiIn baiIn)
         {
             var baiInSua = this.DanhSachBaiIn.Find(x => x.ID == baiIn.ID);
             baiInSua.TieuDe = baiIn.TieuDe;
             baiInSua.DienGiai = baiIn.DienGiai;
             baiInSua.SoLuong = baiIn.SoLuong;
             baiInSua.DonVi = baiIn.DonVi;
             baiInSua.IdHangKH = baiIn.IdHangKH;
             baiInSua.TenHangKH = baiIn.TenHangKH;
             baiInSua.GiayDeInIn = baiIn.GiayDeInIn;
             baiInSua.CauHinhSP = baiIn.CauHinhSP;
             baiInSua.GiaInS = baiIn.GiaInS;
             baiInSua.ThanhPhamS = baiIn.ThanhPhamS;            
         }*/
        public void Xoa_DanhThiep(BaiInDanhThiep baiIn)
        {
            TinhGia.XoaDanhThiep(baiIn);
        }
        public BaiInDanhThiep DocDanhThiepTheoID(int idBaiIn)
        {
            return TinhGia.DocDanhThiepTheoID(idBaiIn);
        }
        public void XoaTatCa_DanhThiep()
        {
            TinhGia.XoaTatDanhThiep();
        }
        public Dictionary<int, List<string>> TrinhBayDanhThiepS()
        {
           
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (BaiInDanhThiep bIn in this.DanhSachDanhThiep())
            {
                var lst = new List<string>();
                lst.Add(bIn.TieuDe);
                lst.Add(string.Format("{0} / {1} /{2}", bIn.KichThuoc, bIn.TenGiayIn,
                                bIn.TenTuyChonSChon()));
                lst.Add(bIn.SoLuongHop.ToString());
                lst.Add("Hộp 100");
                lst.Add(string.Format("{0:0,0.00}đ", bIn.ThanhTien()));

                dict.Add(bIn.ID, lst);//hoàn tất tại đây
            }
            return dict;
        }


        #endregion
        #region Phần In cuốn Digi: thêm sửa, xóa

        public List<GiaInSachDigi> GiaInSachDigiS()
        {
            return TinhGia.GiaInSachDigiS;
        }

        public void Them_Sach(GiaInSachDigi sachDigi)
        {
            TinhGia.ThemCuon(sachDigi);
        }

        public void Xoa_Cuon(GiaInSachDigi inCuon)
        {
            TinhGia.XoaCuon(inCuon);
        }
        public GiaInSachDigi DocCuonTheoID(int idCuonDigi)
        {
            return TinhGia.DocCuonTheoID(idCuonDigi);
        }
        public void XoaTatCa_Cuon()
        {
            TinhGia.XoaTatCaCuon();
        }
        public Dictionary<int, List<string>> TrinhBayCuonS()
        {
            /*lvwCuon.Columns.Add("Id");
            lvwCuon.Columns.Add("Tiêu đề");
            lvwCuon.Columns.Add("Khổ cuốn");
            lvwCuon.Columns.Add("Số Trang/Cuốn");
            lvwCuon.Columns.Add("Số lượng");
            lvwCuon.Columns.Add("Thành tiền"); */ 

            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (GiaInSachDigi sachIn in this.GiaInSachDigiS())
            {
                var lst = new List<string>();
                lst.Add(sachIn.TieuDe);
                lst.Add(string.Format("{0} x {1}cm", sachIn.QuiCachSach.ChieuRong,
                    sachIn.QuiCachSach.ChieuCao));
                lst.Add(sachIn.QuiCachSach.TongSoTrang.ToString());
                lst.Add(sachIn.SoCuon.ToString());
                lst.Add(string.Format("{0:0,0.00}đ", sachIn.GiaChaoTong()));

                dict.Add(sachIn.ID, lst);//hoàn tất tại đây
            }
            return dict;
        }


        #endregion
        #region Phần Thẻ nhựa: thêm sửa, xóa bài in

        public List<BaiInTheNhua> BaiInTheNhuaS()
        {
            return TinhGia.BaiInTheNhuaS;
        }
        public Dictionary<int, List<string>> TrinhBayTheNhuaS()
        {/*
            lvwDanhThiep.Columns.Add("Tiêu đề");
            lvwDanhThiep.Columns.Add("Vật liệu");
            lvwDanhThiep.Columns.Add("Kích thước");
            lvwDanhThiep.Columns.Add("Số lượng");
            lvwDanhThiep.Columns.Add("Đơn vị");
            lvwDanhThiep.Columns.Add("Trị giá");
          */

            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            foreach (BaiInTheNhua bIn in this.BaiInTheNhuaS())
            {
                var lst = new List<string>();
                lst.Add(bIn.TieuDe);
                lst.Add(string.Format("{0} / {1} /{2}", bIn.KichThuoc,
                    bIn.TenGiayBaoGom, bIn.TenTuyChonSChon()));
                lst.Add(bIn.SoLuongThe.ToString());
                lst.Add("Thẻ");
                lst.Add(string.Format("{0:0,0.00}đ", bIn.ThanhTien()));

                dict.Add(bIn.ID, lst);//hoàn tất tại đây
            }
            return dict;
        }
        public void Them_TheNhua(BaiInTheNhua baiIn)
        {
            TinhGia.ThemTheNhua(baiIn);
        }
       
        public void Xoa_TheNhua(BaiInTheNhua baiIn)
        {
            TinhGia.XoaTheNhua(baiIn);
        }
        public BaiInTheNhua DocTheNhuaTheoID(int idBaiIn)
        {
            return TinhGia.DocTheNhuaTheoID(idBaiIn);
        }
        public void XoaTatCa_TheNhua()
        {
            TinhGia.XoaTatTheNhua();
        }
       


        #endregion
        #region phần Tính giá

        public KetQuaTinhGiaIn TaoMauTinTinhGia()
        {
            var ketQua = new KetQuaTinhGiaIn();
            ketQua.NgayTinhGia = View.NgayTinhGia;
            ketQua.IdNguoiDung = View.IdNguoiDung;
            ketQua.TieuDe = View.TieuDeTinhGia;            
            ketQua.TenNguoiDung = View.TenNhanVien;
            ketQua.TenKhachHang = View.TenHangKH;
            //Tạo nội dung chào giá từ List sang 1 chuỗi string
            foreach (string str in TinhGia.NoiDungGiaChaoKhachHang())
            {
                ketQua.NoiDungChaoGia += str + '\r' + '\n';
                
            }
            return ketQua;
        }
        public string ThemTinhGia()
        {
          
            return KetQuaTinhGiaIn.Them(this.TaoMauTinTinhGia());
        }
        public string CapNhatTinhGia()
        {

            return KetQuaTinhGiaIn.Sua(this.TaoMauTinTinhGia());
            
        }
        #endregion
        #region các tổng và tóm tắt
        public decimal TongGiaDanhThiep()
        {
            return this.TinhGia.TongTienDanhThiep();
        }
        public decimal TongGiaBaiIn()
        {
            if (View.QuyetDinhGopTrangIn)
                return this.TinhGia.TongTienBaiInDaDieuChinhTienIn();
            else
                return this.TinhGia.TongTienBaiInChuaDieuChinhGiaIn();
        }
        public decimal TongGiaCuon()
        {
            return this.TinhGia.TongTienCuon();
        }
        public decimal TongGiaTheNhua()
        {
            return this.TinhGia.TongTienTheNhua();
        }
        #region Một số tóm tắt
        public string TomTatTab_DanhThiep()
        {
            var kq = "";
            
            foreach (string st in TinhGia.NoiDungGiaChaoKH_DanhThiep())
            {
                kq += st + '\r' + '\n';
            }
            return kq;
        }
        public string TomTatTab_BaiIn()
        {
            var kq = "";

            foreach (string st in TinhGia.NoiDungGiaChaoKH_InTheoBai())
            {
                kq += st + "\r" + "\n";
            }
            //Thêm phần khấu trừ bài in
            if (View.QuyetDinhGopTrangIn)
            {
                var str2 = "---Có gộp tiền in: " + "\r" + "\n";
                str2 += string.Format("Tiền in khấu trừ: {0:0,0.00}đ" + "\r" + "\n",
                    this.TinhGia.TienInDaKhauTruTheoBai());
                str2 += string.Format("Tổng giá bài in còn: {0:0,0.00}đ" + "\r" + "\n",
                    this.TinhGia.TongTienBaiInDaDieuChinhTienIn());

                kq += str2;
            }
            return kq;
        }
        public string TomTatTab_InCuon()
        {
            var kq = "";

            foreach (string st in TinhGia.NoiDungGiaChaoKH_InSach())
            {
                kq += st + '\r' + '\n';
            }
            return kq;
        }
        public string TomTatTab_TheNhua()
        {
            var kq = "";

            foreach (string st in TinhGia.NoiDungGiaChaoKH_TheNhua())
            {
                kq += st + '\r' + '\n';
            }
            return kq;
        }
        public string TomTatTinhGia_ChaoKH()
        {
            var result = "CHÀO GIÁ" + '\r' + '\n';
            //if (!string.IsNullOrEmpty(View.TenKhachHang) && !string.IsNullOrEmpty(View.TenHangKH))
                result += string.Format("Tên KH: {0} / {1}" + '\r' + '\n', View.TenKhachHang, View.TenHangKH);

            foreach (string st in TinhGia.NoiDungGiaChaoKhachHang())
            {
                result += st + '\r' + '\n';
            }
            return result;
        }

        #endregion
        public string TrinhBayNoiDungBaiIn()
        {
            string result = "";
          
            foreach (KeyValuePair<string, string> str in TinhGia.DocBaiInTheoID(View.IdBaiInChon).TomTat_ChaoKH())
             {
                 result += string.Format("{0} {1}" + '\r' + '\n', str.Key, str.Value);
             }
            return result;
        }
        public string TrinhBayNoiDungDanhThiep()
        {
            string result = "";
            if (View.IdDanhThiepChon <= 0)
                return "";

            foreach (KeyValuePair<string, string> str in TinhGia.DocDanhThiepTheoID(View.IdDanhThiepChon).TomTat_ChaoKH())
            {
                result += string.Format("{0} {1}" + '\r' + '\n', str.Key, str.Value);
            }
            return result;
        }
        public string TrinhBayNoiDungInCuonDigi()
        {
            string kq = "";
            if (View.IdGiaSachDiGiChon >0 )
                kq = TinhGia.DocCuonTheoID(View.IdGiaSachDiGiChon).TomTatChao_DichVu();
            
            return kq;
        }
        public string TrinhBayNoiDungTheNhua()
        {
            var kq = "";
            if (View.IdTheNhuaChon > 0)
            {

                foreach (KeyValuePair<string, string> str in TinhGia.DocTheNhuaTheoID(View.IdTheNhuaChon).TomTat_ChaoKH())
                {
                    kq += string.Format("{0} {1}" + '\r' + '\n', str.Key, str.Value);
                }
            }
            return kq;
        }
        #endregion
    }
}
