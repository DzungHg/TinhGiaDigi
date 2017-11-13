using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinhGiaInClient.Common.Enum;

namespace TinhGiaInClient.Model.Support
{
    public struct ThongTinBanDauDongCuon: IThongTinBanDau
    {
       
        
        public string ThongDiepCanThiet { get; set; }
        public string TieuDeForm { get; set; }
        public bool  MoTextSoLuongCuon { get; set; }
     
        public FormStateS TinhTrangForm { get; set; }




     
    }
}
