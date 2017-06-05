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

    public class ThPhGiaCongNgoaiPresenter
    {
        IViewThPhGiaCongNgoai View = null;
        MucThPhGiaCongNgoai MucGiaCong = null;
        public ThPhGiaCongNgoaiPresenter(IViewThPhGiaCongNgoai view, MucThPhGiaCongNgoai mucThPham )
        {
            View = view;
            MucGiaCong = mucThPham;
            //Cập nhật dữ liệu
            View.ID = MucGiaCong.ID;
            View.IdBaiIn = MucGiaCong.IdBaiIn;
            View.TenThanhPhamChon = MucGiaCong.TenThanhPham;
            View.LoaiThPh = MucGiaCong.LoaiThanhPham;
            View.SoLuong = MucGiaCong.SoLuong;
            View.DonViTinh = MucGiaCong.DonViTinh;
            View.PhiGiaCong = MucGiaCong.PhiGiaCong;
            View.PhiVanChuyen = MucGiaCong.PhiVanChuyen;
            View.TenNhaCungCap = MucGiaCong.TenNhaCungCap;
            View.TyLeMarkUp = MucGiaCong.TyLeMarkUp;
            View.ThanhTien = MucGiaCong.ThanhTien;
          

        }
        public void KhoiTaoBanDau()
        {
            View.TenThanhPhamChon = "Thành phẩm";
            View.SoLuong = 10;
            View.DonViTinh = "???";
            View.PhiGiaCong = 1;
            View.PhiVanChuyen = 0;           
            
        }


      


        public decimal ThanhTien()
        {
            decimal result = 0;

            decimal tyLeMK = (decimal)View.TyLeMarkUp / 100 ;

            decimal tongPhi = (View.PhiGiaCong * View.SoLuong) + 
                                View.PhiVanChuyen;
            result = tongPhi + tongPhi * tyLeMK / (1 - tyLeMK);

            return result;
        }
        private void CapNhatMucThanhPham()
        {
            if (this.MucGiaCong != null)
            {
                MucGiaCong.IdBaiIn = View.IdBaiIn;
                MucGiaCong.TenThanhPham = View.TenThanhPhamChon;
                MucGiaCong.LoaiThanhPham = View.LoaiThPh;
                MucGiaCong.SoLuong = View.SoLuong;
                MucGiaCong.DonViTinh = View.DonViTinh;
                MucGiaCong.TenNhaCungCap = View.TenNhaCungCap;
                MucGiaCong.PhiGiaCong = View.PhiGiaCong;
                MucGiaCong.PhiVanChuyen = View.PhiVanChuyen;
                MucGiaCong.TyLeMarkUp = View.TyLeMarkUp;
                MucGiaCong.ThanhTien = this.ThanhTien();
            }
        }
        public MucThPhGiaCongNgoai DocMucThPhGiaCongNgoai()
        {
            CapNhatMucThanhPham();

            return MucGiaCong;
        }
     
    }
}
