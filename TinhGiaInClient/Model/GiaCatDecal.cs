using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaCatDecal: IGiaThanhPham
    {
        public int SoLuong { get; set; }
        public float ConRong { get; set; }
        public float ConCao { get; set; }
        public int TyLeMarkUp { get; set; }
        public CatDecal MayCatDecal { get; set; }
        
        public GiaCatDecal(int soLuong, CatDecal catDecal,
            float conRong, float conCao, int mucLoiNhuan)
        {
            this.SoLuong = soLuong;
            this.ConRong = conRong;
            this.ConCao = conCao;
            this.MayCatDecal = catDecal;
            
            this.TyLeMarkUp = mucLoiNhuan;
        }
        public decimal ChiPhiChay (int soLuong)
        {
            decimal result = 0;
            ///tốc độ tính theo số tờ đôi /giờ
            float chieuDaiDuongCat = ((this.ConRong + this.ConCao) * 2 * this.SoLuong) / 100;//đổi ra mét
            float soGioChay = chieuDaiDuongCat / this.MayCatDecal.TocDoMetGio;
            decimal phiChay = this.MayCatDecal.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.MayCatDecal.BHR * (decimal)this.MayCatDecal.ThoiGianChuanBi;
            ///Phí nguyên liệu tờ = phí keo cho mỗi tờ đôi
            decimal phiDao = (decimal)chieuDaiDuongCat * this.MayCatDecal.PhiDao1000Met / 1000 ;//1000 mét
            ///Kết quả = phí chạy + phí chuẩn bị + phí keo
            result = phiChay + phiChuanBi + phiDao;
            return result;
        }
       
       
        public decimal ChiPhi(int soLuong)
        {
            return this.ChiPhiChay(soLuong);
        }
        public decimal ThanhTienCoBan(int soLuong)
        { ///Tính giá thấp nhất là đại lý
          ///theo mức lợi nhuận cơ bản ghi trong database
          
          
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.MayCatDecal.DaySoLuong, this.MayCatDecal.DayLoiNhuan, this.SoLuong) / 100;

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
