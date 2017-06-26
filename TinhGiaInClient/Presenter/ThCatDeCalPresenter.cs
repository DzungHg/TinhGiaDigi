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
        MucThPhCatDecal MucDongCuon = null;
        public ThPhCatDecalPresenter(IViewThPhCatDecal view, MucThPhCatDecal mucThPham)
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
            decimal result = 0;            
           
            var catDecal = CatDecal.DocTheoId(View.IdThanhPhamChon);                     
            
            var mucLoiNhuan = TinhToan.GiaTriTheoKhoang(catDecal.DaySoLuong, catDecal.DayLoiNhuan, View.SoLuong);
            var giaDongCuon = new GiaCatDecal(View.SoLuong, catDecal, View.ConRong, 
                                View.ConCao, mucLoiNhuan);
            
            decimal tyLeMK = (decimal)this.TyLeMarkUp() / 100;           

            result = giaDongCuon.ThanhTienCoBan(View.SoLuong) +
                giaDongCuon.ThanhTienCoBan(View.SoLuong) * tyLeMK / (1 - tyLeMK);

            return result;
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
