using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class DongCuonLoXoLogic
    {
        DongCuonLoXoDAO dongCuonDAO = new DongCuonLoXoDAO();
        public List<DongCuonLoXoBDO> DocTatCa()
        {
            var nguon = dongCuonDAO.DocTatCa();
            return nguon.ToList();
        }

        public DongCuonLoXoBDO DocTheoId(int iD)
        {
            return dongCuonDAO.DocTheoId(iD);
        }
        public string Sua(DongCuonLoXoBDO dongCuonBDO)
        {
            return dongCuonDAO.Sua(dongCuonBDO);
        }
    }
}
