using Microsoft.EntityFrameworkCore;
using Cinema.Application.Interfaces;
using Cinema.Domain;
using Cinema.Persinstence.EntityTypeConfiguration;

namespace Cinema.Persinstence
{
    public class CinemaDbContext : DbContext, ICinemaDbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Profit> Profits { get; set; }
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FilmConfiguration());
            builder.ApplyConfiguration(new HallConfiguration());
            builder.ApplyConfiguration(new SeatConfiguration());
            builder.ApplyConfiguration(new TicketConfiguration());
            builder.ApplyConfiguration(new ManagementConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
