//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TinhGiaInDAL.RepoTinhGia
{
    using System;
    using System.Collections.Generic;
    
    public partial class TINH_GIA_IN
    {
        public int ID { get; set; }
        public Nullable<int> ID_NGUOI_DUNG { get; set; }
        public Nullable<System.DateTime> ngay_tinh_gia { get; set; }
        public string tieu_de_tinh_gia { get; set; }
        public string Noi_dung_chao_gia { get; set; }
        public string noi_dung_chao_gia_noi_bo { get; set; }
        public Nullable<int> ID_YEU_CAU_TINH_GIA_IN { get; set; }
        public string ten_nguoi_dung { get; set; }
        public string ten_khach_hang { get; set; }
    }
}
