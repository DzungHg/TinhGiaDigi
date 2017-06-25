using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class DongCuonMoPhangLogic
    {
        DongCuonMoPhangDAO dongCuonDAO = new DongCuonMoPhangDAO();
        public List<DongCuonMoPhangBDO> DocTatCa()
        {
            var nguon = dongCuonDAO.DocTatCa();
            return nguon.ToList();
        }

        public DongCuonMoPhangBDO DocTheoId(int iD)
        {
            return dongCuonDAO.DocTheoId(iD);
        }
        public string Sua(DongCuonMoPhangBDO dongCuonBDO)
        {
            return dongCuonDAO.Sua(dongCuonBDO);
        }
    }
}
