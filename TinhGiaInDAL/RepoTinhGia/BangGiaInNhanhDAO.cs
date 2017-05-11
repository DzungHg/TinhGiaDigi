using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class BangGiaInNhanhDAO: IBangGiaInNhanhDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<BangGiaInNhanhBDO> LayTatCa()
        {
            List<BangGiaInNhanhBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_IN_NHANH.Select(x => new BangGiaInNhanhBDO
                {
                    ID = x.ID,
                    TenBangGia = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongSuDung = (bool)x.khong_su_dung,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<BangGiaInNhanhBDO> LayTheoIdHangKH(int idHangKH)
        {
            List<BangGiaInNhanhBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_IN_NHANH.Where(x => x.ID_HANG_KHACH_HANG == idHangKH).Select(x => new BangGiaInNhanhBDO
                {
                    ID = x.ID,
                    TenBangGia = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongSuDung = (bool)x.khong_su_dung,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public BangGiaInNhanhBDO LayTheoId(int iD)
        {
            BangGiaInNhanhBDO item = null;
            try
            {
                item = db.BANG_GIA_IN_NHANH.Where(x=> x.ID == iD).Select(x => new BangGiaInNhanhBDO
                {
                    ID = x.ID,
                    TenBangGia = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongSuDung = (bool)x.khong_su_dung,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                
            }
            catch { }

            return item;
        }

        public void Them(BangGiaInNhanhBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(BangGiaInNhanhBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
