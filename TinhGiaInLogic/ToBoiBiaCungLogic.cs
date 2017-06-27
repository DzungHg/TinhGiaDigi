using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class ToBoiBiaCungLogic
    {
        ToBoiBiaCungDAO toBoiBiaCungDAO = new ToBoiBiaCungDAO();
        public List<ToBoiBiaCungBDO> DocTatCa()
        {
            var nguon = toBoiBiaCungDAO.DocTatCa();
            return nguon.ToList();
        }

        public ToBoiBiaCungBDO DocTheoId(int iD)
        {
            return toBoiBiaCungDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(ToBoiBiaCungBDO entityBDO)
        {
            return toBoiBiaCungDAO.Them(entityBDO);
        }
        public string Sua(ToBoiBiaCungBDO entityBDO)
        {
            return toBoiBiaCungDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return toBoiBiaCungDAO.Xoa(iD);
        }
        #endregion
    }
}
