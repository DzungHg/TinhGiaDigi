using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model.Support;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class GiaInMayDigi
    {
        public ToInMayDigi ToChayDigi { get; set; }
        public int SoTrangA4 { get; set; }
        public int TyLeMarkUp { get; set; }
        public MauInS MauInChon { get; set; }

        private DuLieuTinhGiaInNhanhTheoMay duLieuTinhGia;
        public GiaInMayDigi(ToInMayDigi toChayDigi, int soLuongA4, int tyLeMarkUp, MauInS mauIn)
        {
            this.ToChayDigi = toChayDigi;
            this.SoTrangA4 = soLuongA4;
            this.TyLeMarkUp = tyLeMarkUp;
            this.MauInChon = mauIn;
            //
            duLieuTinhGia = new DuLieuTinhGiaInNhanhTheoMay();//struct 
            if (this.ToChayDigi != null && this.SoTrangA4 >0 )
            {
                duLieuTinhGia.BHR = this.ToChayDigi.BHR;
                duLieuTinhGia.TocDo = this.ToChayDigi.TocDo; //Tờ trên giờ
                
                duLieuTinhGia.ThoiGianSanSang = this.ToChayDigi.ThoiGianSanSang;
                duLieuTinhGia.InTuTro = this.ToChayDigi.InTuTro;
                duLieuTinhGia.PhiPhePhamSanSang = this.ToChayDigi.PhiPhePhamSanSang;
                duLieuTinhGia.DaySoLuong = this.ToChayDigi.DaySoLuong;
                duLieuTinhGia.DayLoiNhuan = this.ToChayDigi.DayLoiNhuan;
            }
        }
        private decimal PhiIn()
        {
            if (this.ToChayDigi == null || this.SoTrangA4 <= 0)
                return 0;
            //--qua
            decimal result = 0;
            /*
            var BHR = this.ToChayDigi.BHR;
            var tocDo = this.ToChayDigi.TocDo; //Tờ trên giờ
            var click4M = this.ToChayDigi.ClickA4BonMau;//PHí trang A4
            var click6M = this.ToChayDigi.ClickA4SauMau;
            var click1M = this.ToChayDigi.ClickA4MotMau;
            decimal phiSetup = (decimal)this.ToChayDigi.ThoiGianSanSang * BHR; //Lấy giờ
            var phiGiaySanSang = this.ToChayDigi.PhiPhePhamSanSang;


            var thoiGianChay = (decimal)this.SoTrangA4 / tocDo;
            var phiChay =  thoiGianChay * BHR;
            //Phí mực theo click của từng tờ in
            decimal phiMuc = 0;
             */
            switch (this.MauInChon)
            {
                case MauInS.BonMau:
                    duLieuTinhGia.ClickTrangA4 = this.ToChayDigi.ClickA4BonMau * this.SoTrangA4;
                    break;
                case MauInS.MotMau:
                    duLieuTinhGia.ClickTrangA4 = this.ToChayDigi.ClickA4MotMau * this.SoTrangA4;
                    break;
                case MauInS.SauMau:
                    duLieuTinhGia.ClickTrangA4 = this.ToChayDigi.ClickA4SauMau * this.SoTrangA4;
                    break;
            }

            result = new GiaInNhanhTheoMay(this.duLieuTinhGia, this.SoTrangA4, this.TyLeMarkUp).ChiPhi(this.SoTrangA4);

            return result;
        }
        public decimal ThanhTienCoBan()
        {  //Giá đại lý         
            if (this.ToChayDigi == null || this.SoTrangA4 <= 0)
                return 0;
            
            return new GiaInNhanhTheoMay(this.duLieuTinhGia, this.SoTrangA4, this.TyLeMarkUp).ThanhTienCoBan(this.SoTrangA4);
        }
        public decimal ThanhTien_In()
        {
            if (this.ToChayDigi == null || this.SoTrangA4 <= 0)
                return 0;
            return new GiaInNhanhTheoMay(this.duLieuTinhGia, this.SoTrangA4, this.TyLeMarkUp).ThanhTienSales();
        }
    }
}
