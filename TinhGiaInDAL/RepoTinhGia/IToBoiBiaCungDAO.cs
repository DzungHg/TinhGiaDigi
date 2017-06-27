using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IToBoiBiaCungDAO
    {

        IEnumerable<ToBoiBiaCungBDO> DocTatCa();
        ToBoiBiaCungBDO DocTheoId(int iD);
        string Them(ToBoiBiaCungBDO entityBDO);
        string Sua(ToBoiBiaCungBDO entityBDO);
        string Xoa(int iD);


    }
}
