using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class CanPhuDAO : ICanPhuDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<CanPhuBDO> LayTatCa()
        {
            List<CanPhuBDO> list = null;
            try
            {
                var nguon = db.CAN_PHU.Select(x => new CanPhuBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,
                    TocDoMetGio = (int)x.Toc_do_met,
                    PhiNgVLM2 = (int)x.Phi_ngvl_m2,
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public CanPhuBDO LayTheoId(int iD)
        {
            CanPhuBDO dm = null;
            try
            {
                var nguon = db.CAN_PHU.Where(x => x.ID == iD).Select(x => new CanPhuBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,
                    TocDoMetGio = (int)x.Toc_do_met,
                    PhiNgVLM2 = (int)x.Phi_ngvl_m2,
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public void Them(CanPhuBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(CanPhuBDO entityBDO)
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
