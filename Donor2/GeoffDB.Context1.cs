﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DONOR2.Donor2.Donor2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GeoffDBEntities : DbContext
    {
        public GeoffDBEntities()
            : base("name=GeoffDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<LoginDonor> LoginDonors { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
    
        public virtual ObjectResult<DonorsLastNameSearch_Result> DonorsLastNameSearch(string lastNameA_Zsearch)
        {
            var lastNameA_ZsearchParameter = lastNameA_Zsearch != null ?
                new ObjectParameter("LastNameA_Zsearch", lastNameA_Zsearch) :
                new ObjectParameter("LastNameA_Zsearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DonorsLastNameSearch_Result>("DonorsLastNameSearch", lastNameA_ZsearchParameter);
        }
    
        public virtual ObjectResult<LoginLastNameSearch_Result> LoginLastNameSearch(string lastNameSearch)
        {
            var lastNameSearchParameter = lastNameSearch != null ?
                new ObjectParameter("LastNameSearch", lastNameSearch) :
                new ObjectParameter("LastNameSearch", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<LoginLastNameSearch_Result>("LoginLastNameSearch", lastNameSearchParameter);
        }
    }
}
