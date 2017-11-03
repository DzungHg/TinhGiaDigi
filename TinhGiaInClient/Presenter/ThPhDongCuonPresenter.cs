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

    public class ThPhDongCuonPresenter : IThanhPhamPresenter
    {
        IViewThPhDongCuon View = null;
        MucDongCuon MucDongCuonK = null;
        public ThPhDongCuonPresenter(IViewThPhDongCuon view, MucDongCuon mucThPham)
        {
            View = view;
            this.MucDongCuonK = mucThPham;
            View.TieuDe = mucThPham.TieuDe;
            View.KieuDongCuon = mucThPham.KieuDongCuon;
            View.ID = this.MucDongCuonK.ID;
            View.IdBaiIn = this.MucDongCuonK.IdBaiIn;
            View.IdHangKhachHang = this.MucDongCuonK.IdHangKhachHang;
            View.IdThanhPhamChon = this.MucDongCuonK.IdThanhPhamChon;
            View.LoaiThPh = this.MucDongCuonK.LoaiThanhPham;
            View.SoLuong = this.MucDongCuonK.SoLuong;
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
        
        public string TieuDeDongCuon ()
        {
            var kq = "";
            if (View.IdThanhPhamChon > 0)
                kq = DongCuon.DocTheoId(View.IdThanhPhamChon).TieuDe;

            return kq;
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
            if (this.MucDongCuonK != null)
            {
                this.MucDongCuonK.IdBaiIn = View.IdBaiIn;
                this.MucDongCuonK.GayCao = View.GayCao;
                this.MucDongCuonK.GayDay = View.GayDay;
                this.MucDongCuonK.TieuDe = View.TieuDe;
                this.MucDongCuonK.TenThanhPham = string.Format("{0}//{1}", View.TieuDe,
                    View.TenThanhPhamChon);
                this.MucDongCuonK.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucDongCuonK.IdHangKhachHang = View.IdHangKhachHang;
                this.MucDongCuonK.LoaiThanhPham = View.LoaiThPh;
                this.MucDongCuonK.SoLuong = View.SoLuong;
                this.MucDongCuonK.DonViTinh = View.DonViTinh;
                this.MucDongCuonK.ThanhTien = View.ThanhTien;
            }
        }
        public MucDongCuon LayMucThanhPham()
        {
            CapNhatMucThanhPham();
                      
            return this.MucDongCuonK;
        }
    }
}
