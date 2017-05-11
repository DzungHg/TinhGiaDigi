﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaInMayDigi
    {
        public ToChayDigi ToChayDigi { get; set; }
        public int SoTrangA4 { get; set; }
        public int TyLeMarkUp { get; set; }
        public int MauIn { get; set; }
        public GiaInMayDigi(ToChayDigi toChayDigi, int soLuongA4, int tyLeMarkUp, int mauIn)
        {
            this.ToChayDigi = toChayDigi;
            this.SoTrangA4 = soLuongA4;
            this.TyLeMarkUp = tyLeMarkUp;
            this.MauIn = mauIn;

        }
        private decimal PhiIn()
        {
            if (this.ToChayDigi == null || this.SoTrangA4 <= 0)
                return 0;
            //--qua
            decimal result = 0;
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
            switch (this.MauIn)
            {
                case (int)Enumss.MauIn.BonMau:
                    phiMuc =  click4M * this.SoTrangA4;
                    break;
                case (int)Enumss.MauIn.MotMau:
                    phiMuc = click1M * this.SoTrangA4;
                    break;
                case (int)Enumss.MauIn.SauMau:
                    phiMuc = click6M * this.SoTrangA4;
                    break;
            }

            result = phiSetup + phiGiaySanSang + phiChay + phiMuc;

            return result;
        }
        public decimal ThanhTienCoBan()
        {  //Giá đại lý         

            decimal result = 0;
            float tyLeLNCoBan = (float)TinhToan.GiaTriTheoKhoang(this.ToChayDigi.DaySoLuong, this.ToChayDigi.DayLoiNhuan, this.SoTrangA4) / 100;

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
