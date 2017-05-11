using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class OffsetGiaCongLogic
    {
        OffsetGiaCongDAO offsetGiaCongDAO = new OffsetGiaCongDAO();
        public List<OffsetGiaCongBDO> DocTatCa()
        {
            var nguon = offsetGiaCongDAO.DocTatCa();
            return nguon.ToList();
        }
        public OffsetGiaCongBDO DocTheoId(int iD)
        {
            return offsetGiaCongDAO.DocTheoId(iD);
        }
        public List<OffsetGiaCongBDO> DocTheoNhaCungCap(string tenNCC)
        {
            var nguon = offsetGiaCongDAO.DocTheoNhaCungCap(tenNCC)
               ;
            return nguon.ToList();
        }
        public List<string> NhaCungCapS()
        {
            var nguon = offsetGiaCongDAO.NhaCungCapS().ToList();
            return nguon;
        }
    }
}
