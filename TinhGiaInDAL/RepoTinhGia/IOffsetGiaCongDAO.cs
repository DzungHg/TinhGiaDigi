using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    interface IOffsetGiaCongDAO
    {
        IEnumerable<OffsetGiaCongBDO> DocTatCa();
        OffsetGiaCongBDO DocTheoId(int iD);
        IEnumerable<OffsetGiaCongBDO> DocTheoNhaCungCap(string tenNCC);
        IEnumerable<string> NhaCungCapS();
        void Them(OffsetGiaCongBDO entityBDO);
        void Sua(OffsetGiaCongBDO entityBDO);
        void Xoa(int iD);     
        
    }
}
