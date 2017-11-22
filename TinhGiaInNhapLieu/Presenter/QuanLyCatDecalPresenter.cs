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
    
    public class QuanLyCatDecalPresenter
    {
        IViewQuanLyCatDecal View;
        public QuanLyCatDecalPresenter(IViewQuanLyCatDecal view)
        { 
            View = view;
            
        }
        public List<CatDecal> ThanhPhamS()
        {
            return CatDecal.DocTatCa();
        }
    
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
         
            View.DonViTinh = "con";
            View.TocDo = 100;
            View.PhiDao1000Met = 1000;
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

            var catDecal = CatDecal.DocTheoId(View.ID);
            View.ID = catDecal.ID;
            View.Ten = catDecal.Ten;
            View.BHR = catDecal.BHR;
            View.DonViTinh = catDecal.DonViTinh;
            View.TocDo = catDecal.TocDoMetGio;
            View.ThoiGianChuanBi = catDecal.ThoiGianChuanBi;
            View.PhiDao1000Met = catDecal.PhiDao1000Met;
            View.DaySoLuongCoBan = catDecal.DaySoLuong;
            View.DayLoiNhuanCoBan = catDecal.DayLoiNhuan;
            View.DaySoLuongNiemYet = catDecal.DaySoLuongNiemYet;
            View.ThuTu = catDecal.ThuTu;
            View.GhiChu = catDecal.GhiChu;
          
         
            
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
            CatDecal catDecal = new CatDecal();
            catDecal.ID = View.ID; 
            catDecal.Ten = View.Ten;
            catDecal.BHR = View.BHR;
            catDecal.DonViTinh = View.DonViTinh;
            catDecal.TocDoMetGio = View.TocDo;
            catDecal.PhiDao1000Met = View.PhiDao1000Met;
            catDecal.ThoiGianChuanBi = View.ThoiGianChuanBi;
            catDecal.DaySoLuong = View.DaySoLuongCoBan;
            catDecal.DayLoiNhuan = View.DayLoiNhuanCoBan;
            catDecal.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            catDecal.ThuTu = View.ThuTu;
            catDecal.GhiChu = View.GhiChu;
          
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = CatDecal.Sua(catDecal);
                    break;
                /*case TinhGiaInClient.FormStateS.New:
                    thongDiep = BangGiaInNhanh.Them(canPhu);
                    break;
                    */
            }

        }
    }
}
