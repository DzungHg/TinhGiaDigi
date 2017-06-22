using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class NguoiDungDAO : INguoiDungDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<NguoiDungBDO> DocTatCa()
        {
            List<NguoiDungBDO> list = null;
            try
            {
                var nguon = db.NGUOI_DUNG.Select(x => new NguoiDungBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    ChoHangKhachHang = x.cho_hang_khach_hang,
                    FormCoTheMo = x.form_co_the_mo,
                    HieuLuc = (bool)x.hieu_luc
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public NguoiDungBDO DocTheoId(int iD)
        {
            NguoiDungBDO ngDung = null;
            try
            {
                var nguon = db.NGUOI_DUNG.Where(x => x.ID == iD).Select(x => new NguoiDungBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    ChoHangKhachHang = x.cho_hang_khach_hang,
                    FormCoTheMo = x.form_co_the_mo,
                    HieuLuc = (bool)x.hieu_luc
                }).SingleOrDefault();
                ngDung = nguon;
            }
            catch { }

            return ngDung;
        }
        public NguoiDungBDO DocTheoTenDangNhap(string tenDangNhap)
        {
            NguoiDungBDO ngDung = null;
            try
            {
                var nguon = db.NGUOI_DUNG.Where(x => x.ten == tenDangNhap).Select(x => new NguoiDungBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    ChoHangKhachHang = x.cho_hang_khach_hang,
                    FormCoTheMo = x.form_co_the_mo,
                    HieuLuc = (bool)x.hieu_luc
                }).SingleOrDefault();
                ngDung = nguon;
            }
            catch { }

            return ngDung;
        }
        #region Them, sưa, xoa
        public string Them(NguoiDungBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public string Sua(NguoiDungBDO entityBDO)
        {
            NGUOI_DUNG entity = db.NGUOI_DUNG.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = "";
            if (entity != null)
            {
                try
                {                    
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                        return kq;
                 
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Lưu mục tin {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format("Sửa mục tin {0} không thành công!", entity.ID);
                }
            }
            else
            {
                return kq = string.Format("Mục tin {0} không tồn tại!", entity.ID);
            }
            return kq;

        }

        public string Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        private string KiemTraTrung(string value, int id = 0)
        {
            string kq = "";
            var entity = db.CAN_GAP.SingleOrDefault(x => x.Ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(NguoiDungBDO entityBDO, NGUOI_DUNG entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.cho_hang_khach_hang = entityBDO.ChoHangKhachHang;
            entityDAO.form_co_the_mo = entityBDO.FormCoTheMo;
            entityDAO.hieu_luc = entityBDO.HieuLuc;
        }
        #endregion





      
    }
}
