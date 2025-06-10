using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL2.Models;

[Table("Race_Participation")]
[PrimaryKey(nameof(RacerId), nameof(TrackRaceId))]
public class Race_Participation
{
    [ForeignKey(nameof(TrackRace))]
    public int TrackRaceId { get; set; }

    [ForeignKey(nameof(Racer))]
    public int RacerId { get; set; }

    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }

    public Track_Race TrackRace { get; set; }
    public Racer Racer { get; set; }
}
