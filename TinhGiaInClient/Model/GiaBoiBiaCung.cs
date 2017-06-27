using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaBoiBiaCung: IGiaThanhPham
    {
        public int SoLuong { get; set; }
        public float TamRong { get; set; }
        public float TamCao { get; set; }
        public int TyLeMarkUp { get; set; }
        public BoiBiaCung MayBoiBiaCung { get; set; }
        public ToBoiBiaCung ToBoi { get; set; }
        public int SoToBoiMoiBia { get; set; }

        public GiaBoiBiaCung(int soLuongTam, BoiBiaCung boiBiaCung,
            float tamRong, float tamCao, ToBoiBiaCung toBoi, int soToBoiTrenMoiBia, int tyLeMarkUpSales)
        {
            this.SoLuong = soLuongTam;
            this.TamRong = tamRong;
            this.TamCao = tamCao;
            this.MayBoiBiaCung = boiBiaCung;
            this.ToBoi = toBoi;
            this.SoToBoiMoiBia = soToBoiTrenMoiBia;
            this.TyLeMarkUp = tyLeMarkUpSales;
        }
        public decimal ChiPhiChay (int soLuong)
        {
            decimal result = 0;
            ///tốc độ tính theo số tờ đôi /giờ
            
            float soGioChay = this.SoLuong / this.MayBoiBiaCung.TocDoTamGio;
            decimal phiChay = this.MayBoiBiaCung.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.MayBoiBiaCung.BHR * (decimal)this.MayBoiBiaCung.ThoiGianChuanBi;
            ///Phí nguyên liệu tờ = phí keo cho mỗi tờ đôi
            float tongDienTichTam = (this.TamRong /100 * this.TamCao /100) * SoLuong; //cm đổi ra mét vuông
            decimal phiKeo =  (decimal)tongDienTichTam * this.MayBoiBiaCung.PhiKeoMetVuong ;
            ///Kết quả = phí chạy + phí chuẩn bị + phí keo
            result = phiChay + phiChuanBi + phiKeo;
            return result;
        }
        private decimal ChiPhiToBoi()
        {
            decimal kq = 0;
            if (this.ToBoi != null)
            {
                var tongSoToBoi = this.SoLuong * this.SoToBoiMoiBia;
                ///Mỗi tờ đôi có 1 tờ lót
                kq = (decimal)this.ToBoi.GiaMuaTo * tongSoToBoi;

            }
          

            return kq;
        }
       
        public decimal ChiPhi(int soLuong)
        {
            return this.ChiPhiChay(soLuong) + ChiPhiToBoi();
        }
        public decimal ThanhTienCoBan(int soLuong)
        { ///Tính giá thấp nhất là đại lý
          ///theo mức lợi nhuận cơ bản ghi trong database
          
          
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.MayBoiBiaCung.DaySoLuong, this.MayBoiBiaCung.DayLoiNhuan, this.SoLuong) / 100;

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
