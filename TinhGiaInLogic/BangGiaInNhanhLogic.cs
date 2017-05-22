using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class BangGiaInNhanhLogic
    {
        BangGiaInNhanhDAO bangGiaInNhanhDAO = new BangGiaInNhanhDAO();
        public List<BangGiaInNhanhBDO> LayTatCa()
        {
            var nguon = bangGiaInNhanhDAO.LayTatCa().ToList();
            return nguon;
        }
        public List<BangGiaInNhanhBDO> LayTheoIdHangKH(int iDHangKH)
        {
            var nguon = bangGiaInNhanhDAO.LayTheoIdHangKH(iDHangKH);
            return nguon.ToList();
        }
     
        public BangGiaInNhanhBDO LayTheoId(int iD)
        {
            return bangGiaInNhanhDAO.LayTheoId(iD);
        }
        public string Them (BangGiaInNhanhBDO bangGiaBDO)
        {
            return bangGiaInNhanhDAO.Them(bangGiaBDO);
        }
        public bool Sua(ref string thongDiep, BangGiaInNhanhBDO bangGiaBDO)
        {
            return bangGiaInNhanhDAO.Sua(ref thongDiep, bangGiaBDO);
        }
    }
}
