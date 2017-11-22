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
    
    public class QuanLyDongCuonPresenter
    {
        IViewQuanLyDongCuon View;
        public QuanLyDongCuonPresenter(IViewQuanLyDongCuon view)
        { 
            View = view;
            
        }
        public List<DongCuon> ThanhPhamS()
        {
            return DongCuon.DocTatCa();
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

            var canPhu = DongCuon.DocTheoId(View.ID);
            View.ID = canPhu.ID;
            View.Ten = canPhu.Ten;
            View.BHR = canPhu.BHR;
            View.DonViTinh = canPhu.DonViTinh;
            View.TocDo = canPhu.TocDoCuonGio;
            View.ThoiGianChuanBi = canPhu.ThoiGianChuanBi;
            View.PhiNguyenVatLieu = canPhu.PhiNgVLCuon;
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
            DongCuon dongCuon = new DongCuon();
            dongCuon.ID = View.ID; 
            dongCuon.Ten = View.Ten;
            dongCuon.BHR = View.BHR;
            dongCuon.DonViTinh = View.DonViTinh;
            dongCuon.TocDoCuonGio = View.TocDo;
            dongCuon.PhiNgVLCuon = View.PhiNguyenVatLieu;
            dongCuon.ThoiGianChuanBi = View.ThoiGianChuanBi;
            dongCuon.DaySoLuong = View.DaySoLuongCoBan;
            dongCuon.DayLoiNhuan = View.DayLoiNhuanCoBan;
            dongCuon.DaySoLuongNiemYet = View.DaySoLuongNiemYet;                 
            dongCuon.ThuTu = View.ThuTu;
          
            switch (View.TinhTrangForm)
            {
                case FormStateS.Edit:
                    thongDiep = DongCuon.Sua(dongCuon);
                    break;
                /*case TinhGiaInClient.FormStateS.New:
                    thongDiep = BangGiaInNhanh.Them(canPhu);
                    break;
                    */
            }

        }
    }
}
