using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class MayKhoanBoGocLogic
    {
        MayKhoanBoGocDAO khoanBoGocDAO = new MayKhoanBoGocDAO();
        public List<MayKhoanBoGocBDO> DocTatCa()
        {
            var nguon = khoanBoGocDAO.DocTatCa();
            return nguon.ToList();
        }

        public MayKhoanBoGocBDO DocTheoId(int iD)
        {
            return khoanBoGocDAO.DocTheoId(iD);
        }
        public string Them(MayKhoanBoGocBDO khoanBoGocBDO)
        {
            return khoanBoGocDAO.Them(khoanBoGocBDO);
        }
        public string Sua(MayKhoanBoGocBDO khoanBoGocBDO)
        {
            return khoanBoGocDAO.Sua(khoanBoGocBDO);
        }
    }
}
