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
        public float ToChayRong { get; set; }
        public float ToChayDai { get; set; }
        public string KhoToChay
        {
            get
            {
                return string.Format("{0} x {1}cm", this.ToChayRong,
                    this.ToChayDai);
            }
            set { ; }
        }
        
        public int SoConTrenToChay { get; set; }
        public int SoToChayBuHao { get; set; }
        public int SoToChayLyThuyet { get; set; }
        public int SoToChayTong { get; set; }
        public bool GiayKhachDua {get; set; }
        public int IdGiay { get; set; }
        public float GiayLonRong { get; set; }
        public float GiayLonCao { get; set; }
        public string TenGiayIn { get; set; }        
         public int IdBaiIn { get; set; } //Gắn 
        public int SoToChayTrenToLon { get; set; }
        public int SoToLonTong { get; set; }
        public decimal ThanhTienGiay { get; set; }

        public GiayDeIn(float toChayRong, float toChayDai, int soConTrenToChay, int soToChayBuHao,
                    int soToChayLyThuyet, int soToChayTong,
                    bool giayKhachDua, int idGiay,
                    string tenGiayIn, int idBaiIn, int soToChayTrenToLon,
                    int soToLonTong, decimal thanhTienGiay)
        {
            this.ToChayRong = toChayRong;
            this.ToChayDai = toChayDai;

            this.SoConTrenToChay = soConTrenToChay;
            this.SoToChayBuHao = soToChayBuHao;
            this.SoToChayLyThuyet = soToChayLyThuyet;
            this.SoToChayTong = soToChayTong;
            this.GiayKhachDua = giayKhachDua;
            this.IdGiay = idGiay;
            this.TenGiayIn = tenGiayIn;
            this.IdBaiIn = idBaiIn; //Gắn 
            this.SoToChayTrenToLon = soToChayTrenToLon;
            this.SoToLonTong = soToLonTong;
            this.ThanhTienGiay = thanhTienGiay;
            //Tăng Id mỗi lần thêm mới để có Id
            _id += 1;
            this.ID = _id;
        }
        
                      

    }
}
