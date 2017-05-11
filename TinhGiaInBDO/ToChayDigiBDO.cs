﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInBDO
{
    public class ToChayDigiBDO
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public float Rong { get; set; }
        public float Cao { get; set; }
        public float VungInRong { get; set; }
        public float VungInCao { get; set; }
        public int TocDo { get; set; }

        public bool InTuTro { get; set; }
        public bool LaInKhoDai { get; set; }
        public bool LaHPIndigo { get; set; }
        public int ClickA4MotMau { get; set; }
        public int ClickA4BonMau { get; set; }
        public int ClickA4SauMau { get; set; }
        public int QuiA4 { get; set; }
        public int IdMayIn { get; set; }
        public int BHR { get; set; }
        public int PhiPhePhamSanSang { get; set; }
        public float ThoiGianSanSang { get; set; }
        public float ThoiGianDuLieuBienDoi { get; set; }
        public string KhoToChayCoTheIn { get; set; }
        public string DaySoLuong { get; set; }
        public string DayLoiNhuan { get; set; }
        public int ThuTu { get; set; }
    }
}
