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
        BangGiaDanhThiepBDO DocTheoId(int iD);
        void Them(BangGiaDanhThiepBDO entityBDO);
        void Sua(BangGiaDanhThiepBDO entityBDO);
        void Xoa(int iD);     
    }
}
