using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class MayBeLogic
    {
        MayBeDAO mayBeDAO = new MayBeDAO();
        public List<MayBeBDO> DocTatCa()
        {
            var nguon = mayBeDAO.DocTatCa();
            return nguon.ToList();
        }
        public MayBeBDO DocTheoId(int iD)
        {
            return mayBeDAO.DocTheoId(iD);
        }
        public string Them(MayBeBDO epKimBDO)
        {
            return mayBeDAO.Them(epKimBDO);
        }
        public string Sua(MayBeBDO epKimBDO)
        {
            return mayBeDAO.Sua(epKimBDO);
        }
    }
}
