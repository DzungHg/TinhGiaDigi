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
        CanPhuDAO canPhuDAO = new CanPhuDAO();
        public List<CanPhuBDO> LayTatCa()
        {
            var nguon = canPhuDAO.LayTatCa();
            return nguon.ToList();
        }

        public CanPhuBDO LayTheoId(int iD)
        {
            return canPhuDAO.LayTheoId(iD);
        }
        public string Sua(CanPhuBDO canPhuBDO)
        {
            return canPhuDAO.Sua(canPhuBDO);
        }
    }
}
