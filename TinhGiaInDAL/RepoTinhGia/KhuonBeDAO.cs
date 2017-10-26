using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class KhuonBeDAO : IKhuonBeDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<KhuonBeBDO> DocTatCa()
        {
            List<KhuonBeBDO> list = null;
            try
            {
                var nguon = db.KHUON_BE.Select(x => new KhuonBeBDO
                {
                    ID = x.ID,                   
                    Ten = x.ten,
                    
                    
                    DienGiai = x.dien_giai,                    
                    GiaMua = (int)x.gia_mua,
                    IDMAYBE = (int)x.ID_MAY_BE,
                    SoLanBeToiDa = (int)x.so_lan_tieu_hao,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<KhuonBeBDO> DocTheoIdMayBe(int idMayBe)
        {
            List<KhuonBeBDO> list = null;
            try
            {
                var nguon = db.KHUON_BE.Where(x => x.ID_MAY_BE == idMayBe).Select(x => new KhuonBeBDO
                {
                    ID = x.ID,
                    Ten = x.ten,


                    DienGiai = x.dien_giai,
                    GiaMua = (int)x.gia_mua,
                    IDMAYBE = (int)x.ID_MAY_BE,
                    SoLanBeToiDa = (int)x.so_lan_tieu_hao,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public KhuonBeBDO DocTheoId(int iD)
        {
            KhuonBeBDO giay = null;
            try
            {
                var nguon = db.KHUON_BE.Where(x => x.ID == iD).Select(x => new KhuonBeBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    GiaMua = (int)x.gia_mua,
                    IDMAYBE = (int)x.ID_MAY_BE,
                    SoLanBeToiDa = (int)x.so_lan_tieu_hao,
                    ThuTu = (int)x.thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(KhuonBeBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten, entityBDO.IDMAYBE);
                if (kq != "")
                    return kq;
                KHUON_BE entity = new KHUON_BE();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.KHUON_BE.Add(entity);
                db.SaveChanges();
                kq = string.Format("Khuôn bế:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Khuôn bế {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(KhuonBeBDO entityBDO)
        {
            KHUON_BE entity = db.KHUON_BE.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.IDMAYBE, entityBDO.ID);
                    if (kq != "")
                        return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Khuôn bế ID: {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format(" Sửa record {0} không thành công!", entity.ID);
                }
            }
            else
            {
                return kq = string.Format("Thông tin {0} không tồn tại!", entity.ID);
            }
            return kq;
        }

        public string Xoa(int iD)
        {
            string kq = "";

            KHUON_BE entity = db.KHUON_BE.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.KHUON_BE.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa Khuôn bế {0} không thành công!", entity.ten);
                }
            }
            else
                kq = string.Format("Khuôn bế ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(KhuonBeBDO entityBDO, KHUON_BE entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;            
            entityDAO.dien_giai = entityBDO.DienGiai;            
            entityDAO.gia_mua = entityBDO.GiaMua;
            entityDAO.thu_tu = entityBDO.ThuTu;
            entityDAO.ID_MAY_BE = entityBDO.IDMAYBE;

        }
        private string KiemTraTrung(string tenKhuon, int idMayBe, int id = 0)
        {
            string kq = "";
            var entity = db.KHUON_BE.SingleOrDefault(x => x.ten == tenKhuon &&
                x.ID_MAY_BE == idMayBe);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên Khuôn bế {0} đã có", tenKhuon);
            return kq;
        }
        
    }
}
