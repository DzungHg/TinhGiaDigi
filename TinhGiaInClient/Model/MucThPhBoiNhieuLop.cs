using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TinhGiaInClient.Model
{
    public class MucThPhBoiNhieuLop : MucThanhPham
    {

        public float ToBoiRong { get; set; }
        public float ToBoiCao { get; set; }
        public int SoToLotGiua { get; set; }        
        //public int IdGiayBoiGiuaChon { get; set; }
        public GiayDeBoi GiayBoiChon { get; set; }
        public int SoLuongToChay { get; set; }
        public float KhoToChayRong { get; set; }
        public float KhoToChayDai { get; set; }   
    }
}
