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
    
    public partial class BANG_GIA_DANH_THIEP
    {
        public BANG_GIA_DANH_THIEP()
        {
            this.GIA_TUY_CHON_DANH_THIEP = new HashSet<GIA_TUY_CHON_DANH_THIEP>();
        }
    
        public int ID { get; set; }
        public string ten_bang_gia { get; set; }
        public string mo_ta { get; set; }
        public string day_so_luong { get; set; }
        public string day_gia { get; set; }
        public Nullable<int> so_hop_toi_da { get; set; }
        public Nullable<bool> khong_con { get; set; }
        public Nullable<int> thu_tu { get; set; }
        public Nullable<int> ID_HANG_KHACH_HANG { get; set; }
        public Nullable<bool> in_hai_mat { get; set; }
        public string noi_dung_bang_gia { get; set; }
        public string giay_bao_gom { get; set; }
        public string kho_to_chay { get; set; }
        public string don_vi_tinh { get; set; }
        public Nullable<int> so_danh_thiep_tren_hop { get; set; }
    
        public virtual HANG_KHACH_HANG HANG_KHACH_HANG { get; set; }
        public virtual ICollection<GIA_TUY_CHON_DANH_THIEP> GIA_TUY_CHON_DANH_THIEP { get; set; }
    }
}
