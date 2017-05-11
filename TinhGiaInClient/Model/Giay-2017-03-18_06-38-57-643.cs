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
        public string DienDienGiai { get; set; }
        public int DinhLuong { get; set; }
        public string KhoGiay { get; set; }
        public float ChieuNgan { get; set; }
        public float ChieuDai { get; set; }
        public int GiaMua { get; set; }        
        public int IdDanhMucGiay { get; set; }
        public bool TonKho { get; set; }
        public bool KhongCon { get; set; }
        public int ThuTu { get; set; }
        //==
        #region Các hàm static
        public static List<Giay> LayTatCa()
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
                    DienDienGiai = x.DienDienGiai,
                    DinhLuong = x.DinhLuong,
                    KhoGiay = x.KhoGiay,
                    ChieuNgan = x.ChieuNgan,
                    ChieuDai = x.ChieuDai,
                    GiaMua = x.GiaMua,
                    KhongCon = x.KhongCon,                    
                    IdDanhMucGiay = x.IDDanhMucGiay,
                    TonKho = x.TonKho,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static List<Giay> LayGiayTheoDanhMuc(int maDM)
        {
            var giayLogic = new GiayLogic();
            List<Giay> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Where(x => x.IDDanhMucGiay == maDM).Select(x => new Giay
                {
                    ID = x.ID,
                    MaGiayNCC = x.MaGiayNCC,
                    MaGiayTuDat = x.MaGiayTuDat,
                    TenGiay = x.TenGiay,
                    DienDienGiai = x.DienDienGiai,
                    DinhLuong = x.DinhLuong,
                    KhoGiay = x.KhoGiay,
                    ChieuNgan = x.ChieuNgan,
                    ChieuDai = x.ChieuDai,
                    GiaMua = x.GiaMua,
                    KhongCon = x.KhongCon,                   
                    IdDanhMucGiay = x.IDDanhMucGiay,
                    TonKho = x.TonKho,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static Giay LayGiayTheoId(int idGiay)
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
            GiayLogic markUpLNGLogic = new GiayLogic();
            var itemBDO = new GiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            markUpLNGLogic.Them(itemBDO);
        }

        public static string Sua(DanhMucGiay item)
        {
            DanhMucGiayLogic markUpLNGLogic = new DanhMucGiayLogic();
            var itemBDO = new DanhMucGiayBDO();
            ChuyenDoiGiayDTOThanhBDO(item, itemBDO);
            markUpLNGLogic.Sua(itemBDO);
        }
        #endregion
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(GiayBDO giayBDO, Giay giayDTO)
        {
            giayDTO.ID = giayBDO.ID;
            giayDTO.MaGiayNCC = giayBDO.MaGiayNCC;
            giayDTO.MaGiayTuDat = giayBDO.MaGiayTuDat;
            giayDTO.TenGiay = giayBDO.TenGiay;
            giayDTO.DienDienGiai = giayBDO.DienDienGiai;
            giayDTO.DinhLuong = giayBDO.DinhLuong;
            giayDTO.KhoGiay = giayBDO.KhoGiay;
            giayDTO.ChieuNgan = giayBDO.ChieuNgan;
            giayDTO.ChieuDai = giayBDO.ChieuDai;
            giayDTO.GiaMua = giayBDO.GiaMua;
            giayDTO.KhongCon = giayBDO.KhongCon;            
            giayDTO.IdDanhMucGiay = giayBDO.IDDanhMucGiay;
            giayDTO.TonKho = giayBDO.TonKho;
            giayDTO.ThuTu = giayBDO.ThuTu;
        }
        private static void ChuyenDoiGiayDTOThanhBDO(Giay giay, GiayBDO giayBDO)
        {
            giayBDO.ID = giay.ID;
            giayBDO.MaGiayNCC = giay.MaGiayNCC;
            giayBDO.MaGiayTuDat = giay.MaGiayTuDat;
            giayBDO.TenGiay = giay.TenGiay;
            giayBDO.DienDienGiai = giay.DienDienGiai;
            giayBDO.DinhLuong = giay.DinhDinhLuong;
            giayBDO.KhoGiay = giay.KhoGiay;
            giayBDO.ChieuNgan = giay.ChieuNgan;
            giayBDO.ChieuDai = giay.ChieuDai;
            giayBDO.GiaMua = giay.GiaMua;
            giayBDO.KhongCon = giay.KhongCon;
            giayBDO.IdDanhMucGiay = giay.IDDanhMucGiay;
            giayBDO.TonKho = giay.TonKho;
            giayBDO.ThuTu = giay.ThuTu;
        }
        #endregion
    }
}
