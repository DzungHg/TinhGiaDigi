using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IDongCuonLoXoDAO
    {

        IEnumerable<DongCuonLoXoBDO> DocTatCa();

        DongCuonLoXoBDO DocTheoId(int iD);
        string Them(DongCuonLoXoBDO entityBDO);
        string Sua(DongCuonLoXoBDO entityBDO);
        string Xoa(int iD);     
    }
}
