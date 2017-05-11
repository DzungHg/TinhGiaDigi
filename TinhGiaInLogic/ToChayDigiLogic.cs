using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class ToChayDigiLogic
    {
        ToChayDigiDAO toChayDigiDAO = new ToChayDigiDAO();
        public List<ToChayDigiBDO> DocTatCa()
        {
            var nguon = toChayDigiDAO.LayTatCa();
            return nguon.ToList();
        }
        public ToChayDigiBDO DocTheoId(int iD)
        {
            return toChayDigiDAO.LayTheoId(iD);
        }
    }
}
