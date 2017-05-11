using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class KetQuaTinhGiaInLogic
    {
        KetQuaTinhGiaInDAO tinhGiaDAO = new KetQuaTinhGiaInDAO();
        public List<KetQuaTinhGiaInBDO> DocTatCa()
        {
            var nguon = tinhGiaDAO.DocTatCa().ToList();
            return nguon;
        }
        public List<KetQuaTinhGiaInBDO> DocTheuYeuCauTinhGia(int iDYeuCau)
        {
            var nguon = tinhGiaDAO.DocTheoYeuCauTinhGia(iDYeuCau).ToList();
            return nguon;
        } 
        public List<KetQuaTinhGiaInBDO> DocTatCaSX_Ngay()
        {
            var nguon = tinhGiaDAO.DocTatCa().OrderBy(x => x.NgayTinhGia).ToList();
            return nguon;
        }
        public KetQuaTinhGiaInBDO DocTheoId(int iD)
        {
            return tinhGiaDAO.DocTheoId(iD);
        }
        #region Thêm sửa xóa
        public string Them(KetQuaTinhGiaInBDO entityBDO)
        {
            return tinhGiaDAO.Them(entityBDO);
        }
        public string Sua(KetQuaTinhGiaInBDO entityBDO)
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
