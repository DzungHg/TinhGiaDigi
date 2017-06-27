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

    public class ThPhCatDecalPresenter : IThanhPhamPresenter
    {
        IViewThPhCatDecal View = null;
        MucThPhCatDecal MucCatDecal = null;
        public ThPhCatDecalPresenter(IViewThPhCatDecal view, MucThPhCatDecal mucThPham)
        {
            View = view;
            View = view;
            this.MucCatDecal = mucThPham;
            //Cập nhật form
            View.ID = mucThPham.ID;
            View.IdBaiIn = mucThPham.IdBaiIn;
            View.IdHangKhachHang = mucThPham.IdHangKhachHang;
            View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
            View.LoaiThPh = mucThPham.LoaiThanhPham;
          
            View.SoLuong = mucThPham.SoLuong;
            View.DonViTinh = mucThPham.DonViTinh;
            View.ConRong = mucThPham.ConRong;
            View.ConCao = mucThPham.ConCao;

        }
        public void KhoiTaoBanDau()
        {
          //implement
        }

        
        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }

        public List<CatDecal> ThanhPhamS()
        {
            return CatDecal.DocTatCa();
        }
       
        public decimal ThanhTien_ThPh()
        {
            decimal kq = 0;            
           
            var catDecal = CatDecal.DocTheoId(View.IdThanhPhamChon);                     
                  
            var giaDongCuon = new GiaCatDecal(View.SoLuong, catDecal, View.ConRong, 
                                View.ConCao, this.TyLeMarkUp());

            kq = giaDongCuon.ThanhTienSales();

            return kq;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        
     
        private void CapNhatMucThanhPham()
        {
            if (this.MucCatDecal != null)
            {
                this.MucCatDecal.IdBaiIn = View.IdBaiIn;
                this.MucCatDecal.TenThanhPham = View.TenThanhPhamChon;
                this.MucCatDecal.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucCatDecal.IdHangKhachHang = View.IdHangKhachHang;
                this.MucCatDecal.LoaiThanhPham = View.LoaiThPh;
                this.MucCatDecal.ConRong = View.ConRong;
                this.MucCatDecal.ConCao = View.ConCao;
                this.MucCatDecal.SoLuong = View.SoLuong;
                this.MucCatDecal.DonViTinh = View.DonViTinh;
                this.MucCatDecal.ThanhTien = View.ThanhTien;
            }
        }
        public MucThanhPham LayMucThanhPham()
        {
            CapNhatMucThanhPham();
            return this.MucCatDecal;
        }
    }
}
