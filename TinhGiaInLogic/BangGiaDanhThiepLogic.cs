using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class BangGiaDanhThiepLogic
    {
        BangGiaDanhThiepDAO bangGiaInNhanhDAO = new BangGiaDanhThiepDAO();
        public List<BangGiaDanhThiepBDO> LayTatCa()
        {
            var nguon = bangGiaInNhanhDAO.DocTatCa().ToList();
            return nguon;
        }
        public List<BangGiaDanhThiepBDO> LayTheoIdHangKH(int iDHangKH)
        {
            var nguon = bangGiaInNhanhDAO.DocTheoIdHangKH(iDHangKH);
            return nguon.ToList();
        }

        public BangGiaDanhThiepBDO DocTheoId(int iD)
        {
            return bangGiaInNhanhDAO.DocTheoId(iD);
        }
    }
}
