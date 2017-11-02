using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TinhGiaInClient.Model
{
    public class MucThPhKhoanBoGoc : MucThanhPham
    {

        public string KichThuocBlock { get; set; }
        //int SoLuongBlock { get; set; } // Chính là số lượng sp
        public string TieuDe { get; set; }
        public int SoLanKhoanBoTrenMoiBlock { get; set; }       
        //public int IdGiayBoiGiuaChon { get; set; }
        
        public int SoLuongSanPham { get; set; }
        public float KhoSanPhamRong { get; set; }
        public float KhoSanPhamCao { get; set; }
       
        public int TongSoLanKhoanBo {
            get { return this.SoLanKhoanBoTrenMoiBlock * SoLuong; }
        }
    }
}
