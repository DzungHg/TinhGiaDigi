﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyGiaInDBContext : DbContext
    {
        public QuanLyGiaInDBContext()
            : base("name=QuanLyGiaInDBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DANH_MUC_GIAY> DANH_MUC_GIAY { get; set; }
        public virtual DbSet<KHO_SAN_PHAM> KHO_SAN_PHAM { get; set; }
        public virtual DbSet<GIAY> GIAYs { get; set; }
        public virtual DbSet<TO_IN_MAY_DIGI> TO_IN_MAY_DIGI { get; set; }
        public virtual DbSet<MAY_IN_DIGI> MAY_IN_DIGI { get; set; }
        public virtual DbSet<BANG_GIA_IN_NHANH> BANG_GIA_IN_NHANH { get; set; }
        public virtual DbSet<HANG_KHACH_HANG> HANG_KHACH_HANG { get; set; }
        public virtual DbSet<MARK_UP_LOI_NHUAN_GIAY> MARK_UP_LOI_NHUAN_GIAY { get; set; }
        public virtual DbSet<CAN_PHU> CAN_PHU { get; set; }
        public virtual DbSet<DONG_CUON> DONG_CUON { get; set; }
        public virtual DbSet<EP_KIM> EP_KIM { get; set; }
        public virtual DbSet<KHUON_EP_KIM> KHUON_EP_KIM { get; set; }
        public virtual DbSet<NHU_EP_KIM> NHU_EP_KIM { get; set; }
        public virtual DbSet<IN_OFFSET_GIA_CONG> IN_OFFSET_GIA_CONG { get; set; }
        public virtual DbSet<BANG_GIA_DANH_THIEP> BANG_GIA_DANH_THIEP { get; set; }
        public virtual DbSet<TINH_GIA_IN> TINH_GIA_IN { get; set; }
        public virtual DbSet<YEU_CAU_TINH_GIA_IN> YEU_CAU_TINH_GIA_IN { get; set; }
        public virtual DbSet<DS_THANH_PHAM> DS_THANH_PHAM { get; set; }
        public virtual DbSet<CAN_GAP> CAN_GAP { get; set; }
    }
}
