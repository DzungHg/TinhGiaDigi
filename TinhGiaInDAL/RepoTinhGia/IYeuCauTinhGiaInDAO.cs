using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IYeuCauTinhGiaInDAO
    {

        IEnumerable<YeuCauTinhGiaInBDO> DocTatCa();
        YeuCauTinhGiaInBDO DocTheoId(int iD);
        string Them(YeuCauTinhGiaInBDO entityBDO);
        string Sua(YeuCauTinhGiaInBDO entityBDO);
        string Xoa(int iD);


    }
}
