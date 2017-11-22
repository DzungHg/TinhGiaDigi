using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class BangGiaLuyTienDAO : IBangGiaLuyTienDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<BangGiaLuyTienBDO> DocTatCa()
        {
            List<BangGiaLuyTienBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_LUY_TIEN.Select(x => new BangGiaLuyTienBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongCon = (bool)x.khong_con,
                    DonViTinh = x.don_vi_tinh,
                    LoaiBangGia = x.loai_bang_gia.Trim(),
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
      

        public BangGiaLuyTienBDO DocTheoId(int iD)
        {
            BangGiaLuyTienBDO item = null;
            try
            {
                item = db.BANG_GIA_LUY_TIEN.Where(x => x.ID == iD).Select(x => new BangGiaLuyTienBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongCon = (bool)x.khong_con,
                    DonViTinh = x.don_vi_tinh,
                    LoaiBangGia = x.loai_bang_gia.Trim(), //không cần cập nhật vì tự có
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();

            }
            catch { }

            return item;
        }
        #region them, sua, xoa
        public string Them(BangGiaLuyTienBDO entityBDO)
        {
            var entity = new BANG_GIA_LUY_TIEN();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten);
                    if (kq != "")
                    {
                        return kq;
                    }
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.BANG_GIA_LUY_TIEN.Add(entity);
                    db.SaveChanges();
                    kq = string.Format("Thêm mục tin {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format("Thêm mục tin {0} không thành công!", entity.ID);
                }
            }
            else
            {

                return string.Format("Mục tin {0} không tồn tại!", entity.ID);
            }
            return kq;
        }

        public string Sua(BangGiaLuyTienBDO entityBDO)
        {
            var entity = db.BANG_GIA_LUY_TIEN.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                    {
                        return kq;
                    }
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
                kq = string.Format("Mục tin {0} không tồn tại!", entity.ID);
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
            var entity = db.BANG_GIA_LUY_TIEN.SingleOrDefault(x => x.ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        #endregion
        private void ChuyenBDOThanhDAO(BangGiaLuyTienBDO entityBDO, BANG_GIA_LUY_TIEN entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten= entityBDO.Ten;
            entityDAO.dien_giai = entityBDO.DienGiai;
            entityDAO.day_gia = entityBDO.DayGia;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.khong_con = entityBDO.KhongCon;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.thu_tu = entityBDO.ThuTu;
            entityDAO.loai_bang_gia = entityBDO.LoaiBangGia.Trim();
        }
    }
}
