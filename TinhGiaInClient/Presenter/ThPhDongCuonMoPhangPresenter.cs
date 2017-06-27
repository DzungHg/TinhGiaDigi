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

    public class ThPhDongCuonMoPhangPresenter : IThanhPhamPresenter
    {
        IViewThPhDongCuonMoPhang View = null;
        MucDongCuonMoPhang MucDongCuon = null;
        public ThPhDongCuonMoPhangPresenter(IViewThPhDongCuonMoPhang view, MucDongCuonMoPhang mucThPham)
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
            View.IdToLotChon = mucThPham.IdToLotChon;
            View.SoToDoi = mucThPham.SoToDoi;



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

        public List<DongCuonMoPhang> ThanhPhamS()
        {
            return DongCuonMoPhang.DocTatCa();
        }
       
        public decimal ThanhTien_ThPh()
        {
            decimal kq = 0;            
           
            var dongCuon = DongCuonMoPhang.DocTheoId(View.IdThanhPhamChon);
            
            if (View.IdToLotChon <= 0)
                return 0;//Không thể không có nhũ
            var loXo = ToLotMoPhang.DocTheoId(View.IdToLotChon);
            
           
            var giaDongCuon = new GiaDongCuonMoPhang(View.SoLuong, View.SoToDoi, 
                                dongCuon, loXo, this.TyLeMarkUp());

            kq = giaDongCuon.ThanhTienSales();

            return kq;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong;
        }
        //Thêm ngoài Implement
        public List<ToLotMoPhang> ToLotMoPhangS()
       {
           return ToLotMoPhang.DocTatCa();
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
                this.MucDongCuon.SoToDoi = View.SoToDoi;

                this.MucDongCuon.IdToLotChon = View.IdToLotChon;
            }
        }
        public MucDongCuonMoPhang LayMucThanhPham()
        {
            CapNhatMucThanhPham();
           
            return this.MucDongCuon;
        }
    }
}
