using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Model
{
    public class GiayDeIn
    {
        private static int _id = 0;
        public int ID { get; set; }
       
        public bool GiayKhachDua {get; set; }
        public int IdGiay { get; set; }
        public string TenGiayIn { get; set; }
        public string SoLuongTo { get; set; }
         public int IdBaiIn { get; set; } //Gắn 
        public int IdHangKhachHang { get; set; }
        public int SoToChayTrenToLon { get; set; }
        public QuiCachToChay ToChay { get; set; }
        public GiaGiay GiaGiayChon { get; set; }

        public GiayDeIn(QuiCachToChay quiCachToChay,  GiaGiay giaGiay, int soToChayTrenToLon)
        {
            this.ToChay = quiCachToChay;
            this.GiaGiayChon = giaGiay;
            this.SoToChayTrenToLon = SoToChayTrenToLon;
            //this.TiLeMarkUp = TiLeMarkUp;
            //Tăng Id mỗi lần thêm mới để có Id
            _id += 1;
            this.ID = _id;
        }
        
     
         //Giấy chọn từ kho
     
        //public int IdHangKhachHang { get; set; }
        
        public int SoToLonCan ()
        {
            int result = 0;
            if (this.SoToChayTrenToLon == 0)
                return result;
            //Tiếp nếu qua khỏi
            if (this.ToChay.TongSoToChay() % this.SoToChayTrenToLon > 0)//Chia lẻ
                result = this.ToChay.TongSoToChay() / this.SoToChayTrenToLon + 1;
            else
                result = this.ToChay.TongSoToChay() / this.SoToChayTrenToLon;

            return result;
        }
        //Về máy in
 
        public int IdMayIn { get; set; }
 
        public string KhoMayIn
        {
            get
            {
                var khoMayIn = "";
                switch (this.ToChay.PhuongPhapIn)
                {
                    case PhuongPhapInS.KhongIn:
                        khoMayIn = "";
                        break;
                    case PhuongPhapInS.Offset:
                        khoMayIn = OffsetGiaCong.DocTheoId(this.IdMayIn).TenKhoIn;
                        break;
                    case PhuongPhapInS.Toner:
                        khoMayIn = ToInMayDigi.DocTheoId(this.IdMayIn).Ten;
                        break;
                    default:
                        khoMayIn = "";
                        break;
                }
                return khoMayIn;

            }
        }
      
        public decimal GiaBan()
        {
            decimal kq = 0;
             if (this.GiaGiayChon != null)
                kq = this.GiaGiayChon.GiaBan();

            return kq;
        }

        public decimal ThanhTien()
        {
            decimal kq = 0;
            if (this.GiaGiayChon != null)
                kq = this.GiaGiayChon.TienGiaySales(this.SoToLonCan());

            return kq;
        }
        
        


    }
}
