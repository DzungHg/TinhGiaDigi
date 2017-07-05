using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class GiaTuyChonDanhThiepDAO : IGiaTuyChonDanhThiepDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<GiaTuyChonDanhThiepBDO> DocTatCa()
        {
            List<GiaTuyChonDanhThiepBDO> list = null;
            try
            {
                var nguon = db.GIA_TUY_CHON_DANH_THIEP.Select(x => new GiaTuyChonDanhThiepBDO
                {
                    IdBangGiaDanhThiep = x.ID_BANG_GIA_DANH_THIEP,
                    IdTuyChonDanhThiep = x.ID_TUY_CHON_DANH_THIEP,
                    TenTuyChon =x.TUY_CHON_DANH_THIEP.ten, //chỉ get không set được
                    TenBangGia = x.BANG_GIA_DANH_THIEP.ten_bang_gia,
                    GiaBan = (int)x.gia_ban
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public GiaTuyChonDanhThiepBDO DocTheoId(int idBangGia, int idTuyChon)
        {

            GiaTuyChonDanhThiepBDO item = null;
            try
            {
                item = db.GIA_TUY_CHON_DANH_THIEP.Where(x => (x.ID_BANG_GIA_DANH_THIEP == idBangGia)
                    && (x.ID_TUY_CHON_DANH_THIEP == idTuyChon)).Select(x => new GiaTuyChonDanhThiepBDO
                {
                    IdBangGiaDanhThiep = x.ID_BANG_GIA_DANH_THIEP,
                    IdTuyChonDanhThiep = x.ID_TUY_CHON_DANH_THIEP,
                    TenTuyChon = x.TUY_CHON_DANH_THIEP.ten,
                    TenBangGia = x.BANG_GIA_DANH_THIEP.ten_bang_gia,
                    GiaBan = (int)x.gia_ban
                }).SingleOrDefault();

            }
            catch { }

            return item;
        }
        public IEnumerable<GiaTuyChonDanhThiepBDO> DocTheoIdBangGia(int iD)
        {
            List<GiaTuyChonDanhThiepBDO> list = null;
            try
            {
                var nguon = db.GIA_TUY_CHON_DANH_THIEP.Where(x => x.ID_BANG_GIA_DANH_THIEP == iD).Select(x => new GiaTuyChonDanhThiepBDO
                {
                    IdBangGiaDanhThiep = x.ID_BANG_GIA_DANH_THIEP,
                    IdTuyChonDanhThiep = x.ID_TUY_CHON_DANH_THIEP,
                    TenTuyChon = x.TUY_CHON_DANH_THIEP.ten,
                    GiaBan = (int)x.gia_ban
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public IEnumerable<GiaTuyChonDanhThiepBDO> DocTheoIdTuyChon(int iD)
        {
            List<GiaTuyChonDanhThiepBDO> list = null;
            try
            {
                var nguon = db.GIA_TUY_CHON_DANH_THIEP.Where(x => x.ID_TUY_CHON_DANH_THIEP == iD).Select(x => new GiaTuyChonDanhThiepBDO
                {
                    IdBangGiaDanhThiep = x.ID_BANG_GIA_DANH_THIEP,
                    IdTuyChonDanhThiep = x.ID_TUY_CHON_DANH_THIEP,
                    TenBangGia = x.BANG_GIA_DANH_THIEP.ten_bang_gia,
                    GiaBan = (int)x.gia_ban
                });
                list = nguon.ToList();
                list = nguon.ToList();
            }
            catch { }

            return list;
        }




        #region Them, sưa, xoa
        public string Them(GiaTuyChonDanhThiepBDO entityBDO)
        {
        
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.IdBangGiaDanhThiep, entityBDO.IdTuyChonDanhThiep);
                if (kq != "")
                    return kq;
                GIA_TUY_CHON_DANH_THIEP entity = new GIA_TUY_CHON_DANH_THIEP();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.GIA_TUY_CHON_DANH_THIEP.Add(entity);
                db.SaveChanges();
                kq = string.Format("BangGia:{0}_TuyChon:{1}", entity.ID_BANG_GIA_DANH_THIEP, entity.ID_TUY_CHON_DANH_THIEP);
            }
            catch
            {
                kq = string.Format("BangGia_TuyChon {0}-{1} không tồn tại!", entityBDO.IdBangGiaDanhThiep, entityBDO.IdTuyChonDanhThiep);
            }
            return kq;
        }


        public string Sua(GiaTuyChonDanhThiepBDO entityBDO)
        {
            GIA_TUY_CHON_DANH_THIEP entity = db.GIA_TUY_CHON_DANH_THIEP.Where(x => (x.ID_BANG_GIA_DANH_THIEP == entityBDO.IdBangGiaDanhThiep)
                && (x.ID_TUY_CHON_DANH_THIEP == entityBDO.IdTuyChonDanhThiep)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    //Không cần thiết kiểm tra trùng vì không có tên
                    /*kq = KiemTraTrung(entityBDO.);
                    if (kq != "")
                        return kq;
                     */
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Bảng giá:{0}_Tùy chọn:{1}", entity.ID_BANG_GIA_DANH_THIEP, entity.ID_TUY_CHON_DANH_THIEP);//trả về số Id
                }
                catch
                {
                    kq = string.Format("Bảng giá:{0}_Tùy chọn:{1} không thành công!", entity.ID_BANG_GIA_DANH_THIEP, entity.ID_TUY_CHON_DANH_THIEP);
                }
            }
            else
            {
                return kq = string.Format("Thông tin Bảng giá {0} và Tùy chọn {1} không tồn tại!", entity.ID_BANG_GIA_DANH_THIEP, entity.ID_TUY_CHON_DANH_THIEP);
            }
            return kq;

        }

        public string Xoa(int idBangGia, int idTuyChon)
        {
            string kq = "";
            GiaTuyChonDanhThiepBDO entityBDO = this.DocTheoId(idBangGia, idTuyChon);
            GIA_TUY_CHON_DANH_THIEP entity = new GIA_TUY_CHON_DANH_THIEP();
            if (entityBDO != null)
            {
                try
                {
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.GIA_TUY_CHON_DANH_THIEP.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa mục {0}_{1} không thành công!", entity.ID_BANG_GIA_DANH_THIEP,
                                    entity.ID_TUY_CHON_DANH_THIEP);
                }
            }
            else
                kq = string.Format("Mục {0}_{1} không tồn tại!", entityBDO.IdBangGiaDanhThiep,
                                    entityBDO.IdTuyChonDanhThiep);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(GiaTuyChonDanhThiepBDO entityBDO, GIA_TUY_CHON_DANH_THIEP entityDAO)
        {
            entityDAO.ID_BANG_GIA_DANH_THIEP = entityBDO.IdBangGiaDanhThiep;
            entityDAO.ID_TUY_CHON_DANH_THIEP = entityBDO.IdTuyChonDanhThiep;            
            entityDAO.gia_ban = entityBDO.GiaBan;
            
        }

        private string KiemTraTrung(int idBangGia = 0, int idTuyChon = 0)
        {
            string kq = "";
            var entity = db.GIA_TUY_CHON_DANH_THIEP.SingleOrDefault(x => (x.ID_BANG_GIA_DANH_THIEP == idBangGia)
                                                    && x.ID_TUY_CHON_DANH_THIEP == idTuyChon);
            if (entity != null)
                kq = string.Format("Mục này đã có {0}v{1}",idBangGia, idTuyChon);
            return kq;
        }




        
       
    }
       
       
}
