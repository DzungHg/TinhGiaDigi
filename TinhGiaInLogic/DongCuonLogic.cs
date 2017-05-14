using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class DongCuonLogic
    {
        DongCuonDAO dongCuonDAO = new DongCuonDAO();
        public List<DongCuonBDO> DocTatCa()
        {
            var nguon = dongCuonDAO.LayTatCa();
            return nguon.ToList();
        }

        public DongCuonBDO DocTheoId(int iD)
        {
            return dongCuonDAO.LayTheoId(iD);
        }
        public string Sua(DongCuonBDO dongCuonBDO)
        {
            return dongCuonDAO.Sua(dongCuonBDO);
        }
    }
}
