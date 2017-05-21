using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class KhoSanPhamDAO:IKhoSanPhamDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        #region Emplement them sua xoa
        public IEnumerable<KhoSanPhamBDO> LayTatCa()
        {
            List<KhoSanPhamBDO> list = null;
            try
            {
                var nguon = db.KHO_SAN_PHAM.Select(x => new KhoSanPhamBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    KhoCatCao = (float)x.Chieu_cat_cao,
                    KhoCatRong = (float)x.Chieu_cat_rong,
                    DienGiai = x.dien_giai,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public KhoSanPhamBDO LayTheoId(int iD)
        {
            KhoSanPhamBDO item = null;
            try
            {
                var nguon = db.KHO_SAN_PHAM.Where(x => x.ID == iD).Select(x => new KhoSanPhamBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    KhoCatCao = (float)x.Chieu_cat_cao,
                    KhoCatRong = (float)x.Chieu_cat_rong,
                    DienGiai = x.dien_giai,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                
                item = nguon;
            }
            catch { }

            return item;
        }

        public string Them(KhoSanPhamBDO entityBDO)
        {
            string kq = "";
            try
            {
                 kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                KHO_SAN_PHAM entity = new KHO_SAN_PHAM();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.KHO_SAN_PHAM.Add(entity);
                db.SaveChanges();
                kq = string.Format("Khổ Sản phẩm:{0}", entity.ID);
            }
            catch (Exception e)
            {
                kq = string.Format("Thêm Khổ SP {0} bị lỗi: {1}!", entityBDO.ID, e.Message);
            }
            return kq;
        }

        public string Sua(KhoSanPhamBDO entityBDO)
        {
            KHO_SAN_PHAM entity = db.KHO_SAN_PHAM.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
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
                    kq = string.Format("Sửa Khổ ID: {0} thành công", entity.ID);//trả về số Id
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
            throw new NotImplementedException();
        }
        #endregion
        private void ChuyenBDOThanhDAO(KhoSanPhamBDO entityBDO, KHO_SAN_PHAM entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.Chieu_cat_rong = entityBDO.KhoCatRong;
            entityDAO.Chieu_cat_cao = entityBDO.KhoCatCao;            
            entityDAO.dien_giai = entityBDO.DienGiai;
            entityDAO.Thu_tu = entityBDO.ThuTu;


        }
          private string KiemTraTrung(string tenKho, int id = 0)
          {
              string kq = "";
              var entity = db.KHO_SAN_PHAM.SingleOrDefault(x => x.Ten == tenKho );
              if (entity != null && entity.ID != id)
                  kq = string.Format(" Khổ này {0} đã có", tenKho);
              return kq;
          }
          

    }
}
