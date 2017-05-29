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
       
        public ThPhGiaCongNgoaiPresenter(IViewThPhGiaCongNgoai view, MucThPhGiaCongNgoai mucThPham = null)
        {
            View = view;

            if (mucThPham != null)
            {
                View.ID = mucThPham.ID;
                View.IdBaiIn = mucThPham.IdBaiIn;
                View.TenThanhPhamChon = mucThPham.TenThanhPham;
                View.LoaiThPh = mucThPham.LoaiThanhPham;
                View.SoLuong = mucThPham.SoLuong;
                View.DonViTinh = mucThPham.DonViTinh;
                View.PhiGiaCong = mucThPham.PhiGiaCong;
                View.PhiVanChuyen = mucThPham.PhiVanChuyen;                
                View.TenNhaCungCap = mucThPham.TenNhaCungCap;
                View.TyLeMarkUp = mucThPham.TyLeMarkUp;
                View.ThanhTien = mucThPham.ThanhTien;
            }

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
        public MucThPhGiaCongNgoai DocMucThPhGiaCongNgoai()
        {
            var mucThPham = new MucThPhGiaCongNgoai();
            mucThPham.IdBaiIn = View.IdBaiIn;
            mucThPham.TenThanhPham = View.TenThanhPhamChon;
            mucThPham.LoaiThanhPham = View.LoaiThPh;
            mucThPham.SoLuong = View.SoLuong;
            mucThPham.DonViTinh = View.DonViTinh;
            mucThPham.TenNhaCungCap = View.TenNhaCungCap;
            mucThPham.PhiGiaCong = View.PhiGiaCong;
            mucThPham.PhiVanChuyen = View.PhiVanChuyen;
            mucThPham.TyLeMarkUp = View.TyLeMarkUp;
            
            mucThPham.ThanhTien = this.ThanhTien();
            if (View.TinhTrangForm == FormStateS.Edit)
               mucThPham.ID = View.ID;

            return mucThPham;
        }
     
    }
}
