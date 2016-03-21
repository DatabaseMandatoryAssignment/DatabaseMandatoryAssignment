namespace MandatoryAssignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContextTable : DbContext
    {
        public DataContextTable()
            : base("name=DataContextTable")
        {
        }

        public virtual DbSet<Ambient> Ambient { get; set; }
        public virtual DbSet<Enhed> Enhed { get; set; }
        public virtual DbSet<Maalested> Maalested { get; set; }
        public virtual DbSet<Opstilling> Opstilling { get; set; }
        public virtual DbSet<Stof> Stof { get; set; }
        public virtual DbSet<Udstyr> Udstyr { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enhed>()
                .Property(e => e.EnhedNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Enhed>()
                .HasMany(e => e.Ambient)
                .WithRequired(e => e.Enhed)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maalested>()
                .Property(e => e.Maalested1)
                .IsUnicode(false);

            modelBuilder.Entity<Maalested>()
                .HasMany(e => e.Ambient)
                .WithRequired(e => e.Maalested)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Opstilling>()
                .Property(e => e.OpstillingNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Opstilling>()
                .HasMany(e => e.Ambient)
                .WithRequired(e => e.Opstilling)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stof>()
                .Property(e => e.StofNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Stof>()
                .HasMany(e => e.Ambient)
                .WithRequired(e => e.Stof)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Udstyr>()
                .Property(e => e.UdstyrNavn)
                .IsUnicode(false);

            modelBuilder.Entity<Udstyr>()
                .HasMany(e => e.Ambient)
                .WithRequired(e => e.Udstyr)
                .WillCascadeOnDelete(false);
        }
    }
}
