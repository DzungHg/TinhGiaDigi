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
        public string Them(CanPhuBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public string Sua(CanPhuBDO entityBDO)
        {
            CAN_PHU entity = db.CAN_PHU.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                        return kq;

                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Lưu mục tin {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format("Sửa mục tin {0} không thành công!", entity.ID);
                }
            }
            else
            {
                return kq = string.Format("Mục tin {0} không tồn tại!", entity.ID);
            }
            return kq;
        }

        public string Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        private string KiemTraTrung(string value, int id = 0)
        {
            string kq = "";
            var entity = db.CAN_PHU.SingleOrDefault(x => x.Ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(CanPhuBDO entityBDO, CAN_PHU entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.Toc_do_met = entityBDO.TocDoMetGio;
            entityDAO.Phi_ngvl_m2 = entityBDO.PhiNgVLM2;
            entityDAO.Thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.Day_so_luong = entityBDO.DaySoLuong;
            entityDAO.Day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.Thu_tu = entityBDO.ThuTu;
        }
        #endregion
    }
}
