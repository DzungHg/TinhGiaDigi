using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Model.Support;

namespace TinhGiaInClient.Model
{
    public class GiayDeBoi
    {
        private static int _id = 0;
        public int ID { get; set; }
        public float ToBoiRong { get; set; }
        public float ToBoiDai { get; set; }
        public string KhoToChay
        {
            get
            {
                return string.Format("{0} x {1}cm", this.ToBoiRong,
                    this.ToBoiDai);
            }
            set { ; }
        }
        
       
        public int SoToBoiBuHao { get; set; }
        public int SoToBoiLyThuyet { get; set; }
        public int SoToBoiTong
        {
            get
            {
                return this.SoToBoiBuHao
                    + this.SoToBoiLyThuyet;
            }
        }
       
        public int IdGiay { get; set; }
        public string TenGiayIn { get; set; }        
         public int IdBaiIn { get; set; } //Gắn 
        public int SoToBoiTrenToLon { get; set; }
        public int SoToLonTong { get; set; }
        public decimal ThanhTienGiay { get; set; }

        public GiayDeBoi(float toBoiRong, float toBoiDai, int soToBoiBuHao,
                    int soToBoiLyThuyet, int idGiay,
                    string tenGiayIn, int idBaiIn, int soToBoiTrenToLon,
                    int soToLonTong, decimal thanhTienGiay)
        {
            this.ToBoiRong = toBoiRong;
            this.ToBoiDai = toBoiDai;

            
            this.SoToBoiBuHao = soToBoiBuHao;
            this.SoToBoiLyThuyet = soToBoiLyThuyet;
            
         
            this.IdGiay = idGiay;
            this.TenGiayIn = tenGiayIn;
            this.IdBaiIn = idBaiIn; //Gắn 
            this.SoToBoiTrenToLon = soToBoiTrenToLon;
            this.SoToLonTong = soToLonTong;
            this.ThanhTienGiay = thanhTienGiay;
            //Tăng Id mỗi lần thêm mới để có Id
            _id += 1;
            this.ID = _id;
        }
        public List<string>ThongTinGiayBoi()
        {
            var lst = new List<string>();
            var giay = Giay.DocGiayTheoId(this.IdGiay);
            if (giay != null)
            {
                lst.Add(string.Format("Tên: {0}", this.TenGiayIn));
                lst.Add(string.Format("Định lượng: {0}gsm", giay.DinhLuong));
                lst.Add(string.Format("Khổ: {0}", giay.KhoGiay));
                lst.Add(string.Format("Số lượng: {0} tờ", this.SoToLonTong));
                lst.Add(string.Format("Số lượng: {0:0,0.00}đ", this.ThanhTienGiay));
            }
            return lst;
        }
                      

    }
}
