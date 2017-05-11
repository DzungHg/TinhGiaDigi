using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IDanhMucGiayDAO
    {

        IEnumerable<DanhMucGiayBDO> LayTatCa();
        IEnumerable<DanhMucGiayBDO> LayTheoNhaCungCap(string tenNCC);
        IEnumerable<string> NhaCungCapS();
        DanhMucGiayBDO LayTheoId(int iD);
        string  Them(DanhMucGiayBDO entityBDO);
        string  Sua(DanhMucGiayBDO entityBDO);
        string  Xoa(int iD);     
    }
}
