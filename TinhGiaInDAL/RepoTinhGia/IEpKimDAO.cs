using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IEpKimDAO
    {

        IEnumerable<EpKimBDO> DocTatCa();


        EpKimBDO DocTheoId(int iD);
        void Them(EpKimBDO entityBDO);
        void Sua(EpKimBDO entityBDO);
        void Xoa(int iD);     
    }
}
