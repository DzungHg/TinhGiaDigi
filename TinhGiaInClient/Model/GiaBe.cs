using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaBe: IGiaThanhPham
    {
        public int SoLuong { get; set; }
       
        public int TyLeMarkUp { get; set; }
        public MayBe MayBe { get; set; }
        public KhuonBe KhuonBe { get; set; }
        public GiaBe(int soLuong,  
            MayBe mayBe, KhuonBe khuonBe, int tyLeMarkUpSales)
        {
            this.SoLuong = soLuong;
            
            this.MayBe = mayBe;
            this.KhuonBe = khuonBe;
            this.TyLeMarkUp = tyLeMarkUpSales;
        }
        public decimal ChiPhiChay (int soLuong)
        {//Nếu ép vi tính thì tính theo tốc độ mét, còn tính theo số con
            decimal kq = 0;
            float soGioChay = 0;
           
            soGioChay = (float)soLuong / this.MayBe.TocDoTamGio;
           
            decimal phiChay = this.MayBe.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.MayBe.BHR * (decimal)this.MayBe.ThoiGianChuanBi;
            decimal phiNgVLChuanBi = this.MayBe.PhiNVLChuanBi;
            kq = phiChay + phiChuanBi + phiNgVLChuanBi;
            return kq;
        }
        public decimal ChiPhiKhuon ()
        {//Nếu giá khuôn bế tính theo độ bền của khuôn bế
         //Nếu tính vậy phải biết khuôn còn tuổi thọ 
        //bao nhiêu lúc này quản lý hơi khó nên đành lấy luôn giá làm khuôn
            decimal result = 0;
            result = this.KhuonBe.GiaMua;
            return result;
        }
        
        public decimal ChiPhi(int soLuong)
        {
            return this.ChiPhiChay(soLuong) + this.ChiPhiKhuon();
        }
        public decimal ThanhTienCoBan(int soLuong)
        {  //Giá đại lý         
          
            decimal result = 0;
            //Lấy lợi nhuận cơ bản tính
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.MayBe.DaySoLuong, this.MayBe.DayLoiNhuan, this.SoLuong) / 100;

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
