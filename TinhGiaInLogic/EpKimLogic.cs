﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class EpKimLogic
    {
        EpKimDAO epKimDAO = new EpKimDAO();
        public List<EpKimBDO> DocTatCa()
        {
            var nguon = epKimDAO.DocTatCa();
            return nguon.ToList();
        }       
        public EpKimBDO DocTheoId(int iD)
        {
            return epKimDAO.DocTheoId(iD);
        }
    }
}