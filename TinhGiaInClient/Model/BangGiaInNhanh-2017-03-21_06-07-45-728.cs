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
        public int IdHangKhachHang { get; set; }
        public bool KhongSuDung { get; set; }
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
                    ThuTu = x.ThuTu

                }).OrderBy(x => x.ThuTu).ToList();
            }
            catch { }
            return nguon;
        }
        public static BangGiaInNhanh LayGiayTheoId(int idGiay)
        {
            var bGiaInNhanhLogic = new BangGiaInNhanhLogic();
            BangGiaInNhanh bGiaInNhanh = new BangGiaInNhanh();
            try
            {
                var giayBDO = bGiaInNhanhLogic.LayTheoId(idGiay);
                //Chuyen
                ChuyenDoiGiayBDOThanhDTO(giayBDO, bGiaInNhanh);
            }
                catch {
                }
            return bGiaInNhanh;
        }
        //Chuyển đổi
        private static void ChuyenDoiGiayBDOThanhDTO(BangGiaInNhanhBDO bGiaInNhanhBDO, BangGiaInNhanh bGiaInNhanh)
        {
            bGiaInNhanh.ID = bGiaInNhanhBDO.ID;
            bGiaInNhanh.TenBangGia = bGiaInNhanhBDO.TenBangGia;
            bGiaInNhanh.MoTa = bGiaInNhanhBDO.MoTa;
            bGiaInNhanh.DaySoLuong = bGiaInNhanhBDO.DaySoLuong;
            bGiaInNhanh.DayGia = bGiaInNhanhBDO.DayGia;
            bGiaInNhanh.KhongSuDung = bGiaInNhanhBDO.KhongSuDung;            
            bGiaInNhanh.ThuTu = bGiaInNhanhBDO.ThuTu;
            bGiaInNhanh.IdHangKhachHang = bGiaInNhanhBDO.IdHangKhachHang;
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

            //tạo bản dãy chứa block trang theo độ dài
            int[] page_blocks = new int[soLuongs.Length];
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
