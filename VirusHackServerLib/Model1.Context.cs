﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirusHackServerLib
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VirusHackServerEntities : DbContext
    {
        public VirusHackServerEntities()
            : base("name=VirusHackServerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Allergy2User> Allergy2User { get; set; }
        public virtual DbSet<AuthData> AuthData { get; set; }
        public virtual DbSet<DangerousDrugCombination> DangerousDrugCombination { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Drug> Drug { get; set; }
        public virtual DbSet<Measuring> Measuring { get; set; }
        public virtual DbSet<Object> Object { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Patient2Doctor> Patient2Doctor { get; set; }
        public virtual DbSet<Research> Research { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TimetablePush> TimetablePush { get; set; }
        public virtual DbSet<TokenPush> TokenPush { get; set; }
        public virtual DbSet<User2Role> User2Role { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
    }
}
