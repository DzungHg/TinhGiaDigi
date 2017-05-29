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

    public class CanPhuPresenter : IThanhPhamPresenter
    {
        IViewThPhCanPhu View = null;
        public CanPhuPresenter(IViewThPhCanPhu view, MucThanhPham mucThPham = null)
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
            View.SoLuong = 50;
            View.DonViTinh = "Mặt";
            View.KieuCanPhu = 1;
            
        }

        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }
        //Dành cho display
        public List<CanPhu> ThanhPhamS()
        {
            return CanPhu.DocTatCa();
        }

        public decimal ThanhTien_ThPh()
        {
            decimal result = 0;
            if (View.IdBaiIn <= 0 || View.SoLuong <= 0)
                return result;

            
            var canPhu = CanPhu.DocTheoId(View.IdThanhPhamChon);

            var tyLeMK = this.TyLeMarkUp();

            var giaCanPhu = new GiaCanPhu(View.SoLuong, View.DonViTinh,
                TyLeMarkUp(), canPhu);

            result = giaCanPhu.ThanhTienSales();

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
            mucThPham.TenThanhPham = View.TenCanPhuMoRong;
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
