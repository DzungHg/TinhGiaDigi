using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class GiayDAO: IGiayDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
       
        public IEnumerable<GiayBDO> LayTatCa()
        {
            List<GiayBDO> list = null;
            try
            {
                var nguon = db.GIAYs.Select(x => new GiayBDO
                {
                    ID = x.ID,
                    MaGiayNCC = x.Ma_giay_ncc,
                    MaGiayTuDat = x.Ma_giay_tu_dat,
                    TenGiay = x.Ten_giay,
                    DienGiai = x.Dien_giai,
                    DinhLuong = (int)x.Dinh_luong,
                    KhoGiay = x.Kho_giay,
                    ChieuNgan = (float)x.Chieu_ngan,
                    ChieuDai = (float)x.Chieu_dai,
                    TenGiayMoRong = x.ten_mo_rong,
                    GiaMua = (int)x.Gia_mua,
                    KhongCon = (bool)x.Khong_con,                    
                    IdDanhMucGiay = (int)x.ID_DANH_MUC_GIAY,
                    TenDanhMucGiay = x.DANH_MUC_GIAY.Ten, //Tham chiếu
                    TonKho = (bool)x.Ton_kho,

                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<GiayBDO> LayNhieuTheoDanhMuc(int idDanhMuc)
        {
            List<GiayBDO> list = null;
            try
            {
                var nguon = db.GIAYs.Where(x => x.ID_DANH_MUC_GIAY == idDanhMuc).Select(x => new GiayBDO
                {
                    ID = x.ID,
                    TenGiay = x.Ten_giay,
                    MaGiayNCC = x.Ma_giay_ncc,
                    MaGiayTuDat = x.Ma_giay_tu_dat,
                    DienGiai = x.Dien_giai,
                    DinhLuong = (int)x.Dinh_luong,
                    KhoGiay = x.Kho_giay,
                    ChieuNgan = (float)x.Chieu_ngan,
                    ChieuDai = (float)x.Chieu_dai,
                    GiaMua = (int)x.Gia_mua,
                    TenGiayMoRong = x.ten_mo_rong,
                    KhongCon = (bool)x.Khong_con,                   
                    IdDanhMucGiay = (int)x.ID_DANH_MUC_GIAY,
                    TenDanhMucGiay = x.DANH_MUC_GIAY.Ten, //tham chiếu
                    TonKho = (bool)x.Ton_kho,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public GiayBDO LayTheoId(int iD)
        {
            GiayBDO giay = null;
            try
            {
                var nguon = db.GIAYs.Where(x => x.ID == iD).Select(x => new GiayBDO
                {
                    ID = x.ID,
                    MaGiayNCC = x.Ma_giay_ncc,
                    MaGiayTuDat = x.Ma_giay_tu_dat,
                    TenGiay = x.Ten_giay,
                    DienGiai = x.Dien_giai,
                    DinhLuong = (int)x.Dinh_luong,
                    KhoGiay = x.Kho_giay,
                    ChieuNgan = (float)x.Chieu_ngan,
                    ChieuDai = (float)x.Chieu_dai,
                    TenGiayMoRong = x.ten_mo_rong,
                    GiaMua = (int)x.Gia_mua,
                    KhongCon = (bool)x.Khong_con,                   
                    IdDanhMucGiay = (int)x.ID_DANH_MUC_GIAY,
                    TenDanhMucGiay = x.DANH_MUC_GIAY.Ten, //Tham chiếu
                    TonKho = (bool)x.Ton_kho,                    
                    ThuTu = (int)x.Thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(GiayBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.TenGiay, entityBDO.KhoGiay,
                        entityBDO.DinhLuong, entityBDO.IdDanhMucGiay);
                if (kq != "")
                    return kq;
                GIAY entity = new GIAY();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.GIAYs.Add(entity);
                db.SaveChanges();
                kq = string.Format("Giấy:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Giấy {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(GiayBDO entityBDO)
        {
            GIAY entity = db.GIAYs.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.TenGiay, entityBDO.KhoGiay, 
                        entityBDO.DinhLuong, entityBDO.IdDanhMucGiay, entityBDO.ID);
                    if (kq != "")
                        return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Giấy ID: {0} thành công", entity.ID);//trả về số Id
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

            GIAY entity = db.GIAYs.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.GIAYs.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa Giấy {0} không thành công!", entity.Ten_giay);
                }
            }
            else
                kq = string.Format("Giấy ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(GiayBDO entityBDO, GIAY entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten_giay = entityBDO.TenGiay;
            entityDAO.Kho_giay = entityBDO.KhoGiay;
            entityDAO.Dien_giai = entityBDO.DienGiai;
            entityDAO.Dinh_luong = entityBDO.DinhLuong;
            entityDAO.Ma_giay_ncc = entityBDO.MaGiayNCC;
            entityDAO.ID_DANH_MUC_GIAY = entityBDO.IdDanhMucGiay;
            entityDAO.Ma_giay_tu_dat = entityBDO.MaGiayTuDat;
            entityDAO.Chieu_ngan = entityBDO.ChieuNgan;
            entityDAO.Chieu_dai = entityBDO.ChieuDai;
            entityDAO.ten_mo_rong = entityBDO.TenGiayMoRong;
            entityDAO.Ton_kho = entityBDO.TonKho;
            entityDAO.Gia_mua = entityBDO.GiaMua;
            entityDAO.Thu_tu = entityBDO.ThuTu;
            entityDAO.Khong_con = entityBDO.KhongCon;

        }
        private string KiemTraTrung(string tenGiay, string khoGiay,
                        int dinhLuong, int idDanhMuc, int id = 0)
        {
            string kq = "";
            var entity = db.GIAYs.SingleOrDefault(x => ((x.Ten_giay == tenGiay) &&
                (x.Kho_giay == khoGiay) && (x.Dinh_luong == dinhLuong) 
                && (x.ID_DANH_MUC_GIAY == idDanhMuc)));
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên Giấy {0} {1} {2}gsm đã có", tenGiay,
                            khoGiay, dinhLuong);
            return kq;
        }
    }
}
