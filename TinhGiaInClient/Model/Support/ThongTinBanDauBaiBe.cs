using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model.Support
{
    public struct ThongTinBanDauBaiBe: IThongTinBanDau
    {
        //Thi công
        public string ThongDiepCanThiet
        {
            get;
            set;
        }

        public FormStateS TinhTrangForm
        {
            get;
            set;
        }

        public string TieuDeForm
        {
            get;
            set;
        }
        //Thêm vô
        public int IdBaiIn { get; set; }                    
        public int SoLuongSanPham { get; set; }
        
        public string DonViTinh { get; set; }
        public int IdHangKhachHang { get; set; }
        public int SoLuongToChay { get; set; }
        public float ToChayRong { get; set; }
        public float ToChayCao { get; set; }
        public LoaiThanhPhamS LoaiThanhPham { get; set; }


      
    }
}
