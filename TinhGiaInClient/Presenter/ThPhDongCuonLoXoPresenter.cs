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

    public class ThPhDongCuonLoXoPresenter : IThanhPhamPresenter
    {
        IViewThPhDongCuonLoXo View = null;
        MucDongCuonLoXo MucDongCuon = null;
        public ThPhDongCuonLoXoPresenter(IViewThPhDongCuonLoXo view, MucDongCuonLoXo mucThPham)
        {
            View = view;
            View = view;
            this.MucDongCuon = mucThPham;
            //Cập nhật form
            View.ID = mucThPham.ID;
            View.IdBaiIn = mucThPham.IdBaiIn;
            View.IdHangKhachHang = mucThPham.IdHangKhachHang;
            View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
            View.LoaiThPh = mucThPham.LoaiThanhPham;
            View.KieuDongCuon = mucThPham.KieuDongCuon;
            View.SoLuong = mucThPham.SoLuong;
            View.DonViTinh = mucThPham.DonViTinh;
            View.IdLoXoDongCuonChon = mucThPham.IdLoXoChon;
            View.GayCao = mucThPham.GayCao;
            View.GayDay = mucThPham.GayDay;



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

        public List<DongCuonLoXo> ThanhPhamS()
        {
            return DongCuonLoXo.DocTatCa();
        }
       
        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;            
           
            var dongCuon = DongCuonLoXo.DocTheoId(View.IdThanhPhamChon);
            
            if (View.IdLoXoDongCuonChon <= 0)
                return 0;//Không thể không có nhũ
            var loXo = LoXoDongCuon.DocTheoId(View.IdLoXoDongCuonChon);
            
            
            var giaDongCuon = new GiaDongCuonLoXo(View.SoLuong, View.GayCao,
                            dongCuon, loXo, this.TyLeMarkUp());

            result = giaDongCuon.ThanhTienSales();

            return result;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        //Thêm ngoài Implement
        public List<LoXoDongCuon> LoXoDongCuonS()
       {
           return LoXoDongCuon.DocTatCa();
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
                this.MucDongCuon.KieuDongCuon = View.KieuDongCuon;
                this.MucDongCuon.SoLuong = View.SoLuong;
                this.MucDongCuon.DonViTinh = View.DonViTinh;
                this.MucDongCuon.ThanhTien = View.ThanhTien;
                this.MucDongCuon.GayCao = View.GayCao;
                this.MucDongCuon.GayDay = View.GayDay;
                this.MucDongCuon.IdLoXoChon = View.IdLoXoDongCuonChon;
            }
        }
        public MucDongCuonLoXo LayMucThanhPham()
        {
            CapNhatMucThanhPham();
           
            return this.MucDongCuon;
        }
    }
}
