﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhGiaInClient.Model.Support
{
    public struct ThongTinBanDauChoThanhPham
    {
        public string ThongDiepCanThiet { get; set; }
        public int SoLuongSanPham { get; set; }
        public int IdHangKhachHang { get; set; }
        public int SoLuongToChay { get; set; }
        public LoaiThanhPhamS LoaiThanhPham { get; set; }
        public FormStateS TinhTrangForm { get; set; }
  
        
       
    }
}
