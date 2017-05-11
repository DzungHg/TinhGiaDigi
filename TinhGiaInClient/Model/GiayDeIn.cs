using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiayDeIn
    {
        private static int _id = 0;
        public int ID { get; set; }
        public string TenGiayIn { get; set; }
        public bool GiayKhachDua {get; set; }
        public int IdHangKhachHang { get; set; }
        public int SoLuongSanPham { get; set; }
        public int SoConTrenToChay { get; set; }
        public int SoLuongToChayLyThuyet { get; set; }
        public int SoLuongToChayBuHao { get; set; }
        public Giay GiayChon { get; set; } //Giấy chọn từ kho
        public int IdBaiIn { get; set; } //Gắn vô bài in   
        //public int IdHangKhachHang { get; set; }
        public int SoToChayTrenToLon { get; set; }
        public int SoLuongToLonCan { get; set; }
        public int TiLeMarkUp { get; set; }
        //Về máy in
        public int IdPhuongPhapIn { get; set; }
        public int IdMayIn { get; set; }
        public string TenPhuongPhapIn
        {
            get { var tenPPIn = "";
                switch (this.IdPhuongPhapIn)
                {
                    case (int)Enumss.PhuongPhapIn.KhongIn:
                        tenPPIn = "Không In";
                        break;
                     case (int)Enumss.PhuongPhapIn.Offset:
                        tenPPIn = "In Offset";
                        break;
                     case (int)Enumss.PhuongPhapIn.Toner:
                        tenPPIn = "In Nhanh";
                        break;
                }
                return tenPPIn;
            }
      
        }
        public string KhoMayIn
        {
            get
            {
                var khoMayIn = "";
                switch (this.IdPhuongPhapIn)
                {
                    case (int)Enumss.PhuongPhapIn.KhongIn:
                        khoMayIn = "";
                        break;
                    case (int)Enumss.PhuongPhapIn.Offset:
                        khoMayIn = OffsetGiaCong.DocTheoId(this.IdMayIn).TenKhoIn;
                        break;
                    case (int)Enumss.PhuongPhapIn.Toner:
                        khoMayIn = ToChayDigi.DocTheoId(this.IdMayIn).Ten;
                        break;
                    default:
                        khoMayIn = "";
                        break;
                }
                return khoMayIn;

            }
        }
        public string KhoToChay { get; set; }
        public int SoToChayTong
        {
            get;
            set;
        }
        public decimal GiaBan
        {
            get;
            set;
        }

        public decimal ThanhTien
        {
            get;
            set;
        }
        
        public GiayDeIn(Giay giayChon)
        {
            this.GiayChon = giayChon;
            //this.TiLeMarkUp = TiLeMarkUp;
            //Tăng Id mỗi lần thêm mới để có Id
            _id += 1;
            this.ID = _id;
        }


    }
}
