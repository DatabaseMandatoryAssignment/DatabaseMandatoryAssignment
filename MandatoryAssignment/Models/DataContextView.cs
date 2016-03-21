namespace MandatoryAssignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContextView : DbContext
    {
        public DataContextView()
            : base("name=DataContextView")
        {
        }

        public virtual DbSet<AmbientView> AmbientView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmbientView>()
                .Property(e => e.Maalested)
                .IsUnicode(false);

            modelBuilder.Entity<AmbientView>()
                .Property(e => e.OpstillingNavn)
                .IsUnicode(false);

            modelBuilder.Entity<AmbientView>()
                .Property(e => e.StofNavn)
                .IsUnicode(false);

            modelBuilder.Entity<AmbientView>()
                .Property(e => e.EnhedNavn)
                .IsUnicode(false);

            modelBuilder.Entity<AmbientView>()
                .Property(e => e.UdstyrNavn)
                .IsUnicode(false);
        }
    }
}
