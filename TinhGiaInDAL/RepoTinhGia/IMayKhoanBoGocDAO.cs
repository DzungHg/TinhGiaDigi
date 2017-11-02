using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IMayKhoanBoGocDAO
    {

        IEnumerable<MayKhoanBoGocBDO> DocTatCa();

        MayKhoanBoGocBDO DocTheoId(int iD);
        string Them(MayKhoanBoGocBDO entityBDO);
        string Sua(MayKhoanBoGocBDO entityBDO);
        string Xoa(int iD);     
    }
}
