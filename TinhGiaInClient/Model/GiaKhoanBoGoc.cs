using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaKhoanBoGoc: IGiaThanhPham
    {
        public int SoLuong { get; set; } //Số lượng block
       
        public int TyLeMarkUp { get; set; }
        public MayKhoanBoGoc MayMoc { get; set; }       
        public int SoLanKhoanBoTrenBlock { get; set; }      
        public GiaKhoanBoGoc(int soLuongBlock, MayKhoanBoGoc mayMoc,
                      int soLanKhoanBoTrenBlock, int tyLeMarkUpSales)
        {
            this.SoLuong = soLuongBlock;
           
            this.MayMoc = mayMoc;
            
            this.SoLanKhoanBoTrenBlock = soLanKhoanBoTrenBlock;
           
            this.TyLeMarkUp = tyLeMarkUpSales;
        }
        public decimal ChiPhiChayMotLanKhoanBo ()
        {
            decimal kq = 0;
            ///Tốc độ theo block
            ///
            
            float soGioChay = this.SoLuong / this.MayMoc.TocDoBlockGio;
            decimal phiChay = this.MayMoc.BHR * (decimal)soGioChay;
            decimal phiChuanBi = this.MayMoc.BHR * (decimal)this.MayMoc.ThoiGianChuanBi;
            //Phí nguyên liệu là tiêu hao dụng cụ            
            decimal phiDungCu = this.MayMoc.PhiDungCuMoiBlock * this.SoLuong ;
            
            kq = phiChay + phiChuanBi + phiDungCu;
            return kq;
        }


        public decimal ChiPhi(int soLuong)
        {
            ///Tính theo số lượng tờ lót
            decimal kq = ChiPhiChayMotLanKhoanBo();
            //Không xài số lượng ở đây vì đã dùng ở chi phí lần chạy
            kq += kq * (this.SoLanKhoanBoTrenBlock);

            return kq;
        }
        public decimal ThanhTienCoBan(int soLuong)
        { ///Tính giá thấp nhất là đại lý
          ///Trường hợp này chưa tính tờ bồi vì tờ bồi là giấy nên tính riêng
          
          
            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.MayMoc.DaySoLuong, this.MayMoc.DayLoiNhuan, this.SoLuong) / 100;

            result = this.ChiPhi(soLuong) + this.ChiPhi(soLuong) * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTienSales()
        {///thành tiên trên cơ sở Giá cơ bản + maarrkup theo hạng KH nào đó
            decimal kq = 0;
            if (this.SoLuong <= 0)
                return 0;

            var tyLeMK = (decimal)this.TyLeMarkUp / 100;
          
            kq = this.ThanhTienCoBan(this.SoLuong) + this.ThanhTienCoBan(this.SoLuong) * tyLeMK / (1 - tyLeMK);

            return Math.Round(kq);
        }
        public decimal GiaTBTrenDonVi()
        {
            decimal kq = 0;
            if (this.SoLuong <= 0)
                return 0;
            kq = this.ThanhTienSales() / this.SoLuong;

            return Math.Round(kq);
        }
    }
}
