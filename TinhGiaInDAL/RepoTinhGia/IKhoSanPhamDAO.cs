using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    interface IKhoSanPhamDAO
    {
        IEnumerable<KhoSanPhamBDO> LayTatCa();
        KhoSanPhamBDO LayTheoId(int iD);
        void Them(KhoSanPhamBDO entityBDO);
        void Sua(KhoSanPhamBDO entityBDO);
        void Xoa(int iD);     
        
    }
}
