using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL2.Models;

[Table("Track")]
public class Track
{
    [Key]
    public int TrackId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [Precision(5, 2)]
    public double LengthInKM { get; set; }

    public ICollection<Track_Race> TrackRaces { get; set; } = new List<Track_Race>();
}
