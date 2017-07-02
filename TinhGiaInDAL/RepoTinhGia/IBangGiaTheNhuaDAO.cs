using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IBangGiaTheNhuaDAO
    {
        IEnumerable<BangGiaTheNhuaBDO> DocTatCa();
        BangGiaTheNhuaBDO DocTheoId(int iD);
        string Them(BangGiaTheNhuaBDO entityBDO);
        string Sua(BangGiaTheNhuaBDO entityBDO);
        string Xoa(int iD);     
    }
}
