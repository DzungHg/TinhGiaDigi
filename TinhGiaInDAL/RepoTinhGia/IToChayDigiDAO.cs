using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    interface IToChayDigiDAO
    {
        IEnumerable<ToChayDigiBDO> LayTatCa();
        ToChayDigiBDO LayTheoId(int iD);
        void Them(ToChayDigiBDO entityBDO);
        void Sua(ToChayDigiBDO entityBDO);
        void Xoa(int iD);     
        
    }
}
