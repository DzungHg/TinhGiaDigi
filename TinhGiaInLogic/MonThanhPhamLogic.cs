using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class MonThanhPhamLogic
    {
        MonThanhPhamDAO monThanhPhamDAO = new MonThanhPhamDAO();
        public List<MonThanhPhamBDO> DocTatCa()
        {      
            var nguon = monThanhPhamDAO.DocTatCa().ToList();
            return nguon;
        }
        public MonThanhPhamBDO DocTheoId(int iD)
        {
            return monThanhPhamDAO.DocTheoId(iD);
        }
    }
}
