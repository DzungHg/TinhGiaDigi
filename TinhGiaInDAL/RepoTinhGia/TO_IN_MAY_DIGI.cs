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
    
    public partial class TO_IN_MAY_DIGI
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public Nullable<double> Rong { get; set; }
        public Nullable<double> Cao { get; set; }
        public Nullable<int> Toc_do { get; set; }
        public Nullable<bool> In_tu_tro { get; set; }
        public Nullable<bool> La_in_kho_dai { get; set; }
        public Nullable<bool> La_hp_indigo { get; set; }
        public Nullable<int> Click_mot_mau { get; set; }
        public Nullable<int> Click_bon_mau { get; set; }
        public Nullable<int> Click_sau_mau { get; set; }
        public Nullable<int> Qui_a4 { get; set; }
        public Nullable<int> ID_MAY_IN { get; set; }
        public Nullable<int> Thu_tu { get; set; }
        public Nullable<double> Vung_in_rong { get; set; }
        public Nullable<double> Vung_in_cao { get; set; }
        public string Kho_to_chay_co_the_in { get; set; }
        public string Day_so_luong { get; set; }
        public string Day_loi_nhuan { get; set; }
        public string day_so_luong_niem_yet { get; set; }
        public Nullable<bool> khong_su_dung { get; set; }
    
        public virtual MAY_IN_DIGI MAY_IN_DIGI { get; set; }
    }
}
