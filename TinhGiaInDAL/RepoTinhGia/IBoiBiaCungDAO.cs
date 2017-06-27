using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IBoiBiaCungDAO
    {

        IEnumerable<BoiBiaCungBDO> DocTatCa();

        BoiBiaCungBDO DocTheoId(int iD);
        string Them(BoiBiaCungBDO entityBDO);
        string Sua(BoiBiaCungBDO entityBDO);
        string Xoa(int iD);     
    }
}
