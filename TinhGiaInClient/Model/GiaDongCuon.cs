using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaDongCuon: IGiaThanhPham
    {
        /// <summary>
        ///Chưa cần thiết để thừa kế MucThanhPham để chỉnh sửa nâng cấp sau này
        /// </summary>
        public int SoLuong { get; set; }
      
        public int TyLeMarkUp { get; set; }
        public string DonViTinh { get; set; }
        public DongCuon DongCuon { get; set; }
        public GiaDongCuon(int soLuong, int tyLeMarkUpSales, string donViTinh, DongCuon dongCuon)
        {
            this.SoLuong = soLuong;
            this.DongCuon = dongCuon;
            this.TyLeMarkUp = tyLeMarkUpSales;
            this.DonViTinh = donViTinh;
        }
        public decimal ChiPhi(int soLuong)
        {
            
            decimal result = 0;
            float soGioChay = (float)this.SoLuong / this.DongCuon.TocDoCuonGio;
            decimal phiChay = this.DongCuon.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.DongCuon.BHR * (decimal)this.DongCuon.ThoiGianChuanBi;
            decimal phiNguyenVatLieu = this.DongCuon.PhiNgVLCuon * this.SoLuong;
            result = phiChay + phiChuanBi + phiNguyenVatLieu;
            return result;
        }
        
        public decimal ThanhTienCoBan(int soLuong)
        {  // số trang a4, Giá đại lý         
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.DongCuon.DaySoLuong, this.DongCuon.DayLoiNhuan, this.SoLuong) / 100;
            if (tyLeLNCoBan >= 1f) //chêm vô sợ chia 0
                tyLeLNCoBan = 0.9f;

            result = this.ChiPhi(soLuong) + this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTienSales()
        {
            decimal result = 0;            
            decimal tyLeMK = (decimal)this.TyLeMarkUp / 100;
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
