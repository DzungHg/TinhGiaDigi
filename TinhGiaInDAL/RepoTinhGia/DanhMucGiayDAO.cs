using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class DanhMucGiayDAO:IDanhMucGiayDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<DanhMucGiayBDO> LayTatCa()
        {
            List<DanhMucGiayBDO> list = null;
            try
            {
                var nguon = db.DANH_MUC_GIAY.Select(x => new DanhMucGiayBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    NhaCungCap = x.Nha_cung_cap,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public IEnumerable<DanhMucGiayBDO> LayTheoNhaCungCap(string tenNCC)
        {
            List<DanhMucGiayBDO> list = null;
            try
            {
                var nguon = db.DANH_MUC_GIAY.Where(x => x.Nha_cung_cap == tenNCC.Trim()).Select(x => new DanhMucGiayBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    NhaCungCap = x.Nha_cung_cap,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public IEnumerable<string> NhaCungCapS()
        {            
            var dsNguon = db.DANH_MUC_GIAY.Select(x => x.Nha_cung_cap).Distinct().ToList();         
            return dsNguon;

        }

        public DanhMucGiayBDO LayTheoId(int iD)
        {
            DanhMucGiayBDO dm = null;
            try
            {
                var nguon = db.DANH_MUC_GIAY.Where(x => x.ID == iD).Select(x => new DanhMucGiayBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    NhaCungCap = x.Nha_cung_cap,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public string Them(DanhMucGiayBDO entityBDO)
        {
             string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten, entityBDO.NhaCungCap);
                if (kq != "")
                    return kq;
                DANH_MUC_GIAY entity = new DANH_MUC_GIAY();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.DANH_MUC_GIAY.Add(entity);
                db.SaveChanges();
                kq = string.Format("Danh mục:{0}_", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Danh mục {0}-{1} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(TinhGiaInBDO.DanhMucGiayBDO entityBDO)
        {
            DANH_MUC_GIAY entity = db.DANH_MUC_GIAY.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.NhaCungCap, entityBDO.ID);
                    if (kq != "")
                        return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Thêm: {0} thành công", entity.ID);//trả về số Id
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
            ///Đầu tiên kểm xem Danh mục có giấy không
            ///Nếu có thì không thể xóa
            ///đang tiến hành làm tiếp
            string kq = "";

            DANH_MUC_GIAY entity = db.DANH_MUC_GIAY.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.DANH_MUC_GIAY.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = String.Format("Xóa Danh mục {0} không thành công!", entity.Ten);
                }
            }
            else
                kq = String.Format("Danh mục ID:{0} không tồn tại!", iD);
            return kq;

        }
        #endregion
        private string KiemTraTrung(string tenDanhMuc, string tenNhaCC, int id = 0)
        {
            string kq = "";
            var entity = db.DANH_MUC_GIAY.SingleOrDefault(x => (x.Ten == tenDanhMuc) && (x.Nha_cung_cap == tenNhaCC));
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên Danh mục {0} đã có rồi!", tenDanhMuc);
            return kq;
        }
        private void ChuyenBDOThanhDAO(DanhMucGiayBDO entityBDO, DANH_MUC_GIAY entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.Nha_cung_cap = entityBDO.NhaCungCap;
            entityDAO.Thu_tu = entityBDO.ThuTu;
        }
    }
}
