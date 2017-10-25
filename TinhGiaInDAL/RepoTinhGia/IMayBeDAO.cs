using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IMayBeDAO
    {

        IEnumerable<MayBeBDO> DocTatCa();


        MayBeBDO DocTheoId(int iD);
        string Them(MayBeBDO entityBDO);
        string Sua(MayBeBDO entityBDO);
        string Xoa(int iD);     
    }
}
