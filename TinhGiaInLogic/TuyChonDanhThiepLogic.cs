using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class TuyChonDanhThiepLogic
    {
        TuyChonDanhThiepDAO tuyChonDanhThiepDAO = new TuyChonDanhThiepDAO();
        public List<TuyChonDanhThiepBDO> DocTatCa()
        {
            var nguon = tuyChonDanhThiepDAO.DocTatCa();
            return nguon.ToList();
        }

        public TuyChonDanhThiepBDO DocTheoId(int iD)
        {
            return tuyChonDanhThiepDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(TuyChonDanhThiepBDO entityBDO)
        {
            return tuyChonDanhThiepDAO.Them(entityBDO);
        }
        public string Sua(TuyChonDanhThiepBDO entityBDO)
        {
            return tuyChonDanhThiepDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return tuyChonDanhThiepDAO.Xoa(iD);
        }
        #endregion
    }
}
