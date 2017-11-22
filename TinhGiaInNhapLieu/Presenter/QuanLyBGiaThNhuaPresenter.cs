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
    
    public class QuanLyBGiaThNhuaPresenter
    {
        IViewQuanLyBGiaThNhua View;
        public QuanLyBGiaThNhuaPresenter(IViewQuanLyBGiaThNhua view)
        { 
            View = view;
            
        }
        public List<BangGiaTheNhua> BangGiaTheNhuaS()
        {
            return BangGiaTheNhua.DocTatCa();
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
            View.SoTheToiDa = 0;
            View.VatLieuInBaoGom = "Nhựa PVC";
            View.KhoToChay = "32 x 47cm";
            View.DaySoLuong = ";";
            View.DayGiaThe = ";";
            View.DaySoLuongNiemYet = ";";
            View.InHaiMat = false;
            View.ThuTu = 100;
       
            View.KhongCon = false;
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var bangGiaIn = BangGiaTheNhua.DocTheoId(View.ID);
            View.ID = bangGiaIn.ID;
            View.Ten = bangGiaIn.Ten;
            View.MoTa = bangGiaIn.MoTa;
            View.NoiDungBangGia = bangGiaIn.NoiDungBangGia;
            View.IdHangKhachHang = bangGiaIn.IdHangKhachHang;
            View.InHaiMat = bangGiaIn.InHaiMat;
            View.SoTheToiDa = bangGiaIn.SoTheToiDa;
            View.DaySoLuong = bangGiaIn.DaySoLuong;
            View.DayGiaThe = bangGiaIn.DayGia;
            View.VatLieuInBaoGom = bangGiaIn.VatLieuInBaoGom;
            View.KhoToChay = bangGiaIn.KhoToChay;
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
            BangGiaTheNhua bGiaDThiep = new BangGiaTheNhua();
            bGiaDThiep.ID = View.ID; 
            bGiaDThiep.Ten= View.Ten;
            bGiaDThiep.MoTa = View.MoTa;
            bGiaDThiep.NoiDungBangGia = View.NoiDungBangGia;
            bGiaDThiep.IdHangKhachHang = View.IdHangKhachHang;
            bGiaDThiep.InHaiMat = View.InHaiMat;
            bGiaDThiep.SoTheToiDa = View.SoTheToiDa;
            bGiaDThiep.DaySoLuong = View.DaySoLuong;
            bGiaDThiep.DayGia = View.DayGiaThe;
            bGiaDThiep.KhoToChay = View.KhoToChay;
            bGiaDThiep.VatLieuInBaoGom = View.VatLieuInBaoGom;     
            bGiaDThiep.ThuTu = View.ThuTu;
            bGiaDThiep.KhongCon = View.KhongCon;

            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = BangGiaTheNhua.Sua(bGiaDThiep);
                    break;
                case FormStateS.New:
                    thongDiep = BangGiaTheNhua.Them(bGiaDThiep);
                    break;

            }

        }
    }
}
