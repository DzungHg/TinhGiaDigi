using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class MayInDigiDAO : IMayInDigiDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();

        public IEnumerable<MayInDigiBDO> DocTatCa()
        {
            List<MayInDigiBDO> list = null;
            try
            {
                var nguon = db.MAY_IN_DIGI.Select(x => new MayInDigiBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    KhoInMin = x.kho_in_min,
                    KhoInMax = x.kho_in_max,
                    BHR = (int)x.BHR,
                    ClickA4_1M = (int)x.Click_A4_1M,
                    ClickA4_4M = (int)x.Click_A4_4M,
                    ClickA4_6M = (int)x.Click_A4_6M,
                    ThoiGianSanSang = (float)x.Thoi_gian_san_sang,
                    ThongTinTocDo = x.Thong_tin_toc_do,
                    TocDoHieuQua = (int)x.toc_do_hieu_qua,
                    PhiPhePhamSanSang = (int)x.Phi_phe_pham_san_sang
                                     
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public MayInDigiBDO DocTheoId(int iD)
        {
            MayInDigiBDO item = null;
            try
            {
                var nguon = db.MAY_IN_DIGI.Where(x => x.ID == iD).Select(x => new MayInDigiBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    KhoInMin = x.kho_in_min,
                    KhoInMax = x.kho_in_max,
                    BHR = (int)x.BHR,
                    ClickA4_1M = (int)x.Click_A4_1M,
                    ClickA4_4M = (int)x.Click_A4_4M,
                    ClickA4_6M = (int)x.Click_A4_6M,
                    ThoiGianSanSang = (float)x.Thoi_gian_san_sang,
                    ThongTinTocDo = x.Thong_tin_toc_do,
                    TocDoHieuQua = (int)x.toc_do_hieu_qua,
                    PhiPhePhamSanSang = (int)x.Phi_phe_pham_san_sang
                  
                    
                }).SingleOrDefault();
                
                item = nguon;
            }
            catch { }

            return item;
        }
        #region Emplement them sua xoa
        public string Them(MayInDigiBDO entityBDO)
        {
            string kq = "";
            try
            {
                kq = KiemTraTrung(entityBDO.Ten);
                if (kq != "")
                    return kq;
                MAY_IN_DIGI entity = new MAY_IN_DIGI();
                ChuyenBDOThanhDAO(entityBDO, entity);
                db.MAY_IN_DIGI.Add(entity);
                db.SaveChanges();
                kq = string.Format("Máy In :{0}", entity.ID);
            }
            catch
            {
                kq = string.Format("Thêm Máy In {0} lỗi!", entityBDO.ID);
            }
            return kq;
        }

        public string Sua(MayInDigiBDO entityBDO)
        {
            MAY_IN_DIGI entity = db.MAY_IN_DIGI.Where(x => (x.ID == entityBDO.ID)).SingleOrDefault();
            string kq = "";
            if (entity != null)
            {
                try
                {
                    kq = KiemTraTrung(entityBDO.Ten, entityBDO.ID);
                    if (kq != "")
                        return kq;
                    //Vượt thì chuyển
                    ChuyenBDOThanhDAO(entityBDO, entity);
                    //Chú ý
                    db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    kq = string.Format("Sửa Máy In ID: {0} thành công", entity.ID);//trả về số Id
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
            throw new NotImplementedException();
        }
        #endregion

        private string KiemTraTrung(string tenMay, int id = 0)
        {
            string kq = "";
            var entity = db.MAY_IN_DIGI.SingleOrDefault(x => x.Ten == tenMay);
            if (entity != null && entity.ID != id)
                kq = string.Format("Tên Máy {0} đã có", tenMay);
            return kq;
        }
        private void ChuyenBDOThanhDAO(MayInDigiBDO entityBDO, MAY_IN_DIGI entityDAO)
        {
            entityDAO.ID = entityBDO.ID;
            entityDAO.Ten = entityBDO.Ten;
            entityDAO.BHR = entityBDO.BHR;
            entityDAO.kho_in_min = entityBDO.KhoInMin;
            entityDAO.kho_in_max = entityBDO.KhoInMax;
            entityDAO.Click_A4_1M = entityBDO.ClickA4_1M;
            entityDAO.Click_A4_4M = entityBDO.ClickA4_4M;
            entityDAO.Click_A4_6M = entityBDO.ClickA4_6M;
            entityDAO.Thoi_gian_san_sang = entityBDO.ThoiGianSanSang;
            entityDAO.Thong_tin_toc_do = entityBDO.ThongTinTocDo;
            entityDAO.toc_do_hieu_qua = entityBDO.TocDoHieuQua;
            entityDAO.Phi_phe_pham_san_sang = entityBDO.PhiPhePhamSanSang;            

        }


       
    }
}
