using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class MayInDigiLogic
    {
        MayInDigiDAO mayInDigiDAO = new MayInDigiDAO();
        public List<MayInDigiBDO> DocTatCa()
        {
            var nguon = mayInDigiDAO.DocTatCa().ToList();
            return nguon;
        }
        public MayInDigiBDO DocTheoId(int iD)
        {
            return mayInDigiDAO.DocTheoId(iD);
        }
        public string Sua(MayInDigiBDO mayIn)
        {
            return mayInDigiDAO.Sua(mayIn);
        }
        public string Them(MayInDigiBDO mayIn)
        {
            return mayInDigiDAO.Them(mayIn);
        }
    }
}
