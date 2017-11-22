using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;
using TinhGiaInNhapLieu.View;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInNhapLieu.Presenter
{
    
    public class QuanLyBGiaDThiepPresenter
    {
        IViewQuanLyBGiaDThiep View;
        public QuanLyBGiaDThiepPresenter(IViewQuanLyBGiaDThiep view)
        { 
            View = view;
            
        }
        public List<BangGiaDanhThiep> BangGiaDanhThiepS()
        {
            return BangGiaDanhThiep.DocTatCa();
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
            View.SoHopToiDa = 0;
            View.GiayBaoGom = "Couche 300gsm";
            View.KhoToChay = "32 x 47cm";
            View.DaySoLuong = ";";
            View.DayGiaTrang = ";";
            View.DaySoLuongNiemYet = ";";
            View.InHaiMat = false;
            View.SoDanhThiepTrenHop = 100;
            View.ThuTu = 100;
       
            View.KhongCon = false;
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var bangGiaIn = BangGiaDanhThiep.DocTheoId(View.ID);
            View.ID = bangGiaIn.ID;
            View.Ten = bangGiaIn.Ten;
            View.MoTa = bangGiaIn.MoTa;
            View.NoiDungBangGia = bangGiaIn.NoiDungBangGia;
            View.IdHangKhachHang = bangGiaIn.IdHangKhachHang;
            View.InHaiMat = bangGiaIn.InHaiMat;
            View.SoHopToiDa = bangGiaIn.SoHopToiDa;
            View.DaySoLuong = bangGiaIn.DaySoLuong;
            View.DayGiaTrang = bangGiaIn.DayGia;
            View.GiayBaoGom = bangGiaIn.GiayBaoGom;
            View.KhoToChay = bangGiaIn.KhoToChay;
            View.SoDanhThiepTrenHop = bangGiaIn.SoDanhThiepTrenHop;
            View.ThuTu = bangGiaIn.ThuTu;
          
            View.KhongCon = bangGiaIn.KhongCon;
            
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
            BangGiaDanhThiep bGiaDThiep = new BangGiaDanhThiep();
            bGiaDThiep.ID = View.ID; 
            bGiaDThiep.Ten= View.Ten;
            bGiaDThiep.MoTa = View.MoTa;
            bGiaDThiep.NoiDungBangGia = View.NoiDungBangGia;
            bGiaDThiep.IdHangKhachHang = View.IdHangKhachHang;
            bGiaDThiep.InHaiMat = View.InHaiMat;
            bGiaDThiep.SoHopToiDa = View.SoHopToiDa;
            bGiaDThiep.DaySoLuong = View.DaySoLuong;
            bGiaDThiep.DayGia = View.DayGiaTrang;
            bGiaDThiep.KhoToChay = View.KhoToChay;
            bGiaDThiep.GiayBaoGom = View.GiayBaoGom;
            bGiaDThiep.SoDanhThiepTrenHop = View.SoDanhThiepTrenHop;
            bGiaDThiep.ThuTu = View.ThuTu;
            bGiaDThiep.KhongCon = View.KhongCon;

            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = BangGiaDanhThiep.Sua(bGiaDThiep);
                    break;
                case FormStateS.New:
                    thongDiep = BangGiaDanhThiep.Them(bGiaDThiep);
                    break;

            }

        }
    }
}
