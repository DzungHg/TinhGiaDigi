using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IGiaTuyChonDanhThiepDAO
    {

        IEnumerable<GiaTuyChonDanhThiepBDO> DocTatCa();
        GiaTuyChonDanhThiepBDO DocTheoId(int idBangGia, int idTuyChon);
        IEnumerable<GiaTuyChonDanhThiepBDO> DocTheoIdBangGia(int iD);
        IEnumerable<GiaTuyChonDanhThiepBDO> DocTheoIdTuyChon(int iD);
        string Them(GiaTuyChonDanhThiepBDO entityBDO);
        string Sua(GiaTuyChonDanhThiepBDO entityBDO);
        string Xoa(int idBangGia, int idTuyChon);     
    }
}
