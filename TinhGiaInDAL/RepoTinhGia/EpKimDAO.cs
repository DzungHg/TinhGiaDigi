using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class EpKimDAO : IEpKimDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<EpKimBDO> DocTatCa()
        {
            List<EpKimBDO> list = null;
            try
            {
                var nguon = db.EP_KIM.Select(x => new EpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    LaViTinh = (bool)x.La_vi_tinh,
                    PhiNguyenVatLieuChuanBi = (int)x.Phi_ngvl_chuan_bi,
                    GiaKhuonCm2 = (int)x.Gia_khuon_cm2,
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



        public EpKimBDO DocTheoId(int iD)
        {
            EpKimBDO dm = null;
            try
            {
                var nguon = db.EP_KIM.Where(x => x.ID == iD).Select(x => new EpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    LaViTinh = (bool)x.La_vi_tinh,
                    PhiNguyenVatLieuChuanBi = (int)x.Phi_ngvl_chuan_bi,
                    GiaKhuonCm2 = (int)x.Gia_khuon_cm2,
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
        public void Them(EpKimBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(EpKimBDO entityBDO)
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
