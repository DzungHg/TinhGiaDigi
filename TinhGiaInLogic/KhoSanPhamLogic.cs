using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class KhoSanPhamLogic
    {
        KhoSanPhamDAO khoSanPhamDAO = new KhoSanPhamDAO();
        public List<KhoSanPhamBDO> LayTatCa()
        {      
            var nguon = khoSanPhamDAO.LayTatCa().ToList();
            return nguon;
        }
        public KhoSanPhamBDO LayTheoId(int iD)
        {
            return khoSanPhamDAO.LayTheoId(iD);
        }
    }
}
