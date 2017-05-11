using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaInOffsetGiaCong
    {
        public OffsetGiaCong MayInOffset { get; set; }
        public int SoMatIn { get; set; }
        public int TyLeMarkUp { get; set; }
        public int KieuInOffset { get; set; }
        public decimal PhiVanChuyen { get; set; }
        public decimal PhiCanhBai { get; set; }
        public GiaInOffsetGiaCong(OffsetGiaCong mayInOffset, int soMatIn, int tyLeMarkUp, int kieuInOffset,
            decimal phiVanChuyen, decimal phiCanhBai)
        {
            this.MayInOffset = mayInOffset;
            this.SoMatIn = soMatIn;
            this.TyLeMarkUp = tyLeMarkUp;
            this.KieuInOffset = kieuInOffset;
            this.PhiVanChuyen = phiVanChuyen;
            this.PhiCanhBai = phiCanhBai;

        }
        private decimal PhiIn()
        {
            if (this.MayInOffset == null || this.SoMatIn <= 0)
                return 0;
            ///Nếu in tự trở chỉ tính 1 lần in, nếu in AB tính 2 lần in
            ///Nếu số trang vượi số trang cơ bản cho phép sẽ tính số trang còn lại theo giá phụ trội
            decimal result = 0;
            decimal tienInGiaCong = 0;
            var giaInMotLan = this.MayInOffset.GiaCongIn;
            var soMatCoBan = this.MayInOffset.SoMatInCoBan;
            var giaMotMatVuotCoBan = this.MayInOffset.GiaInMoiMatVuotCoBan;
            var soMatInVuotCoBan = 0;

            switch (this.KieuInOffset)
            {
                case (int)Enumss.KieuInOffset.MotMat:
                    if (this.SoMatIn - soMatCoBan > 0)
                        soMatInVuotCoBan = this.SoMatIn - soMatCoBan;
                    tienInGiaCong = giaInMotLan + soMatInVuotCoBan * giaMotMatVuotCoBan;
                    break;
                case (int)Enumss.KieuInOffset.TuTro:
                case (int)Enumss.KieuInOffset.TuTroNhip:

                    break;
            }
            if (this.SoMatIn - soMatCoBan > 0)
                soMatInVuotCoBan = this.SoMatIn - soMatCoBan;
            //

            var tocDo = this.MayInOffset.TocDo; //Tờ trên giờ
            var click4M = this.MayInOffset.ClickA4BonMau;//PHí trang A4
            var click6M = this.MayInOffset.ClickA4SauMau;
            var click1M = this.MayInOffset.ClickA4MotMau;
            decimal phiSetup = (decimal)this.MayInOffset.ThoiGianSanSang * giaInMotLan; //Lấy giờ
            var phiGiaySanSang = this.MayInOffset.PhiPhePhamSanSang;


            var thoiGianChay = (decimal)this.SoMatIn / tocDo;
            var phiChay =  thoiGianChay * giaInMotLan;
            //Phí mực theo click của từng tờ in
            decimal phiMuc = 0;
            switch (this.KieuInOffset)
            {
                case (int)Enumss.MauIn.BonMau:
                    phiMuc =  click4M * this.SoMatIn;
                    break;
                case (int)Enumss.MauIn.MotMau:
                    phiMuc = click1M * this.SoMatIn;
                    break;
                case (int)Enumss.MauIn.SauMau:
                    phiMuc = click6M * this.SoMatIn;
                    break;
            }

            result = phiSetup + phiGiaySanSang + phiChay + phiMuc;

            return result;
        }
        public decimal ThanhTienCoBan()
        {  //Giá đại lý         

            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToanThanhPham.MucLoiNhuan(this.MayInOffset.DaySoLuong, this.MayInOffset.DayLoiNhuan, this.SoMatIn) / 100;

            result = this.PhiIn() + this.PhiIn() * (decimal)tyLeLNCoBan / (decimal)(1 - tyLeLNCoBan);
            return result;
        }
        public decimal ThanhTien_In()
        {
            decimal result = 0;
            decimal tyLeMK = (decimal)this.TyLeMarkUp / 100;
            result = this.ThanhTienCoBan() + this.ThanhTienCoBan() * tyLeMK / (1 - tyLeMK);
            return result;
        }
    }
}
