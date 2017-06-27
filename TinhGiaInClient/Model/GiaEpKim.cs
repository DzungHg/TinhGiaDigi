using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaEpKim: IGiaThanhPham
    {
        public int SoLuong { get; set; }
        public float KhoEpRong { get; set; }
        public float KhoEpCao { get; set; }
        public int TyLeMarkUp { get; set; }
        public EpKim EpKim { get; set; }
        public NhuEpKim NhuEp { get; set; }
        public GiaEpKim(int soLuong, float khoEpRong, float khoEpCao, 
            EpKim epKim, NhuEpKim nhuEp, int tyLeMarkUpSales)
        {
            this.SoLuong = soLuong;
            this.KhoEpRong = khoEpRong;
            this.KhoEpCao = khoEpCao;
            this.EpKim = epKim;
            this.NhuEp = nhuEp;
            this.TyLeMarkUp = tyLeMarkUpSales;
        }
        public decimal ChiPhiChay (int soLuong)
        {
            decimal result = 0;
            float soGioChay = (float)soLuong / this.EpKim.TocDoConGio;
            decimal phiChay = this.EpKim.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.EpKim.BHR * (decimal)this.EpKim.ThoiGianChuanBi;
            decimal phiNgVLChuanBi = this.EpKim.PhiNVLChuanBi;
            result = phiChay + phiChuanBi + phiNgVLChuanBi;
            return result;
        }
        public decimal ChiPhiKhuon ()
        {
            decimal result = 0;
            result = this.EpKim.GiaKhuonCm2 * (decimal)(this.KhoEpRong * this.KhoEpCao);
            return result;

        }
        public decimal ChiPhiPhiNhuEp()
        {
            decimal result = 0;
            if (this.NhuEp != null)
            {
                float dienTichEp = this.KhoEpRong * this.KhoEpCao;
                decimal phiNVL = (decimal)dienTichEp * this.NhuEp.GiaMuaCm2;
                result = phiNVL * this.SoLuong;
            }

            return result;
        }
        public decimal ChiPhi(int soLuong)
        {
            return this.ChiPhiChay(soLuong) + this.ChiPhiKhuon() + this.ChiPhiPhiNhuEp();
        }
        public decimal ThanhTienCoBan(int soLuong)
        {  //Giá đại lý         
          
            decimal result = 0;
            //Lấy lợi nhuận cơ bản tính
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.EpKim.DaySoLuong, this.EpKim.DayLoiNhuan, this.SoLuong) / 100;

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
