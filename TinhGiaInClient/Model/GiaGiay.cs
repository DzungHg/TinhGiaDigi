using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaGiay
    {
        public Giay Giay { get; set; }
        public int TyLeMarkUpSales { get; set; }
        public bool GiayKhachDua { get; set; }
        public GiaGiay (Giay giay, int tyLeMarkUpSales, bool giayKhachDua = false)
        {
            Giay = giay;
            TyLeMarkUpSales = tyLeMarkUpSales;
            GiayKhachDua = giayKhachDua;
        }
        public decimal GiaMua()
        {
            decimal kq = 0;
            if (this.GiayKhachDua)
                kq = 0;
            else
                kq = this.Giay.GiaMua;
            return kq;
        }
        public decimal GiaBan()
        {
            decimal kq = 0;
            decimal tiLeMarkUp = (decimal)this.TyLeMarkUpSales / 100;

            kq = this.Giay.GiaMua + this.Giay.GiaMua * tiLeMarkUp /
                    (1 - tiLeMarkUp);
            return kq;
        }
        public decimal TienGiaySales(int soTo)
        {
            return soTo * GiaBan();
        }

    }
}
