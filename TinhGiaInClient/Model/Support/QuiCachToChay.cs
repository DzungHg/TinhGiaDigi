using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Support
{
    public class QuiCachToChay
    {
        public string KhoToChay { get; set; }
        //public PhuongPhapInS PhuongPhapIn { get; set; }
       
        public int SoConTrenToChay { get; set; }
       
        public int SoToChayBuHao { get; set; }

        public QuiCachToChay( string khoToChay, int soToChayBuHao)
        {
            this.KhoToChay = khoToChay;
            //this.PhuongPhapIn = phPhapIn;
        
            this.SoToChayBuHao = soToChayBuHao;
        }
       /* public string TenPhuongPhapIn
        {
            get
            {
                var tenPPIn = "";
                switch (this.PhuongPhapIn)
                {
                    case PhuongPhapInS.KhongIn:
                        tenPPIn = "Không In";
                        break;
                    case PhuongPhapInS.Offset:
                        tenPPIn = "In Offset";
                        break;
                    case PhuongPhapInS.Toner:
                        tenPPIn = "In Nhanh";
                        break;
                }
                return tenPPIn;
            }
        
        }*/
       
        public static int soLuongToChayLyThuyet ()
        {
            int kq = 0;
            if (SoConTrenToChay <= 0 || SoLuongSanPham <= 0)
                return kq;
            //Tiếp nếu quá
            if (this.SoLuongSanPham % this.SoConTrenToChay > 0)//Chia lẻ
                kq = this.SoLuongSanPham / this.SoConTrenToChay + 1;
            else
                kq = this.SoLuongSanPham / this.SoConTrenToChay;

            return kq;
        }
        public int TongSoToChay()
        {
            return soLuongToChayLyThuyet() + this.SoToChayBuHao;
        }
    }
}
