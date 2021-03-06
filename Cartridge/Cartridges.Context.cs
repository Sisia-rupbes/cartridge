﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cartridge
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class b1cakEntities : DbContext
    {
        public b1cakEntities()
            : base("name=b1cakEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<p000044> p000044 { get; set; }
        public virtual DbSet<p000045> p000045 { get; set; }
        public virtual DbSet<p000046> p000046 { get; set; }
        public virtual DbSet<p000047> p000047 { get; set; }
        public virtual DbSet<p000048> p000048 { get; set; }
        public virtual DbSet<p000049> p000049 { get; set; }
        public virtual DbSet<p000051> p000051 { get; set; }
        public virtual DbSet<p000052> p000052 { get; set; }
        public virtual DbSet<p000053> p000053 { get; set; }
        public virtual DbSet<p000054> p000054 { get; set; }
    
        public virtual int AddRequest(Nullable<int> deviceID)
        {
            var deviceIDParameter = deviceID.HasValue ?
                new ObjectParameter("deviceID", deviceID) :
                new ObjectParameter("deviceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddRequest", deviceIDParameter);
        }
    
        public virtual int CartridgeChangeStatus(Nullable<int> cartridgeID, Nullable<int> statusID)
        {
            var cartridgeIDParameter = cartridgeID.HasValue ?
                new ObjectParameter("cartridgeID", cartridgeID) :
                new ObjectParameter("cartridgeID", typeof(int));
    
            var statusIDParameter = statusID.HasValue ?
                new ObjectParameter("statusID", statusID) :
                new ObjectParameter("statusID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CartridgeChangeStatus", cartridgeIDParameter, statusIDParameter);
        }
    
        public virtual int CloseRequest(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CloseRequest", iDParameter);
        }
    }
}
