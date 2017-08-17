using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class BangGiaInNhanhDAO: IBangGiaInNhanhDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<BangGiaInNhanhBDO> LayTatCa()
        {
            List<BangGiaInNhanhBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_IN_NHANH.Select(x => new BangGiaInNhanhBDO
                {
                    ID = x.ID,
                    TenBangGia = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongSuDung = (bool)x.khong_su_dung,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    GiaTheoKhoang = (bool)x.gia_theo_khoang,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<BangGiaInNhanhBDO> LayTheoIdHangKH(int idHangKH)
        {
            List<BangGiaInNhanhBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_IN_NHANH.Where(x => x.ID_HANG_KHACH_HANG == idHangKH).Select(x => new BangGiaInNhanhBDO
                {
                    ID = x.ID,
                    TenBangGia = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongSuDung = (bool)x.khong_su_dung,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    GiaTheoKhoang = (bool)x.gia_theo_khoang,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public BangGiaInNhanhBDO LayTheoId(int iD)
        {
            BangGiaInNhanhBDO item = null;
            try
            {
                item = db.BANG_GIA_IN_NHANH.Where(x=> x.ID == iD).Select(x => new BangGiaInNhanhBDO
                {
                    ID = x.ID,
                    TenBangGia = x.ten_bang_gia,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    KhongSuDung = (bool)x.khong_su_dung,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    GiaTheoKhoang = (bool)x.gia_theo_khoang,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                
            }
            catch { }

            return item;
        }

        public string Them(BangGiaInNhanhBDO entityBDO)
        {
            var entity = new BANG_GIA_IN_NHANH();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.TenBangGia);
                    if (kq != "")
                    {                        
                        return kq;
                    }
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.BANG_GIA_IN_NHANH.Add(entity);
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

        public bool Sua(ref string thongDiep, BangGiaInNhanhBDO entityBDO)
        {
            var entity = db.BANG_GIA_IN_NHANH.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = true;
            if (entity != null)
            {
                try
                {
                    var kqKiemTrung = KiemTraTrung(entityBDO.TenBangGia, entityBDO.ID);
                    if (kqKiemTrung != "")
                    {
                        thongDiep = kqKiemTrung;
                        return false;
                    }
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    thongDiep = string.Format("Lưu mục tin {0} thành công", entity.ID);//trả về số Id
                }
                catch
                {
                    thongDiep = string.Format("Sửa mục tin {0} không thành công!", entity.ID);
                }
            }
            else
            {
                thongDiep = string.Format("Mục tin {0} không tồn tại!", entity.ID);
                return false;
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
            var entity = db.BANG_GIA_IN_NHANH.SingleOrDefault(x => x.ten_bang_gia == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(BangGiaInNhanhBDO entityBDO, BANG_GIA_IN_NHANH entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten_bang_gia = entityBDO.TenBangGia;
            entityDAO.mo_ta = entityBDO.MoTa;
            entityDAO.day_gia = entityBDO.DayGia;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.khong_su_dung = entityBDO.KhongSuDung;
            entityDAO.ID_HANG_KHACH_HANG = entityBDO.IdHangKhachHang;
            entityDAO.so_trang_toi_da = entityBDO.SoTrangToiDa;
            entityDAO.noi_dung_bang_gia = entityBDO.NoiDungBangGia;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.gia_theo_khoang = entityBDO.GiaTheoKhoang;
            entityDAO.thu_tu = entityBDO.ThuTu;
        }
    }
}
