using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface ICanPhuDAO
    {

        IEnumerable<CanPhuBDO> LayTatCa();

        CanPhuBDO LayTheoId(int iD);
        string Them(CanPhuBDO entityBDO);
        string Sua(CanPhuBDO entityBDO);
        string Xoa(int iD);     
    }
}
