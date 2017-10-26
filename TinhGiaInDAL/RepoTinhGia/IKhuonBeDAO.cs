using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IKhuonBeDAO
    {

        IEnumerable<KhuonBeBDO> DocTatCa();
        IEnumerable<KhuonBeBDO> DocTheoIdMayBe(int idMayBe);
        KhuonBeBDO DocTheoId(int iD);
        string Them(KhuonBeBDO entityBDO);
        string Sua(KhuonBeBDO entityBDO);
        string Xoa(int iD);


    }
}
