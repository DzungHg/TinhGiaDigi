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
    
    public class QuanLyEpKimPresenter
    {
        IViewQuanLyEpKim View;
        public QuanLyEpKimPresenter(IViewQuanLyEpKim view)
        { 
            View = view;
            
        }
        public List<EpKim> ThanhPhamS()
        {
            return EpKim.DocTatCa();
        }
    
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
         
            View.DonViTinh = "mặt";
            View.TocDo = 0;
            View.BHR = 0;
            View.PhiNguyenVatLieuChuanBi = 0;
            View.GiaKhuonCM2 = 1;
            View.LaNhuViTinh = false;
            View.DaySoLuongCoBan = ";";
            View.DayLoiNhuanCoBan = ";";
            View.DaySoLuongNiemYet = ";";

            View.ThuTu = 100;
       
          
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var epKim = EpKim.DocTheoId(View.ID);
            View.ID = epKim.ID;
            View.Ten = epKim.Ten;
            View.BHR = epKim.BHR;
            View.DonViTinh = epKim.DonViTinh;
            View.TocDo = epKim.TocDoConGio;
            View.ThoiGianChuanBi = epKim.ThoiGianChuanBi;
            View.PhiNguyenVatLieuChuanBi = epKim.PhiNVLChuanBi;
            View.GiaKhuonCM2 = epKim.GiaKhuonCm2;
            View.LaNhuViTinh = epKim.LaNhuViTinh;
            View.DaySoLuongCoBan = epKim.DaySoLuong;
            View.DayLoiNhuanCoBan = epKim.DayLoiNhuan;
            View.DaySoLuongNiemYet = epKim.DaySoLuongNiemYet;
            View.ThuTu = epKim.ThuTu;
          
         
            
        }
        public bool KiemTraDaySoLuongVaLoiNhuan()
        {
            var kq = true;
            if (View.DaySoLuongCoBan.Split(';').Count() !=
                View.DayLoiNhuanCoBan.Split(';').Count())
                kq = false;
            return kq;
        }
     
        public void Luu(ref string thongDiep)
        {
            EpKim epKim = new EpKim();
            epKim.ID = View.ID; 
            epKim.Ten = View.Ten;
            epKim.BHR = View.BHR;
            epKim.DonViTinh = View.DonViTinh;
            epKim.GiaKhuonCm2 = View.GiaKhuonCM2;
            epKim.LaNhuViTinh = View.LaNhuViTinh;
            epKim.TocDoConGio = View.TocDo;
            epKim.PhiNVLChuanBi = View.PhiNguyenVatLieuChuanBi;
            epKim.ThoiGianChuanBi = View.ThoiGianChuanBi;
            epKim.DaySoLuong = View.DaySoLuongCoBan;
            epKim.DayLoiNhuan = View.DayLoiNhuanCoBan;
            epKim.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            epKim.ThuTu = View.ThuTu;
          
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = EpKim.Sua(epKim);
                    break;
                case FormStateS.New:
                    thongDiep = EpKim.Them(epKim);
                    break;
                    
            }

        }
    }
}
