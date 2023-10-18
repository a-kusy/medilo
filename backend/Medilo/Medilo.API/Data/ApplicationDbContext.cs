using Microsoft.EntityFrameworkCore;
using Medilo.API.Models;

namespace Medilo.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Receptionist> Receptionists { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<DoctorSpecializations> DoctorSpecializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .UsingEntity<UserRoles>();

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Specializations)
                .WithMany(e => e.Doctors)
                .UsingEntity<DoctorSpecializations>();
        }
    }
}
