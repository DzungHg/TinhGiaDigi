using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class BangGiaDanhThiepDAO : IBangGiaDanhThiepDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<BangGiaDanhThiepBDO> DocTatCa()
        {
            List<BangGiaDanhThiepBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_DANH_THIEP.Select(x => new BangGiaDanhThiepBDO
                {
                    ID = x.ID,
                    Ten = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    GiayBaoGom = x.giay_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoHopToiDa = (int)x.so_hop_toi_da,
                    SoDanhThiepTrenHop = (int)x.so_danh_thiep_tren_hop,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<BangGiaDanhThiepBDO> DocTheoIdHangKH(int idHangKH)
        {
            List<BangGiaDanhThiepBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_DANH_THIEP.Where(x => x.ID_HANG_KHACH_HANG == idHangKH).Select(x => new BangGiaDanhThiepBDO
                {
                    ID = x.ID,
                    Ten = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    GiayBaoGom = x.giay_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoHopToiDa = (int)x.so_hop_toi_da,
                    SoDanhThiepTrenHop = (int)x.so_danh_thiep_tren_hop,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public BangGiaDanhThiepBDO DocTheoId(int iD)
        {
            BangGiaDanhThiepBDO item = null;
            try
            {
                item = db.BANG_GIA_DANH_THIEP.Where(x => x.ID == iD).Select(x => new BangGiaDanhThiepBDO
                {
                    ID = x.ID,
                    Ten = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    GiayBaoGom = x.giay_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoHopToiDa = (int)x.so_hop_toi_da,
                    SoDanhThiepTrenHop = (int)x.so_danh_thiep_tren_hop,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();

            }
            catch { }

            return item;
        }
        #region them, sua, xoa
        public string Them(BangGiaDanhThiepBDO entityBDO)
        {
            var entity = new BANG_GIA_DANH_THIEP();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten);
                    if (kq != "")
                    {
                        return kq;
                    }
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.BANG_GIA_DANH_THIEP.Add(entity);
                    db.SaveChanges();
                    kq = string.Format("Thêm mục tin {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    kq = string.Format("Thêm mục tin {0} không thành công!", entity.ID);
                }
            }
            else
            {

                return string.Format("Mục tin {0} không tồn tại!", entity.ID);
            }
            return kq;
        }

        public string Sua(BangGiaDanhThiepBDO entityBDO)
        {
            var entity = db.BANG_GIA_DANH_THIEP.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                    {
                        return kq;
                    }
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
                kq = string.Format("Mục tin {0} không tồn tại!", entity.ID);
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
            var entity = db.BANG_GIA_DANH_THIEP.SingleOrDefault(x => x.ten_bang_gia == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        #endregion
        private void ChuyenBDOThanhDAO(BangGiaDanhThiepBDO entityBDO, BANG_GIA_DANH_THIEP entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten_bang_gia = entityBDO.Ten;
            entityDAO.mo_ta = entityBDO.MoTa;
            entityDAO.day_gia = entityBDO.DayGia;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.khong_con = entityBDO.KhongCon;
            entityDAO.ID_HANG_KHACH_HANG = entityBDO.IdHangKhachHang;
            entityDAO.so_hop_toi_da = entityBDO.SoHopToiDa;
            entityDAO.noi_dung_bang_gia = entityBDO.NoiDungBangGia;
            entityDAO.in_hai_mat = entityBDO.InHaiMat;
            entityDAO.giay_bao_gom = entityBDO.GiayBaoGom;
            entityDAO.kho_to_chay = entityBDO.KhoToChay;
            entityDAO.so_danh_thiep_tren_hop = entityBDO.SoDanhThiepTrenHop;
            entityDAO.thu_tu = entityBDO.ThuTu;
        }
    }
}
