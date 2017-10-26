using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class MayBeDAO : IMayBeDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<MayBeBDO> DocTatCa()
        {
            List<MayBeBDO> list = null;
            try
            {
                var nguon = db.MAY_BE.Select(x => new MayBeBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    BHR = (int)x.BHR,
                    TocDoTamGio = (int)x.toc_do_con,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,                   
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,                   
                    PhiNguyenVatLieuChuanBi = (int)x.phi_ngvl_chuan_bi,                                        
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public MayBeBDO DocTheoId(int iD)
        {
            MayBeBDO dm = null;
            try
            {
                var nguon = db.MAY_BE.Where(x => x.ID == iD).Select(x => new MayBeBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    BHR = (int)x.BHR,
                    TocDoTamGio = (int)x.toc_do_con,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,                   
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,
                  
                    PhiNguyenVatLieuChuanBi = (int)x.phi_ngvl_chuan_bi,                    
                    
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public string Them(MayBeBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                MAY_BE entity = new MAY_BE();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.MAY_BE.Add(entity);
                db.SaveChanges();
                kq = string.Format("Máy ép kim:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Máy bế {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(MayBeBDO entityBDO)
        {
            MAY_BE entity = db.MAY_BE.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
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
        private void ChuyenBDOThanhDAO(MayBeBDO entityBDO, MAY_BE entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.toc_do_con = entityBDO.TocDoTamGio;
            entityDAO.thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.phi_ngvl_chuan_bi = entityBDO.PhiNguyenVatLieuChuanBi;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.day_loi_nhuan = entityBDO.DayLoiNhuan;
            
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            
            entityDAO.thu_tu = entityBDO.ThuTu;
        }
        #endregion

       
    }
}
