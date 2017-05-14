using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IDongCuonDAO
    {

        IEnumerable<DongCuonBDO> LayTatCa();

        DongCuonBDO LayTheoId(int iD);
        string Them(DongCuonBDO entityBDO);
        string Sua(DongCuonBDO entityBDO);
        string Xoa(int iD);     
    }
}
