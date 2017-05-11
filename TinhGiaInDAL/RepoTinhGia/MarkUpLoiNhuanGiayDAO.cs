using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class MarkUpLoiNhuanGiayDAO : IMarkUpLoiNhuanGiayDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<MarkUpLoiNhuanGiayBDO> LayTatCa()
        {
            List<MarkUpLoiNhuanGiayBDO> list = null;
            try
            {
                var nguon = db.MARK_UP_LOI_NHUAN_GIAY.Select(x => new MarkUpLoiNhuanGiayBDO
                {
                    IdDanhMucGiay = x.ID_DANH_MUC_GIAY,
                    IdHangKhachHang = x.ID_HANG_KHACH_HANG,
                    TiLeLoiNhuanTrenDoanhThu = (int)x.Ty_le_mark_up
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public MarkUpLoiNhuanGiayBDO LayTheoId(int idDanhMucGiay, int idHangKH)
        {

            MarkUpLoiNhuanGiayBDO item = null;
            try
            {
                item = db.MARK_UP_LOI_NHUAN_GIAY.Where(x => (x.ID_DANH_MUC_GIAY == idDanhMucGiay)
                    && (x.ID_HANG_KHACH_HANG == idHangKH)).Select(x => new MarkUpLoiNhuanGiayBDO
                {
                    IdDanhMucGiay = x.ID_DANH_MUC_GIAY,
                    IdHangKhachHang = x.ID_HANG_KHACH_HANG,
                    TenHangKhachHang = x.HANG_KHACH_HANG.Ten,
                    TiLeLoiNhuanTrenDoanhThu = (int)x.Ty_le_mark_up
                }).SingleOrDefault();

            }
            catch { }

            return item;
        }
        public IEnumerable<MarkUpLoiNhuanGiayBDO> LayTheoIdDanhMucGiay(int iD)
        {
            List<MarkUpLoiNhuanGiayBDO> list = null;
            try
            {
                var nguon = db.MARK_UP_LOI_NHUAN_GIAY.Where(x => x.ID_DANH_MUC_GIAY == iD).Select(x => new MarkUpLoiNhuanGiayBDO
                {
                    IdDanhMucGiay = x.ID_DANH_MUC_GIAY,
                    IdHangKhachHang = x.ID_HANG_KHACH_HANG,
                    TenHangKhachHang = x.HANG_KHACH_HANG.Ten,
                    TiLeLoiNhuanTrenDoanhThu = (int)x.Ty_le_mark_up
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public IEnumerable<MarkUpLoiNhuanGiayBDO> LayTheoIdHangKH(int iD)
        {
            List<MarkUpLoiNhuanGiayBDO> list = null;
            try
            {
                var nguon = db.MARK_UP_LOI_NHUAN_GIAY.Where(x => x.ID_HANG_KHACH_HANG == iD).Select(x => new MarkUpLoiNhuanGiayBDO
                {
                    IdDanhMucGiay = x.ID_DANH_MUC_GIAY,
                    IdHangKhachHang = x.ID_HANG_KHACH_HANG,
                    TiLeLoiNhuanTrenDoanhThu = (int)x.Ty_le_mark_up
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }




        #region Them, sưa, xoa
        public string Them(MarkUpLoiNhuanGiayBDO entityBDO)
        {
        
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.IdDanhMucGiay, entityBDO.IdHangKhachHang);
                if (kq != "")
                    return kq;
                MARK_UP_LOI_NHUAN_GIAY entity = new MARK_UP_LOI_NHUAN_GIAY();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.MARK_UP_LOI_NHUAN_GIAY.Add(entity);
                db.SaveChanges();
                kq = string.Format("DMG:{0}_HKH:{1}", entity.ID_DANH_MUC_GIAY, entity.ID_HANG_KHACH_HANG);
            }
            catch
            {
                kq = string.Format("Thêm DMG_HKH {0}-{1} không tồn tại!", entityBDO.IdDanhMucGiay, entityBDO.IdHangKhachHang);
            }
            return kq;
        }


        public string Sua(MarkUpLoiNhuanGiayBDO entityBDO)
        {
            MARK_UP_LOI_NHUAN_GIAY entity = db.MARK_UP_LOI_NHUAN_GIAY.Where(x => (x.ID_DANH_MUC_GIAY == entityBDO.IdDanhMucGiay)
                && (x.ID_HANG_KHACH_HANG == entityBDO.IdHangKhachHang)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    //Không cần thiết kiểm tra trùng
                    /*kq = KiemTraTrung(entityBDO.);
                    if (kq != "")
                        return kq;
                     */
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("DMG:{0}_HKH:{1}", entity.ID_DANH_MUC_GIAY, entity.ID_HANG_KHACH_HANG);//trả về số Id
                }
                catch
                {
                    kq = string.Format(" Sửa record DMG:{0}_HKH:{1} không thành công!", entity.ID_DANH_MUC_GIAY, entity.ID_HANG_KHACH_HANG);
                }
            }
            else
            {
                return kq = string.Format("Thông tin DMG_HKH {0}-{1} không tồn tại!", entity.ID_DANH_MUC_GIAY, entity.ID_HANG_KHACH_HANG);
            }
            return kq;

        }

        public void Xoa(int idDanhMucGiay, int idHangKH)
        {
            throw new NotImplementedException();
        }
        #endregion
        private void ChuyenBDOThanhDAO(MarkUpLoiNhuanGiayBDO entityBDO, MARK_UP_LOI_NHUAN_GIAY entityDAO)
        {
            entityDAO.ID_HANG_KHACH_HANG = entityBDO.IdHangKhachHang;
            entityDAO.ID_DANH_MUC_GIAY = entityBDO.IdDanhMucGiay;
            entityDAO.Ty_le_mark_up = entityBDO.TiLeLoiNhuanTrenDoanhThu;
            
        }

        private string KiemTraTrung(int idDanhMucGiay = 0, int IdHangKH = 0)
        {
            string kq = "";
            var entity = db.MARK_UP_LOI_NHUAN_GIAY.SingleOrDefault(x => (x.ID_DANH_MUC_GIAY == idDanhMucGiay)
                                                    && x.ID_HANG_KHACH_HANG == IdHangKH);
            if (entity != null)
                kq = string.Format("Mục này đã có {0}v{1}",idDanhMucGiay,IdHangKH);
            return kq;
        }
 


    }
       
       
}
