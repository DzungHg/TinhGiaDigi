using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class ThongTinBanDauChoBaiIn
    {
       
        public string TieuDeForm { get; set; }
        public string TieuDeBaiIn { get; set; }
        public string YeuCauTinhGia { get; set; }
        public string DanDoThem { get; set; }
        public float SanPhamRong { get; set; }
        public float SanPhamCao { get; set; }
        public FormStateS TinhTrangForm { get; set; }
        public int IdHangKhachHang { get; set; }
        public string DonViTinh { get; set; }
        public string TenHangKhachHang
        {
            get { return HangKhachHang.LayTheoId(this.IdHangKhachHang).Ten; }
        }
    }
}
