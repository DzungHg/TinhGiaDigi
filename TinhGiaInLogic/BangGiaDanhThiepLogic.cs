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
        BangGiaDanhThiepDAO bangGiaDAO = new BangGiaDanhThiepDAO();
        public List<BangGiaDanhThiepBDO> LayTatCa()
        {
            var nguon = bangGiaDAO.DocTatCa().ToList();
            return nguon;
        }
        public List<BangGiaDanhThiepBDO> LayTheoIdHangKH(int iDHangKH)
        {
            var nguon = bangGiaDAO.DocTheoIdHangKH(iDHangKH);
            return nguon.ToList();
        }

        public BangGiaDanhThiepBDO DocTheoId(int iD)
        {
            return bangGiaDAO.DocTheoId(iD);
        }
        public string Them(BangGiaDanhThiepBDO bangGiaBDO)
        {
            return bangGiaDAO.Them(bangGiaBDO);
        }
        public string Sua( BangGiaDanhThiepBDO bangGiaBDO)
        {
            return bangGiaDAO.Sua(bangGiaBDO);
        }
    }
}
