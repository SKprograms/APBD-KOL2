namespace APBD_KOL2.DTOs;

public class AddTrackRaceParticipantsDTO
{
    public string RaceName { get; set; } = null!;
    public string TrackName { get; set; } = null!;
    public List<ParticipationEntryDTO> Participations { get; set; } = new();
}

public class ParticipationEntryDTO
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}