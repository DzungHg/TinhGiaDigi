using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaCanPhu: MucThanhPham, IGiaThanhPham
    {
        //Bổ sung ngoài mục thành phẩm
        
        public int KieuCanPhu { get; set; }
        
        public CanPhu CanPhu { get; set; }
        public GiaCanPhu(int idBaiIn, LoaiThanhPhamS loaiThanhPham, string tenCanPhu, int idHangKH,
                int tyLeMarkUp, int soLuong, int idThanhPhamChon,
                string donViTinh, string thongTinBoSung, 
                int kieuCanPhu, CanPhu canPhu)
        {
            this.IdBaiIn = idBaiIn;
            this.LoaiThanhPham = loaiThanhPham;
            this.IdThanhPhamChon = idThanhPhamChon;
            this.IdHangKhachHang = idHangKH;
            this.TenThanhPham = tenCanPhu;                 
            this.TyLeMarkUp = tyLeMarkUp;
      
            this.SoLuong = soLuong;
            this.DonViTinh = donViTinh;
            this.KieuCanPhu = kieuCanPhu;          
            this.CanPhu = canPhu;
        }
        public GiaCanPhu(int soLuong, string donViTinh, int tyLeMarkUpSales, CanPhu canPhu)
        {//Dùng cho từng mục tiêu 
           
            this.TyLeMarkUp = tyLeMarkUpSales;
            this.CanPhu = canPhu;
            this.SoLuong = soLuong;
            this.DonViTinh = donViTinh;
            
        }
        public decimal ChiPhi(int soLuong)
        {            
            decimal result = 0;
            float soGioChay = (soLuong * 0.21f) / this.CanPhu.TocDoMetGio;
            decimal phiChay = this.CanPhu.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.CanPhu.BHR * (decimal)this.CanPhu.ThoiGianChuanBi;
            decimal phiNguyenVatLieu = this.CanPhu.PhiNgVLM2 * (decimal)(soLuong * 0.30f * 0.24f);
            result = phiChay + phiChuanBi + phiNguyenVatLieu;
            return result;
        }
        
        public decimal ThanhTienCoBan(int soLuong)
        {  // số trang a4, Giá đại lý         
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.CanPhu.DaySoLuong, this.CanPhu.DayLoiNhuan, soLuong) / 100;

            result = this.ChiPhi(soLuong) + (this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan) / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTienSales()
        {
            decimal result = 0;
            var tyLeMK = (decimal)this.TyLeMarkUp / 100;
            result = this.ThanhTienCoBan(this.SoLuong) + this.ThanhTienCoBan(this.SoLuong) * tyLeMK / (1 - tyLeMK);
            return Math.Round(result);
        }
        public decimal GiaTBTrenDonVi()
        {            
            if (this.SoLuong <= 0)
                return 0;

            return this.ThanhTienSales() / this.SoLuong;
        }


       
    }
   
}
