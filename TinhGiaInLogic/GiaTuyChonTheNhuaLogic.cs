using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class GiaTuyChonTheNhuaLogic
    {
        GiaTuyChonTheNhuaDAO giaTuyChonTheNhuaDAO = new GiaTuyChonTheNhuaDAO();

        public List<GiaTuyChonTheNhuaBDO> DocTatCa()
        {
            return giaTuyChonTheNhuaDAO.DocTatCa().ToList();
        }
        public GiaTuyChonTheNhuaBDO DocTheoId(int idDanhMucGiay, int idHangKH)
        {
            return giaTuyChonTheNhuaDAO.DocTheoId(idDanhMucGiay, idHangKH);
        }
        public List<GiaTuyChonTheNhuaBDO> DocTheoIdBangGia(int iD)
        {
            return giaTuyChonTheNhuaDAO.DocTheoIdBangGia(iD).ToList();
        }
        public List<GiaTuyChonTheNhuaBDO> DocTheoIdTuyChon(int iD)
        {
            return giaTuyChonTheNhuaDAO.DocTheoIdTuyChon(iD).ToList();
        }
        public string Them(GiaTuyChonTheNhuaBDO entityBDO)
        {
            return giaTuyChonTheNhuaDAO.Them(entityBDO);
        }
        public string Sua(GiaTuyChonTheNhuaBDO entityBDO)
        {
            return giaTuyChonTheNhuaDAO.Sua(entityBDO);
        }
        public string Xoa(int idBangGia, int idTuyChon)
        {
            return giaTuyChonTheNhuaDAO.Xoa(idBangGia, idTuyChon);
        }
    }
}
