using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IMayBoiNhieuLopDAO
    {

        IEnumerable<MayBoiNhieuLopBDO> DocTatCa();

        MayBoiNhieuLopBDO DocTheoId(int iD);
        string Them(MayBoiNhieuLopBDO entityBDO);
        string Sua(MayBoiNhieuLopBDO entityBDO);
        string Xoa(int iD);     
    }
}
