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
    
    public class QuanLyBoiBiaCungPresenter
    {
        IViewQuanLyBoiBiaCung View;
        public QuanLyBoiBiaCungPresenter(IViewQuanLyBoiBiaCung view)
        { 
            View = view;
            
        }
        public List<BoiBiaCung> ThanhPhamS()
        {
            return BoiBiaCung.DocTatCa();
        }
    
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
         
            View.DonViTinh = "tấm";
            View.TocDo = 100;
            View.PhiKeoMetVuong = 1000;
            View.BHR = 0;
                  
            View.DaySoLuongCoBan = ";";
            View.DayLoiNhuanCoBan = ";";
            View.DaySoLuongNiemYet = ";";
            View.ThuTu = 100;
       
          
        }
        public void TrinhBayChiTietMayIn()
        {
            if (View.ID <= 0)
                return;

            var boiBiaCung = BoiBiaCung.DocTheoId(View.ID);
            View.ID = boiBiaCung.ID;
            View.Ten = boiBiaCung.Ten;
            View.BHR = boiBiaCung.BHR;
            View.DonViTinh = boiBiaCung.DonViTinh;
            View.TocDo = boiBiaCung.TocDoTamGio;
            View.ThoiGianChuanBi = boiBiaCung.ThoiGianChuanBi;
            View.PhiKeoMetVuong = boiBiaCung.PhiKeoMetVuong;
            View.DaySoLuongCoBan = boiBiaCung.DaySoLuong;
            View.DayLoiNhuanCoBan = boiBiaCung.DayLoiNhuan;
            View.DaySoLuongNiemYet = boiBiaCung.DaySoLuongNiemYet;
            View.ThuTu = boiBiaCung.ThuTu;
            View.DienGiai = boiBiaCung.DienGiai;
          
         
            
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
            var boiBiaCung = new BoiBiaCung();
            boiBiaCung.ID = View.ID; 
            boiBiaCung.Ten = View.Ten;
            boiBiaCung.BHR = View.BHR;
            boiBiaCung.DonViTinh = View.DonViTinh;
            boiBiaCung.TocDoTamGio = View.TocDo;
            boiBiaCung.PhiKeoMetVuong = View.PhiKeoMetVuong;
            boiBiaCung.ThoiGianChuanBi = View.ThoiGianChuanBi;
            boiBiaCung.DaySoLuong = View.DaySoLuongCoBan;
            boiBiaCung.DayLoiNhuan = View.DayLoiNhuanCoBan;
            boiBiaCung.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            boiBiaCung.ThuTu = View.ThuTu;
            boiBiaCung.DienGiai = View.DienGiai;
          
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = BoiBiaCung.Sua(boiBiaCung);
                    break;
                case FormStateS.New:
                    thongDiep = BoiBiaCung.Them(boiBiaCung);
                    break;
                
            }

        }
    }
}
