using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInLogic;

namespace TinhGiaInClient.Presenter
{

    public class CanGapPresenter : IThanhPhamPresenter
    {
        IViewGiaCanGap View = null;
        //MucThanhPham mucThanhPham;
        public CanGapPresenter(IViewGiaCanGap view, MucThanhPham mucThPham)
        {
            View = view;

            if (mucThPham != null)
            {
                View.ID = mucThPham.ID;
                View.IdBaiIn = mucThPham.IdBaiIn;
                View.IdHangKhachHang = mucThPham.IdHangKhachHang;
                View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
                View.LoaiThPh = mucThPham.LoaiThanhPham;
                View.SoLuong = mucThPham.SoLuong;

            }
            /*
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:
                    this.mucThanhPham = new MucThanhPham();
                    break;

            } */
           
            

        }
        public void KhoiTaoBanDau()
        {

            View.SoDuongCan = 1;
            //View.SoLuong = 1;
          
        }


        
        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
      

        public List<CanGap> ThanhPhamS()
        {
            return CanGap.DocTatCa();
        }

        public decimal ThanhTien_ThPh()
        {
            if (View.IdThanhPhamChon <= 0)
                return 0;

            decimal result = 0;

            
            var canGap = CanGap.DocTheoId(View.IdThanhPhamChon);
            var tyLeMK = this.TyLeMarkUp();
            var giaCanGap = new GiaCanGap(View.SoLuong, View.SoDuongCan, tyLeMK, View.DonViTinh, canGap);
            result = giaCanGap.ThanhTienSales();
            return result;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        public MucThanhPham LayMucThanhPham()
        {
            var mucThPham = new MucThanhPham();
            mucThPham.IdBaiIn = View.IdBaiIn;
            mucThPham.TenThanhPham = View.TenThanhPhamChon;
            mucThPham.IdThanhPhamChon = View.IdThanhPhamChon;
            mucThPham.IdHangKhachHang = View.IdHangKhachHang;
            mucThPham.LoaiThanhPham = View.LoaiThPh;
            mucThPham.SoLuong = View.SoLuong;
            mucThPham.DonViTinh = View.DonViTinh;
            mucThPham.ThanhTien = View.ThanhTien;
            if (View.TinhTrangForm == FormStateS.Edit)
                mucThPham.ID = View.ID; //Cập nhật lại ID
            return mucThPham;
        }
    }
}
