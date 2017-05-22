using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;

namespace TinhGiaInNhapLieu.Presenter
{
    
    public class QuanLyBangGiaInNhanhPresenter
    {
        IViewQuanLyBangGiaInNhanh View;
        public QuanLyBangGiaInNhanhPresenter(IViewQuanLyBangGiaInNhanh view)
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
            View.MoTa = "Mô tả";
            View.NoiDungBangGia = "Cần thiết";
            View.IdHangKhachHang = 0;
            View.SoTrangToiDaTinh = 0;
                  
            View.DaySoLuong = ";";
            View.DayGiaTrang = ";";
            View.DaySoLuongNiemYet = ";";
            View.ThuTu = 100;
       
            View.KhongSuDung = false;
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var bangGiaIn = BangGiaInNhanh.DocTheoId(View.ID);
            View.ID = bangGiaIn.ID;
            View.Ten = bangGiaIn.TenBangGia;
            View.MoTa = bangGiaIn.MoTa;
            View.NoiDungBangGia = bangGiaIn.NoiDungBangGia;
            View.IdHangKhachHang = bangGiaIn.IdHangKhachHang;
          
            View.SoTrangToiDaTinh = bangGiaIn.SoTrangToiDa;
            View.DaySoLuong = bangGiaIn.DaySoLuong;
            View.DayGiaTrang = bangGiaIn.DayGia;
            View.DaySoLuongNiemYet = bangGiaIn.DaySoLuongNiemYet;
            View.ThuTu = bangGiaIn.ThuTu;
          
            View.KhongSuDung = bangGiaIn.KhongSuDung;
            
        }
        public string DienGiaiHangKhachHang()
        {
            var kq = "";
            if (View.IdHangKhachHang > 0)
                kq = HangKhachHang.LayTheoId(View.IdHangKhachHang).DienGiai;

            return kq;
        }
        public void Luu(ref string thongDiep)
        {
            BangGiaInNhanh toInMayDigi = new BangGiaInNhanh();
            toInMayDigi.ID = View.ID; 
            toInMayDigi.TenBangGia = View.Ten;
            toInMayDigi.MoTa = View.MoTa;
            toInMayDigi.NoiDungBangGia = View.NoiDungBangGia;
            toInMayDigi.IdHangKhachHang = View.IdHangKhachHang;
           
            toInMayDigi.IdHangKhachHang = View.IdHangKhachHang;
          
            toInMayDigi.SoTrangToiDa = View.SoTrangToiDaTinh;
            toInMayDigi.DaySoLuong = View.DaySoLuong;
            toInMayDigi.DayGia = View.DayGiaTrang;
            toInMayDigi.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            toInMayDigi.ThuTu = View.ThuTu;
            View.KhongSuDung = View.KhongSuDung;
            switch (View.TinhTrangForm)
            {
                case TinhGiaInClient.FormStateS.Edit:
                    BangGiaInNhanh.Sua(ref thongDiep, toInMayDigi);
                    break;
                case TinhGiaInClient.FormStateS.New:
                    thongDiep = BangGiaInNhanh.Them(toInMayDigi);
                    break;

            }

        }
    }
}
