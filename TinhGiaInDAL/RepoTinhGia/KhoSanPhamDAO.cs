using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public class KhoSanPhamDAO:IKhoSanPhamDAO
    {
        QuanLyGiaInDBContext db = new QuanLyGiaInDBContext();
        #region Emplement them sua xoa
        public IEnumerable<KhoSanPhamBDO> LayTatCa()
        {
            List<KhoSanPhamBDO> list = null;
            try
            {
                var nguon = db.KHO_SAN_PHAM.Select(x => new KhoSanPhamBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    KhoCatCao = (float)x.Chieu_cat_cao,
                    KhoCatRong = (float)x.Chieu_cat_rong,
                    ThuTu = (int)x.Thu_tu
                });
                list = nguon.ToList();
            }
            catch { }

            return list;
        }

        public KhoSanPhamBDO LayTheoId(int iD)
        {
            KhoSanPhamBDO item = null;
            try
            {
                var nguon = db.KHO_SAN_PHAM.Where(x => x.ID == iD).Select(x => new KhoSanPhamBDO
                {
                    ID = x.ID,
                    Ten = x.Ten,
                    KhoCatCao = (float)x.Chieu_cat_cao,
                    KhoCatRong = (float)x.Chieu_cat_rong,
                    ThuTu = (int)x.Thu_tu
                }).SingleOrDefault();
                
                item = nguon;
            }
            catch { }

            return item;
        }

        public void Them(KhoSanPhamBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Sua(KhoSanPhamBDO entityBDO)
        {
            throw new NotImplementedException();
        }

        public void Xoa(int iD)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
