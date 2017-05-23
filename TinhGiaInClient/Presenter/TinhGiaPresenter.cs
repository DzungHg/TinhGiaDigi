using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
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


        #endregion
        #region Phần Danh Thiếp: thêm sửa, xóa bài in

        public List<BaiInDanhThiep> DanhSachDanhThiep()
        {
            return TinhGia.BaiInGiaDanhThiepS;
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
                lst.Add(bIn.TenBangGia);
                lst.Add(string.Format("{0} {1}", bIn.KichThuoc, bIn.TenGiayIn));
                lst.Add(bIn.SoLuongHop.ToString());
                lst.Add("Hộp 100");
                lst.Add(string.Format("{0:0,0.00}đ", bIn.ThanhTien));

                dict.Add(bIn.ID, lst);//hoàn tất tại đây
            }
            return dict;
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

        public string TomTatTinhGia_ChaoKH()
        {
            var result = "";
            foreach (string st in TinhGia.NoiDungGiaChaoKhachHang())
            {
                result += st + '\r' + '\n';
            }
            return result;
        }
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
    }
}
