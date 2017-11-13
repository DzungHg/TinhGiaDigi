using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model.Support
{
    public struct ThongTinBanDauChoGiayIn: IThongTinBanDauChoGiayIn
    {
        public string ThongTinCanThiet { get; set; }
        public int SoLuongSanPham { get; set; }
        public string DonViTinhSanPham { get; set; }
        public KichThuocPhang KichThuocSanPham { get; set; }
       

        public int IdHangKhachHang { get; set; }
        public int IdToIn_MayInChon { get; set; }
        public PhuongPhapInS PhuongPhapIn { get; set; }
        public FormStateS TinhTrangForm { get; set; }
        //Thêm
        public bool LaInDanhThiep { get; set; }

       /* public string KhoMayIn
        {
            get
            {
                var khoMayIn = "";
                switch (this.PhuongPhapIn)
                {
                    case PhuongPhapInS.KhongIn:
                        khoMayIn = "";
                        break;
                    case PhuongPhapInS.Offset:
                        khoMayIn = OffsetGiaCong.DocTheoId(this.IdToIn_MayInChon).TenKhoIn;
                        break;
                    case PhuongPhapInS.Toner:
                        khoMayIn = ToInMayDigi.DocTheoId(this.IdToIn_MayInChon).Ten;
                        break;
                    default:
                        khoMayIn = "";
                        break;
                }
                return khoMayIn;

            }
        }*/
       
    }
}
