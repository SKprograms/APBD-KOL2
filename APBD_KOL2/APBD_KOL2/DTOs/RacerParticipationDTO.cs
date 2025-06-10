namespace APBD_KOL2.DTOs;

public class RacerParticipationDTO
{
    public int RacerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<ParticipationDetailsDTO> Participations { get; set; } = new();
}

public class ParticipationDetailsDTO
{
    public RaceDTO Race { get; set; } = null!;
    public TrackDTO Track { get; set; } = null!;
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceDTO
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime Date { get; set; }
}

public class TrackDTO
{
    public string Name { get; set; } = null!;
    public double LengthInKm { get; set; }
}