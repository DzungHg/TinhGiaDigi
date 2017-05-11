using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IHangKhachHangDAO
    {
        IEnumerable<HangKhachHangBDO> LayTatCa();
        HangKhachHangBDO LayTheoId(int iD);
        void Them(HangKhachHangBDO entityBDO);
        void Sua(HangKhachHangBDO entityBDO);
        void Xoa(int iD);     
    }
}
