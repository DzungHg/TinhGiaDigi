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
    
    public class QuanLyCanPhuPresenter
    {
        IViewQuanLyCanPhu View;
        public QuanLyCanPhuPresenter(IViewQuanLyCanPhu view)
        { 
            View = view;
            
        }
        public List<CanPhu> ThanhPhamS()
        {
            return CanPhu.DocTatCa();
        }
    
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
         
            View.DonViTinh = "mặt";
            View.TocDo = 0;
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

            var canPhu = CanPhu.DocTheoId(View.ID);
            View.ID = canPhu.ID;
            View.Ten = canPhu.Ten;
            View.BHR = canPhu.BHR;
            View.DonViTinh = canPhu.DonViTinh;
            View.TocDo = canPhu.TocDoMetGio;
            View.ThoiGianChuanBi = canPhu.ThoiGianChuanBi;
            View.PhiNguyenVatLieuM2 = canPhu.PhiNgVLM2;
            View.DaySoLuongCoBan = canPhu.DaySoLuong;
            View.DayLoiNhuanCoBan = canPhu.DayLoiNhuan;
            View.DaySoLuongNiemYet = canPhu.DaySoLuongNiemYet;
            View.ThuTu = canPhu.ThuTu;
          
         
            
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
            CanPhu canPhu = new CanPhu();
            canPhu.ID = View.ID; 
            canPhu.Ten = View.Ten;
            canPhu.BHR = View.BHR;
            canPhu.DonViTinh = View.DonViTinh;                      
            canPhu.TocDoMetGio = View.TocDo;
            canPhu.PhiNgVLM2 = View.PhiNguyenVatLieuM2;
            canPhu.ThoiGianChuanBi = View.ThoiGianChuanBi;
            canPhu.DaySoLuong = View.DaySoLuongCoBan;
            canPhu.DayLoiNhuan = View.DayLoiNhuanCoBan;
            canPhu.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            canPhu.ThuTu = View.ThuTu;
          
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = CanPhu.Sua(canPhu);
                    break;
                /*case TinhGiaInClient.FormStateS.New:
                    thongDiep = BangGiaInNhanh.Them(canPhu);
                    break;
                    */
            }

        }
    }
}
