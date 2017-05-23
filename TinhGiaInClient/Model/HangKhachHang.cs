using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInLogic;

namespace TinhGiaInClient.Model
{
    public class HangKhachHang
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string DienGiai { get; set; }
        public int GiaTriHang { get; set; }
        public int LoiNhuanChenhLech { get; set; }
        public int LoiNhuanOffsetGiaCong { get; set; }
        public string MaHieu { get; set; }
        public int ThuTu { get; set; }
        //==
        #region Các hàm static
        public static List<HangKhachHang> LayTatCa()
        {
            var giayLogic = new HangKhachHangLogic();
            List<HangKhachHang> nguon = null;
            try
            {
                nguon = giayLogic.LayTatCa().Select(x => new HangKhachHang
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    DienGiai = x.Ten,
                    GiaTriHang = x.HangHangKhachHang,
                    LoiNhuanChenhLech = x.LoiNhuanChenhLech,
                    LoiNhuanOffsetGiaCong = x.LoiNhuanOffsetGiaCong,
                    MaHieu = x.MaHieu,
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }

        public static HangKhachHang LayTheoId(int idHangKH)
        {
            var bGiaInNhanhLogic = new HangKhachHangLogic();
            HangKhachHang hangKH = new HangKhachHang();
            try
            {
                var hangKHBDO = bGiaInNhanhLogic.LayTheoId(idHangKH);
                //Chuyen
                ChuyenDoiBDOThanhDTO(hangKHBDO, hangKH);
            }
                catch {
                }
            return hangKH;
        }
        //Chuyển đổi
        private static void ChuyenDoiBDOThanhDTO(HangKhachHangBDO hangKHBDO, HangKhachHang hangKH)
        {
            hangKH.ID = hangKHBDO.ID;
            hangKH.Ten = hangKHBDO.Ten;
            hangKH.DienGiai = hangKHBDO.DienGiai;
            hangKH.GiaTriHang = hangKHBDO.HangHangKhachHang;
            hangKH.LoiNhuanChenhLech = hangKHBDO.LoiNhuanChenhLech;
            hangKH.LoiNhuanOffsetGiaCong = hangKHBDO.LoiNhuanOffsetGiaCong;
            hangKH.MaHieu = hangKHBDO.MaHieu;
            hangKH.ThuTu = hangKHBDO.ThuTu;
            
        }
        private static void ChuyenDoiDTOThanhBDO(HangKhachHang hangKH, HangKhachHangBDO hangKHBDO)
        {
            hangKHBDO.ID = hangKH.ID;
            hangKHBDO.Ten = hangKH.Ten;
            hangKHBDO.DienGiai = hangKH.DienGiai;
            hangKHBDO.HangHangKhachHang = hangKH.GiaTriHang;
            hangKHBDO.LoiNhuanChenhLech = hangKH.LoiNhuanChenhLech;
            hangKHBDO.LoiNhuanOffsetGiaCong = hangKH.LoiNhuanOffsetGiaCong;
            hangKHBDO.MaHieu = hangKH.MaHieu;
            hangKHBDO.ThuTu = hangKH.ThuTu;

        }
        #endregion
        #region  hàm tính giá in nhanh
        public static decimal TinhGiaInNhanh(BangGiaInNhanh bangGia, int soTrangA4)
        {
            if (bangGia == null || soTrangA4 <= 0)
                return 0;

            string[] soLuongs = bangGia.DaySoLuong.Split(';'); //[1,11,51,101];
            string [] giaTheos = bangGia.DayGia.Split(';'); //[15000,5000,3000,2500];
            var result = 0;
            var soTrangGoc = soTrangA4;//lưu để tính cuối.

            //tạo bản dãy chứa block trang
            int[] page_blocks = {0, 0, 0, 0};
            var i = 0;
            for (i = 0; i < page_blocks.Length - 1; i++)
            {
                if (soTrangA4 <= int.Parse(soLuongs[i + 1]) - int.Parse(soLuongs[i]))
                {
                    page_blocks[i] = soTrangA4;
                    soTrangA4 = 0;//ngăn không cho cộng thêm ở cuối
                    break;
                }
                else
                {
                    page_blocks[i] = int.Parse(soLuongs[i + 1]) - int.Parse(soLuongs[i]);
                    //page num còn lại
                    soTrangA4 -= page_blocks[i];
                }
            }

            if (soTrangA4 > 0)
            {
                page_blocks[i] = soTrangA4;
            }
            //tính giá theo các blocks trang đã có

            for (i = 0; i < page_blocks.Length; i++)
            {
                result += page_blocks[i] * int.Parse(giaTheos[i]);
            }


            return result;
        }

        #endregion
    }
}
