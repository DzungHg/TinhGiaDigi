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
        void Them(DongCuonBDO entityBDO);
        void Sua(DongCuonBDO entityBDO);
        void Xoa(int iD);     
    }
}
