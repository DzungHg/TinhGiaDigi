using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class BangGiaTheNhuaDAO : IBangGiaTheNhuaDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<BangGiaTheNhuaBDO> DocTatCa()
        {
            List<BangGiaTheNhuaBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_THE_NHUA.Select(x => new BangGiaTheNhuaBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    VatLieuInBaoGom = x.vat_lieu_in_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTheToiDa = (int)x.so_luong_tinh_toi_da,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<BangGiaTheNhuaBDO> DocTheoIdHangKH(int idHangKH)
        {
            List<BangGiaTheNhuaBDO> list = null;
            try
            {
                var nguon = db.BANG_GIA_THE_NHUA.Where(x => x.ID_HANG_KHACH_HANG == idHangKH).Select(x => new BangGiaTheNhuaBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    VatLieuInBaoGom  = x.vat_lieu_in_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTheToiDa = (int)x.so_luong_tinh_toi_da,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public BangGiaTheNhuaBDO DocTheoId(int iD)
        {
            BangGiaTheNhuaBDO item = null;
            try
            {
                item = db.BANG_GIA_THE_NHUA.Where(x => x.ID == iD).Select(x => new BangGiaTheNhuaBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    MoTa = x.mo_ta,
                    DayGia = x.day_gia,
                    DaySoLuong = x.day_so_luong,
                    InHaiMat = (bool)x.in_hai_mat,
                    KhongCon = (bool)x.khong_con,
                    NoiDungBangGia = x.noi_dung_bang_gia,
                    VatLieuInBaoGom = x.vat_lieu_in_bao_gom,
                    KhoToChay = x.kho_to_chay,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTheToiDa = (int)x.so_luong_tinh_toi_da,
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                
            }
            catch { }

            return item;
        }
        #region them, sua, xoa
        public string Them(BangGiaTheNhuaBDO entityBDO)
        {
            var entity = new BANG_GIA_THE_NHUA();
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
                    db.BANG_GIA_THE_NHUA.Add(entity);
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

        public string Sua(BangGiaTheNhuaBDO entityBDO)
        {
            var entity = db.BANG_GIA_THE_NHUA.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
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
            var entity = db.BANG_GIA_THE_NHUA.SingleOrDefault(x => x.ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
#endregion
        private void ChuyenBDOThanhDAO(BangGiaTheNhuaBDO entityBDO, BANG_GIA_THE_NHUA entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.mo_ta = entityBDO.MoTa;
            entityDAO.day_gia = entityBDO.DayGia;
            entityDAO.day_so_luong = entityBDO.DaySoLuong;
            entityDAO.khong_con = entityBDO.KhongCon;
            entityDAO.ID_HANG_KHACH_HANG = entityBDO.IdHangKhachHang;
            entityDAO.so_luong_tinh_toi_da = entityBDO.SoTheToiDa;
            entityDAO.noi_dung_bang_gia = entityBDO.NoiDungBangGia;
            entityDAO.in_hai_mat = entityBDO.InHaiMat;
            entityDAO.vat_lieu_in_bao_gom = entityBDO.VatLieuInBaoGom;
            entityDAO.kho_to_chay = entityBDO.KhoToChay;
            entityDAO.thu_tu = entityBDO.ThuTu;
        }


       
    }
}
