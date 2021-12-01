namespace Websters
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Websters.Models;

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
            this.Configuration.ProxyCreationEnabled = false; 
        }

        public virtual DbSet<CommitedViolation> CommitedViolations { get; set; }
        public virtual DbSet<Violation> Violations { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Load Identity relationships of identity classes (Ex. AspUsers, ASPRoles, etc)

            modelBuilder.Entity<Violation>()
                .HasMany(e => e.CommitedViolations)
                .WithRequired(e => e.Violation)
                .WillCascadeOnDelete(false);
        }
    }
}
