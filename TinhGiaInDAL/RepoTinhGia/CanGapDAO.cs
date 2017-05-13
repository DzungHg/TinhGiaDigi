using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class CanGapDAO : ICanGapDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<CanGapBDO> LayTatCa()
        {
            List<CanGapBDO> list = null;
            try
            {
                var nguon = db.CAN_GAP.Select(x => new CanGapBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public CanGapBDO LayTheoId(int iD)
        {
            CanGapBDO dm = null;
            try
            {
                var nguon = db.CAN_GAP.Where(x => x.ID == iD).Select(x => new CanGapBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public void Them(CanGapBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(CanGapBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
