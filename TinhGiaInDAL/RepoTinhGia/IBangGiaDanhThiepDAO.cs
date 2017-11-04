using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IBangGiaDanhThiepDAO
    {
        IEnumerable<BangGiaDanhThiepBDO> DocTatCa();
        IEnumerable<BangGiaDanhThiepBDO> DocTheoIdHangKH(int idHangKH);
        BangGiaDanhThiepBDO DocTheoId(int iD);
        string Them(BangGiaDanhThiepBDO entityBDO);
        string Sua(BangGiaDanhThiepBDO entityBDO);
        string Xoa(int iD);     
    }
}
