using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IMayInDigiDAO
    {
        IEnumerable<MayInDigiBDO> DocTatCa();
        MayInDigiBDO DocTheoId(int iD);
        string Them(MayInDigiBDO entityBDO);
        string Sua(MayInDigiBDO entityBDO);
        string Xoa(int iD);     
        
    }
}
