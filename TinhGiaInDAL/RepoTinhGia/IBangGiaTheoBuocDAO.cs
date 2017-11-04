using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IBangGiaTheoBuocDAO
    {
        IEnumerable<BangGiaTheoBuocBDO> DocTatCa();
        BangGiaTheoBuocBDO DocTheoId(int iD);
        string Them(BangGiaTheoBuocBDO entityBDO);
        string Sua(BangGiaTheoBuocBDO entityBDO);
        string Xoa(int iD);     
    }
}
