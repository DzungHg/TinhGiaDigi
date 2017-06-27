using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class ToBoiBiaCungDAO : IToBoiBiaCungDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<ToBoiBiaCungBDO> DocTatCa()
        {
            List<ToBoiBiaCungBDO> list = null;
            try
            {
                var nguon = db.TO_BOI_BIA_CUNG.Select(x => new ToBoiBiaCungBDO
                {
                    ID = x.ID,                   
                    Ten = x.ten,
                    DoDayCm = (float)x.do_day_cm,                   
                    GiaMuaTo = (int)x.gia_mua_to,                   
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public ToBoiBiaCungBDO DocTheoId(int iD)
        {
            ToBoiBiaCungBDO giay = null;
            try
            {
                var nguon = db.TO_BOI_BIA_CUNG.Where(x => x.ID == iD).Select(x => new ToBoiBiaCungBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DoDayCm = (float)x.do_day_cm,
                    GiaMuaTo = (int)x.gia_mua_to,
                    ThuTu = (int)x.thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(ToBoiBiaCungBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                TO_BOI_BIA_CUNG entity = new  TO_BOI_BIA_CUNG();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.TO_BOI_BIA_CUNG.Add(entity);
                db.SaveChanges();
                kq = string.Format("Tờ bồi:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm tờ bồi {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(ToBoiBiaCungBDO entityBDO)
        {
            TO_BOI_BIA_CUNG entity = db.TO_BOI_BIA_CUNG.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
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
                    kq = string.Format("Sửa Tờ lót ID: {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format(" Sửa Tờ lót {0} không thành công!", entity.ID);
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

            TO_BOI_BIA_CUNG entity = db.TO_BOI_BIA_CUNG.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.TO_BOI_BIA_CUNG.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa Mục tin {0} không thành công!", entity.ten);
                }
            }
            else
                kq = string.Format("Mục tin ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(ToBoiBiaCungBDO entityBDO, TO_BOI_BIA_CUNG entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.do_day_cm = entityBDO.DoDayCm;
                     
            entityDAO.gia_mua_to = entityBDO.GiaMuaTo;
            entityDAO.thu_tu = entityBDO.ThuTu;
         

        }
        private string KiemTraTrung(string tenNhu, int id = 0)
        {
            string kq = "";
            var entity = db.TO_BOI_BIA_CUNG.SingleOrDefault(x => x.ten == tenNhu);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên tờ {0} đã có", tenNhu);
            return kq;
        }
        
    }
}
