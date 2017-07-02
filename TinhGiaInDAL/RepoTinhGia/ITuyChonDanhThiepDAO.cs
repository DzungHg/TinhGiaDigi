using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface ITuyChonDanhThiepDAO
    {

        IEnumerable<TuyChonDanhThiepBDO> DocTatCa();
        TuyChonDanhThiepBDO DocTheoId(int iD);
        string Them(TuyChonDanhThiepBDO entityBDO);
        string Sua(TuyChonDanhThiepBDO entityBDO);
        string Xoa(int iD);


    }
}
