namespace Dentistry.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelFirs : DbContext
    {
        public ModelFirs()
            : base("name=ModelFirst")
        {
        }

        public virtual DbSet<Appoinments> Appoinments { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<MedCards> MedCards { get; set; }
        public virtual DbSet<Policies> Policies { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>()
                .HasMany(e => e.Appoinments)
                .WithOptional(e => e.Doctors)
                .HasForeignKey(e => e.Doctor_DoctorId);

            modelBuilder.Entity<Doctors>()
                .HasMany(e => e.MedCards)
                .WithOptional(e => e.Doctors)
                .HasForeignKey(e => e.Doctor_DoctorId);

            modelBuilder.Entity<MedCards>()
                .HasMany(e => e.Appoinments)
                .WithOptional(e => e.MedCards)
                .HasForeignKey(e => e.MedCard_MedCardID);

            modelBuilder.Entity<Policies>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Policies)
                .HasForeignKey(e => e.Policy_PolicyId);
        }
    }
}
