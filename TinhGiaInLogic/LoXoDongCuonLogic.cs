using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class LoXoDongCuonLogic
    {
        LoXoDongCuonDAO loXoDongCuonDAO = new LoXoDongCuonDAO();
        public List<LoXoDongCuonBDO> DocTatCa()
        {
            var nguon = loXoDongCuonDAO.DocTatCa();
            return nguon.ToList();
        }

        public LoXoDongCuonBDO DocTheoId(int iD)
        {
            return loXoDongCuonDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(LoXoDongCuonBDO entityBDO)
        {
            return loXoDongCuonDAO.Them(entityBDO);
        }
        public string Sua(LoXoDongCuonBDO entityBDO)
        {
            return loXoDongCuonDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return loXoDongCuonDAO.Xoa(iD);
        }
        #endregion
    }
}
