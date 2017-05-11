using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class KhuonEpKimLogic
    {
        KhuonEpKimDAO khuonEpKimDAO = new KhuonEpKimDAO();
        public List<KhuonEpKimBDO> DocTatCa()
        {
            var nguon = khuonEpKimDAO.DocTatCa();
            return nguon.ToList();
        }
        public List<KhuonEpKimBDO> DocTheoIdEpKim( int idEpKim)
        {
            var nguon = khuonEpKimDAO.DocTheoIdEpkim(idEpKim);
            return nguon.ToList();
        }
        public KhuonEpKimBDO DocTheoId(int iD)
        {
            return khuonEpKimDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(KhuonEpKimBDO entityBDO)
        {
            return khuonEpKimDAO.Them(entityBDO);
        }
        public string Sua(KhuonEpKimBDO entityBDO)
        {
            return khuonEpKimDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return khuonEpKimDAO.Xoa(iD);
        }
        #endregion
    }
}
