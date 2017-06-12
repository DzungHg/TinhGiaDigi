using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinhGiaInClient.Model.Booklet
{
    public class Sach
    {
        public KieuDongCuonS KieuDongCuon { get; set; }
        public int SoTrangRuot { get; set; }
        public int SoTrangBia { get; set; }
        public float ChieuRong { get; set; }
        public float ChieuCao { get; set; }
        public float GayDay { get; set; }
        public int TongSoTrang
        {
            get { return this.SoTrangBia + this.SoTrangRuot; }
        }
    }

}
