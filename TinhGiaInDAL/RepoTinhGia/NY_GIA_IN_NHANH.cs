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
    
    public partial class NY_GIA_IN_NHANH
    {
        public int ID { get; set; }
        public string dien_giai { get; set; }
        public Nullable<int> ID_BANG_GIA { get; set; }
        public Nullable<int> thu_tu { get; set; }
        public Nullable<int> ID_HANG_KHACH_HANG { get; set; }
        public Nullable<int> so_trang_toi_da { get; set; }
        public Nullable<bool> khong_su_dung { get; set; }
        public string day_so_luong_niem_yet { get; set; }
        public string LOAI_BANG_GIA { get; set; }
        public string ten { get; set; }
        public Nullable<bool> duoc_gom_trang { get; set; }
    
        public virtual HANG_KHACH_HANG HANG_KHACH_HANG { get; set; }
    }
}
