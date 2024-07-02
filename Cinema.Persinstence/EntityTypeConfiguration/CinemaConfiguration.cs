using Cinema.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.Persinstence.EntityTypeConfiguration
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(film => film.Id);
            builder.HasIndex(film => film.Id).IsUnique();
            builder.Property(film => film.Name).HasMaxLength(250);
        }
    }

    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(hall => hall.Id);
            builder.HasIndex(hall => hall.Id).IsUnique();
            builder.Property(hall => hall.Name).HasMaxLength(250);
        }
    }

    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder
                .HasOne(s => s.Hall)
                .WithMany(h => h.Seats)
                .HasForeignKey(s => s.HallID);
        }
    }

    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            //Один ко многим с Films
            builder
                .HasOne(s => s.Film)
                .WithMany(f => f.Tickets)
                .HasForeignKey(f => f.FilmId);

            //Один к одному с Seats
            builder
                .HasOne(s => s.Seat);
        }
    }

    public class ManagementConfiguration : IEntityTypeConfiguration<Profit>
    {
        public void Configure(EntityTypeBuilder<Profit> builder)
        {
            //Один к одному с Films (один доход - один фильм)
            builder
                .HasOne(s => s.Film);
        }
    }
}
