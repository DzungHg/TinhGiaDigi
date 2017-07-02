using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class GiaTuyChonDanhThiepLogic
    {
        GiaTuyChonDanhThiepDAO giaTuyChonDanhThiepDAO = new GiaTuyChonDanhThiepDAO();

        public List<GiaTuyChonDanhThiepBDO> DocTatCa()
        {
            return giaTuyChonDanhThiepDAO.DocTatCa().ToList();
        }
        public GiaTuyChonDanhThiepBDO DocTheoId(int idDanhMucGiay, int idHangKH)
        {
            return giaTuyChonDanhThiepDAO.DocTheoId(idDanhMucGiay, idHangKH);
        }
        public List<GiaTuyChonDanhThiepBDO> DocTheoIdBangGia(int iD)
        {
            return giaTuyChonDanhThiepDAO.DocTheoIdBangGia(iD).ToList();
        }
        public List<GiaTuyChonDanhThiepBDO> DocTheoIdTuyChon(int iD)
        {
            return giaTuyChonDanhThiepDAO.DocTheoIdTuyChon(iD).ToList();
        }
        public string Them(GiaTuyChonDanhThiepBDO entityBDO)
        {
            return giaTuyChonDanhThiepDAO.Them(entityBDO);
        }
        public string Sua(GiaTuyChonDanhThiepBDO entityBDO)
        {
            return giaTuyChonDanhThiepDAO.Sua(entityBDO);
        }
        public string Xoa(int idBangGia, int idTuyChon)
        {
            return giaTuyChonDanhThiepDAO.Xoa(idBangGia, idTuyChon);
        }
    }
}
