﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class BangGiaInNhanh
    {
        public int ID { get; set; }
        public string TenBangGia { get; set; }
        public string MoTa { get; set; }
        public string DaySoLuong { get; set; }
        public string DayGia { get; set; }
        public int ThuTu { get; set; }
        public int IdHangKhachHang { get; set; }
        public bool KhongSuDung { get; set; }
        public int SoTrangToiDa { get; set; }
        //==
        #region Các hàm static
        public static List<BangGiaInNhanh> DocTatCa()
        {
            var giayLogic = new BangGiaInNhanhLogic();
            List<BangGiaInNhanh> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Where(x => x.KhongSuDung == false).Select(x => new BangGiaInNhanh
                {
                    ID = x.ID,
                    TenBangGia = x.TenBangGia,
                    MoTa = x.MoTa,
                    DaySoLuong = x.DaySoLuong,
                    DayGia = x.DayGia,
                    KhongSuDung = x.KhongSuDung,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoTrangToiDa = x.SoTrangToiDa,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<BangGiaInNhanh> DocTheoIdHangKH(int idHangKH)
        {
            var giayLogic = new BangGiaInNhanhLogic();
            List<BangGiaInNhanh> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Where(x => (x.IdHangKhachHang == idHangKH) && (x.KhongSuDung == false)).Select(x => new BangGiaInNhanh
                {
                    ID = x.ID,
                    TenBangGia = x.TenBangGia,
                    MoTa = x.MoTa,
                    DaySoLuong = x.DaySoLuong,
                    DayGia = x.DayGia,
                    KhongSuDung = x.KhongSuDung,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoTrangToiDa = x.SoTrangToiDa,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static BangGiaInNhanh DocTheoId(int idBangGia)
        {
            var bGiaInNhanhLogic = new BangGiaInNhanhLogic();
            BangGiaInNhanh bGiaInNhanh = new BangGiaInNhanh();
            try
            {
                var giayBDO = bGiaInNhanhLogic.LayTheoId(idBangGia);
                //Chuyen
                ChuyenDoiBangGiaInNhanhBDOThanhDTO(giayBDO, bGiaInNhanh);
            }
            catch
            {
            }
            return bGiaInNhanh;
        }
        //Chuyển đổi
        private static void ChuyenDoiBangGiaInNhanhBDOThanhDTO(BangGiaInNhanhBDO bGiaInNhanhBDO, BangGiaInNhanh bGiaInNhanh)
        {
            bGiaInNhanh.ID = bGiaInNhanhBDO.ID;
            bGiaInNhanh.TenBangGia = bGiaInNhanhBDO.TenBangGia;
            bGiaInNhanh.MoTa = bGiaInNhanhBDO.MoTa;
            bGiaInNhanh.DaySoLuong = bGiaInNhanhBDO.DaySoLuong;
            bGiaInNhanh.DayGia = bGiaInNhanhBDO.DayGia;
            bGiaInNhanh.KhongSuDung = bGiaInNhanhBDO.KhongSuDung;
            bGiaInNhanh.ThuTu = bGiaInNhanhBDO.ThuTu;
            bGiaInNhanh.IdHangKhachHang = bGiaInNhanhBDO.IdHangKhachHang;
            bGiaInNhanh.SoTrangToiDa = bGiaInNhanhBDO.SoTrangToiDa;
        }
        private static void ChuyenDoiBangGiaInNhanhDTOThanhBDO(BangGiaInNhanh bGiaInNhanh, BangGiaInNhanhBDO bGiaInNhanhBDO)
        {
            bGiaInNhanhBDO.ID = bGiaInNhanh.ID;
            bGiaInNhanhBDO.TenBangGia = bGiaInNhanh.TenBangGia;
            bGiaInNhanhBDO.MoTa = bGiaInNhanh.MoTa;
            bGiaInNhanhBDO.DaySoLuong = bGiaInNhanh.DaySoLuong;
            bGiaInNhanhBDO.DayGia = bGiaInNhanh.DayGia;
            bGiaInNhanhBDO.KhongSuDung = bGiaInNhanh.KhongSuDung;
            bGiaInNhanhBDO.ThuTu = bGiaInNhanh.ThuTu;
            bGiaInNhanhBDO.IdHangKhachHang = bGiaInNhanh.IdHangKhachHang;
            bGiaInNhanhBDO.SoTrangToiDa = bGiaInNhanh.SoTrangToiDa;
        }
        #endregion

    }
}