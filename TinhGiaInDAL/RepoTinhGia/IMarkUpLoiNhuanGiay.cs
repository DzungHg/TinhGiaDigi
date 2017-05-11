using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IMarkUpLoiNhuanGiayDAO
    {

        IEnumerable<MarkUpLoiNhuanGiayBDO> LayTatCa();
        MarkUpLoiNhuanGiayBDO LayTheoId(int idDanhMucGiay, int idHangKH);
        IEnumerable<MarkUpLoiNhuanGiayBDO> LayTheoIdDanhMucGiay(int iD);
        IEnumerable<MarkUpLoiNhuanGiayBDO> LayTheoIdHangKH(int iD);
        string Them(MarkUpLoiNhuanGiayBDO entityBDO);
        string Sua(MarkUpLoiNhuanGiayBDO entityBDO);
        void Xoa(int idDanhMucGiay, int idHangKH);     
    }
}
