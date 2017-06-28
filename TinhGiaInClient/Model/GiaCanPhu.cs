using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class GiaCanPhu: IGiaThanhPham
    {
        //Bổ sung ngoài mục thành phẩm
        
        public int SoMatCanTheoTo { get; set; }
        public float ToChayRong { get; set; }
        public float ToChayDai { get; set; }
        public int SoLuong { get; set; }
        public int TyLeMarkUpSales { get; set; }
        public CanPhu CanPhu { get; set; }
        public GiaCanPhu(int soLuong, float toChayRong, float toChayDai,
            int soMatCanTrenTo, int tyLeMarkUpSales, CanPhu canPhu)
        {           
            this.SoLuong = soLuong;
            this.ToChayRong = toChayRong;
            this.ToChayDai = toChayDai;
            this.SoMatCanTheoTo = soMatCanTrenTo;
            this.TyLeMarkUpSales = tyLeMarkUpSales;      
            this.CanPhu = canPhu;
        }
        
        public decimal ChiPhi(int soLuong)
        {            
            decimal result = 0;
            //Tính tổng chiều dài tờ chạy đổi cm ra mét * số mặt * số lương
            float tongChieuDaiToChay = (this.ToChayDai / 100) * this.SoMatCanTheoTo
                                        * soLuong;
            //Số giờ chạy và phí
            float soGioChay = tongChieuDaiToChay / this.CanPhu.TocDoMetGio;
            decimal phiChay = this.CanPhu.BHR * (decimal)soGioChay;
            //Phí chuẩn bị
            decimal phiChuanBi = this.CanPhu.BHR * (decimal)this.CanPhu.ThoiGianChuanBi;
            //Tổng diện tích tờ chạy số mặt, diện tích m2, số mặt
            float tongDienTichToChay = (this.ToChayRong / 100) * (this.ToChayDai / 100) * this.SoMatCanTheoTo
                                        * soLuong;
            //Phí nguyên liệu màng/UV
            decimal phiNguyenVatLieu = this.CanPhu.PhiNgVLM2 * (decimal)tongDienTichToChay;
            //Tổng phí
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
            var tyLeMK = (decimal)this.TyLeMarkUpSales / 100;
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
