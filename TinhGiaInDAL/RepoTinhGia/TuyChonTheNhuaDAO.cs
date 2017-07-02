using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class TuyChonTheNhuaDAO : ITuyChonTheNhuaDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<TuyChonTheNhuaBDO> DocTatCa()
        {
            List<TuyChonTheNhuaBDO> list = null;
            try
            {
                var nguon = db.TUY_CHON_THE_NHUA.Select(x => new TuyChonTheNhuaBDO
                {
                    ID = x.ID,                   
                    Ten = x.ten,                                   
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public TuyChonTheNhuaBDO DocTheoId(int iD)
        {
            TuyChonTheNhuaBDO giay = null;
            try
            {
                var nguon = db.TUY_CHON_THE_NHUA.Where(x => x.ID == iD).Select(x => new TuyChonTheNhuaBDO
                {
                    ID = x.ID,
                    Ten = x.ten,                 
                    ThuTu = (int)x.thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(TuyChonTheNhuaBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                TUY_CHON_DANH_THIEP entity = new TUY_CHON_DANH_THIEP();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.TUY_CHON_DANH_THIEP.Add(entity);
                db.SaveChanges();
                kq = string.Format("Tùy chọ:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Tùy chọn {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(TuyChonTheNhuaBDO entityBDO)
        {
            TUY_CHON_DANH_THIEP entity = db.TUY_CHON_DANH_THIEP.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
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
                    kq = string.Format("Sửa Tùy chọn ID: {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format(" Sửa Tùy chọn {0} không thành công!", entity.ID);
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

            TUY_CHON_DANH_THIEP entity = db.TUY_CHON_DANH_THIEP.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.TUY_CHON_DANH_THIEP.Remove(entity);
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
        private void ChuyenBDOThanhDAO(TuyChonTheNhuaBDO entityBDO, TUY_CHON_DANH_THIEP entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;           
            entityDAO.thu_tu = entityBDO.ThuTu;
         

        }
        private string KiemTraTrung(string tenTuyChon, int id = 0)
        {
            string kq = "";
            var entity = db.TUY_CHON_DANH_THIEP.SingleOrDefault(x => x.ten == tenTuyChon);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên tùy chọn {0} đã có", tenTuyChon);
            return kq;
        }
        
    }
}
