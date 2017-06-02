using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface ILoXoDongCuonDAO
    {

        IEnumerable<LoXoDongCuonBDO> DocTatCa();
      
        LoXoDongCuonBDO DocTheoId(int iD);
        string Them(LoXoDongCuonBDO entityBDO);
        string Sua(LoXoDongCuonBDO entityBDO);
        string Xoa(int iD);


    }
}
