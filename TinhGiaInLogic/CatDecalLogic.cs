using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class CatDecalLogic
    {
        CatDecalDAO catDecalDAO = new CatDecalDAO();
        public List<CatDecalBDO> DocTatCa()
        {
            var nguon = catDecalDAO.DocTatCa();
            return nguon.ToList();
        }

        public CatDecalBDO DocTheoId(int iD)
        {
            return catDecalDAO.DocTheoId(iD);
        }
        public string Them(CatDecalBDO catDecalBDO)
        {
            return catDecalDAO.Them(catDecalBDO);
        }
        public string Sua(CatDecalBDO catDecalBDO)
        {
            return catDecalDAO.Sua(catDecalBDO);
        }
    }
}
