using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class ToInMayDigiLogic
    {
        ToInMayDigiDAO toChayDigiDAO = new ToInMayDigiDAO();
        public List<ToInMayDigiBDO> DocTatCa()
        {
            var nguon = toChayDigiDAO.LayTatCa();
            return nguon.ToList();
        }
        public ToInMayDigiBDO DocTheoId(int iD)
        {
            return toChayDigiDAO.LayTheoId(iD);
        }
        public bool Sua (ref string thongDiep, ToInMayDigiBDO toMayInDigi)
        {
            return toChayDigiDAO.Sua(ref thongDiep, toMayInDigi);
        }
        public bool Them(ref string thongDiep, ToInMayDigiBDO toMayInDigi)
        {
            return toChayDigiDAO.Them(ref thongDiep, toMayInDigi);
        }
    }
}
