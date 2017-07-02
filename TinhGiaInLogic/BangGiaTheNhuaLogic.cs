using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class BangGiaTheNhuaLogic
    {
        BangGiaTheNhuaDAO bangGiaDAO = new BangGiaTheNhuaDAO();
        public List<BangGiaTheNhuaBDO> DocTatCa()
        {
            var nguon = bangGiaDAO.DocTatCa().ToList();
            return nguon;
        }
        public List<BangGiaTheNhuaBDO> DocTheoIdHangKH(int iDHangKH)
        {
            var nguon = bangGiaDAO.DocTheoIdHangKH(iDHangKH);
            return nguon.ToList();
        }

        public BangGiaTheNhuaBDO DocTheoId(int iD)
        {
            return bangGiaDAO.DocTheoId(iD);
        }
        public string Them(BangGiaTheNhuaBDO bangGiaBDO)
        {
            return bangGiaDAO.Them(bangGiaBDO);
        }
        public string Sua( BangGiaTheNhuaBDO bangGiaBDO)
        {
            return bangGiaDAO.Sua(bangGiaBDO);
        }
    }
}
