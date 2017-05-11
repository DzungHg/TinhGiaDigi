using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class HangKhachHangLogic
    {
        HangKhachHangDAO hangKhachHangDAO = new HangKhachHangDAO();
        public List<HangKhachHangBDO> LayTatCa()
        {
            var nguon = hangKhachHangDAO.LayTatCa().ToList();
            return nguon;
        }


        public HangKhachHangBDO LayTheoId(int iD)
        {
            return hangKhachHangDAO.LayTheoId(iD);
        }
    }
}
