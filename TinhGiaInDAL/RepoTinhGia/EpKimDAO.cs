using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class EpKimDAO : IEpKimDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<EpKimBDO> DocTatCa()
        {
            List<EpKimBDO> list = null;
            try
            {
                var nguon = db.EP_KIM.Select(x => new EpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    LaViTinh = (bool)x.La_vi_tinh,
                    PhiNguyenVatLieuChuanBi = (int)x.Phi_ngvl_chuan_bi,
                    GiaKhuonCm2 = (int)x.Gia_khuon_cm2,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public EpKimBDO DocTheoId(int iD)
        {
            EpKimBDO dm = null;
            try
            {
                var nguon = db.EP_KIM.Where(x => x.ID == iD).Select(x => new EpKimBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    LaViTinh = (bool)x.La_vi_tinh,
                    PhiNguyenVatLieuChuanBi = (int)x.Phi_ngvl_chuan_bi,
                    GiaKhuonCm2 = (int)x.Gia_khuon_cm2,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public string Them(EpKimBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                EP_KIM entity = new EP_KIM();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.EP_KIM.Add(entity);
                db.SaveChanges();
                kq = string.Format("Máy ép kim:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Máy ép kim {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(EpKimBDO entityBDO)
        {
            EP_KIM entity = db.EP_KIM.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
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
        private void ChuyenBDOThanhDAO(EpKimBDO entityBDO, EP_KIM entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.Toc_do_con = entityBDO.TocDoConGio;
            entityDAO.Thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.Phi_ngvl_chuan_bi = entityBDO.PhiNguyenVatLieuChuanBi;
            entityDAO.Day_so_luong = entityBDO.DaySoLuong;
            entityDAO.Day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.La_vi_tinh = entityBDO.LaViTinh;
            entityDAO.Thu_tu = entityBDO.ThuTu;
        }
        #endregion

       
    }
}
