using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class YeuCauTinhGiaInDAO : IYeuCauTinhGiaInDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<YeuCauTinhGiaInBDO> DocTatCa()
        {
            List<YeuCauTinhGiaInBDO> list = null;
            try
            {
                var nguon = db.YEU_CAU_TINH_GIA_IN.Select(x => new YeuCauTinhGiaInBDO
                {
                    ID = x.ID,
                    IdNguoiDung = (int)x.ID_NGUOI_DUNG,
                    NgayYeuCau = (DateTime)x.ngay_yeu_cau,
                    HoTen = x.ho_ten,
                    CongTy = x.cong_ty,
                    SoDienThoai = x.so_dien_thoai,
                    Email = x.email,
                    NoiDung = x.noi_dung,
                    ThamChieuTicket = x.tham_chieu_ticket,
                    PhanChoNhanVien = x.phan_cho_nhan_vien,
                    TinhTrang = (int)x.tinh_trang
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public YeuCauTinhGiaInBDO DocTheoId(int iD)
        {
            YeuCauTinhGiaInBDO giay = null;
            try
            {
                var nguon = db.YEU_CAU_TINH_GIA_IN.Where(x => x.ID == iD).Select(x => new YeuCauTinhGiaInBDO
                {
                    ID = x.ID,
                    IdNguoiDung = (int)x.ID_NGUOI_DUNG,
                    NgayYeuCau = (DateTime)x.ngay_yeu_cau,
                    HoTen = x.ho_ten,
                    CongTy = x.cong_ty,
                    SoDienThoai = x.so_dien_thoai,
                    Email = x.email,
                    NoiDung = x.noi_dung,
                    ThamChieuTicket = x.tham_chieu_ticket,
                    PhanChoNhanVien = x.phan_cho_nhan_vien,
                    TinhTrang = (int)x.tinh_trang
                    
                  
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(YeuCauTinhGiaInBDO entityBDO)
        {
            string kq = "";
            try
            {
               // kq = KiemTraTrung(entityBDO.So);
                //if (kq != "")
                //    return kq;
                YEU_CAU_TINH_GIA_IN entity = new YEU_CAU_TINH_GIA_IN();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.YEU_CAU_TINH_GIA_IN.Add(entity);
                db.SaveChanges();
                kq = string.Format("Tính giá:{0}", entity.ID);
            }
            catch (Exception e)
            {
                kq = string.Format("Thêm Tính giá {0} bị lỗi: {1}!", entityBDO.ID, e.Message);
            }
            return kq;
        }

        public string Sua(YeuCauTinhGiaInBDO entityBDO)
        {
            YEU_CAU_TINH_GIA_IN entity = db.YEU_CAU_TINH_GIA_IN.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                   // kq = KiemTraTrung(entityBDO.So, entityBDO.ID);
                   // if (kq != "")
                   //     return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Tính giá ID: {0} thành công", entity.ID);//trả về số Id
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

            YEU_CAU_TINH_GIA_IN entity = db.YEU_CAU_TINH_GIA_IN.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.YEU_CAU_TINH_GIA_IN.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa Tính giá {0} không thành công!", entity.ID);
                }
            }
            else
                kq = string.Format("Tính giá ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(YeuCauTinhGiaInBDO entityBDO, YEU_CAU_TINH_GIA_IN entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ID_NGUOI_DUNG = entityBDO.IdNguoiDung;
            entityDAO.ngay_yeu_cau = entityBDO.NgayYeuCau;
            entityDAO.ho_ten = entityBDO.HoTen;
            entityDAO.cong_ty = entityBDO.CongTy;
            entityDAO.so_dien_thoai = entityBDO.SoDienThoai;
            entityDAO.email = entityBDO.Email;
            entityDAO.noi_dung = entityBDO.NoiDung;
            entityDAO.tham_chieu_ticket = entityBDO.ThamChieuTicket;
            entityDAO.phan_cho_nhan_vien = entityBDO.PhanChoNhanVien;
            entityDAO.tinh_trang = entityBDO.TinhTrang;
           
        }
      /*  private string KiemTraTrung(string soTinhGia, int id = 0)
        {
            string kq = "";
            var entity = db.TINH_GIA_IN.SingleOrDefault(x => x.So == soTinhGia );
            if (entity != null && entity.ID != id)
                kq = string.Format(" Số Tính giá {0} đã có", soTinhGia);
            return kq;
        }
        */

      
    }
}
