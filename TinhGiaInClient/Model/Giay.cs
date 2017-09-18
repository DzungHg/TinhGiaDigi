using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class Giay
    {
        public int ID { get; set; }
        public string MaGiayNCC { get; set; }
        public string MaGiayTuDat { get; set; }
        public string TenGiay { get; set; }
        public string DienGiai { get; set; }
        public int DinhLuong { get; set; }
        public string KhoGiay { get; set; }
        public float ChieuNgan { get; set; }
        public float ChieuDai { get; set; }
        public string TenGiayMoRong { get; set; }
        public int GiaMua { get; set; }        
        public int IdDanhMucGiay { get; set; }
        public string TenDanhMucGiay { get; set; } //Tham chiếu
        public bool TonKho { get; set; }
        public bool KhongCon { get; set; }
        public int ThuTu { get; set; }
        
        //==
        public static int SoCopyTam { get; set; }//Dùng nhân đôi tên giây khỏi trùng
        #region Các hàm static
        public static List<Giay> DocTatCa()
        {
            var giayLogic = new GiayLogic();
            List<Giay> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Select(x => new Giay
                {
                    ID = x.ID,
                    MaGiayNCC = x.MaGiayNCC,
                    MaGiayTuDat = x.MaGiayTuDat,
                    TenGiay = x.TenGiay,
                    DienGiai = x.DienGiai,
                    DinhLuong = x.DinhLuong,
                    KhoGiay = x.KhoGiay,
                    ChieuNgan = x.ChieuNgan,
                    ChieuDai = x.ChieuDai,
                    TenGiayMoRong = x.TenGiayMoRong,
                    GiaMua = x.GiaMua,
                    KhongCon = x.KhongCon,                    
                    IdDanhMucGiay = x.IdDanhMucGiay,
                    TonKho = x.TonKho,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<Giay> DocGiayTheoDanhMuc(int maDM)
        {
            var giayLogic = new GiayLogic();
            List<Giay> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Where(x => x.IdDanhMucGiay == maDM).Select(x => new Giay
                {
                    ID = x.ID,
                    MaGiayNCC = x.MaGiayNCC,
                    MaGiayTuDat = x.MaGiayTuDat,
                    TenGiay = x.TenGiay,
                    DienGiai = x.DienGiai,
                    DinhLuong = x.DinhLuong,
                    KhoGiay = x.KhoGiay,
                    ChieuNgan = x.ChieuNgan,
                    ChieuDai = x.ChieuDai,
                    TenGiayMoRong = x.TenGiayMoRong,
                    GiaMua = x.GiaMua,
                    KhongCon = x.KhongCon,                   
                    IdDanhMucGiay = x.IdDanhMucGiay,
                    TenDanhMucGiay = x.TenDanhMucGiay, //Chỉ tham chiếu không chỉnh sửa
                    TonKho = x.TonKho,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static Giay DocGiayTheoId(int idGiay)
        {
            var giayLogic = new GiayLogic();
            Giay giay = new Giay();
            try
            {
                var giayBDO = giayLogic.LayTheoId(idGiay);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(giayBDO, giay);
            }
                catch {
                }
            return giay;
        }
        
        #region Thêm sửa xóa

        public static string Them(Giay item)
        {
            GiayLogic giayLogic = new GiayLogic();
            var itemBDO = new GiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giayLogic.Them(itemBDO);
        }

        public static string Sua(Giay item)
        {
            GiayLogic giayLogic = new GiayLogic();
            var itemBDO = new GiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            return giayLogic.Sua(itemBDO);
        }
        public static string Xoa(int idGiay)
        {
            GiayLogic giayLogic = new GiayLogic();
            
            return giayLogic.Xoa(idGiay);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(GiayBDO giayBDO, Giay giay)
        {
            giay.ID = giayBDO.ID;
            giay.MaGiayNCC = giayBDO.MaGiayNCC;
            giay.MaGiayTuDat = giayBDO.MaGiayTuDat;
            giay.TenGiay = giayBDO.TenGiay;
            giay.DienGiai = giayBDO.DienGiai;
            giay.DinhLuong = giayBDO.DinhLuong;
            giay.KhoGiay = giayBDO.KhoGiay;
            giay.ChieuNgan = giayBDO.ChieuNgan;
            giay.ChieuDai = giayBDO.ChieuDai;
            giay.TenGiayMoRong = giayBDO.TenGiayMoRong;
            giay.GiaMua = giayBDO.GiaMua;
            giay.KhongCon = giayBDO.KhongCon;            
            giay.IdDanhMucGiay = giayBDO.IdDanhMucGiay;
            giay.TenDanhMucGiay = giayBDO.TenDanhMucGiay;//Chỉ tham chiếu không chỉnh sửa được
            giay.TonKho = giayBDO.TonKho;
            giay.ThuTu = giayBDO.ThuTu;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(Giay giay, GiayBDO giayBDO)
        {//Chuyển đổi để lưu lại
            giayBDO.ID = giay.ID;
            giayBDO.MaGiayNCC = giay.MaGiayNCC;
            giayBDO.MaGiayTuDat = giay.MaGiayTuDat;
            giayBDO.TenGiay = giay.TenGiay;
            giayBDO.DienGiai = giay.DienGiai;
            giayBDO.DinhLuong = giay.DinhLuong;
            giayBDO.KhoGiay = giay.KhoGiay;
            giayBDO.ChieuNgan = giay.ChieuNgan;
            giayBDO.ChieuDai = giay.ChieuDai;
            giayBDO.TenGiayMoRong = giay.TenGiayMoRong;
            giayBDO.GiaMua = giay.GiaMua;
            giayBDO.KhongCon = giay.KhongCon;
            giayBDO.IdDanhMucGiay = giay.IdDanhMucGiay;
            giayBDO.TonKho = giay.TonKho;
            giayBDO.ThuTu = giay.ThuTu;
        }
        #endregion
    }
}
