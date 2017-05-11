using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class DanhMucGiayLogic
    {
        DanhMucGiayDAO dMucGiayDAO = new DanhMucGiayDAO();
        public List<DanhMucGiayBDO> LayTatCa()
        {
            var nguon = dMucGiayDAO.LayTatCa();
            return nguon.ToList();
        }
        public List<DanhMucGiayBDO> LayTheoNhaCungCap(string tenNCC)
        {
            var nguon = dMucGiayDAO.LayTheoNhaCungCap(tenNCC)
               ;
            return nguon.ToList();
        }
        public List<string> NhaCungCapS()
        {
            var nguon = dMucGiayDAO.NhaCungCapS().ToList();
            return nguon;
        }
        public DanhMucGiayBDO LayTheoId(int iD)
        {
            return dMucGiayDAO.LayTheoId(iD);
        }
        #region Thêm, sửa, xóa
        public string Them(DanhMucGiayBDO entityBDO)
        {
            return dMucGiayDAO.Them(entityBDO);
        }
        public string Sua(DanhMucGiayBDO entityBDO)
        {
            return dMucGiayDAO.Sua(entityBDO);
        }
        public string Xoa(int iD)
        {
            ///Cần kiểm tra xem tên danh mục có chứa giấy hay không nếu có thì 0 cho xóa
            var giayCheck = new  GiayDAO().LayNhieuTheoDanhMuc(iD);
            if (giayCheck != null)
                return "Không thể xóa vì đã có giấy kèm!";
            else
                return dMucGiayDAO.Xoa(iD);

        }
        #endregion
    }
}
