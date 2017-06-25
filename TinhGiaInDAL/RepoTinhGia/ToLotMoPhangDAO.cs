using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class ToLotMoPhangDAO : IToLotMoPhangDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<ToLotMoPhangBDO> DocTatCa()
        {
            List<ToLotMoPhangBDO> list = null;
            try
            {
                var nguon = db.TO_LOT_MO_PHANG.Select(x => new ToLotMoPhangBDO
                {
                    ID = x.ID,                   
                    Ten = x.ten,
                    TenNhaCungCap = x.ten_nha_cung_cap,
                    DienGiai = x.dien_giai,                    
                    GiaMuaTo = (int)x.gia_mua_to,                   
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public ToLotMoPhangBDO DocTheoId(int iD)
        {
            ToLotMoPhangBDO giay = null;
            try
            {
                var nguon = db.TO_LOT_MO_PHANG.Where(x => x.ID == iD).Select(x => new ToLotMoPhangBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    TenNhaCungCap = x.ten_nha_cung_cap,
                    DienGiai = x.dien_giai,
                    GiaMuaTo = (int)x.gia_mua_to,
                    ThuTu = (int)x.thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(ToLotMoPhangBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                TO_LOT_MO_PHANG entity = new TO_LOT_MO_PHANG();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.TO_LOT_MO_PHANG.Add(entity);
                db.SaveChanges();
                kq = string.Format("Tờ lót:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Tờ lót {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(ToLotMoPhangBDO entityBDO)
        {
            TO_LOT_MO_PHANG entity = db.TO_LOT_MO_PHANG.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
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

            TO_LOT_MO_PHANG entity = db.TO_LOT_MO_PHANG.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.TO_LOT_MO_PHANG.Remove(entity);
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
        private void ChuyenBDOThanhDAO(ToLotMoPhangBDO entityBDO, TO_LOT_MO_PHANG entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.ma_nha_cung_cap = entityBDO.MaNhaCungCap;
            entityDAO.ten_nha_cung_cap = entityBDO.TenNhaCungCap;
            entityDAO.dien_giai = entityBDO.DienGiai;            
            entityDAO.gia_mua_to = entityBDO.GiaMuaTo;
            entityDAO.thu_tu = entityBDO.ThuTu;
         

        }
        private string KiemTraTrung(string tenNhu, int id = 0)
        {
            string kq = "";
            var entity = db.TO_LOT_MO_PHANG.SingleOrDefault(x => x.ten == tenNhu);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên tờ {0} đã có", tenNhu);
            return kq;
        }
        
    }
}
