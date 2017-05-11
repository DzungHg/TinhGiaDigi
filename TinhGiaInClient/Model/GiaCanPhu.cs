using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaCanPhu: MucThanhPham
    {
        //Bổ sung ngoài mục thành phẩm
        
        public int KieuCanPhu { get; set; }       
        public CanPhu CanPhu { get; set; }
        public GiaCanPhu(int idBaiIn, int loaiThanhPham, string tenCanPhu, int idHangKH,
                string thongTinHangKH, int tyLeMarkUp, string thongTinTyLeMarkUp, int soLuong,
                string donViTinh, string thongTinBoSung, string tenCanPhuMoRong,
                int kieuCanPhu, CanPhu canPhu)
        {
            this.IdBaiIn = idBaiIn;
            this.LoaiThPh = loaiThanhPham;
            this.TenThPh = tenCanPhu;
            this.IdHangKhachHang = idHangKH;
            this.TenThPhMoRong = tenCanPhuMoRong;            
            this.ThongTinHangKH = thongTinHangKH;
            this.TyLeMarkUp = tyLeMarkUp;
            this.ThongTinTyLeMarkUp = thongTinTyLeMarkUp;
            this.SoLuong = soLuong;
            this.DonViTinh = donViTinh;
            this.KieuCanPhu = kieuCanPhu;
            this.ThongTinBoSung = thongTinBoSung;
            this.CanPhu = canPhu;
        }
        public decimal ChiPhi()
        {            
            decimal result = 0;
            float soGioChay = (this.SoLuong * 0.21f) / this.CanPhu.TocDoMetGio;
            decimal phiChay = this.CanPhu.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.CanPhu.BHR * (decimal)this.CanPhu.ThoiGianChuanBi;
            decimal phiNguyenVatLieu = this.CanPhu.PhiNgVLM2 * (decimal)(this.SoLuong * 0.30f * 0.24f);
            result = phiChay + phiChuanBi + phiNguyenVatLieu;
            return result;
        }
        
        public decimal ThanhTienCoBan()
        {  // số trang a4, Giá đại lý         
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.CanPhu.DaySoLuong, this.CanPhu.DayLoiNhuan, this.SoLuong) / 100;
            
            result = this.ChiPhi() + (this.ChiPhi() * (decimal)tyLeLNCoBan) / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTien_CanPhu()
        {
            decimal result = 0;            
            decimal tyLeMK = (decimal)this.TyLeMarkUp / 100;
            result = this.ThanhTienCoBan() + this.ThanhTienCoBan() * tyLeMK / (1 - tyLeMK);
            return result;
        }
        public decimal GiaTBTrenDonVitinh()
        {            
            if (this.SoLuong <= 0)
                return 0;

            return this.ThanhTien_CanPhu() / this.SoLuong;
        }
    }
   
}
