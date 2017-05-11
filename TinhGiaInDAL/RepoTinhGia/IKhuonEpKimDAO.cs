using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IKhuonEpKimDAO
    {

        IEnumerable<KhuonEpKimBDO> DocTatCa();
        IEnumerable<KhuonEpKimBDO> DocTheoIdEpkim(int idEpKim);
        KhuonEpKimBDO DocTheoId(int iD);
        string Them(KhuonEpKimBDO entityBDO);
        string Sua(KhuonEpKimBDO entityBDO);
        string Xoa(int iD);


    }
}
