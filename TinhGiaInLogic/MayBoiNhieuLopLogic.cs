using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;
using TinhGiaInDAL.RepoTinhGia;

namespace TinhGiaInLogic
{
    public class MayBoiNhieuLopLogic
    {
        MayBoiNhieuLopDAO boiNhieuLopDAO = new MayBoiNhieuLopDAO();
        public List<MayBoiNhieuLopBDO> DocTatCa()
        {
            var nguon = boiNhieuLopDAO.DocTatCa();
            return nguon.ToList();
        }

        public MayBoiNhieuLopBDO DocTheoId(int iD)
        {
            return boiNhieuLopDAO.DocTheoId(iD);
        }
        public string Them(MayBoiNhieuLopBDO boiBiaCungBDO)
        {
            return boiNhieuLopDAO.Them(boiBiaCungBDO);
        }
        public string Sua(MayBoiNhieuLopBDO boiBiaCungBDO)
        {
            return boiNhieuLopDAO.Sua(boiBiaCungBDO);
        }
    }
}
