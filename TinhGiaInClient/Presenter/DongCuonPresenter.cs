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

    public class DongCuonPresenter : IThanhPhamPresenter
    {
        IViewThanhPham View = null;
        MucThanhPham MucDongCuon = null;
        public DongCuonPresenter(IViewThanhPham view, MucThanhPham mucThPham)
        {
            View = view;
            this.MucDongCuon = mucThPham;

            View.ID = this.MucDongCuon.ID;
            View.IdBaiIn = this.MucDongCuon.IdBaiIn;
            View.IdHangKhachHang = this.MucDongCuon.IdHangKhachHang;
            View.IdThanhPhamChon = this.MucDongCuon.IdThanhPhamChon;
            View.LoaiThPh = this.MucDongCuon.LoaiThanhPham;
            View.SoLuong = this.MucDongCuon.SoLuong;
            View.DonViTinh = "cuốn";


        }
        public void KhoiTaoBanDau()
        {
            ;
            
        }


        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        


        public List<DongCuon> ThanhPhamS()
        {
            return DongCuon.DocTatCa();
        }

        public decimal ThanhTien_ThPh()
        {
            if (View.IdThanhPhamChon <= 0)
                return 0;

            decimal result = 0;

           
            var dongCuon = DongCuon.DocTheoId(View.IdThanhPhamChon);
            var tyLeMK = this.TyLeMarkUp();
            var giaDongCuon = new GiaDongCuon(View.SoLuong, tyLeMK, View.DonViTinh, dongCuon);

            result = giaDongCuon.ThanhTienSales();

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
            if (this.MucDongCuon != null)
            {
                this.MucDongCuon.IdBaiIn = View.IdBaiIn;
                this.MucDongCuon.TenThanhPham = View.TenThanhPhamChon;
                this.MucDongCuon.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucDongCuon.IdHangKhachHang = View.IdHangKhachHang;
                this.MucDongCuon.LoaiThanhPham = View.LoaiThPh;
                this.MucDongCuon.SoLuong = View.SoLuong;
                this.MucDongCuon.DonViTinh = View.DonViTinh;
                this.MucDongCuon.ThanhTien = View.ThanhTien;
            }
        }
        public MucThanhPham LayMucThanhPham()
        {
            CapNhatMucThanhPham();
           
            
            return this.MucDongCuon;
        }
    }
}
