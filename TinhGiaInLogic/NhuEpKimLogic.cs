using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class NhuEpKimLogic
    {
        NhuEpKimDAO nhuEpKimDAO = new NhuEpKimDAO();
        public List<NhuEpKimBDO> DocTatCa()
        {
            var nguon = nhuEpKimDAO.DocTatCa();
            return nguon.ToList();
        }
        public List<NhuEpKimBDO> DocTheoIdEpKim(int idEpKim)
        {
            var nguon = nhuEpKimDAO.DocTheoIdEpkim(idEpKim);
            return nguon.ToList();
        }
        public NhuEpKimBDO DocTheoId(int iD)
        {
            return nhuEpKimDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(NhuEpKimBDO entityBDO)
        {
            return nhuEpKimDAO.Them(entityBDO);
        }
        public string Sua(NhuEpKimBDO entityBDO)
        {
            return nhuEpKimDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return nhuEpKimDAO.Xoa(iD);
        }
        #endregion
    }
}
