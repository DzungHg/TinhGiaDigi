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
                //View.ID = mucThPham.ID;
                View.IdBaiIn = mucThPham.IdBaiIn;
                View.Ten.TenThanhPham = mucThPham.TenThanhPham;
                View.SoLuong = mucThPham.SoLuong;
                View.DonViTinh = mucThPham.DonViTinh;
                View.PhiVanChuyen = mucThPham.PhiGiaCong;
                View.PhiGiaCong = mucThPham.PhiGiaCong;
                View.TyLeMarkUp = mucThPham.TyLeMarkUp;
                View.ThanhTien = mucThPham.ThanhTien;
            }

        }
        public void KhoiTaoBanDau()
        {
            View.TenThanhPham = "";
            View.SoLuong = 10;
            View.DonViTinh = "???";
            View.PhiGiaCong = 1;
            View.PhiVanChuyen = 0;
            
            
        }


      


        public decimal ThanhTien()
        {
            decimal result = 0;

            decimal tyLeMK = (decimal)(View.TyLeMarkUp / 100) ;

            decimal tongPhi = View.PhiGiaCong + View.PhiVanChuyen;
            result = tongPhi + tongPhi * tyLeMK / (1 - tyLeMK);

            return result;
        }
        public MucThPhGiaCongNgoai DocMucThPhGiaCongNgoai()
        {
            var mucThPham = new MucThPhGiaCongNgoai();
            mucThPham.TenThanhPham = View.TenThanhPhamChon;
            mucThPham.SoLuong = View.SoLuong;
            mucThPham.DonViTinh = View.DonViTinh;
            mucThPham.PhiVanChuyen = View.PhiGiaCong;
            mucThPham.PhiGiaCong = View.PhiGiaCong;
            mucThPham.TyLeMarkUp = View.TyLeMarkUp;
            
            mucThPham.ThanhTien = this.ThanhTien();
            //if (View.TinhTrangForm == FormStateS.Edit)
            //    mucThPham.ID = View.ID;

            return mucThPham;
        }
     
    }
}
