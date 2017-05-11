using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IGiayDAO
    {

        IEnumerable<GiayBDO> LayTatCa();
        IEnumerable<GiayBDO> LayNhieuTheoDanhMuc(int idDanhMuc);
        GiayBDO LayTheoId(int iD);
        string Them(GiayBDO entityBDO);
        string Sua(GiayBDO entityBDO);
        string Xoa(int iD);


    }
}
