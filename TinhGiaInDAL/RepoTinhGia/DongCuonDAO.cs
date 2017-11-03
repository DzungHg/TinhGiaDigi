using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class DongCuonDAO : IDongCuonDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<DongCuonBDO> LayTatCa()
        {
            List<DongCuonBDO> list = null;
            try
            {
                var nguon = db.DONG_CUON.Select(x => new DongCuonBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    TieuDe = x.tieu_de,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,
                    TocDoCuonGio = (int)x.Toc_do_cuon,
                    PhiNgVLCuon = (int)x.Phi_ngvl_cuon,
                    BiaToDon = (bool)x.bia_to_don,
                    RuotToDon = (bool)x.ruot_to_don,
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
                    DonViTinh = x.don_vi_tinh,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    Ma_01 = x.ma_01,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }



        public DongCuonBDO LayTheoId(int iD)
        {
            DongCuonBDO dm = null;
            try
            {
                var nguon = db.DONG_CUON.Where(x => x.ID == iD).Select(x => new DongCuonBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    TieuDe = x.tieu_de,
                    BHR = (int)x.BHR,
                    ThoiGianChuanBi = (float)x.Thoi_gian_chuan_bi,
                    TocDoCuonGio = (int)x.Toc_do_cuon,
                    PhiNgVLCuon = (int)x.Phi_ngvl_cuon,
                    BiaToDon = (bool)x.bia_to_don,
                    RuotToDon = (bool)x.ruot_to_don,
                    DaySoLuong = x.Day_so_luong,
                    DayLoiNhuan = x.Day_loi_nhuan,
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
        public string Them(DongCuonBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public string Sua(DongCuonBDO entityBDO)
        {
            DONG_CUON entity = db.DONG_CUON.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
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
            var entity = db.DONG_CUON.SingleOrDefault(x => x.Ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(DongCuonBDO entityBDO, DONG_CUON entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.tieu_de = entityBDO.TieuDe;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.Toc_do_cuon = entityBDO.TocDoCuonGio;
            entityDAO.Thoi_gian_chuan_bi = entityBDO.ThoiGianChuanBi;
            entityDAO.bia_to_don = entityBDO.BiaToDon;
            entityDAO.ruot_to_don = entityBDO.RuotToDon; 
            entityDAO.Day_so_luong = entityBDO.DaySoLuong;
            entityDAO.Day_loi_nhuan = entityBDO.DayLoiNhuan;
            entityDAO.ma_01 = entityBDO.Ma_01;
            entityDAO.don_vi_tinh = entityBDO.DonViTinh;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.Thu_tu = entityBDO.ThuTu;
        }
        #endregion
    }
}
