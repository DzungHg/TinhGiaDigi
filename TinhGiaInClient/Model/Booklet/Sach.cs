using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;


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
        public bool BiaLayNgoai { get; set; }//Làm riêng sau đó lắp vô hay khách mang tới
        public int TongSoTrang
        {
            get
            {
                if (!this.BiaLayNgoai)
                    return this.SoTrangBia + this.SoTrangRuot;
                else
                    return this.SoTrangRuot;
            }
        }
    }

}
