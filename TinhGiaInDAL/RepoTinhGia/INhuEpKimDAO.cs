using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface INhuEpKimDAO
    {

        IEnumerable<NhuEpKimBDO> DocTatCa();
        IEnumerable<NhuEpKimBDO> DocTheoIdEpkim(int idEpKim);
        NhuEpKimBDO DocTheoId(int iD);
        string Them(NhuEpKimBDO entityBDO);
        string Sua(NhuEpKimBDO entityBDO);
        string Xoa(int iD);


    }
}
