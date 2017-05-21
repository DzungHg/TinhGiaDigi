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
        IEnumerable<ToInMayDigiBDO> LayTatCa();
        ToInMayDigiBDO LayTheoId(int iD);
        bool Them(ref string thongDiep, ToInMayDigiBDO entityBDO);
        bool Sua( ref string thongDiep, ToInMayDigiBDO entityBDO);
        bool Xoa(int iD);     
        
    }
}
