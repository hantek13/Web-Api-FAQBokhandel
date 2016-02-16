using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Web_Api_FAQBokhandel.Models
{
    public class FaqBokhandelContext : DbContext
    {
        public FaqBokhandelContext() : base("name=FAQBokhandel")
        {
            
        }

        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Katagori> Katagorier { get; set; }
        public DbSet<FAQ> Faqer { get; set; }
        public DbSet<KundeSporsmol> KundeSporsmoler { get; set; }
   




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}