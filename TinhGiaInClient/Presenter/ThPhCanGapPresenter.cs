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

    public class ThPhCanGapPresenter : IThanhPhamPresenter
    {
        IViewGiaCanGap View = null;
        MucThPhCanGap MucCanGap = null;
        public ThPhCanGapPresenter(IViewGiaCanGap view, MucThPhCanGap mucThPham)
        {
            this.MucCanGap = mucThPham;

            View = view;


            View.ID = this.MucCanGap.ID;
            View.IdBaiIn = this.MucCanGap.IdBaiIn;
            View.IdHangKhachHang = this.MucCanGap.IdHangKhachHang;
            View.IdThanhPhamChon = this.MucCanGap.IdThanhPhamChon;
            View.LoaiThPh = this.MucCanGap.LoaiThanhPham;
            View.SoLuong = this.MucCanGap.SoLuong;
            View.DonViTinh = "con";
            View.SoDuongCan = this.MucCanGap.SoDuongCan;

            
           
            

        }
        public void KhoiTaoBanDau()
        {

          
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
        private void CapNhatMucThanhPham()
        {
            if (this.MucCanGap != null)
            {
                //Chỉ cần cập nhật lại
                this.MucCanGap.IdBaiIn = View.IdBaiIn;
                this.MucCanGap.TenThanhPham = View.TenThanhPhamChon;
                this.MucCanGap.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucCanGap.IdHangKhachHang = View.IdHangKhachHang;
                this.MucCanGap.LoaiThanhPham = View.LoaiThPh;
                this.MucCanGap.SoLuong = View.SoLuong;
                this.MucCanGap.SoDuongCan = View.SoDuongCan;
                this.MucCanGap.DonViTinh = View.DonViTinh;
                this.MucCanGap.ThanhTien = View.ThanhTien;
            }
        }
        public MucThPhCanGap LayMucThanhPham()
        {
            //cập nhật
            CapNhatMucThanhPham();
            return this.MucCanGap;
        }
    }
}
