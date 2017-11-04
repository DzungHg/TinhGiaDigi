using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IBangGiaLuyTienDAO
    {
        IEnumerable<BangGiaLuyTienBDO> DocTatCa();
        BangGiaLuyTienBDO DocTheoId(int iD);
        string Them(BangGiaLuyTienBDO entityBDO);
        string Sua(BangGiaLuyTienBDO entityBDO);
        string Xoa(int iD);     
    }
}
