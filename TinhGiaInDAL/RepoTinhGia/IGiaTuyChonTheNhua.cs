using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IGiaTuyChonTheNhuaDAO
    {

        IEnumerable<GiaTuyChonTheNhuaBDO> DocTatCa();
        GiaTuyChonTheNhuaBDO DocTheoId(int idBangGia, int idTuyChon);
        IEnumerable<GiaTuyChonTheNhuaBDO> DocTheoIdBangGia(int iD);
        IEnumerable<GiaTuyChonTheNhuaBDO> DocTheoIdTuyChon(int iD);
        string Them(GiaTuyChonTheNhuaBDO entityBDO);
        string Sua(GiaTuyChonTheNhuaBDO entityBDO);
        string Xoa(int idBangGia, int idTuyChon);     
    }
}
