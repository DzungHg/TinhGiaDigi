using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class CatDecalDAO : ICatDecalDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<CatDecalBDO> DocTatCa()
        {
            List<CatDecalBDO> list = null;
            try
            {
                var nguon = db.CAT_DECAL.Select(x => new CatDecalBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,
                    TocDoMetGio = (int)x.toc_do_met_gio,
                    PhiDao1000Met = (int)x.phi_dao_mot_ngan_met,
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    Ma_01 = x.ma_01,
                    GhiChu = x.ghi_chu,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public CatDecalBDO DocTheoId(int iD)
        {
            CatDecalBDO dm = null;
            try
            {
                var nguon = db.CAT_DECAL.Where(x => x.ID == iD).Select(x => new CatDecalBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,
                    TocDoMetGio = (int)x.toc_do_met_gio,
                    PhiDao1000Met = (int)x.phi_dao_mot_ngan_met,                   
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    GhiChu = x.ghi_chu,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public string Them(CatDecalBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                CAT_DECAL entity = new CAT_DECAL();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.CAT_DECAL.Add(entity);
                db.SaveChanges();
                kq = string.Format("Mục tin:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Mục tin {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(CatDecalBDO entityBDO)
        {
            CAT_DECAL entity = db.CAT_DECAL.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
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
            var entity = db.CAT_DECAL.SingleOrDefault(x => x.ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(CatDecalBDO entityBDO, CAT_DECAL entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.toc_do_met_gio = entityBDO.TocDoMetGio;
            entityDAO.phi_dao_mot_ngan_met = entityBDO.PhiDao1000Met;
            entityDAO.thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.ghi_chu = entityBDO.GhiChu;
            entityDAO.thu_tu = entityBDO.ThuTu;
        }
        #endregion
    }
}
