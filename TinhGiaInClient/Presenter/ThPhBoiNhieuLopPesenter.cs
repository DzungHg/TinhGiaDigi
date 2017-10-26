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

    public class ThPhBoiNhieuLopPresenter : IThanhPhamPresenter
    {
        IViewThPhBoiNhieuLop View = null;
        MucThPhBoiNhieuLop MucBoiNhieuLop = null;
        public ThPhBoiNhieuLopPresenter(IViewThPhBoiNhieuLop view, MucThPhBoiNhieuLop mucThPham)
        {
            View = view;
            View = view;
            this.MucBoiNhieuLop = mucThPham;
            //Cập nhật form
            View.ID = mucThPham.ID;
            View.IdBaiIn = mucThPham.IdBaiIn;
            View.IdHangKhachHang = mucThPham.IdHangKhachHang;
            View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
            View.LoaiThPh = mucThPham.LoaiThanhPham;
            View.ToBoiRong = mucThPham.ToBoiRong;
            View.ToBoiCao = mucThPham.ToBoiCao;
            View.SoLuong = mucThPham.SoLuong;
            View.DonViTinh = mucThPham.DonViTinh;
            View.IdGiayBoiGiuaChon = mucThPham.IdGiayBoiGiuaChon;
            View.SoToLotGiua = mucThPham.SoToLotGiua;
            //Nếu mới
            if (View.TinhTrangForm == FormStateS.New)
                LamLai();


        }
        public void KhoiTaoBanDau()
        {
          //implement
        }
        public void LamLai()
        {
            View.SoLuong = MucBoiNhieuLop.SoLuongToChay;
            View.ToBoiRong = MucBoiNhieuLop.ToBoiRong;
            View.ToBoiCao = MucBoiNhieuLop.ToBoiCao;
            View.SoToLotGiua = 0;
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
            
            if (View.IdGiayBoiGiuaChon <= 0)
                return 0;//Không thể không có nhũ
            var toBoiBia = ToBoiBiaCung.DocTheoId(View.IdGiayBoiGiuaChon);
            
           
            var giaDongCuon = new GiaBoiBiaCung(View.SoLuong, boiBiaCung, 
                            View.ToBoiRong, View.ToBoiCao,toBoiBia,
                            View.SoToLotGiua, this.TyLeMarkUp());

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
       
        private void CapNhatMucThanhPham()
        {
            if (this.MucBoiNhieuLop != null)
            {
                this.MucBoiNhieuLop.IdBaiIn = View.IdBaiIn;
                this.MucBoiNhieuLop.TenThanhPham = View.TenThanhPhamChon;
                this.MucBoiNhieuLop.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucBoiNhieuLop.IdHangKhachHang = View.IdHangKhachHang;
                this.MucBoiNhieuLop.LoaiThanhPham = View.LoaiThPh;
                this.MucBoiNhieuLop.ToBoiRong = View.ToBoiRong;
                this.MucBoiNhieuLop.ToBoiCao = View.ToBoiCao;
                this.MucBoiNhieuLop.SoLuong = View.SoLuong;
                this.MucBoiNhieuLop.DonViTinh = View.DonViTinh;
                this.MucBoiNhieuLop.ThanhTien = View.ThanhTien;
                this.MucBoiNhieuLop.SoToLotGiua = View.SoToLotGiua;

                this.MucBoiNhieuLop.IdGiayBoiGiuaChon = View.IdGiayBoiGiuaChon;
            }
        }
        public MucThPhBoiNhieuLop LayMucThanhPham()
        {
            CapNhatMucThanhPham();
           
            return this.MucBoiNhieuLop;
        }
    }
}
