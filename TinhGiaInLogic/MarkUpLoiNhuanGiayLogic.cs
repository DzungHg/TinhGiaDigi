using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class MarkUpLoiNhuanGiayLogic
    {
        MarkUpLoiNhuanGiayDAO markUpLNGDAO = new MarkUpLoiNhuanGiayDAO();

        public List<MarkUpLoiNhuanGiayBDO> LayTatCa()
        {
            return markUpLNGDAO.LayTatCa().ToList();
        }
        public MarkUpLoiNhuanGiayBDO LayTheoId(int idDanhMucGiay, int idHangKH)
        {
            return markUpLNGDAO.LayTheoId(idDanhMucGiay, idHangKH);
        }
        public List<MarkUpLoiNhuanGiayBDO> LayTheoIdDanhMucGiay(int iD)
        {
            return markUpLNGDAO.LayTheoIdDanhMucGiay(iD).ToList();
        }
        public List<MarkUpLoiNhuanGiayBDO> LayTheoIdHangKH(int iD)
        {
            return markUpLNGDAO.LayTheoIdHangKH(iD).ToList();
        }
        public string Them(MarkUpLoiNhuanGiayBDO entityBDO)
        {
            return markUpLNGDAO.Them(entityBDO);
        }
        public string Sua(MarkUpLoiNhuanGiayBDO entityBDO)
        {
            return markUpLNGDAO.Sua(entityBDO);
        }
    }
}
