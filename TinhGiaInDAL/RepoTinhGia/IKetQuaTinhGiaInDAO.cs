using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IKetQuaTinhGiaInDAO
    {

        IEnumerable<KetQuaTinhGiaInBDO> DocTatCa();
        IEnumerable<KetQuaTinhGiaInBDO> DocTheoYeuCauTinhGia(int iDYeuCau);
        KetQuaTinhGiaInBDO DocTheoId(int iD);
        string Them(KetQuaTinhGiaInBDO entityBDO);
        string Sua(KetQuaTinhGiaInBDO entityBDO);
        string Xoa(int iD);


    }
}
