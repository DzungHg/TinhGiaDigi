using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface ICanGapDAO
    {

        IEnumerable<CanGapBDO> LayTatCa();


        CanGapBDO LayTheoId(int iD);
        void Them(CanGapBDO entityBDO);
        void Sua(CanGapBDO entityBDO);
        void Xoa(int iD);     
    }
}
