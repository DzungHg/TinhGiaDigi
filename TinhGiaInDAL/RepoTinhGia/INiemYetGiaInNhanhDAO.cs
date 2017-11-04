using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface INiemYetGiaInNhanhDAO
    {
        IEnumerable<NiemYetGiaInNhanhBDO> DocTatCa();
        IEnumerable<NiemYetGiaInNhanhBDO> DocTheoIdHangKhachHang(int idHangKH);  

        NiemYetGiaInNhanhBDO DocTheoId(int iD);
        string Them(NiemYetGiaInNhanhBDO entityBDO);
        bool Sua(ref string thongDiep, NiemYetGiaInNhanhBDO entityBDO);
        string Xoa(int iD);     
    }
}
