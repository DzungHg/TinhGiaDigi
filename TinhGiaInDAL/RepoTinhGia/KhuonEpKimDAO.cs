using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class KhuonEpKimDAO : IKhuonEpKimDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<KhuonEpKimBDO> DocTatCa()
        {
            List<KhuonEpKimBDO> list = null;
            try
            {
                var nguon = db.KHUON_EP_KIM.Select(x => new KhuonEpKimBDO
                {
                    ID = x.ID,                   
                    Ten = x.Ten,
                    DienGiai = x.Dien_giai,                    
                    GiaMua = (int)x.Gia_mua,
                    IDEPKIM = (int)x.ID_EP_KIM,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<KhuonEpKimBDO> DocTheoIdEpkim(int idEpKim)
        {           
            List<KhuonEpKimBDO> list = null;
            try
            {
                var nguon = db.KHUON_EP_KIM.Where(x => x.ID_EP_KIM == idEpKim).Select(x => new KhuonEpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    DienGiai = x.Dien_giai,
                    GiaMua = (int)x.Gia_mua,
                    IDEPKIM = (int)x.ID_EP_KIM,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public KhuonEpKimBDO DocTheoId(int iD)
        {
            KhuonEpKimBDO giay = null;
            try
            {
                var nguon = db.KHUON_EP_KIM.Where(x => x.ID == iD).Select(x => new KhuonEpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    DienGiai = x.Dien_giai,
                    GiaMua = (int)x.Gia_mua,
                    IDEPKIM = (int)x.ID_EP_KIM,
                    ThuTu = (int)x.Thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(KhuonEpKimBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                KHUON_EP_KIM entity = new KHUON_EP_KIM();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.KHUON_EP_KIM.Add(entity);
                db.SaveChanges();
                kq = string.Format("Khuôn Ép kim:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format(" Khuôn Ép kim{0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(KhuonEpKimBDO entityBDO)
        {
            KHUON_EP_KIM entity = db.KHUON_EP_KIM.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                        return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Khuôn ép kim ID: {0} thành công", entity.ID);//trả về số Id
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

            KHUON_EP_KIM entity = db.KHUON_EP_KIM.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.KHUON_EP_KIM.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa Khuôn ép Kim {0} không thành công!", entity.Ten);
                }
            }
            else
                kq = string.Format("Khuôn ép kim ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(KhuonEpKimBDO entityBDO, KHUON_EP_KIM entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;            
            entityDAO.Dien_giai = entityBDO.DienGiai;            
            entityDAO.Gia_mua = entityBDO.GiaMua;
            entityDAO.Thu_tu = entityBDO.ThuTu;
            entityDAO.ID_EP_KIM = entityBDO.IDEPKIM;

        }
        private string KiemTraTrung(string tenGiay, int id = 0)
        {
            string kq = "";
            var entity = db.KHUON_EP_KIM.SingleOrDefault(x => x.Ten == tenGiay);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên Khuôn Ép kim {0} {1} {2}gsm đã có", tenGiay);
            return kq;
        }


        
    }
}
