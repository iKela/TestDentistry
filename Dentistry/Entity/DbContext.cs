using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry.Entity
{
    public class DentistryContext : DbContext
    {
        public DentistryContext() : base("TestDb2")
        {

        }

        public DbSet<MedCard> MedCards { get; set; }
       // public DbSet<Appoinment> Appoinments { get; set; }
       // public DbSet<User> Users { get; set; }
       // public DbSet<Policy> Policies { get; set; }
       // public DbSet<Doctor> Doctors { get; set; }
    }
}
