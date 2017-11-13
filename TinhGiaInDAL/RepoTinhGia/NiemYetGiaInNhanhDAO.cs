using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class NiemYetGiaInNhanhDAO: INiemYetGiaInNhanhDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        public IEnumerable<NiemYetGiaInNhanhBDO> DocTatCa()
        {
            List<NiemYetGiaInNhanhBDO> list = null;
            try
            {
                var nguon = db.NY_GIA_IN_NHANH.Select(x => new NiemYetGiaInNhanhBDO
                {
                    ID = x.ID,                   
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    IdBangGia = (int)x.ID_BANG_GIA,
                    KhongSuDung = (bool)x.khong_su_dung,
                    DuocGomTrang = (bool)x.duoc_gom_trang,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,                    
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    LoaiBangGia = x.LOAI_BANG_GIA.Trim(),
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<NiemYetGiaInNhanhBDO> DocTheoIdHangKhachHang(int idHangKH)
        {
       
            List<NiemYetGiaInNhanhBDO> list = null;
            try
            {
                var nguon = db.NY_GIA_IN_NHANH.Where(x => x.ID_HANG_KHACH_HANG == idHangKH).Select(x => new NiemYetGiaInNhanhBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    IdBangGia = (int)x.ID_BANG_GIA,
                    KhongSuDung = (bool)x.khong_su_dung,
                    DuocGomTrang = (bool)x.duoc_gom_trang,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    LoaiBangGia = x.LOAI_BANG_GIA.Trim(),
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public NiemYetGiaInNhanhBDO DocTheoId(int iD)
        {
            NiemYetGiaInNhanhBDO item = null;
            try
            {
                item = db.NY_GIA_IN_NHANH.Where(x=> x.ID == iD).Select(x => new NiemYetGiaInNhanhBDO
                {
                    ID = x.ID,
                    Ten = x.ten,
                    DienGiai = x.dien_giai,
                    IdBangGia = (int)x.ID_BANG_GIA,
                    KhongSuDung = (bool)x.khong_su_dung,
                    DuocGomTrang = (bool)x.duoc_gom_trang,
                    IdHangKhachHang = (int)x.ID_HANG_KHACH_HANG,
                    SoTrangToiDa = (int)x.so_trang_toi_da,
                    DaySoLuongNiemYet = x.day_so_luong_niem_yet,
                    LoaiBangGia = x.LOAI_BANG_GIA.Trim(),
                    ThuTu = (int)x.thu_tu
                }).SingleOrDefault();
                
            }
            catch { }

            return item;
        }

        public string Them(NiemYetGiaInNhanhBDO entityBDO)
        {
            var entity = new NY_GIA_IN_NHANH();
            var kq = "";
            if (entity != null)
            {
                try
                {
                    //Kiểm tra xem bị trùng IDBangGia Khong
                    kq = KiemTraTrung(entityBDO.Ten);
                    if (kq != "")
                    {                        
                        return kq;
                    }
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    db.NY_GIA_IN_NHANH.Add(entity);
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

        public bool Sua(ref string thongDiep, NiemYetGiaInNhanhBDO entityBDO)
        {
            var entity = db.NY_GIA_IN_NHANH.Where(x => x.ID == entityBDO.ID).SingleOrDefault();
            var kq = true;
            if (entity != null)
            {
                try
                {
                    //Kiểm tra bị trùng ID bảng giá không
                    var kqKiemTrung = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
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
            var entity = db.NY_GIA_IN_NHANH.SingleOrDefault(x => x.ten == value);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên {0} đã có rồi!", value);
            return kq;
        }
        private void ChuyenBDOThanhDAO(NiemYetGiaInNhanhBDO entityBDO, NY_GIA_IN_NHANH entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
          
            entityDAO.dien_giai = entityBDO.DienGiai;
            entityDAO.ten = entityBDO.Ten;
            entityDAO.ID_BANG_GIA = entityBDO.IdBangGia;
            
            entityDAO.khong_su_dung = entityBDO.KhongSuDung;
            entityDAO.ID_HANG_KHACH_HANG = entityBDO.IdHangKhachHang;
            entityDAO.so_trang_toi_da = entityBDO.SoTrangToiDa;
            entityDAO.duoc_gom_trang = entityBDO.DuocGomTrang;
            entityDAO.day_so_luong_niem_yet = entityBDO.DaySoLuongNiemYet;
            entityDAO.LOAI_BANG_GIA = entityBDO.LoaiBangGia.Trim();
            entityDAO.thu_tu = entityBDO.ThuTu;
        }






        
    }
}
