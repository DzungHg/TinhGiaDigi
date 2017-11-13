using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.View;
using TinhGiaInClient.Model;
using TinhGiaInLogic;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Presenter
{

    public class ThPhBePresenter : IThanhPhamPresenter
    {
        IViewThPhBe View = null;
        MucThPhBe MucBe = null;
        public ThPhBePresenter(IViewThPhBe view, MucThPhBe mucThPham)
        {
            View = view;
            this.MucBe = mucThPham;

            View.ID = this.MucBe.ID;
            View.IdBaiIn = this.MucBe.IdBaiIn;
            View.IdHangKhachHang = this.MucBe.IdHangKhachHang;
            View.IdThanhPhamChon = this.MucBe.IdThanhPhamChon;
            View.LoaiThPh = this.MucBe.LoaiThanhPham;
            View.SoLuong = this.MucBe.SoLuong;
            View.DonViTinh = this.MucBe.DonViTinh;
            View.IdKhuonBeChon = this.MucBe.IdKhuonBeChon;
            
         
            View.KhoToChayRong = this.MucBe.KhoToChayRong;
            View.KhoToChayDai = this.MucBe.KhoToChayDai;
            View.KhoBeCao = this.MucBe.KhoBeCao;
            View.KhoBeRong = this.MucBe.KhoBeRong;
            View.SoLuongToChay = this.MucBe.SoLuongToChay;
            View.SoLuong = this.MucBe.SoLuong;
            //Nếu mới
            if (View.TinhTrangForm == FormStateS.New)
                LamLai();
        }
        public void KhoiTaoBanDau()
        {
           
        }

        public void LamLai()
        {
            View.KhoBeCao = this.MucBe.KhoToChayDai;
            View.KhoBeRong = this.MucBe.KhoToChayRong;                       
            View.SoLuong = this.MucBe.SoLuongToChay;
            View.DonViTinh = "Tấm";
        }
        
        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }

        public List<MayBe> ThanhPhamS()
        {
            return MayBe.DocTatCa();
        }
        public List<KhuonBe> KhuonBeS()
        {
            return KhuonBe.DocTatCa();
        }
        public decimal ThanhTien_ThPh()
        {
            decimal kq = 0;            
           
            var mayBe = MayBe.DocTheoId(View.IdThanhPhamChon);
            
            if (View.IdKhuonBeChon <= 0)
                return 0;//Không thể không có khuôn
            var khuonBe = KhuonBe.DocTheoId(View.IdKhuonBeChon);           
            //Lưu ý số lượng tính giá
            var giaBe = new GiaBe(View.SoLuong, mayBe, khuonBe, this.TyLeMarkUp());    
       
            kq = giaBe.ThanhTienSales();

            return kq;
        }

        public decimal GiaTB_ThPh()
        {
            if (View.SoLuong <= 0)
                return 0;
            return ThanhTien_ThPh() / View.SoLuong; //Số lượng Để tính giá
        }
        //Thêm ngoài Implement
       
       
        private void CapNhatMucThanhPham()
        {
            if (this.MucBe != null)
            {
                this.MucBe.ID = View.ID;
                this.MucBe.IdBaiIn = View.IdBaiIn;
                this.MucBe.TenThanhPham = string.Format("Bế/{0}", View.TenThanhPhamChon);
                this.MucBe.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucBe.IdHangKhachHang = View.IdHangKhachHang;
                this.MucBe.LoaiThanhPham = View.LoaiThPh;
                this.MucBe.SoLuong = View.SoLuong;
                this.MucBe.KhoBeCao = View.KhoBeCao;
                this.MucBe.KhoBeRong = View.KhoBeRong;
                this.MucBe.KhoToChayRong = View.KhoToChayRong;
                this.MucBe.KhoToChayDai = View.KhoToChayDai;
                this.MucBe.SoLuongToChay = View.SoLuongToChay;
                this.MucBe.IdKhuonBeChon = View.IdKhuonBeChon;
                this.MucBe.DonViTinh = View.DonViTinh;
                this.MucBe.ThanhTien = View.ThanhTien;
            }
        }
        public MucThPhBe LayMucThanhPham()
        {
            CapNhatMucThanhPham();

            return this.MucBe;
        }
    }
}
