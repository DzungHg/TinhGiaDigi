using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaIn
    {
        static int _prevId = 0;
        public int ID { get; set; }
        public int IdBaiIn { get; set; }
        public int LoaiBangGia { get; set; }
        public string TenBangGiaChon { get; set; }
        public int PhuongPhapIn { get; set; }
               
        public int IdMayIn { get; set; }
        public int SoTrangIn { get; set; }
        public decimal TienIn { get; set; }
        public string GiaTBTrang { get; set; }
        public GiaIn(int kieuIn, int loaiBangGia
            , int soTrangIn, int idBaiIn, string tenBangGia, int idToInDigi,
            decimal tienIn, string giaTBTrang)
        {
            
            this.PhuongPhapIn = kieuIn;
            this.LoaiBangGia = loaiBangGia;
            this.SoTrangIn = soTrangIn;
            this.TienIn = tienIn;
            this.IdBaiIn = idBaiIn;
            this.TenBangGiaChon = tenBangGia;
            this.GiaTBTrang = giaTBTrang;
            this.IdToInDigi = idToInDigi;
            //Tạo Id mới tăng dần
            _prevId += 1;
            this.ID = _prevId;
            
        }
    }
}
