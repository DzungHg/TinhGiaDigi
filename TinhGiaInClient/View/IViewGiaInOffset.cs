﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model;

namespace TinhGiaInClient.View
{
    public interface IViewGiaInOffset
    {
        int ID { get; set; }
        int IdBaiIn { get; set; }
        int IdHangKH { get; set; }
        string TenHangKH { get; set; }        
        int KieuInOffset { get; set; }
        int IdMayIn { get; set; }
        string KhoToChay { get; set; }
        int SoTrangIn { get; }
        int SoToChay { get; set; }
        int PhiVanChuyen { get; set; }
        int PhiCanhBai { get; set; }
        decimal TienIn { get; set; }
        string GiaTBTrangInfo { get; }
        int PhuongPhapIn { get; }
        FormStates TinhTrangForm { get; set; }
        /*
        List<ToChayDigi> ToChayDigiS { get; set; }
        List<BangGiaInNhanh> BangGiaInNhanhS { get; set; }
        */
    }
}
