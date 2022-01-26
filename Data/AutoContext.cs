using Auto.Models;
using Microsoft.EntityFrameworkCore;


namespace Auto.Data
{
    public class AutoContext : DbContext
    {
        public AutoContext (DbContextOptions<AutoContext> options):base(options)
        {
        }

        public DbSet<Car> Masina { get; set; }
        public DbSet<Part> Piesa { get; set; }
        public DbSet<Garage> Service { get; set; }
        public DbSet<Appointment> Programare { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Masina");
            modelBuilder.Entity<Part>().ToTable("Piesa");
            modelBuilder.Entity<Garage>().ToTable("Service");
            modelBuilder.Entity<Appointment>().ToTable("Programare");

            // modelBuilder.Entity<Appointment>()
            //     .HasMany(e => e.Piese)
            //     .WithRequired(e => e.Programare)
            //     .HasForeignKey(e => e.AppointmentID)
            //     .WillCascadeOnDelete(false);
        }
    }
}
