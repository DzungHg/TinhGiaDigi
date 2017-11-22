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
    
    public class QuanLyDongCuonMPPresenter
    {
        IViewQuanLyDongCuonMP View;
        public QuanLyDongCuonMPPresenter(IViewQuanLyDongCuonMP view)
        { 
            View = view;
            
        }
        public List<DongCuonMoPhang> ThanhPhamS()
        {
            return DongCuonMoPhang.DocTatCa();
        }
    
        public void TrinhBayThemMoi()
        {
            View.ID = 0;
            View.Ten = "";
         
            View.DonViTinh = "mặt";
            View.TocDo = 0;
            View.PhiKeoToDoi = 0;
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

            var dongCuon = DongCuonMoPhang.DocTheoId(View.ID);
            View.ID = dongCuon.ID;
            View.Ten = dongCuon.Ten;
            View.BHR = dongCuon.BHR;
            View.DonViTinh = dongCuon.DonViTinh;
            View.TocDo = dongCuon.TocDoToDoiGio;
            View.ThoiGianChuanBi = dongCuon.ThoiGianChuanBi;
            View.PhiKeoToDoi = dongCuon.PhiKeoToDoi;
            View.DaySoLuongCoBan = dongCuon.DaySoLuong;
            View.DayLoiNhuanCoBan = dongCuon.DayLoiNhuan;
            View.DaySoLuongNiemYet = dongCuon.DaySoLuongNiemYet;
            View.ThuTu = dongCuon.ThuTu;
          
         
            
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
            DongCuonMoPhang dongCuon = new DongCuonMoPhang();
            dongCuon.ID = View.ID; 
            dongCuon.Ten = View.Ten;
            dongCuon.BHR = View.BHR;
            dongCuon.DonViTinh = View.DonViTinh;
            dongCuon.TocDoToDoiGio = View.TocDo;
            dongCuon.PhiKeoToDoi = View.PhiKeoToDoi;
            dongCuon.ThoiGianChuanBi = View.ThoiGianChuanBi;
            dongCuon.DaySoLuong = View.DaySoLuongCoBan;
            dongCuon.DayLoiNhuan = View.DayLoiNhuanCoBan;
            dongCuon.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            dongCuon.ThuTu = View.ThuTu;
          
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = DongCuonMoPhang.Sua(dongCuon);
                    break;
                /*case TinhGiaInClient.FormStateS.New:
                    thongDiep = BangGiaInNhanh.Them(canPhu);
                    break;
                    */
            }

        }
    }
}
