using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaEpKim
    {
        public int SoLuong { get; set; }
        public float KhoEpRong { get; set; }
        public float KhoEpCao { get; set; }
        public int TyLeMarkUp { get; set; }
        public EpKim EpKim { get; set; }
        public NhuEpKim NhuEp { get; set; }
        public GiaEpKim(int soLuong, float khoEpRong, float khoEpCao, 
            EpKim epKim, NhuEpKim nhuEp, int mucLoiNhuan)
        {
            this.SoLuong = soLuong;
            this.KhoEpRong = khoEpRong;
            this.KhoEpCao = khoEpCao;
            this.EpKim = epKim;
            this.NhuEp = nhuEp;
            this.TyLeMarkUp = mucLoiNhuan;
        }
        public decimal ChiPhiChay ()
        {
            decimal result = 0;
            float soGioChay = (float)this.SoLuong / this.EpKim.TocDoConGio;
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
        private decimal TongChiPhi()
        {
            return this.ChiPhiChay() + this.ChiPhiKhuon() + this.ChiPhiPhiNhuEp();
        }
        public decimal ThanhTienCoBan()
        {  //Giá đại lý         
          
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.EpKim.DaySoLuong, this.EpKim.DayLoiNhuan, this.SoLuong) / 100;
            
            result = this.TongChiPhi() + this.TongChiPhi() * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTien_EpKim()
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
            return this.ThanhTien_EpKim() / this.SoLuong;
        }
    }
}
