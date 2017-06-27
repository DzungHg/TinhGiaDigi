using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class DongCuonLoXoDAO : IDongCuonLoXoDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<DongCuonLoXoBDO> DocTatCa()
        {
            List<DongCuonLoXoBDO> list = null;
            try
            {
                var nguon = db.DONG_CUON_LO_XO.Select(x => new DongCuonLoXoBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,
                    TocDoCuonGio = (int)x.toc_do_cuon,
                    BiaToDon = (bool)x.bia_to_don,
                    RuotToDon = (bool)x.ruot_to_don,
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    Ma_01 = x.ma_01,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public DongCuonLoXoBDO DocTheoId(int iD)
        {
            DongCuonLoXoBDO dm = null;
            try
            {
                var nguon = db.DONG_CUON_LO_XO.Where(x => x.ID == iD).Select(x => new DongCuonLoXoBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.thoi_gian_chuan_bi,
                    TocDoCuonGio = (int)x.toc_do_cuon,
                    BiaToDon = (bool)x.bia_to_don,
                    RuotToDon = (bool)x.ruot_to_don,
                    DaySoLuong = x.day_so_luong,
                    DayLoiNhuan = x.day_loi_nhuan,
                    Ma_01 = x.ma_01,
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
        public string Them(DongCuonLoXoBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public string Sua(DongCuonLoXoBDO entityBDO)
        {
            DONG_CUON_LO_XO entity = db.DONG_CUON_LO_XO.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
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
            var entity = db.DONG_CUON_LO_XO.SingleOrDefault(x => x.ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(DongCuonLoXoBDO entityBDO, DONG_CUON_LO_XO entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.toc_do_cuon = entityBDO.TocDoCuonGio;
            entityDAO.thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.bia_to_don = entityBDO.BiaToDon;
            entityDAO.ruot_to_don = entityBDO.RuotToDon; 
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.thu_tu = entityBDO.ThuTu;
        }
        #endregion
    }
}
