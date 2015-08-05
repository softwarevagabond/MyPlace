using Core.Common.Contracts;
using MyPlace.Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyPlace.Data
{
    public class SocietyMasterContext : DbContext
    {
        public SocietyMasterContext()
            : base("name=SocietyMaster")
        {
            Database.SetInitializer<SocietyMasterContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        //ToDO: Add others here 
        public virtual DbSet<Resident> ResidentSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();
            //IREsidentOwnedEntity is not ignored bcos it is explicit interface..

            //ToDO: Do for others
            modelBuilder.Entity<Resident>().ToTable("Resident", "Security").HasKey<Guid>(e => e.Id).Ignore(e => e.EntityId);


        }
    }
}
