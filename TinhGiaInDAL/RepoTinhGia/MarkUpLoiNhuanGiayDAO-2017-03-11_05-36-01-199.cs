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
        IEnumerable<MarkUpLoiNhuanGiayBDO> LayTatCa()
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

            MarkUpLoiNhuanGiayBDO list = null;
            try
            {
                list = db.MARK_UP_LOI_NHUAN_GIAY.Where(x => (x.ID_DANH_MUC_GIAY == idDanhMucGiay)
                    && (x.ID_HANG_KHACH_HANG == idHangKH)).Select(x => new MarkUpLoiNhuanGiayBDO
                {
                    IdDanhMucGiay = x.ID_DANH_MUC_GIAY,
                    IdHangKhachHang = x.ID_HANG_KHACH_HANG,
                    TiLeLoiNhuanTrenDoanhThu = (int)x.Ty_le_mark_up
                }).SingleOrDefault();

            }
            catch { }

            return list;
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
                /*kq = KiemTraTrung(ngDung.Ten);
                if (kq != "")
                    return kq; */
                MARK_UP_LOI_NHUAN_GIAY entity = new MARK_UP_LOI_NHUAN_GIAY();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.MARK_UP_LOI_NHUAN_GIAY.Add(entity);
                db.SaveChanges();
                kq = entity.ID.ToString();
            }
            catch
            {
                kq = String.Format("Thêm mới {0} không thành công!", ngDung.Ten);
            }
            return kq;
        }


        public void Sua(MarkUpLoiNhuanGiayBDO entityBDO)
        {
            throw new NotImplementedException();
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




    }
       
       
}
