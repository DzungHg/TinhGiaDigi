using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaCanGap: IGiaThanhPham
    {
        /// <summary>
        ///Chưa cần thiết để thừa kế MucThanhPham để chỉnh sửa nâng cấp sau này
        /// </summary>
        public int SoLuong { get; set; }
        public int TyLeMarkUp { get; set; }
        public string DonViTinh { get; set; }
        public CanGap CanGap { get; set; }
        public GiaCanGap(int soLuong,  int tyLeMarkUp, string donViTinh, CanGap canGap)
        {
            this.SoLuong = soLuong;
            this.CanGap = canGap;
            this.TyLeMarkUp = tyLeMarkUp;
            this.DonViTinh = donViTinh;
        }
        
        public decimal ChiPhi(int soLuong)
        {
            decimal result = 0;
            float soGioChay = (float)soLuong / this.CanGap.TocDoConGio;
            decimal phiChay = this.CanGap.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.CanGap.BHR * (decimal)this.CanGap.ThoiGianChuanBi;
            result = phiChay + phiChuanBi;
            return result;
        }
        
        public decimal ThanhTienCoBan(int soLuong)
        {  // số trang a4, Giá đại lý         
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.CanGap.DaySoLuong, this.CanGap.DayLoiNhuan, this.SoLuong) / 100;

            result = this.ChiPhi(soLuong) + (this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan) / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTienSales()
        {
            decimal result = 0;            
            decimal tyLeMK = (decimal)this.TyLeMarkUp / 100;
            result = this.ThanhTienCoBan(this.SoLuong) + this.ThanhTienCoBan(this.SoLuong) * tyLeMK / (1 - tyLeMK);
            return result;
        }
        public decimal GiaTBTrenDonVi()
        {            
            if (this.SoLuong <= 0)
                return 0;

            return this.ThanhTienSales() / this.SoLuong;
        }
    }
   
}
