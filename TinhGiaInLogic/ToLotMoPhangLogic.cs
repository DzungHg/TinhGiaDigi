using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class ToLotMoPhangLogic
    {
        ToLotMoPhangDAO toLotMoPhangDAO = new ToLotMoPhangDAO();
        public List<ToLotMoPhangBDO> DocTatCa()
        {
            var nguon = toLotMoPhangDAO.DocTatCa();
            return nguon.ToList();
        }
        
        public ToLotMoPhangBDO DocTheoId(int iD)
        {
            return toLotMoPhangDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(ToLotMoPhangBDO entityBDO)
        {
            return toLotMoPhangDAO.Them(entityBDO);
        }
        public string Sua(ToLotMoPhangBDO entityBDO)
        {
            return toLotMoPhangDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return toLotMoPhangDAO.Xoa(iD);
        }
        #endregion
    }
}
