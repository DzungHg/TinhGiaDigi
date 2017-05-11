using System;
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
        public bool KhongSuDung { get; set; }
        //==
        #region Các hàm static
        public static List<BangGiaInNhanh> LayTatCa()
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
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static BangGiaInNhanh LayGiayTheoId(int idGiay)
        {
            var bGiaInNhanhLogic = new BangGiaInNhanhLogic();
            BangGiaInNhanh giay = new BangGiaInNhanh();
            try
            {
                var giayBDO = bGiaInNhanhLogic.LayTheoId(idGiay);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(giayBDO, giay);
            }
                catch {
                }
            return giay;
        }
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(BangGiaInNhanhBDO giayBDO, BangGiaInNhanh giayDTO)
        {
            giayDTO.ID = giayBDO.ID;
            giayDTO.MaGiayNCC = giayBDO.MaGiayNCC;
            giayDTO.MaGiayTuDat = giayBDO.MaGiayTuDat;
            giayDTO.TenGiay = giayBDO.TenGiay;
            giayDTO.DienDienGiai = giayBDO.DienDienGiai;
            giayDTO.DinhDinhLuong = giayBDO.DinhDinhLuong;
            giayDTO.KhoGiay = giayBDO.KhoGiay;
            giayDTO.ChieuNgan = giayBDO.ChieuNgan;
            giayDTO.ChieuDai = giayBDO.ChieuDai;
            giayDTO.GiaMua = giayBDO.GiaMua;
            giayDTO.Markup_1 = giayBDO.Markup_1;
            giayDTO.Markup_2 = giayBDO.Markup_2;
            giayDTO.Markup_3 = giayBDO.Markup_3;
            giayDTO.IDDanhMucGiay = giayBDO.IDDanhMucGiay;
            giayDTO.TonKho = giayBDO.TonKho;
            giayDTO.ThuTu = giayBDO.ThuTu;
        }
        #endregion
    }
}
