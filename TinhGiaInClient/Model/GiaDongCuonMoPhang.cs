using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaDongCuonMoPhang: IGiaThanhPham
    {
        public int SoLuong { get; set; }
        public int SoToDoi { get; set; }
        
        public int TyLeMarkUp { get; set; }
        public DongCuonMoPhang DongCuonMP { get; set; }
        public ToLotMoPhang ToLotMP { get; set; }
        public GiaDongCuonMoPhang(int soLuong, int soToDoi, 
            DongCuonMoPhang mayDongMoPhang, ToLotMoPhang toLot, int tyLeMarkUpSales)
        {
            this.SoLuong = soLuong;
            this.SoToDoi = soToDoi;
          
            this.DongCuonMP = mayDongMoPhang;
            this.ToLotMP = toLot;
            this.TyLeMarkUp = tyLeMarkUpSales;
        }
        public decimal ChiPhiChay (int soLuong)
        {
            decimal result = 0;
            ///tốc độ tính theo số tờ đôi /giờ
            int soToDoi = this.SoToDoi * this.SoLuong;
            float soGioChay = (float)soToDoi / this.DongCuonMP.TocDoToDoiGio;
            decimal phiChay = this.DongCuonMP.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.DongCuonMP.BHR * (decimal)this.DongCuonMP.ThoiGianChuanBi;
            ///Phí nguyên liệu tờ = phí keo cho mỗi tờ đôi
            decimal phiKeo = soToDoi * this.DongCuonMP.PhiKeoToDoi;
            ///Kết quả = phí chạy + phí chuẩn bị + phí keo
            result = phiChay + phiChuanBi + phiKeo;
            return result;
        }
       
        private decimal ChiPhiToLot()
        {
            decimal kq = 0;
            if (this.ToLotMP != null)
            {
                int soToDoi = this.SoToDoi * this.SoLuong;
                ///Mỗi tờ đôi có 1 tờ lót
                kq = (decimal)this.ToLotMP.GiaMuaTo * soToDoi;
                
            }

            return kq;
        }
        public decimal ChiPhi(int soLuong)
        {
            return this.ChiPhiChay(soLuong)  + this.ChiPhiToLot();
        }
        public decimal ThanhTienCoBan(int soLuong)
        { ///Tính giá thấp nhất là đại lý
          ///theo mức lợi nhuận cơ bản ghi trong database
          
          
            decimal result = 0;
            //Lấy tỉ lệ lợi nhuận cơ bản từ database 
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.DongCuonMP.DaySoLuong, this.DongCuonMP.DayLoiNhuan, this.SoLuong) / 100;
            
            result = this.ChiPhi(soLuong) + this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTienSales()
        {///thành tiên trên cơ sở Giá cơ bản + maarrkup theo hạng KH nào đó
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
