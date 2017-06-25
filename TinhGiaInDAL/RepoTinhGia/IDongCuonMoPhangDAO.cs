using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IDongCuonMoPhangDAO
    {

        IEnumerable<DongCuonMoPhangBDO> DocTatCa();

        DongCuonMoPhangBDO DocTheoId(int iD);
        string Them(DongCuonMoPhangBDO entityBDO);
        string Sua(DongCuonMoPhangBDO entityBDO);
        string Xoa(int iD);     
    }
}
