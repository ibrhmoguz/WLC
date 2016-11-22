using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WLC.Domain.Entities;

namespace WLC.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("wlcAppConnectionString")
        {

        }

        public EFDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<WLCTanim> WLCTanimlar { get; set; }
        public DbSet<KullaniciYapilanAp> KullaniciYapilanApler{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
