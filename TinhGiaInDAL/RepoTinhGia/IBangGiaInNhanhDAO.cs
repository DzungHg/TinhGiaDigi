using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IBangGiaInNhanhDAO
    {
        IEnumerable<BangGiaInNhanhBDO> LayTatCa();       
        BangGiaInNhanhBDO LayTheoId(int iD);
        string Them(BangGiaInNhanhBDO entityBDO);
        bool Sua(ref string thongDiep, BangGiaInNhanhBDO entityBDO);
        string Xoa(int iD);     
    }
}
