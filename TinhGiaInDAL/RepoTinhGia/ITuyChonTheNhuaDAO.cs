using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface ITuyChonTheNhuaDAO
    {

        IEnumerable<TuyChonTheNhuaBDO> DocTatCa();
        TuyChonTheNhuaBDO DocTheoId(int iD);
        string Them(TuyChonTheNhuaBDO entityBDO);
        string Sua(TuyChonTheNhuaBDO entityBDO);
        string Xoa(int iD);


    }
}
