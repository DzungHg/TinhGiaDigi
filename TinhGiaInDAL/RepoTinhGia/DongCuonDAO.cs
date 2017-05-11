using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class DongCuonDAO : IDongCuonDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<DongCuonBDO> LayTatCa()
        {
            List<DongCuonBDO> list = null;
            try
            {
                var nguon = db.DONG_CUON.Select(x => new DongCuonBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,
                    TocDoCuonGio = (int)x.Toc_do_cuon,
                    PhiNgVLCuon = (int)x.Phi_ngvl_cuon,
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public DongCuonBDO LayTheoId(int iD)
        {
            DongCuonBDO dm = null;
            try
            {
                var nguon = db.DONG_CUON.Where(x => x.ID == iD).Select(x => new DongCuonBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,
                    TocDoCuonGio = (int)x.Toc_do_cuon,
                    PhiNgVLCuon = (int)x.Phi_ngvl_cuon,
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
        public void Them(DongCuonBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(DongCuonBDO entityBDO)
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
