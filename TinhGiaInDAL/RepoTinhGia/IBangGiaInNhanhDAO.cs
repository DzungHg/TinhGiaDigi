﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInBDO;

namespace TinhGiaInDAL.RepoTinhGia
{
    public interface IBangGiaInNhanhDAO
    {
        IEnumerable<BangGiaInNhanhBDO> LayTatCa();       
        BangGiaInNhanhBDO LayTheoId(int iD);
        void Them(BangGiaInNhanhBDO entityBDO);
        void Sua(BangGiaInNhanhBDO entityBDO);
        void Xoa(int iD);     
    }
}
