using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient
{
    public enum FormStateS { View = 0, New = 1, Edit = 2, Get = 3, Delete = 4, TinhThu = 10 }
    public enum SapXepTinhGiaS { Khong = 0, TheoNgay = 1, TheoNhanVien = 2, TheoTieuDe = 3 }
    public enum ChieuSapXepS { Ascending = 0, Descending = 1 }
    public enum LoaiThanhPhamS { CanPhu = 1, CanGap = 2, DongCuon = 3, EpKim = 4,
                                Be = 5, CatDecal = 6, BoiBiaCung = 7, 
                        BoiNhieuLop = 8, KhoanBoGoc = 9, GiaCongNgoai = 12 }
    public enum KieuDongCuonS { KimKeoNep = 1, LoXo = 2, MoPhang = 3 }
    public enum MauInS { BonMau = 0, MotMau = 1, SauMau = 2 }
    public enum PhuongPhapInS { Toner = 1, HPIndigo = 2, Offset = 3, KhoLon = 4, KhongIn = 0 }
    public enum MotHaiMat { MotMat = 1, HaiMat = 2}
    public enum PrintSideColorS { FourFour = 1, FourOne = 2, FourZero = 3, OneOne = 4, OneZero = 5 }
    public enum LoaiBangGia { InNhanh = 0, InNhanhTheoMay = 1, InOffset = 2, InKhoLon = 3 }
    public enum KieuBoiNhieuLop { BoiDap = 0, BoiLotGiua = 1}
    //
    
    public static class EnumsS
    {
        //Hằng bảng giá in
        public const string cBangGiaLuyTien = "BG_LUY_TIEN";
        public const string cBangGiaBuoc = "BG_BUOC";
        public const string cBangGiaGoi = "BG_GOI";
        //Dãy số lượng tính thử mặc định
        public const string cDaySoLuongA4TinhThu = "10;50;80;100;120;130;150;170;200;" +
                                                   "250;300;350;400;450;500;550;600;650;" +
                                                   "700;750;800;850;900;950;1000;1100; " +
                                                   "1200;1300;1400;1500;2000;3000;4000;" +
                                                   "5000;6000;7000;8000;9000;10000;15000;20000";
        //

        public enum SideSel { OneSide = 1, TwoSide = 2 }
        public enum QntyCalc { Lot = 1001, Piece = 1, Hundred = 100, Thousand = 1000 }
        public enum InkCoverPct { None = 0, Five = 5, Ten = 10, Fifteen = 15, Thirty = 30 }
        public enum BindingType { None = 0, Saddle = 1, Perfect = 2, Wire = 3, Pur = 4 }
        public enum BindingOption { NoneTrim = 0, FrontTrim = 1, ThreeFrontTrim = 2 }
        
        
       
       
        
        
        public enum KieuInOffset { MotMat = 0, TuTro = 1, TuTroNhip = 2, AB = 3 }
       
    }
}
  