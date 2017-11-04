using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class NiemYetGiaInNhanh
    {
        public int ID { get; set; }
        public string DienGiai { get; set; }
        public int IdBangGia { get; set; }
        public int IdHangKhachHang { get; set; }
        public int SoTrangToiDa { get; set; }
        public int ThuTu { get; set; }
        public bool KhongSuDung { get; set; }
        public string DaySoLuongNiemYet { get; set; }
        public string LoaiBangGia { get; set; }//CONTS
        //==
        #region Các hàm static
        public static List<NiemYetGiaInNhanh> DocTatCa()
        {
            var niemYetGiaLogic = new NiemYetGiaInNhanhLogic();
            List<NiemYetGiaInNhanh> nguon = null;
            try
            {
                nguon = niemYetGiaLogic.DocTatCa().Select(x => new NiemYetGiaInNhanh
                {
                    ID = x.ID,
                    DienGiai = x.DienGiai,
                    IdBangGia = x.IdBangGia,
                   
                    KhongSuDung = x.KhongSuDung,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoTrangToiDa = x.SoTrangToiDa,
                    DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                    LoaiBangGia = x.LoaiBangGia,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<NiemYetGiaInNhanh> DocTatCaConDung()
        {
            var nguon = DocTatCa().Where(x => !x.KhongSuDung).OrderBy(x => x.ThuTu);
            return nguon.ToList();
        }
       
        public static List<NiemYetGiaInNhanh> DocConDungTheoIdHangKH(int idHangKH)
        {
            var giayLogic = new NiemYetGiaInNhanhLogic();
            List<NiemYetGiaInNhanh> nguon = null;
            try
            {
                nguon = giayLogic.DocTheoIdHangKH(idHangKH).Where(x => (x.IdHangKhachHang == idHangKH) && (x.KhongSuDung == false)).Select(x => new NiemYetGiaInNhanh
                {
                    ID = x.ID,
                    DienGiai = x.DienGiai,
                    IdBangGia = x.IdBangGia,
                    KhongSuDung = x.KhongSuDung,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoTrangToiDa = x.SoTrangToiDa,
                    DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                    LoaiBangGia = x.LoaiBangGia,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<NiemYetGiaInNhanh> DocTheoIdHangKH(int idHangKH)
        {
            var giayLogic = new NiemYetGiaInNhanhLogic();
            List<NiemYetGiaInNhanh> nguon = null;
            try
            {
                nguon = giayLogic.DocTheoIdHangKH(idHangKH).Where(x => (x.IdHangKhachHang == idHangKH)).Select(x => new NiemYetGiaInNhanh
                {
                    ID = x.ID,
                    DienGiai = x.DienGiai,
                    IdBangGia = x.IdBangGia,

                    KhongSuDung = x.KhongSuDung,
                    IdHangKhachHang = x.IdHangKhachHang,
                    SoTrangToiDa = x.SoTrangToiDa,
                    DaySoLuongNiemYet = x.DaySoLuongNiemYet,
                    LoaiBangGia = x.LoaiBangGia,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static NiemYetGiaInNhanh DocTheoId(int idNiemYetGia)
        {
            var bGiaInNhanhLogic = new NiemYetGiaInNhanhLogic();
            NiemYetGiaInNhanh bGiaInNhanh = new NiemYetGiaInNhanh();
            try
            {
                var giayBDO = bGiaInNhanhLogic.DocTheoId(idNiemYetGia);
                //Chuyen
                ChuyenDoiNiemYetGiaInNhanhBDOThanhDTO(giayBDO, bGiaInNhanh);
            }
            catch
            {
            }
            return bGiaInNhanh;
        }
        #region them sua xoa
        public static string Them(NiemYetGiaInNhanh toInMayDigi)
        {
            var NiemYetGiaInNhanhLogic = new NiemYetGiaInNhanhLogic();
            var itemBDO = new NiemYetGiaInNhanhBDO();
            ChuyenDoiNiemYetGiaInNhanhDTOThanhBDO(toInMayDigi, itemBDO);
            return NiemYetGiaInNhanhLogic.Them(itemBDO);
        }
        public static bool Sua(ref string thongDiep, NiemYetGiaInNhanh toInMayDigi)
        {
            var NiemYetGiaInNhanhLogic = new NiemYetGiaInNhanhLogic();
            var itemBDO = new NiemYetGiaInNhanhBDO();
            ChuyenDoiNiemYetGiaInNhanhDTOThanhBDO(toInMayDigi, itemBDO);
            return NiemYetGiaInNhanhLogic.Sua(ref thongDiep, itemBDO);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiNiemYetGiaInNhanhBDOThanhDTO(NiemYetGiaInNhanhBDO bGiaInNhanhBDO, NiemYetGiaInNhanh bGiaInNhanh)
        {
            bGiaInNhanh.ID = bGiaInNhanhBDO.ID;
            bGiaInNhanh.DienGiai = bGiaInNhanhBDO.DienGiai;
            bGiaInNhanh.IdBangGia = bGiaInNhanhBDO.IdBangGia;
            bGiaInNhanh.KhongSuDung = bGiaInNhanhBDO.KhongSuDung;
            bGiaInNhanh.ThuTu = bGiaInNhanhBDO.ThuTu;
            bGiaInNhanh.IdHangKhachHang = bGiaInNhanhBDO.IdHangKhachHang;
            bGiaInNhanh.SoTrangToiDa = bGiaInNhanhBDO.SoTrangToiDa;           
            bGiaInNhanh.DaySoLuongNiemYet = bGiaInNhanhBDO.DaySoLuongNiemYet;
            bGiaInNhanh.LoaiBangGia = bGiaInNhanhBDO.LoaiBangGia;
        }
        private static void ChuyenDoiNiemYetGiaInNhanhDTOThanhBDO(NiemYetGiaInNhanh bGiaInNhanh, NiemYetGiaInNhanhBDO bGiaInNhanhBDO)
        {
            bGiaInNhanhBDO.ID = bGiaInNhanh.ID;
            bGiaInNhanhBDO.DienGiai = bGiaInNhanh.DienGiai;
            bGiaInNhanhBDO.IdBangGia = bGiaInNhanh.IdBangGia;
          
            bGiaInNhanhBDO.KhongSuDung = bGiaInNhanh.KhongSuDung;
            bGiaInNhanhBDO.ThuTu = bGiaInNhanh.ThuTu;
            bGiaInNhanhBDO.IdHangKhachHang = bGiaInNhanh.IdHangKhachHang;
            bGiaInNhanhBDO.SoTrangToiDa = bGiaInNhanh.SoTrangToiDa;
           
            bGiaInNhanhBDO.DaySoLuongNiemYet = bGiaInNhanh.DaySoLuongNiemYet;
            bGiaInNhanhBDO.LoaiBangGia = bGiaInNhanh.LoaiBangGia;
        }
        #endregion

    }
}
