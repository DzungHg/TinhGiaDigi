using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient
{
    public enum FormStateS { View = 0, New = 1, Edit = 2, Get = 3 }
    public enum SapXepTinhGiaS { Khong = 0, TheoNgay = 1, TheoNhanVien = 2, TheoTieuDe = 3 }
    public enum ChieuSapXepS { Ascending = 0, Descending = 1 }
    public enum LoaiThanhPhamS { CanPhu = 1, CanGap = 2, DongCuon = 3, EpKim = 4, Be = 5, CatDecal = 6, GiaCongNgoai = 10 }
    public enum KieuDongCuonS { Kim = 1, LoXo = 2, Keo = 3, MoPhang = 4 }
    public enum MauInS { BonMau = 0, MotMau = 1, SauMau = 2 }
    public enum PhuongPhapInS { Toner = 1, HPIndigo = 2, Offset = 3, KhoLon = 4, KhongIn = 0 }
    public enum MotHaiMat { MotMat = 1, HaiMat = 2}
    public enum PrintSideColorS { FourFour = 1, FourOne = 2, FourZero = 3, OneOne = 4, OneZero = 5 }
    public enum LoaiBangGia { InNhanh = 0, InNhanhTheoMay = 1, InOffset = 2, InKhoLon = 3 }

    public static class Enumss
    {
       
        public enum SideSel { OneSide = 1, TwoSide = 2 }
        public enum QntyCalc { Lot = 1001, Piece = 1, Hundred = 100, Thousand = 1000 }
        public enum InkCoverPct { None = 0, Five = 5, Ten = 10, Fifteen = 15, Thirty = 30 }
        public enum BindingType { None = 0, Saddle = 1, Perfect = 2, Wire = 3, Pur = 4 }
        public enum BindingOption { NoneTrim = 0, FrontTrim = 1, ThreeFrontTrim = 2 }
        
        
       
       
        
        
        public enum KieuInOffset { MotMat = 0, TuTro = 1, TuTroNhip = 2, AB = 3 }
       
    }
}
  