using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IToLotMoPhangDAO
    {

        IEnumerable<ToLotMoPhangBDO> DocTatCa();       
        ToLotMoPhangBDO DocTheoId(int iD);
        string Them(ToLotMoPhangBDO entityBDO);
        string Sua(ToLotMoPhangBDO entityBDO);
        string Xoa(int iD);


    }
}
