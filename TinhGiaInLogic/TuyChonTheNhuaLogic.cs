using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class TuyChonTheNhuaLogic
    {
        TuyChonTheNhuaDAO tuyChonTheNhuaDAO = new TuyChonTheNhuaDAO();
        public List<TuyChonTheNhuaBDO> DocTatCa()
        {
            var nguon = tuyChonTheNhuaDAO.DocTatCa();
            return nguon.ToList();
        }

        public TuyChonTheNhuaBDO DocTheoId(int iD)
        {
            return tuyChonTheNhuaDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(TuyChonTheNhuaBDO entityBDO)
        {
            return tuyChonTheNhuaDAO.Them(entityBDO);
        }
        public string Sua(TuyChonTheNhuaBDO entityBDO)
        {
            return tuyChonTheNhuaDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return tuyChonTheNhuaDAO.Xoa(iD);
        }
        #endregion
    }
}
