using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class MonThanhPhamDAO : IMonThanhPhamDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<MonThanhPhamBDO> DocTatCa()
        {
            List<MonThanhPhamBDO> list = null;
            try
            {
                var nguon = db.DS_THANH_PHAM.Select(x => new MonThanhPhamBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    Ma_01 = x.ma_01,
                    Ma_02 = x.ma_03,
                    Ma_03 = x.ma_03,
                    DaySoLuong = x.day_so_luong,
                    DonViTinh = x.don_vi_tinh,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public MonThanhPhamBDO DocTheoId(int iD)
        {
            MonThanhPhamBDO item = null;
            try
            {
                var nguon = db.DS_THANH_PHAM.Where(x => x.ID == iD).Select(x => new MonThanhPhamBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    Ma_01 = x.ma_01,
                    Ma_02 = x.ma_03,
                    Ma_03 = x.ma_03,
                    DaySoLuong = x.day_so_luong,
                    DonViTinh = x.don_vi_tinh,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                
                item = nguon;
            }
            catch { }

            return item;
        }
        #region Emplement them sua xoa
        public void Them(MonThanhPhamBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public string Sua(MonThanhPhamBDO entityBDO)
        {
            DS_THANH_PHAM entity = db.DS_THANH_PHAM.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                        return kq;
                    //Vượt thì chuyển
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Món thành phẩm ID: {0} thành công", entity.ID);//trả về số Id
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

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        #endregion

        private string KiemTraTrung(string tenMon, int id = 0)
        {
            string kq = "";
            var entity = db.DS_THANH_PHAM.SingleOrDefault(x => x.ten == tenMon);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên món này {0} đã có", tenMon);
            return kq;
        }
        private void ChuyenBDOThanhDAO(MonThanhPhamBDO entityBDO, DS_THANH_PHAM entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.ma_02 = entityBDO.Ma_02;
            entityDAO.ma_03 = entityBDO.Ma_03;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;           
            entityDAO.thu_tu = entityBDO.ThuTu;
            
        }


       
    }
}
