using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class BangGiaDanhThiep
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string DaySoLuong { get; set; }
        public string DayGia { get; set; }
        public bool InHaiMat { get; set; }
        public int ThuTu { get; set; }
        public int IdHangKhachHang { get; set; }
        public bool KhongCon { get; set; }
        public string NoiDungBangGia { get; set; }
        public string GiayBaoGom { get; set; }
        public string KhoToChay { get; set; }
        public int SoHopToiDa { get; set; }
        public int SoDanhThiepTrenHop { get; set; }
        //==
        #region Các hàm static
        public static List<BangGiaDanhThiep> DocTatCa()
        {
            var giayLogic = new BangGiaDanhThiepLogic();
            List<BangGiaDanhThiep> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Where(x => x.KhongCon == false).Select(x => new BangGiaDanhThiep
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    MoTa = x.MoTa,
                    DaySoLuong = x.DaySoLuong,
                    DayGia = x.DayGia,
                    InHaiMat = x.InHaiMat,
                    KhongCon = x.KhongCon,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoHopToiDa = x.SoHopToiDa,
                    NoiDungBangGia = x.NoiDungBangGia,
                    GiayBaoGom = x.GiayBaoGom,
                    KhoToChay = x.KhoToChay,
                    SoDanhThiepTrenHop = x.SoDanhThiepTrenHop,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<BangGiaDanhThiep> DocTheoIdHangKH(int idHangKH)
        {
            var giayLogic = new BangGiaDanhThiepLogic();
            List<BangGiaDanhThiep> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Where(x => (x.IdHangKhachHang == idHangKH) && (x.KhongCon == false)).Select(x => new BangGiaDanhThiep
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    MoTa = x.MoTa,
                    DaySoLuong = x.DaySoLuong,
                    DayGia = x.DayGia,
                    InHaiMat = x.InHaiMat,
                    KhongCon = x.KhongCon,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoHopToiDa = x.SoHopToiDa,
                    NoiDungBangGia = x.NoiDungBangGia,
                    GiayBaoGom = x.GiayBaoGom,
                    KhoToChay = x.KhoToChay,
                    SoDanhThiepTrenHop = x.SoDanhThiepTrenHop,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static BangGiaDanhThiep DocTheoId(int idBangGia)
        {
            var bGiaInNhanhLogic = new BangGiaDanhThiepLogic();
            BangGiaDanhThiep bGiaInNhanh = new BangGiaDanhThiep();
            try
            {
                var giayBDO = bGiaInNhanhLogic.DocTheoId(idBangGia);
                //Chuyen
                ChuyenDoiBDOThanhDTO(giayBDO, bGiaInNhanh);
            }
            catch
            {
            }
            return bGiaInNhanh;
        }
        #region them sua xoa
        public static string Them(BangGiaDanhThiep bGiaDThiep)
        {
            var bangGiaDanhThiepLogic = new BangGiaDanhThiepLogic();
            var itemBDO = new BangGiaDanhThiepBDO();
            ChuyenDoDTOThanhBDO(bGiaDThiep, itemBDO);
            return bangGiaDanhThiepLogic.Them(itemBDO);
        }
        public static string Sua(BangGiaDanhThiep bGiaDThiep)
        {
            var bangGiaDanhThiepLogic = new BangGiaDanhThiepLogic();
            var itemBDO = new BangGiaDanhThiepBDO();
            ChuyenDoDTOThanhBDO(bGiaDThiep, itemBDO);
            return bangGiaDanhThiepLogic.Sua(itemBDO);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiBDOThanhDTO(BangGiaDanhThiepBDO bGiaDanhThiepBDO, BangGiaDanhThiep bGiaDanhThiep)
        {
            bGiaDanhThiep.ID = bGiaDanhThiepBDO.ID;
            bGiaDanhThiep.Ten = bGiaDanhThiepBDO.Ten;
            bGiaDanhThiep.MoTa = bGiaDanhThiepBDO.MoTa;
            bGiaDanhThiep.DaySoLuong = bGiaDanhThiepBDO.DaySoLuong;
            bGiaDanhThiep.DayGia = bGiaDanhThiepBDO.DayGia;
            bGiaDanhThiep.InHaiMat = bGiaDanhThiepBDO.InHaiMat;
            bGiaDanhThiep.KhongCon = bGiaDanhThiepBDO.KhongCon;
            bGiaDanhThiep.ThuTu = bGiaDanhThiepBDO.ThuTu;
            bGiaDanhThiep.IdHangKhachHang = bGiaDanhThiepBDO.IdHangKhachHang;
            bGiaDanhThiep.SoHopToiDa = bGiaDanhThiepBDO.SoHopToiDa;
            bGiaDanhThiep.NoiDungBangGia = bGiaDanhThiepBDO.NoiDungBangGia;
            bGiaDanhThiep.GiayBaoGom = bGiaDanhThiepBDO.GiayBaoGom;
            bGiaDanhThiep.KhoToChay = bGiaDanhThiepBDO.KhoToChay;
            bGiaDanhThiep.SoDanhThiepTrenHop = bGiaDanhThiepBDO.SoDanhThiepTrenHop;
        }
        private static void ChuyenDoDTOThanhBDO(BangGiaDanhThiep bGiaDanhThiep, BangGiaDanhThiepBDO bGiaDanhThiepBDO)
        {
            bGiaDanhThiepBDO.ID = bGiaDanhThiep.ID;
            bGiaDanhThiepBDO.Ten = bGiaDanhThiep.Ten;
            bGiaDanhThiepBDO.MoTa = bGiaDanhThiep.MoTa;
            bGiaDanhThiepBDO.DaySoLuong = bGiaDanhThiep.DaySoLuong;
            bGiaDanhThiepBDO.DayGia = bGiaDanhThiep.DayGia;
            bGiaDanhThiepBDO.InHaiMat = bGiaDanhThiep.InHaiMat;
            bGiaDanhThiepBDO.KhongCon = bGiaDanhThiep.KhongCon;
            bGiaDanhThiepBDO.ThuTu = bGiaDanhThiep.ThuTu;
            bGiaDanhThiepBDO.IdHangKhachHang = bGiaDanhThiep.IdHangKhachHang;
            bGiaDanhThiepBDO.SoHopToiDa = bGiaDanhThiep.SoHopToiDa;
            bGiaDanhThiepBDO.NoiDungBangGia = bGiaDanhThiep.NoiDungBangGia;
            bGiaDanhThiepBDO.GiayBaoGom = bGiaDanhThiep.GiayBaoGom;
            bGiaDanhThiepBDO.KhoToChay = bGiaDanhThiep.KhoToChay;
            bGiaDanhThiepBDO.SoDanhThiepTrenHop = bGiaDanhThiep.SoDanhThiepTrenHop;
        }
        #endregion

    }
}
