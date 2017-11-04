using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;

namespace TinhGiaInNhapLieu.Presenter
{
    
    public class NiemYetGiaInNhanhPresenter
    {
        IViewNiemYetGiaInNhanh View;
        public NiemYetGiaInNhanhPresenter(IViewNiemYetGiaInNhanh view)
        { 
            View = view;
            
        }
        public List<BangGiaInNhanh> BangGiaInNhanhS()
        {
            return BangGiaInNhanh.DocTatCa();
        }
        public List<HangKhachHang> HangKhachHangS()
        {
            return HangKhachHang.LayTatCa();
        }
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
            View.DienGiai = "Mô tả";
            View.NoiDungBangGia = "Cần thiết";
            View.IdHangKhachHang = 0;
            View.SoTrangToiDaTinh = 0;
                  
            View.DaySoLuong = ";";
            View.DayGiaTrang = ";";
            View.DaySoLuongNiemYet = ";";
            View.ThuTu = 100;
            View.GiaTheoKhoang = false;
       
            View.KhongSuDung = false;
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var bangGiaIn = BangGiaInNhanh.DocTheoId(View.ID);
            View.ID = bangGiaIn.ID;
            View.Ten = bangGiaIn.TenBangGia;
            View.DienGiai = bangGiaIn.MoTa;
            View.NoiDungBangGia = bangGiaIn.NoiDungBangGia;
            View.IdHangKhachHang = bangGiaIn.IdHangKhachHang;
          
            View.SoTrangToiDaTinh = bangGiaIn.SoTrangToiDa;
            View.DaySoLuong = bangGiaIn.DaySoLuong;
            View.DayGiaTrang = bangGiaIn.DayGia;
            View.DaySoLuongNiemYet = bangGiaIn.DaySoLuongNiemYet;
            View.ThuTu = bangGiaIn.ThuTu;
            View.GiaTheoKhoang = bangGiaIn.GiaTheoKhoang;
          
            View.KhongSuDung = bangGiaIn.KhongSuDung;
            
        }
        public string DienGiaiHangKhachHang()
        {
            var kq = "";
            if (View.IdHangKhachHang > 0)
                kq = HangKhachHang.LayTheoId(View.IdHangKhachHang).DienGiai;

            return kq;
        }
        public void NhanDoiBangGia(ref string thongDiep)
        {
            if (View.ID <= 0)
            {
                thongDiep = "Thất bại";
                return;
            }
            var bangGiaInNhanh = new BangGiaInNhanh();
            
            bangGiaInNhanh.TenBangGia = View.Ten + " Copy";
            bangGiaInNhanh.MoTa = View.DienGiai;
            bangGiaInNhanh.NoiDungBangGia = View.NoiDungBangGia;
            bangGiaInNhanh.IdHangKhachHang = View.IdHangKhachHang;
            bangGiaInNhanh.SoTrangToiDa = View.SoTrangToiDaTinh;
            bangGiaInNhanh.DaySoLuong = View.DaySoLuong;
            bangGiaInNhanh.DayGia = View.DayGiaTrang;
            bangGiaInNhanh.DaySoLuongNiemYet = View.DaySoLuongNiemYet;
            bangGiaInNhanh.GiaTheoKhoang = View.GiaTheoKhoang;
            bangGiaInNhanh.ThuTu = View.ThuTu;
            bangGiaInNhanh.KhongSuDung = View.KhongSuDung;

            thongDiep = BangGiaInNhanh.Them(bangGiaInNhanh);
        }
        public void Luu(ref string thongDiep)
        {
            BangGiaInNhanh bangGiaInNhanh = new BangGiaInNhanh();
            bangGiaInNhanh.ID = View.ID; 
            bangGiaInNhanh.TenBangGia = View.Ten;
            bangGiaInNhanh.MoTa = View.DienGiai;
            bangGiaInNhanh.NoiDungBangGia = View.NoiDungBangGia;
            bangGiaInNhanh.IdHangKhachHang = View.IdHangKhachHang;           
          
            bangGiaInNhanh.SoTrangToiDa = View.SoTrangToiDaTinh;
            bangGiaInNhanh.DaySoLuong = View.DaySoLuong;
            bangGiaInNhanh.DayGia = View.DayGiaTrang;
            bangGiaInNhanh.DaySoLuongNiemYet = View.DaySoLuongNiemYet;
            bangGiaInNhanh.GiaTheoKhoang = View.GiaTheoKhoang;   
            bangGiaInNhanh.ThuTu = View.ThuTu;
            bangGiaInNhanh.KhongSuDung = View.KhongSuDung;
            switch (View.TinhTrangForm)
            {
                case TinhGiaInClient.FormStateS.Edit:
                    BangGiaInNhanh.Sua(ref thongDiep, bangGiaInNhanh);
                    break;
                case TinhGiaInClient.FormStateS.New:
                    thongDiep = BangGiaInNhanh.Them(bangGiaInNhanh);
                    break;

            }

        }
    }
}
