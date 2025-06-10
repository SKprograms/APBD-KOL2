using APBD_KOL2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Track_Race> TrackRaces { get; set; }
    public DbSet<Race_Participation> RaceParticipations { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    
    protected DatabaseContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race_Participation>()
            .HasKey(rp => new { rp.TrackRaceId, rp.RacerId });

        modelBuilder.Entity<Racer>().HasData(new Racer
        {
            RacerId = 1,
            FirstName = "Lewis",
            LastName = "Hamilton",
        });

        modelBuilder.Entity<Race>().HasData(
            new Race { Name = "British Grand Prix", Location = "Silverstone, UK", Date = DateTime.Parse("2025-07-14T00:00:00")},
            new Race { Name = "Monaco Grand Prix", Location = "Monte Carlo, Monaco", Date = DateTime.Parse("2025-05-25T00:00:00") }
        );

        modelBuilder.Entity<Track>().HasData(
            new Track { Name = "Silverstone Circuit", LengthInKM = 5.89},
            new Track { Name = "Monaco Circuit", LengthInKM = 3.34}

        );

        modelBuilder.Entity<Track_Race>().HasData(
            new Track_Race {Laps = 52},
            new Track_Race {Laps = 78}
        );
        
        modelBuilder.Entity<Race_Participation>().HasData(
            new Race_Participation { FinishTimeInSeconds = 5460, Position = 1},
            new Race_Participation {FinishTimeInSeconds = 6300, Position = 2}
        );
    }
    
}

