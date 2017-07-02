using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class GiaTuyChonTheNhuaDAO : IGiaTuyChonTheNhuaDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<GiaTuyChonTheNhuaBDO> DocTatCa()
        {
            List<GiaTuyChonTheNhuaBDO> list = null;
            try
            {
                var nguon = db.GIA_TUY_CHON_THE_NHUA.Select(x => new GiaTuyChonTheNhuaBDO
                {
                    IdBangGiaTheNhua = x.ID_BANG_GIA_THE_NHUA,
                    IdTuyChonTheNhua = x.ID_TUY_CHON_THE_NHUA,
                    TenTuyChon = x.TUY_CHON_THE_NHUA.ten, //chỉ get không set được
                    GiaBan = (int)x.gia_ban
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public GiaTuyChonTheNhuaBDO DocTheoId(int idBangGia, int idTuyChon)
        {

            GiaTuyChonTheNhuaBDO item = null;
            try
            {
                item = db.GIA_TUY_CHON_THE_NHUA.Where(x => (x.ID_BANG_GIA_THE_NHUA == idBangGia)
                    && (x.ID_TUY_CHON_THE_NHUA == idTuyChon)).Select(x => new GiaTuyChonTheNhuaBDO
                {
                    IdBangGiaTheNhua = x.ID_BANG_GIA_THE_NHUA,
                    IdTuyChonTheNhua = x.ID_TUY_CHON_THE_NHUA,
                    TenTuyChon = x.TUY_CHON_THE_NHUA.ten,
                    TenBangGia = x.BANG_GIA_THE_NHUA.ten,
                    GiaBan = (int)x.gia_ban
                }).SingleOrDefault();

            }
            catch { }

            return item;
        }
        public IEnumerable<GiaTuyChonTheNhuaBDO> DocTheoIdBangGia(int iD)
        {
            List<GiaTuyChonTheNhuaBDO> list = null;
            try
            {
                var nguon = db.GIA_TUY_CHON_THE_NHUA.Where(x => x.ID_BANG_GIA_THE_NHUA == iD).Select(x => new GiaTuyChonTheNhuaBDO
                {
                    IdBangGiaTheNhua = x.ID_BANG_GIA_THE_NHUA,
                    IdTuyChonTheNhua = x.ID_TUY_CHON_THE_NHUA,
                    TenTuyChon = x.TUY_CHON_THE_NHUA.ten,
                    
                    GiaBan = (int)x.gia_ban
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public IEnumerable<GiaTuyChonTheNhuaBDO> DocTheoIdTuyChon(int iD)
        {
            List<GiaTuyChonTheNhuaBDO> list = null;
            try
            {
                var nguon = db.GIA_TUY_CHON_THE_NHUA.Where(x => x.ID_TUY_CHON_THE_NHUA == iD).Select(x => new GiaTuyChonTheNhuaBDO
                {
                    IdBangGiaTheNhua = x.ID_BANG_GIA_THE_NHUA,
                    IdTuyChonTheNhua = x.ID_TUY_CHON_THE_NHUA,                  
                    TenBangGia = x.BANG_GIA_THE_NHUA.ten,
                    GiaBan = (int)x.gia_ban
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }




        #region Them, sưa, xoa
        public string Them(GiaTuyChonTheNhuaBDO entityBDO)
        {
        
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.IdBangGiaTheNhua, entityBDO.IdTuyChonTheNhua);
                if (kq != "")
                    return kq;
                GIA_TUY_CHON_THE_NHUA entity = new GIA_TUY_CHON_THE_NHUA();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.GIA_TUY_CHON_THE_NHUA.Add(entity);
                db.SaveChanges();
                kq = string.Format("BangGia:{0}_TuyChon:{1}", entity.ID_BANG_GIA_THE_NHUA, entity.ID_TUY_CHON_THE_NHUA);
            }
            catch
            {
                kq = string.Format("BangGia_TuyChon {0}-{1} không tồn tại!", entityBDO.IdBangGiaTheNhua, entityBDO.IdTuyChonTheNhua);
            }
            return kq;
        }


        public string Sua(GiaTuyChonTheNhuaBDO entityBDO)
        {
            GIA_TUY_CHON_THE_NHUA entity = db.GIA_TUY_CHON_THE_NHUA.Where(x => (x.ID_BANG_GIA_THE_NHUA == entityBDO.IdBangGiaTheNhua)
                && (x.ID_TUY_CHON_THE_NHUA == entityBDO.IdTuyChonTheNhua)).SingleOrDefault();
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
                    kq = string.Format("Bảng giá:{0}_Tùy chọn:{1}", entity.ID_BANG_GIA_THE_NHUA, entity.ID_TUY_CHON_THE_NHUA);//trả về số Id
                }
                catch
                {
                    kq = string.Format("Bảng giá:{0}_Tùy chọn:{1} không thành công!", entity.ID_BANG_GIA_THE_NHUA, entity.ID_TUY_CHON_THE_NHUA);
                }
            }
            else
            {
                return kq = string.Format("Thông tin Bảng giá {0} và Tùy chọn {1} không tồn tại!", entity.ID_BANG_GIA_THE_NHUA, entity.ID_TUY_CHON_THE_NHUA);
            }
            return kq;

        }
        public string Xoa(int idBangGia, int idTuyChon)
        {
            string kq = "";
            GiaTuyChonTheNhuaBDO entityBDO = this.DocTheoId(idBangGia, idTuyChon);
            GIA_TUY_CHON_THE_NHUA entity = new GIA_TUY_CHON_THE_NHUA();
            if (entityBDO != null)
            {
                try
                {
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.GIA_TUY_CHON_THE_NHUA.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa mục {0}_{1} không thành công!", entity.ID_BANG_GIA_THE_NHUA,
                                    entity.ID_TUY_CHON_THE_NHUA);
                }
            }
            else
                kq = string.Format("Mục {0}_{1} không tồn tại!", entityBDO.IdBangGiaTheNhua,
                                    entityBDO.IdTuyChonTheNhua);
            return kq; ;
        }

       
        #endregion
        private void ChuyenBDOThanhDAO(GiaTuyChonTheNhuaBDO entityBDO, GIA_TUY_CHON_THE_NHUA entityDAO)
        {
            entityDAO.ID_BANG_GIA_THE_NHUA = entityBDO.IdBangGiaTheNhua;
            entityDAO.ID_TUY_CHON_THE_NHUA = entityBDO.IdTuyChonTheNhua;
           
            entityDAO.gia_ban = entityBDO.GiaBan;
            
        }

        private string KiemTraTrung(int idBangGia = 0, int idTuyChon = 0)
        {
            string kq = "";
            var entity = db.GIA_TUY_CHON_THE_NHUA.SingleOrDefault(x => (x.ID_BANG_GIA_THE_NHUA == idBangGia)
                                                    && x.ID_TUY_CHON_THE_NHUA == idTuyChon);
            if (entity != null)
                kq = string.Format("Mục này đã có {0}v{1}",idBangGia,idTuyChon);
            return kq;
        }




        
       
    }
       
       
}
