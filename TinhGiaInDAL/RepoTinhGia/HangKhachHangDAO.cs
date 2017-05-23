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
                    LoiNhuanOffsetGiaCong = (int)x.Loi_nhuan_offset_gia_cong,
                    MaHieu = x.ma_hieu,
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
                item = db.HANG_KHACH_HANG.Where(x => x.ID == iD).Select(x => new HangKhachHangBDO
                {

                    ID = x.ID,
                    Ten = x.Ten,
                    DienGiai = x.Dien_giai,
                    HangHangKhachHang = (int)x.Hang_khach_hang,
                    LoiNhuanChenhLech = (int)x.Loi_nhuan_chenh_lech,
                    LoiNhuanOffsetGiaCong = (int)x.Loi_nhuan_offset_gia_cong,
                    MaHieu = x.ma_hieu,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                
            }
            catch { }

            return item;
        }

        public void Them(HangKhachHangBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(HangKhachHangBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
    }
}
