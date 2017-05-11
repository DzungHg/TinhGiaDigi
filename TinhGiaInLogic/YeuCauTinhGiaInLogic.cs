using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class YeuCauTinhGiaInLogic
    {
        YeuCauTinhGiaInDAO tinhGiaDAO = new YeuCauTinhGiaInDAO();
        public List<YeuCauTinhGiaInBDO> DocTatCa()
        {
            var nguon = tinhGiaDAO.DocTatCa().ToList();
            return nguon;
        }

        public YeuCauTinhGiaInBDO DocTheoId(int iD)
        {
            return tinhGiaDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(YeuCauTinhGiaInBDO entityBDO)
        {
            return tinhGiaDAO.Them(entityBDO);
        }
        public string Sua(YeuCauTinhGiaInBDO entityBDO)
        {
            return tinhGiaDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return tinhGiaDAO.Xoa(iD);
        }
        #endregion
    }
}
