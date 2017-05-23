using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class NguoiDungLogic
    {
        NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();
        public List<NguoiDungBDO> DocTatCa()
        {
            var nguon = nguoiDungDAO.DocTatCa();
            return nguon.ToList();
        }

        public NguoiDungBDO DicTheoId(int iD)
        {
            return nguoiDungDAO.DocTheoId(iD);
        }
        public NguoiDungBDO DicTheoTenDangNhap(string tenDangNhap)
        {
            return nguoiDungDAO.DocTheoTenDangNhap(tenDangNhap);
        }
        public string Sua(NguoiDungBDO canGapBDO)
        {
            return nguoiDungDAO.Sua(canGapBDO);
        }
    }
}
