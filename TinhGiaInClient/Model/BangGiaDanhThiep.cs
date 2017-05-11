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
                ChuyenDoiBangGiaInNhanhBDOThanhDTO(giayBDO, bGiaInNhanh);
            }
            catch
            {
            }
            return bGiaInNhanh;
        }
        //Chuyển đổi
        private static void ChuyenDoiBangGiaInNhanhBDOThanhDTO(BangGiaDanhThiepBDO bGiaInNhanhBDO, BangGiaDanhThiep bGiaInNhanh)
        {
            bGiaInNhanh.ID = bGiaInNhanhBDO.ID;
            bGiaInNhanh.Ten = bGiaInNhanhBDO.Ten;
            bGiaInNhanh.MoTa = bGiaInNhanhBDO.MoTa;
            bGiaInNhanh.DaySoLuong = bGiaInNhanhBDO.DaySoLuong;
            bGiaInNhanh.DayGia = bGiaInNhanhBDO.DayGia;
            bGiaInNhanh.InHaiMat = bGiaInNhanhBDO.InHaiMat;
            bGiaInNhanh.KhongCon = bGiaInNhanhBDO.KhongCon;
            bGiaInNhanh.ThuTu = bGiaInNhanhBDO.ThuTu;
            bGiaInNhanh.IdHangKhachHang = bGiaInNhanhBDO.IdHangKhachHang;
            bGiaInNhanh.SoHopToiDa = bGiaInNhanhBDO.SoHopToiDa;
            bGiaInNhanh.NoiDungBangGia = bGiaInNhanhBDO.NoiDungBangGia;
            bGiaInNhanh.GiayBaoGom = bGiaInNhanhBDO.GiayBaoGom;
            bGiaInNhanh.KhoToChay = bGiaInNhanhBDO.KhoToChay;
        }
        private static void ChuyenDoiBangGiaInNhanhDTOThanhBDO(BangGiaDanhThiep bGiaInNhanh, BangGiaDanhThiepBDO bGiaInNhanhBDO)
        {
            bGiaInNhanhBDO.ID = bGiaInNhanh.ID;
            bGiaInNhanhBDO.Ten = bGiaInNhanh.Ten;
            bGiaInNhanhBDO.MoTa = bGiaInNhanh.MoTa;
            bGiaInNhanhBDO.DaySoLuong = bGiaInNhanh.DaySoLuong;
            bGiaInNhanhBDO.DayGia = bGiaInNhanh.DayGia;
            bGiaInNhanhBDO.InHaiMat = bGiaInNhanh.InHaiMat;
            bGiaInNhanhBDO.KhongCon = bGiaInNhanh.KhongCon;
            bGiaInNhanhBDO.ThuTu = bGiaInNhanh.ThuTu;
            bGiaInNhanhBDO.IdHangKhachHang = bGiaInNhanh.IdHangKhachHang;
            bGiaInNhanhBDO.SoHopToiDa = bGiaInNhanh.SoHopToiDa;
            bGiaInNhanhBDO.NoiDungBangGia = bGiaInNhanh.NoiDungBangGia;
            bGiaInNhanhBDO.GiayBaoGom = bGiaInNhanh.GiayBaoGom;
            bGiaInNhanhBDO.KhoToChay = bGiaInNhanh.KhoToChay;
        }
        #endregion

    }
}
