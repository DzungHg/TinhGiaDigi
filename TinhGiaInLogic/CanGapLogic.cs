using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class CanGapLogic
    {
        CanGapDAO canGapDAO = new CanGapDAO();
        public List<CanGapBDO> LayTatCa()
        {
            var nguon = canGapDAO.LayTatCa();
            return nguon.ToList();
        }

        public CanGapBDO LayTheoId(int iD)
        {
            return canGapDAO.LayTheoId(iD);
        }
        public string Sua(CanGapBDO canGapBDO)
        {
            return canGapDAO.Sua(canGapBDO);
        }
    }
}
