using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class GiaBoiNhieuLop: IGiaThanhPham
    {
        public int SoLuong { get; set; } //Số lượng tấm thành phẩm
        public float TamRong { get; set; }
        public float TamCao { get; set; }
        public int TyLeMarkUp { get; set; }
        public MayBoiNhieuLop MayBoi { get; set; }
        public GiayDeBoi ToBoi { get; set; }
        public int SoLopLot { get; set; }
        public KieuBoiNhieuLop KieuBoi { get; set; }
        public GiaBoiNhieuLop(int soLuongTamBoi, MayBoiNhieuLop boiBiaCung,
            float tamRong, float tamCao, GiayDeBoi toBoi,
            int soLopLot, KieuBoiNhieuLop kieuBoi, int tyLeMarkUpSales)
        {
            this.SoLuong = soLuongTamBoi;
            this.TamRong = tamRong;
            this.TamCao = tamCao;
            this.MayBoi = boiBiaCung;
            this.ToBoi = toBoi;
            this.SoLopLot = soLopLot;
            this.KieuBoi = kieuBoi;
            this.TyLeMarkUp = tyLeMarkUpSales;
        }
        public decimal ChiPhiChayMotLop (int soLuong)
        {
            decimal result = 0;
            ///Tốc độ theo tờ
            ///
            
            float soGioChay = this.SoLuong / this.MayBoi.TocDoTamGio;
            decimal phiChay = this.MayBoi.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.MayBoi.BHR * (decimal)this.MayBoi.ThoiGianChuanBi;
            ///Phí nguyên liệu tờ = phí keo cho mỗi tờ đôi
            float tongDienTichTam = (this.TamRong /100 * this.TamCao /100) * SoLuong; //cm đổi ra mét vuông
            decimal phiKeo =  (decimal)tongDienTichTam * this.MayBoi.PhiKeoMetVuong ;
            ///Kết quả = phí chạy + phí chuẩn bị + phí keo
            result = phiChay + phiChuanBi + phiKeo;
            return result;
        }
       
              
        public decimal ChiPhi(int soLuong)
        {
            ///Tính theo số lượng tờ lót
            decimal kq = ChiPhiChayMotLop(this.SoLuong);
            switch (this.KieuBoi)
            {
                case KieuBoiNhieuLop.BoiDap:
                    kq += kq * (this.SoLopLot);
                    break;
                case KieuBoiNhieuLop.BoiLotGiua:
                    kq += kq * (this.SoLopLot + 1);
                    break;
            }
            
          
            return kq;
        }
        public decimal ThanhTienCoBan(int soLuong)
        { ///Tính giá thấp nhất là đại lý
          ///Trường hợp này chưa tính tờ bồi vì tờ bồi là giấy nên tính riêng
          
          
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.MayBoi.DaySoLuong, this.MayBoi.DayLoiNhuan, this.SoLuong) / 100;

            result = this.ChiPhi(soLuong) + this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTienSales()
        {///thành tiên trên cơ sở Giá cơ bản + maarrkup theo hạng KH nào đó
            decimal result = 0;
            if (this.SoLuong <= 0)
                return 0;

            var tyLeMK = (decimal)this.TyLeMarkUp / 100;
            if (this.ToBoi != null) //Có tờ bồi
                result = this.ThanhTienCoBan(this.SoLuong) + this.ThanhTienCoBan(this.SoLuong) * tyLeMK / (1 - tyLeMK)
                    + this.ToBoi.ThanhTienGiay;//Cộng thêm tiền giấy lót vô
            else //Không bồi lót
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
