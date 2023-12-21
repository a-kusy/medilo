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

        public DbSet<PatientCard> PatientCards { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<DayOfTheWeek> DayOfTheWeek { get; set; }

        public DbSet<ScheduleValidityPeriod> SchedulesValidityPeriod { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many
            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .UsingEntity<UserRoles>();

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Specializations)
                .WithMany(e => e.Doctors)
                .UsingEntity<DoctorSpecializations>();

            //one to one
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Person)
                .WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.PersonId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne(u => u.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId);

            modelBuilder.Entity<Receptionist>()
                .HasOne(r => r.Person)
                .WithOne(p => p.Receptionist)
                .HasForeignKey<Receptionist>(r => r.PersonId);

            modelBuilder.Entity<Receptionist>()
                .HasOne(r => r.User)
                .WithOne(u => u.Receptionist)
                .HasForeignKey<Receptionist>(r => r.UserId);

            modelBuilder.Entity<PatientCard>()
                .HasOne(pc => pc.Person)
                .WithOne(p => p.PatientCard)
                .HasForeignKey<PatientCard>(pc => pc.PersonId);

            //one to many
            modelBuilder.Entity<Address>()
                .HasMany(a => a.Persons)
                .WithOne(p => p.Address)
                .HasForeignKey(p => p.AddressId);

            modelBuilder.Entity<DayOfTheWeek>()
                .HasMany(d => d.Schedules)
                .WithOne(s => s.DayOfTheWeek)
                .HasForeignKey(s => s.DayOfTheWeekId);

            modelBuilder.Entity<ScheduleValidityPeriod>()
                .HasMany(sv => sv.Schedules)
                .WithOne(s => s.ScheduleValidityPeriod)
                .HasForeignKey(s => s.ScheduleValidityPeriodId);

            modelBuilder.Entity<Specialization>()
                .HasMany(sp => sp.Schedules)
                .WithOne(s => s.Specialization)
                .HasForeignKey(s => s.SpecializationId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.SchedulesValidityPeriod)
                .WithOne(s => s.Doctor)
                .HasForeignKey(s => s.DoctorId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<PatientCard>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.PatientCard)
                .HasForeignKey(a => a.PatientCardId);

            modelBuilder.Entity<Specialization>()
                .HasMany(s => s.Appointments)
                .WithOne(a => a.Specialization)
                .HasForeignKey(a => a.SpecializationId);
        }
    }
}