using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOL2.Models;

[Table("Racer")]
public class Racer
{
    [Key]
    public int RacerId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public ICollection<Race_Participation> RaceParticipations { get; set; }
}