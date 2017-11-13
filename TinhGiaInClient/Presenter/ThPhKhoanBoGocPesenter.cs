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

    public class ThPhKhoanBoGocPresenter : IThanhPhamPresenter
    {
        IViewThPhKhoanBoGoc View = null;
        MucThPhKhoanBoGoc MucKhoanBoGoc = null;
        public ThPhKhoanBoGocPresenter(IViewThPhKhoanBoGoc view, MucThPhKhoanBoGoc mucThPham)
        {
          
            View = view;
            this.MucKhoanBoGoc = mucThPham;
            //Cập nhật form
            View.ID = mucThPham.ID;
            View.IdBaiIn = mucThPham.IdBaiIn;
            View.IdHangKhachHang = mucThPham.IdHangKhachHang;
            View.IdThanhPhamChon = mucThPham.IdThanhPhamChon;
            View.LoaiThPh = mucThPham.LoaiThanhPham;
            View.KichThuocBlock = mucThPham.KichThuocBlock;
            View.SoLuong = mucThPham.SoLuong;
           
            View.DonViTinh = mucThPham.DonViTinh;
           
           
            View.SoLanKhoanBoTrenMoiBlock = mucThPham.SoLanKhoanBoTrenMoiBlock;
          ;
            
            //Nếu mới
            switch (View.TinhTrangForm)
            {
                case FormStateS.New:
                    LamLai();
                    break;
                case FormStateS.Edit:
                    
                    break;
            }
           
            


        }
        public void KhoiTaoBanDau()
        {
          //implement
        }
        public void LamLai()
        {
            View.SoLuong = MucKhoanBoGoc.SoLuongSanPham;
            View.KichThuocBlock = MucKhoanBoGoc.KichThuocBlock;
            View.SoLuong = MucKhoanBoGoc.SoLuongSanPham;
            View.SoLanKhoanBoTrenMoiBlock = 1;
            View.KichThuocBlock = string.Format("{0} x {1}cm", 
                this.MucKhoanBoGoc.KhoSanPhamRong, this.MucKhoanBoGoc.KhoSanPhamCao);
           
        }
        public int TongSoLanKhoanBoGoc()
        {
            return View.SoLanKhoanBoTrenMoiBlock * View.SoLuong;
        }
        
        public int TyLeMarkUp()
        {
            return HangKhachHang.LayTheoId(View.IdHangKhachHang).LoiNhuanChenhLech;
        }
        public string ThongTinHangKH(int idHangKH)
        {
            return HangKhachHang.LayTheoId(idHangKH).Ten;
        }

        public List<MayKhoanBoGoc> ThanhPhamS()
        {
            return MayKhoanBoGoc.DocTatCa();
        }
        public string TieuDeThPh ()
        {
            var kq = "Chưa chọn";
            if (View.IdThanhPhamChon > 0)
                kq = MayKhoanBoGoc.DocTheoId(View.IdThanhPhamChon).TieuDe;

            return kq;
        }
        public decimal ThanhTien_ThPh()
        {
            decimal kq = 0;

           var mayMoc = MayKhoanBoGoc.DocTheoId(View.IdThanhPhamChon);
            
                                   
            var giaBoi = new GiaKhoanBoGoc(View.SoLuong, mayMoc,
                            View.SoLanKhoanBoTrenMoiBlock, this.TyLeMarkUp());

            kq = giaBoi.ThanhTienSales();
           
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
            if (this.MucKhoanBoGoc != null)
            {
                this.MucKhoanBoGoc.IdBaiIn = View.IdBaiIn;
                this.MucKhoanBoGoc.TenThanhPham = string.Format( "{0}\\{1}", View.TieuDe, View.TenThanhPhamChon);
                this.MucKhoanBoGoc.IdThanhPhamChon = View.IdThanhPhamChon;
                this.MucKhoanBoGoc.IdHangKhachHang = View.IdHangKhachHang;
                this.MucKhoanBoGoc.LoaiThanhPham = View.LoaiThPh;
                this.MucKhoanBoGoc.KichThuocBlock = View.KichThuocBlock;
                this.MucKhoanBoGoc.SoLuong = View.SoLuong;
               
                this.MucKhoanBoGoc.DonViTinh = View.DonViTinh;
                this.MucKhoanBoGoc.ThanhTien = View.ThanhTien;
                this.MucKhoanBoGoc.SoLanKhoanBoTrenMoiBlock = View.SoLanKhoanBoTrenMoiBlock;
                
             
            }
        }
        public MucThPhKhoanBoGoc LayMucThanhPham()
        {
            CapNhatMucThanhPham();
           
            return this.MucKhoanBoGoc;
        }
    }
}
