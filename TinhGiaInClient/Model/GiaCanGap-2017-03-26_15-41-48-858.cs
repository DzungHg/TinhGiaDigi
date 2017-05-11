using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaCanGap
    {
        /// <summary>
        ///Chưa cần thiết để thừa kế MucThanhPham để chỉnh sửa nâng cấp sau này
        /// </summary>
        public int SoLuong { get; set; }
        public int TyLeMarkUp { get; set; }
      
        public CanGap CanGap { get; set; }
        public GiaCanGap(int soLuong, CanGap canGap, int tyLeMarkUp)
        {
            this.SoLuong = soLuong;
            this.CanGap = canGap;
            this.TyLeMarkUp = tyLeMarkUp;
        }
        public decimal ChiPhi()
        {
            decimal result = 0;
            float soGioChay = this.SoLuong / this.CanGap.TocDoConGio;
            decimal phiChay = this.CanGap.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.CanGap.BHR * (decimal)this.CanGap.ThoiGianChuanBi;
            result = phiChay + phiChuanBi;
            return result;
        }
        
        public decimal ThanhTienCoBan()
        {  // số trang a4, Giá đại lý         
            decimal result = 0;
            float tyLeLN = (float)TinhToanThanhPham.MucLoiNhuan(this.CanGap.DaySoLuong, this.CanGap.DayLoiNhuan, this.SoLuong) / 100;
            decimal chiPhiCanGap = ChiPhi();
            result = chiPhiCanGap + (chiPhiCanGap *(decimal)tyLeLN) / (decimal)(1 - tyLeLN);
            return result;
        }
        public decimal ThanhTien_CanGap()
        {
            decimal result = 0;            
            decimal tyLeMK = (decimal)this.TyLeMarkUp / 100;
            result = this.ThanhTienCoBan() + this.ThanhTienCoBan() * tyLeMK / (1 - tyLeMK);
            return result;
        }
        public decimal GiaTBTrenDonViTinh()
        {            
            if (this.SoLuong <= 0)
                return 0;

            return this.ThanhTien_CanGap() / this.SoLuong;
        }
    }
   
}
