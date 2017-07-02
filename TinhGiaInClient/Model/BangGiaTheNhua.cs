using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class BangGiaTheNhua
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
        public string VatLieuInBaoGom { get; set; }
        public string KhoToChay { get; set; }
        public int SoTheToiDa { get; set; }
        //==
        #region Các hàm static
        public static List<BangGiaTheNhua> DocTatCa()
        {
            var bGiaThNhuaLogic = new BangGiaTheNhuaLogic();
            List<BangGiaTheNhua> nguon = null;
            try
            {
                nguon = bGiaThNhuaLogic.DocTatCa().Where(x => x.KhongCon == false).Select(x => new BangGiaTheNhua
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    MoTa = x.MoTa,
                    DaySoLuong = x.DaySoLuong,
                    DayGia = x.DayGia,
                    InHaiMat = x.InHaiMat,
                    KhongCon = x.KhongCon,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoTheToiDa = x.SoTheToiDa,
                    NoiDungBangGia = x.NoiDungBangGia,
                    VatLieuInBaoGom = x.VatLieuInBaoGom,
                    KhoToChay = x.KhoToChay,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<BangGiaTheNhua> DocTheoIdHangKH(int idHangKH)
        {
            var giayLogic = new BangGiaTheNhuaLogic();
            List<BangGiaTheNhua> nguon = null;
            try
            {
                nguon = giayLogic.DocTatCa().Where(x => (x.IdHangKhachHang == idHangKH) && (x.KhongCon == false)).Select(x => new BangGiaTheNhua
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    MoTa = x.MoTa,
                    DaySoLuong = x.DaySoLuong,
                    DayGia = x.DayGia,
                    InHaiMat = x.InHaiMat,
                    KhongCon = x.KhongCon,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoTheToiDa = x.SoTheToiDa,
                    NoiDungBangGia = x.NoiDungBangGia,
                    VatLieuInBaoGom = x.VatLieuInBaoGom,
                    KhoToChay = x.KhoToChay,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static BangGiaTheNhua DocTheoId(int idBangGia)
        {
            var bGiaInNhanhLogic = new BangGiaTheNhuaLogic();
            BangGiaTheNhua bGiaInNhanh = new BangGiaTheNhua();
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
        public static string Them(BangGiaTheNhua bGiaDThiep)
        {
            var bangGiaTheNhuaLogic = new BangGiaTheNhuaLogic();
            var itemBDO = new BangGiaTheNhuaBDO();
            ChuyenDoDTOThanhBDO(bGiaDThiep, itemBDO);
            return bangGiaTheNhuaLogic.Them(itemBDO);
        }
        public static string Sua(BangGiaTheNhua bGiaDThiep)
        {
            var bangGiaTheNhuaLogic = new BangGiaTheNhuaLogic();
            var itemBDO = new BangGiaTheNhuaBDO();
            ChuyenDoDTOThanhBDO(bGiaDThiep, itemBDO);
            return bangGiaTheNhuaLogic.Sua(itemBDO);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiBDOThanhDTO(BangGiaTheNhuaBDO bGiaTheNhuaBDO, BangGiaTheNhua bGiaTheNhua)
        {
            bGiaTheNhua.ID = bGiaTheNhuaBDO.ID;
            bGiaTheNhua.Ten = bGiaTheNhuaBDO.Ten;
            bGiaTheNhua.MoTa = bGiaTheNhuaBDO.MoTa;
            bGiaTheNhua.DaySoLuong = bGiaTheNhuaBDO.DaySoLuong;
            bGiaTheNhua.DayGia = bGiaTheNhuaBDO.DayGia;
            bGiaTheNhua.InHaiMat = bGiaTheNhuaBDO.InHaiMat;
            bGiaTheNhua.KhongCon = bGiaTheNhuaBDO.KhongCon;
            bGiaTheNhua.ThuTu = bGiaTheNhuaBDO.ThuTu;
            bGiaTheNhua.IdHangKhachHang = bGiaTheNhuaBDO.IdHangKhachHang;
            bGiaTheNhua.SoTheToiDa = bGiaTheNhuaBDO.SoTheToiDa;
            bGiaTheNhua.NoiDungBangGia = bGiaTheNhuaBDO.NoiDungBangGia;
            bGiaTheNhua.VatLieuInBaoGom = bGiaTheNhuaBDO.VatLieuInBaoGom;
            bGiaTheNhua.KhoToChay = bGiaTheNhuaBDO.KhoToChay;
        }
        private static void ChuyenDoDTOThanhBDO(BangGiaTheNhua bGiaTheNhua, BangGiaTheNhuaBDO bGiaTheNhuaBDO)
        {
            bGiaTheNhuaBDO.ID = bGiaTheNhua.ID;
            bGiaTheNhuaBDO.Ten = bGiaTheNhua.Ten;
            bGiaTheNhuaBDO.MoTa = bGiaTheNhua.MoTa;
            bGiaTheNhuaBDO.DaySoLuong = bGiaTheNhua.DaySoLuong;
            bGiaTheNhuaBDO.DayGia = bGiaTheNhua.DayGia;
            bGiaTheNhuaBDO.InHaiMat = bGiaTheNhua.InHaiMat;
            bGiaTheNhuaBDO.KhongCon = bGiaTheNhua.KhongCon;
            bGiaTheNhuaBDO.ThuTu = bGiaTheNhua.ThuTu;
            bGiaTheNhuaBDO.IdHangKhachHang = bGiaTheNhua.IdHangKhachHang;
            bGiaTheNhuaBDO.SoTheToiDa = bGiaTheNhua.SoTheToiDa;
            bGiaTheNhuaBDO.NoiDungBangGia = bGiaTheNhua.NoiDungBangGia;
            bGiaTheNhuaBDO.VatLieuInBaoGom = bGiaTheNhua.VatLieuInBaoGom;
            bGiaTheNhuaBDO.KhoToChay = bGiaTheNhua.KhoToChay;
        }
        #endregion

    }
}
