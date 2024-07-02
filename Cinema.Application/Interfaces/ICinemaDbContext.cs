using Cinema.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Application.Interfaces
{
    public interface ICinemaDbContext
    {
        DbSet<Film> Films { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<Hall> Halls { get; set; }
        DbSet<Ticket> Tickets { get; set; }
        DbSet<Profit> Profits { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
