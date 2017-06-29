using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class KetQuaTinhGiaInDAO : IKetQuaTinhGiaInDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<KetQuaTinhGiaInBDO> DocTatCa()
        {
            List<KetQuaTinhGiaInBDO> list = null;
            try
            {
                var nguon = db.TINH_GIA_IN.Select(x => new KetQuaTinhGiaInBDO
                {
                    ID = x.ID,
                    IdNguoiDung = (int)x.ID_NGUOI_DUNG,
                    NgayTinhGia = (DateTime)x.ngay_tinh_gia,
                    TieuDe = x.tieu_de_tinh_gia,
                    IdYeuCauTinhGiaIn = (int)x.ID_YEU_CAU_TINH_GIA_IN,
                    NoiDungChaoGia = x.Noi_dung_chao_gia,
                    NoiDungChaoGiaNoiBo = x.noi_dung_chao_gia_noi_bo,
                    TenNguoiDung = x.ten_nguoi_dung,
                    TenKhachHang = x.ten_khach_hang
                    
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
        public IEnumerable<KetQuaTinhGiaInBDO> DocTheoYeuCauTinhGia(int iDYeuCau)
        {
            return this.DocTatCa().Where(x => x.IdYeuCauTinhGiaIn == iDYeuCau);
        }
        public KetQuaTinhGiaInBDO DocTheoId(int iD)
        {
            KetQuaTinhGiaInBDO giay = null;
            try
            {
                var nguon = db.TINH_GIA_IN.Where(x => x.ID == iD).Select(x => new KetQuaTinhGiaInBDO
                {
                    ID = x.ID,
                    IdNguoiDung = (int)x.ID_NGUOI_DUNG,
                    NgayTinhGia = (DateTime)x.ngay_tinh_gia,
                    TieuDe = x.tieu_de_tinh_gia,
                    IdYeuCauTinhGiaIn = (int)x.ID_YEU_CAU_TINH_GIA_IN,
                    NoiDungChaoGia = x.Noi_dung_chao_gia,
                    NoiDungChaoGiaNoiBo = x.noi_dung_chao_gia_noi_bo,
                    TenNguoiDung = x.ten_nguoi_dung,
                    TenKhachHang = x.ten_khach_hang                    
                  
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(KetQuaTinhGiaInBDO entityBDO)
        {
            string kq = "";
            try
            {
               // kq = KiemTraTrung(entityBDO.So);
                //if (kq != "")
                //    return kq;
                TINH_GIA_IN entity = new TINH_GIA_IN();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.TINH_GIA_IN.Add(entity);
                db.SaveChanges();
                kq = string.Format("Tính giá:{0}", entity.ID);
            }
            catch (Exception e)
            {
                kq = string.Format("Thêm Tính giá {0} bị lỗi: {1}!", entityBDO.ID, e.Message);
            }
            return kq;
        }

        public string Sua(KetQuaTinhGiaInBDO entityBDO)
        {
            TINH_GIA_IN entity = db.TINH_GIA_IN.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                   // kq = KiemTraTrung(entityBDO.So, entityBDO.ID);
                   // if (kq != "")
                   //     return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Tính giá ID: {0} thành công", entity.ID);//trả về số Id
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

            TINH_GIA_IN entity = db.TINH_GIA_IN.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.TINH_GIA_IN.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa Tính giá {0} không thành công!", entity.ID);
                }
            }
            else
                kq = string.Format("Tính giá ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(KetQuaTinhGiaInBDO entityBDO, TINH_GIA_IN entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ID_NGUOI_DUNG = entityBDO.IdNguoiDung;
            entityDAO.ngay_tinh_gia = entityBDO.NgayTinhGia;
            entityDAO.tieu_de_tinh_gia = entityBDO.TieuDe;
            entityDAO.ID_YEU_CAU_TINH_GIA_IN = entityBDO.IdYeuCauTinhGiaIn;
            entityDAO.ten_nguoi_dung = entityBDO.TenNguoiDung;
            entityDAO.Noi_dung_chao_gia = entityBDO.NoiDungChaoGia;
            entityDAO.noi_dung_chao_gia_noi_bo = entityBDO.NoiDungChaoGiaNoiBo;
            entityDAO.ten_khach_hang = entityBDO.TenKhachHang;
           

        }
      /*  private string KiemTraTrung(string soTinhGia, int id = 0)
        {
            string kq = "";
            var entity = db.TINH_GIA_IN.SingleOrDefault(x => x.So == soTinhGia );
            if (entity != null && entity.ID != id)
                kq = string.Format(" Số Tính giá {0} đã có", soTinhGia);
            return kq;
        }
        */




       
    }
}
