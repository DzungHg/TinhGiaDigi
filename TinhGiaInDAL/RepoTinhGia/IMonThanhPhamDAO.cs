using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IMonThanhPhamDAO
    {
        IEnumerable<MonThanhPhamBDO> DocTatCa();
        MonThanhPhamBDO DocTheoId(int iD);
        void Them(MonThanhPhamBDO entityBDO);
        string Sua(MonThanhPhamBDO entityBDO);
        void Xoa(int iD);     
        
    }
}
