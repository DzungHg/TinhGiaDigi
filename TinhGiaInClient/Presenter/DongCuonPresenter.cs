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
        public DongCuonPresenter(IViewThanhPham view, MucThanhPham mucThPham)
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
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:
                    KhoiTaoBanDau();
                    break;

            }
        }
        public void KhoiTaoBanDau()
        {
            View.SoLuong = 10;
            View.DonViTinh = "Cuốn";
            
        }


        public int TyLeMarkUp(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).LoiNhuanChenhLech;
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
            decimal result = 0;

           
            var dongCuon = DongCuon.DocTheoId(View.IdThanhPhamChon);
            var tyLeMK = this.TyLeMarkUp(View.IdHangKhachHang);
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
        public MucThanhPham LayMucThanhPham()
        {
            var mucThPham = new MucThanhPham();
            mucThPham.IdBaiIn = View.IdBaiIn;
            mucThPham.TenThanhPham = View.TenThanhPhamChon;
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
