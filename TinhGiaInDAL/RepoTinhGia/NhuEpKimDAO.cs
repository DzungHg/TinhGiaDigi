using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class NhuEpKimDAO : INhuEpKimDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<NhuEpKimBDO> DocTatCa()
        {
            List<NhuEpKimBDO> list = null;
            try
            {
                var nguon = db.NHU_EP_KIM.Select(x => new NhuEpKimBDO
                {
                    ID = x.ID,                   
                    Ten = x.Ten,
                    TenNhaCungCap = x.ten_nha_cung_cap,
                    DienGiai = x.Dien_giai,                    
                    GiaMuaCm2 = (int)x.Gia_mua_cm2,
                    IDEPKIM = (int)x.ID_EP_KIM,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<NhuEpKimBDO> DocTheoIdEpkim(int idEpKim)
        {        
            List<NhuEpKimBDO> list = null;
            try
            {
                var nguon = db.NHU_EP_KIM.Where(x => x.ID_EP_KIM == idEpKim).Select(x => new NhuEpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    MaNhaCungCap = x.Ma_nha_cung_cap,
                    TenNhaCungCap = x.ten_nha_cung_cap,                   
                    DienGiai = x.Dien_giai,
                    GiaMuaCm2 = (int)x.Gia_mua_cm2,
                    IDEPKIM = (int)x.ID_EP_KIM,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public NhuEpKimBDO DocTheoId(int iD)
        {
            NhuEpKimBDO giay = null;
            try
            {
                var nguon = db.NHU_EP_KIM.Where(x => x.ID == iD).Select(x => new NhuEpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    MaNhaCungCap = x.Ma_nha_cung_cap,
                    TenNhaCungCap = x.ten_nha_cung_cap,                   
                    DienGiai = x.Dien_giai,
                    GiaMuaCm2 = (int)x.Gia_mua_cm2,
                    IDEPKIM = (int)x.ID_EP_KIM,
                    ThuTu = (int)x.Thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(NhuEpKimBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten, entityBDO.IDEPKIM);
                if (kq != "")
                    return kq;
                NHU_EP_KIM entity = new NHU_EP_KIM();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.NHU_EP_KIM.Add(entity);
                db.SaveChanges();
                kq = string.Format("Ép kim:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Nhũ ép kim {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(NhuEpKimBDO entityBDO)
        {
            NHU_EP_KIM entity = db.NHU_EP_KIM.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.IDEPKIM, entityBDO.ID);
                    if (kq != "")
                        return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Nhũ ép kim ID: {0} thành công", entity.ID);//trả về số Id
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

            NHU_EP_KIM entity = db.NHU_EP_KIM.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.NHU_EP_KIM.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa Nhũ ép Kim {0} không thành công!", entity.Ten);
                }
            }
            else
                kq = string.Format("Nhũ ép kim ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(NhuEpKimBDO entityBDO, NHU_EP_KIM entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.Ma_nha_cung_cap = entityBDO.MaNhaCungCap;
            entityDAO.ten_nha_cung_cap = entityBDO.TenNhaCungCap;
            entityDAO.Dien_giai = entityBDO.DienGiai;            
            entityDAO.Gia_mua_cm2 = entityBDO.GiaMuaCm2;
            entityDAO.Thu_tu = entityBDO.ThuTu;
            entityDAO.ID_EP_KIM = entityBDO.IDEPKIM;

        }
        private string KiemTraTrung(string tenNhu, int idEpKim, int id = 0)
        {
            string kq = "";
            var entity = db.NHU_EP_KIM.SingleOrDefault(x => x.Ten == tenNhu &&
                x.ID_EP_KIM == idEpKim);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên Ép kim {0} đã có", tenNhu);
            return kq;
        }
        
    }
}
