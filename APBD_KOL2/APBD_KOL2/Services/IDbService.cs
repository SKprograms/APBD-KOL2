using APBD_KOL2.DTOs;

namespace APBD_KOL2.Services;

public interface IDbService
{
    Task<RacerParticipationDTO> GetRacerParticipations(int racerId);
    Task AddTrackRaceParticipantsAsync(AddTrackRaceParticipantsDTO dto);
}
