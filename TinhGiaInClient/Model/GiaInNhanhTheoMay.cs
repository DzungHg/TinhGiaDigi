using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Model
{
    public class GiaInNhanhTheoMay: IGiaIn
    {
        private DuLieuTinhGiaInNhanhTheoMay DuLieuDeTinh { get; set; }
        private int SoTrangA4 {get;set;}
        private int TyLeLoiNhuanSales { get; set; }
        public GiaInNhanhTheoMay(DuLieuTinhGiaInNhanhTheoMay duLieuDeTinh, int soTrangA4,
            int tyLeLoiNhuanSales)
        {
            this.DuLieuDeTinh = duLieuDeTinh;
            this.SoTrangA4 = soTrangA4;
            this.TyLeLoiNhuanSales = tyLeLoiNhuanSales;
        }
        public decimal ChiPhi(int soLuong)
        {
            if (soLuong <= 0)
                return 0;
            
            //--qua
            decimal ketQua = 0;
            decimal phiSetup = (decimal)DuLieuDeTinh.ThoiGianSanSang * DuLieuDeTinh.BHR; //Lấy giờ
            var phiGiaySanSang = this.DuLieuDeTinh.PhiPhePhamSanSang;
            var thoiGianChay = (decimal)soLuong / this.DuLieuDeTinh.TocDo;
            var phiDuLieuBienDoi = (decimal)DuLieuDeTinh.ThoiGianDuLieuBienDoi 
                                * this.DuLieuDeTinh.BHR;
            var phiChay = thoiGianChay * this.DuLieuDeTinh.BHR;
            //Phí mực theo click của từng tờ in            
            ketQua = phiSetup + phiGiaySanSang + phiDuLieuBienDoi
                    + phiChay + this.DuLieuDeTinh.ClickTrangA4;

            return ketQua;
        }

        public decimal ThanhTienCoBan(int soLuong)
        {
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.DuLieuDeTinh.DaySoLuong,
                this.DuLieuDeTinh.DayLoiNhuan, soLuong) / 100;

            result = this.ChiPhi(soLuong) + this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
            return result;
        }

        public decimal ThanhTienSales()
        {
            decimal result = 0;
            decimal tyLeMK = (decimal)this.TyLeLoiNhuanSales / 100;
            result = this.ThanhTienCoBan(this.SoTrangA4) + this.ThanhTienCoBan(this.SoTrangA4) * tyLeMK / (1 - tyLeMK);
            return Math.Round(result);
        }

        public decimal GiaTBTrenDonVi()
        {
            decimal kq = 0;
            if (this.SoTrangA4  > 0)
                kq = this.ThanhTienSales() / this.SoTrangA4;
            return kq;
        }
    }
}
