using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class HangKhachHangDAO : IHangKhachHangDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<HangKhachHangBDO> LayTatCa()
        {
            List<HangKhachHangBDO> list = null;
            try
            {
                var nguon = db.HANG_KHACH_HANG.Select(x => new HangKhachHangBDO
                {
                  
                    ID = x.ID,
                    Ten = x.Ten,
                    DienGiai = x.Dien_giai,
                    HangHangKhachHang = (int)x.Hang_khach_hang,
                    LoiNhuanChenhLech = (int)x.Loi_nhuan_chenh_lech,                    
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public HangKhachHangBDO LayTheoId(int iD)
        {
            HangKhachHangBDO item = null;
            try
            {
                item = db.BANG_GIA_IN_NHANH.Where(x => x.ID == iD).Select(x => new HangKhachHangDAO
                {
                    ID = x.ID,
                    TenBangGia = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongSuDung = (bool)x.khong_su_dung,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                
            }
            catch { }

            return item;
        }

        public void Them(HangKhachHangDAO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(HangKhachHangDAO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
