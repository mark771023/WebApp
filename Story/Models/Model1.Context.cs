﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Story.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class STORYEntities : DbContext
    {
        public STORYEntities()
            : base("name=STORYEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<AccountsMapping> AccountsMapping { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Announcement> Announcement { get; set; }
        public virtual DbSet<Commodity> Commodity { get; set; }
        public virtual DbSet<CommodityEvaluation> CommodityEvaluation { get; set; }
        public virtual DbSet<CommodityReport> CommodityReport { get; set; }
        public virtual DbSet<CommodityReportMapping> CommodityReportMapping { get; set; }
        public virtual DbSet<Favourite> Favourite { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberEvaluation> MemberEvaluation { get; set; }
        public virtual DbSet<MemberReport> MemberReport { get; set; }
        public virtual DbSet<MemberReportMapping> MemberReportMapping { get; set; }
        public virtual DbSet<MessageMapping> MessageMapping { get; set; }
        public virtual DbSet<MessageReply> MessageReply { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderMapping> OrderMapping { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Visitors> Visitors { get; set; }
    }
}
