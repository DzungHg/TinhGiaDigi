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
        DongCuonDAO dMucGiayDAO = new DongCuonDAO();
        public List<DongCuonBDO> DocTatCa()
        {
            var nguon = dMucGiayDAO.LayTatCa();
            return nguon.ToList();
        }

        public DongCuonBDO DocTheoId(int iD)
        {
            return dMucGiayDAO.LayTheoId(iD);
        }
    }
}
