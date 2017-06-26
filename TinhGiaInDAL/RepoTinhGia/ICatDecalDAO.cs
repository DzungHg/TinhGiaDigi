using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface ICatDecalDAO
    {

        IEnumerable<CatDecalBDO> DocTatCa();

        CatDecalBDO DocTheoId(int iD);
        string Them(CatDecalBDO entityBDO);
        string Sua(CatDecalBDO entityBDO);
        string Xoa(int iD);     
    }
}
