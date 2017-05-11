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
        CanGapDAO dMucGiayDAO = new CanGapDAO();
        public List<CanGapBDO> LayTatCa()
        {
            var nguon = dMucGiayDAO.LayTatCa();
            return nguon.ToList();
        }

        public CanGapBDO LayTheoId(int iD)
        {
            return dMucGiayDAO.LayTheoId(iD);
        }
    }
}
