using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class LoXoDongCuonDAO : ILoXoDongCuonDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<LoXoDongCuonBDO> DocTatCa()
        {
            List<LoXoDongCuonBDO> list = null;
            try
            {
                var nguon = db.LO_XO_DONG_CUON.Select(x => new LoXoDongCuonBDO
                {
                    ID = x.ID,
                    TenVongXoan = x.ten_vong_xoan,
                    KichCoBuoc = x.kich_co_buoc,
                    MauSac = x.mau_sac,
                    ChoDoDay = x.cho_do_day,
                    GiaMuaTheoMet = (int)x.gia_mua_theo_met,
                    ThuTu = (int)x.thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }
      
        public LoXoDongCuonBDO DocTheoId(int iD)
        {
            LoXoDongCuonBDO giay = null;
            try
            {
                var nguon = db.LO_XO_DONG_CUON.Where(x => x.ID == iD).Select(x => new LoXoDongCuonBDO
                {
                    ID = x.ID,
                    TenVongXoan = x.ten_vong_xoan,
                    KichCoBuoc = x.kich_co_buoc,
                    MauSac = x.mau_sac,
                    ChoDoDay = x.cho_do_day,
                    GiaMuaTheoMet = (int)x.gia_mua_theo_met,
                    ThuTu = (int)x.thu_tu
                });
                giay = nguon.SingleOrDefault();
            }
            catch { }

            return giay;
        }

        #region Thêm sửa xóa
        public string Them(LoXoDongCuonBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.TenVongXoan);
                if (kq != "")
                    return kq;
                LO_XO_DONG_CUON entity = new LO_XO_DONG_CUON();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.LO_XO_DONG_CUON.Add(entity);
                db.SaveChanges();
                kq = string.Format("Ép kim:{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Nhũ ép kim {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(LoXoDongCuonBDO entityBDO)
        {
            LO_XO_DONG_CUON entity = db.LO_XO_DONG_CUON.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.TenVongXoan, entityBDO.ID);
                    if (kq != "")
                        return kq;
                     
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Nhũ ép kim ID: {0} thành công", entity.ID);//trả về số Id
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

            LO_XO_DONG_CUON entity = db.LO_XO_DONG_CUON.Find(iD);
            if (entity != null)
            {
                try
                {
                    db.LO_XO_DONG_CUON.Remove(entity);
                    db.SaveChanges();
                }
                catch
                {
                    kq = string.Format("Xóa {0} không thành công!", entity.ten_vong_xoan);
                }
            }
            else
                kq = string.Format("Mẫu tin ID:{0} không tồn tại!", iD);
            return kq; ;
        }
        #endregion
        private void ChuyenBDOThanhDAO(LoXoDongCuonBDO entityBDO, LO_XO_DONG_CUON entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.ten_vong_xoan = entityBDO.TenVongXoan;
            entityDAO.kich_co_buoc = entityBDO.KichCoBuoc;
            entityDAO.mau_sac = entityBDO.MauSac;
            entityDAO.cho_do_day = entityBDO.ChoDoDay;
            entityDAO.gia_mua_theo_met = entityBDO.GiaMuaTheoMet;
            entityDAO.thu_tu = entityBDO.ThuTu;
          

        }
        private string KiemTraTrung(string tenNhu,  int id = 0)
        {
            string kq = "";
            var entity = db.LO_XO_DONG_CUON.SingleOrDefault(x => x.ten_vong_xoan == tenNhu);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên Mẫu tin này {0} đã có", tenNhu);
            return kq;
        }
        
    }
}
