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
    
    public partial class NHU_EP_KIM
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public string Ma_nha_cung_cap { get; set; }
        public string Dien_giai { get; set; }
        public Nullable<int> Gia_mua_cm2 { get; set; }
        public Nullable<int> Thu_tu { get; set; }
        public Nullable<int> ID_EP_KIM { get; set; }
    
        public virtual EP_KIM EP_KIM { get; set; }
    }
}
