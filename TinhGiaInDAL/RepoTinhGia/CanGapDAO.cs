using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class CanGapDAO : ICanGapDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<CanGapBDO> LayTatCa()
        {
            List<CanGapBDO> list = null;
            try
            {
                var nguon = db.CAN_GAP.Select(x => new CanGapBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    MotDuongCanTangThoiGianChuanBi = (float)x.mot_duong_tang_tgcb,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public CanGapBDO LayTheoId(int iD)
        {
            CanGapBDO dm = null;
            try
            {
                var nguon = db.CAN_GAP.Where(x => x.ID == iD).Select(x => new CanGapBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    BHR = (int)x.BHR,
                    TocDoConGio = (int)x.Toc_do_con,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,                   
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    Ma_01 = x.ma_01,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    MotDuongCanTangThoiGianChuanBi = (float)x.mot_duong_tang_tgcb,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                dm = nguon;
            }
            catch { }

            return dm;
        }
        #region Them, sưa, xoa
        public string Them(CanGapBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public string Sua(CanGapBDO entityBDO)
        {
            CAN_GAP entity = db.CAN_GAP.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
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
        private void ChuyenBDOThanhDAO(CanGapBDO entityBDO, CAN_GAP entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.Toc_do_con = entityBDO.TocDoConGio;
            entityDAO.Thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.Day_so_luong = entityBDO.DaySoLuong;
            entityDAO.Day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.mot_duong_tang_tgcb = entityBDO.MotDuongCanTangThoiGianChuanBi;
            entityDAO.Thu_tu = entityBDO.ThuTu;
        }
        #endregion


      
    }
}
