using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.Models
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<VrstaStana> VrstaStana_set { get; set; }
        public virtual DbSet<Grad> Grad_set { get; set; }
        public virtual DbSet<Stan> Stan_set { get; set; }
        public virtual DbSet<Iznajmljivanje> Iznajmljivanje_set { get; set; }
        public virtual DbSet<Podstanar> Podstanar_set { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}