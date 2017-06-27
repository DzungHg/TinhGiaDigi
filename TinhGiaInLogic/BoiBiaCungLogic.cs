using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class BoiBiaCungLogic
    {
        BoiBiaCungDAO boiBiaCungDAO = new BoiBiaCungDAO();
        public List<BoiBiaCungBDO> DocTatCa()
        {
            var nguon = boiBiaCungDAO.DocTatCa();
            return nguon.ToList();
        }

        public BoiBiaCungBDO DocTheoId(int iD)
        {
            return boiBiaCungDAO.DocTheoId(iD);
        }
        public string Them(BoiBiaCungBDO boiBiaCungBDO)
        {
            return boiBiaCungDAO.Them(boiBiaCungBDO);
        }
        public string Sua(BoiBiaCungBDO boiBiaCungBDO)
        {
            return boiBiaCungDAO.Sua(boiBiaCungBDO);
        }
    }
}
