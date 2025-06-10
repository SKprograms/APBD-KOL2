using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOL2.Models;

[Table("Track_Race")]
public class Track_Race
{
    [Key]
    public int TrackRaceId { get; set; }

    [ForeignKey(nameof(Track))]
    public int TrackId { get; set; }

    [ForeignKey(nameof(Race))]
    public int RaceId { get; set; }

    public int Laps { get; set; }
    public int? BestTimeInSeconds { get; set; }

    public Track Track { get; set; }
    public Race Race { get; set; }
    
    public ICollection<Race_Participation> RaceParticipations { get; set; }
}