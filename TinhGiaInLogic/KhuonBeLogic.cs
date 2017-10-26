using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class KhuonBeLogic
    {
        KhuonBeDAO khuonBeDAO = new KhuonBeDAO();
        public List<KhuonBeBDO> DocTatCa()
        {
            var nguon = khuonBeDAO.DocTatCa();
            return nguon.ToList();
        }
        public List<KhuonBeBDO> DocTheoIdEpKim(int idMayBe)
        {
            var nguon = khuonBeDAO.DocTheoIdMayBe(idMayBe);
            return nguon.ToList();
        }
        public KhuonBeBDO DocTheoId(int iD)
        {
            return khuonBeDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(KhuonBeBDO entityBDO)
        {
            return khuonBeDAO.Them(entityBDO);
        }
        public string Sua(KhuonBeBDO entityBDO)
        {
            return khuonBeDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return khuonBeDAO.Xoa(iD);
        }
        #endregion
    }
}
