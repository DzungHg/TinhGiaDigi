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
    
    public partial class EP_KIM
    {
        public EP_KIM()
        {
            this.KHUON_EP_KIM = new HashSet<KHUON_EP_KIM>();
            this.NHU_EP_KIM = new HashSet<NHU_EP_KIM>();
        }
    
        public int ID { get; set; }
        public string Ten { get; set; }
        public Nullable<int> BHR { get; set; }
        public Nullable<int> Toc_do_con { get; set; }
        public Nullable<double> Thoi_gian_chuan_bi { get; set; }
        public Nullable<int> Phi_ngvl_chuan_bi { get; set; }
        public string Day_so_luong { get; set; }
        public string Day_loi_nhuan { get; set; }
        public Nullable<int> Thu_tu { get; set; }
        public Nullable<bool> La_vi_tinh { get; set; }
        public Nullable<int> Gia_khuon_cm2 { get; set; }
        public string ma_01 { get; set; }
        public string don_vi_tinh { get; set; }
        public string day_so_luong_niem_yet { get; set; }
    
        public virtual ICollection<KHUON_EP_KIM> KHUON_EP_KIM { get; set; }
        public virtual ICollection<NHU_EP_KIM> NHU_EP_KIM { get; set; }
    }
}
