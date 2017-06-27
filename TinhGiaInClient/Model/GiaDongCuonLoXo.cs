using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaDongCuonLoXo: IGiaThanhPham
    {
        public int SoLuong { get; set; }
        public float GayRong { get; set; }
       
        public int TyLeMarkUp { get; set; }
        public DongCuonLoXo DongCuonLX { get; set; }
        public LoXoDongCuon LoXo { get; set; }
        public GiaDongCuonLoXo(int soLuong, float gayRong, 
            DongCuonLoXo mayDongLoXo, LoXoDongCuon loXo, int tyLeMarkUpSales)
        {
            this.SoLuong = soLuong;
            this.GayRong = gayRong;
          
            this.DongCuonLX = mayDongLoXo;
            this.LoXo = loXo;
            this.TyLeMarkUp = tyLeMarkUpSales;
        }
        public decimal ChiPhiChay (int soLuong)
        {
            decimal result = 0;
            float soGioChay = (float)soLuong / this.DongCuonLX.TocDoCuonGio;
            decimal phiChay = this.DongCuonLX.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.DongCuonLX.BHR * (decimal)this.DongCuonLX.ThoiGianChuanBi;

            result = phiChay + phiChuanBi;
            return result;
        }
       
        public decimal ChiPhiPhiLoXo()
        {
            decimal result = 0;
            if (this.LoXo != null)
            {
                //Gáy rộng theo lò xo
                decimal phiNVL = (decimal)this.GayRong/100 * this.LoXo.GiaMuaTheoMet;
                result = phiNVL * this.SoLuong;
            }

            return result;
        }
        public decimal ChiPhi(int soLuong)
        {
            return this.ChiPhiChay(soLuong)  + this.ChiPhiPhiLoXo();
        }
        public decimal ThanhTienCoBan(int soLuong)
        {  //Giá đại lý         
          
            decimal result = 0;
            //Lấy tỉ lệ lợi nhuận cơ bản
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.DongCuonLX.DaySoLuong, this.DongCuonLX.DayLoiNhuan, this.SoLuong) / 100;

            result = this.ChiPhi(soLuong) + this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
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
