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
    
    public partial class TUY_CHON_DANH_THIEP
    {
        public TUY_CHON_DANH_THIEP()
        {
            this.GIA_TUY_CHON_DANH_THIEP = new HashSet<GIA_TUY_CHON_DANH_THIEP>();
        }
    
        public int ID { get; set; }
        public string ten { get; set; }
        public Nullable<int> thu_tu { get; set; }
    
        public virtual ICollection<GIA_TUY_CHON_DANH_THIEP> GIA_TUY_CHON_DANH_THIEP { get; set; }
    }
}
