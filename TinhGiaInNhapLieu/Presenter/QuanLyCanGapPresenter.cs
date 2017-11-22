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
    
    public class QuanLyCanGapPresenter
    {
        IViewQuanLyCanGap View;
        public QuanLyCanGapPresenter(IViewQuanLyCanGap view)
        { 
            View = view;
            
        }
        public List<CanGap> ThanhPhamS()
        {
            return CanGap.DocTatCa();
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

            var canGap = CanGap.DocTheoId(View.ID);
            View.ID = canGap.ID;
            View.Ten = canGap.Ten;
            View.BHR = canGap.BHR;
            View.DonViTinh = canGap.DonViTinh;
            View.TocDo = canGap.TocDoConGio;
            View.ThoiGianChuanBi = canGap.ThoiGianChuanBi;
            View.ThoiGianTangKhiThemMotDungCan = canGap.MotDuongCanTangThoiGianChuanBi; 
            View.DaySoLuongCoBan = canGap.DaySoLuong;
            View.DayLoiNhuanCoBan = canGap.DayLoiNhuan;
            View.DaySoLuongNiemYet = canGap.DaySoLuongNiemYet;
            View.ThuTu = canGap.ThuTu;
          
         
            
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
            CanGap canGap = new CanGap();
            canGap.ID = View.ID; 
            canGap.Ten = View.Ten;
            canGap.BHR = View.BHR;
            canGap.DonViTinh = View.DonViTinh;
            canGap.TocDoConGio = View.TocDo;
            canGap.MotDuongCanTangThoiGianChuanBi = View.ThoiGianTangKhiThemMotDungCan;
            canGap.ThoiGianChuanBi = View.ThoiGianChuanBi;
            canGap.DaySoLuong = View.DaySoLuongCoBan;
            canGap.DayLoiNhuan = View.DayLoiNhuanCoBan;
            canGap.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            canGap.ThuTu = View.ThuTu;
          
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = CanGap.Sua(canGap);
                    break;
                /*case TinhGiaInClient.FormStateS.New:
                    thongDiep = BangGiaInNhanh.Them(canPhu);
                    break;
                    */
            }

        }
    }
}
