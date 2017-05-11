using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class GiayLogic
    {
        GiayDAO giayDAO = new GiayDAO();
        public List<GiayBDO> LayTatCa()
        {
            var nguon = giayDAO.LayTatCa().ToList();
            return nguon;
        }
        public List<GiayBDO> LayNhieuTheoDanhMuc(int idDanhMuc)
        {
            var nguon = giayDAO.LayNhieuTheoDanhMuc(idDanhMuc).ToList();
            return nguon;
        }
        public GiayBDO LayTheoId(int iD)
        {
            return giayDAO.LayTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(GiayBDO entityBDO)
        {
            return giayDAO.Them(entityBDO);
        }
        public string Sua(GiayBDO entityBDO)
        {
            return giayDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            return giayDAO.Xoa(iD);
        }
        #endregion
    }
}
