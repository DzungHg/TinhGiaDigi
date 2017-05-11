using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model
{
    public class GiaInNhanh
    {
        static int _prevId = 0;
        public int ID { get; set; }
        public int IdBaiIn { get; set; }
        public int LoaiBangGia { get; set; }
        public int KieuIn { get; set; }
       
        public string TenBangGiaChon { get; set; }
        public int IdToInDigi { get; set; }
        public int SoTrangA4 { get; set; }
        public decimal TienIn { get; set; }
        public string GiaTBTrang { get; set; }
        public GiaInNhanh(int kieuIn, int loaiBangGia
            , int soTrangA4, int idBaiIn, string tenBangGia, int idToInDigi,
            decimal tienIn, string giaTBTrang)
        {
            
            this.KieuIn = kieuIn;
            this.LoaiBangGia = loaiBangGia;
            this.SoTrangA4 = soTrangA4;
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
