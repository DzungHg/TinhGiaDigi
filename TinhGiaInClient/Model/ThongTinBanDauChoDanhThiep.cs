using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model
{
    public class ThongTinBanDauChoDanhThiep
    {
        public string YeuCauTinhGia { get; set; }
        public FormStateS TinhTrangForm { get; set; }
        public int IdHangKhachHang { get; set; }
        public string TenHangKhachHang
        {
            get { return HangKhachHang.LayTheoId(this.IdHangKhachHang).Ten; }
        }
    }
}
