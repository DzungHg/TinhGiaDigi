using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface INguoiDungDAO
    {

        IEnumerable<NguoiDungBDO> DocTatCa();


        NguoiDungBDO DocTheoId(int iD);
        NguoiDungBDO DocTheoTenDangNhap(string tenDangNhap);
        string Them(NguoiDungBDO entityBDO);
        string Sua(NguoiDungBDO entityBDO);
        string Xoa(int iD);     
    }
}
