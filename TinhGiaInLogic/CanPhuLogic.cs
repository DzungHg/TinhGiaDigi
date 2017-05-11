using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class CanPhuLogic
    {
        CanPhuDAO dMucGiayDAO = new CanPhuDAO();
        public List<CanPhuBDO> LayTatCa()
        {
            var nguon = dMucGiayDAO.LayTatCa();
            return nguon.ToList();
        }

        public CanPhuBDO LayTheoId(int iD)
        {
            return dMucGiayDAO.LayTheoId(iD);
        }
    }
}
