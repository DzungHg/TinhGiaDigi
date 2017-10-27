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

    public class ThPhBoiBiaCungPresenter : IThanhPhamPresenter
    {
        IViewThPhBoiBiaCung View = null;
        MucThPhBoiBiaCung MucBoiBiaCung = null;
        public ThPhBoiBiaCungPresenter(IViewThPhBoiBiaCung view, MucThPhBoiBiaCung mucThPham)
        {
            View = view;
            View = view;
            this.MucBoiBiaCung = mucThPham;
            //Cập nhật form
            View.ID = mucThPham.ID;
            View.IdBaiIn = mucThPham.IdBaiIn;
            View.IdHangKhachHang = mucThPham.IdHangKhachHang;
            View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
            View.LoaiThPh = mucThPham.LoaiThanhPham;
            View.TamRong = mucThPham.TamRong;
            View.TamCao = mucThPham.TamCao;
            View.SoLuong = mucThPham.SoLuong;
            View.DonViTinh = mucThPham.DonViTinh;
            View.IdToBoiChon = mucThPham.IdToBoiChon;
            View.SoToBoiTrenTamBia = mucThPham.SoToBoiTrenTamBia;



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

        public List<BoiBiaCung> ThanhPhamS()
        {
            return BoiBiaCung.DocTatCa();
        }
       
        public decimal ThanhTien_ThPh()
        {
            decimal kq = 0;            
           
            var boiBiaCung = BoiBiaCung.DocTheoId(View.IdThanhPhamChon);
            
            if (View.IdToBoiChon <= 0)
                return 0;//Không thể không có nhũ
            var toBoiBia = ToBoiBiaCung.DocTheoId(View.IdToBoiChon);
            
           
            var giaDongCuon = new GiaBoiBiaCung(View.SoLuong, boiBiaCung, 
                            View.TamRong, View.TamCao,toBoiBia,
                            View.SoToBoiTrenTamBia, this.TyLeMarkUp());

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
        public List<ToBoiBiaCung> ToBoiBiaCungS()
       {
           return ToBoiBiaCung.DocTatCa();
       }
        private void CapNhatMucThanhPham()
        {
            if (this.MucBoiBiaCung != null)
            {
                this.MucBoiBiaCung.IdBaiIn = View.IdBaiIn;
                this.MucBoiBiaCung.TenThanhPham = string.Format("Bồi bìa cứng/{0}", View.TenThanhPhamChon);
                this.MucBoiBiaCung.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucBoiBiaCung.IdHangKhachHang = View.IdHangKhachHang;
                this.MucBoiBiaCung.LoaiThanhPham = View.LoaiThPh;
                this.MucBoiBiaCung.TamRong = View.TamRong;
                this.MucBoiBiaCung.TamCao = View.TamCao;
                this.MucBoiBiaCung.SoLuong = View.SoLuong;
                this.MucBoiBiaCung.DonViTinh = View.DonViTinh;
                this.MucBoiBiaCung.ThanhTien = View.ThanhTien;
                this.MucBoiBiaCung.SoToBoiTrenTamBia = View.SoToBoiTrenTamBia;

                this.MucBoiBiaCung.IdToBoiChon = View.IdToBoiChon;
            }
        }
        public MucThPhBoiBiaCung LayMucThanhPham()
        {
            CapNhatMucThanhPham();
           
            return this.MucBoiBiaCung;
        }
    }
}
