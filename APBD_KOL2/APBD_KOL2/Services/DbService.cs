using APBD_KOL2.Data;
using APBD_KOL2.DTOs;
using APBD_KOL2.Exceptions;
using APBD_KOL2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_KOL2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<RacerParticipationDTO> GetRacerParticipations(int racerId)
    {
        var racer = await _context.Racers
            .Include(r => r.RaceParticipations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Track)
            .Include(r => r.RaceParticipations)
            .ThenInclude(p => p.TrackRace.Race)
            .FirstOrDefaultAsync(r => r.RacerId == racerId);

        if (racer == null)
            throw new NotFoundException("Racer not found.");

        return new RacerParticipationDTO
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            Participations = racer.RaceParticipations.Select(p => new ParticipationDetailsDTO
            {
                Race = new RaceDTO
                {
                    Name = p.TrackRace.Race.Name,
                    Location = p.TrackRace.Race.Location,
                    Date = p.TrackRace.Race.Date
                },
                Track = new TrackDTO
                {
                    Name = p.TrackRace.Track.Name,
                    LengthInKm = p.TrackRace.Track.LengthInKM
                },
                Laps = p.TrackRace.Laps,
                FinishTimeInSeconds = p.FinishTimeInSeconds,
                Position = p.Position
            }).ToList()
        };
    }

    public async Task AddTrackRaceParticipantsAsync(AddTrackRaceParticipantsDTO dto)
    {
        var race = await _context.Races.FirstOrDefaultAsync(r => r.Name == dto.RaceName);
        if (race == null) throw new NotFoundException("Race not found.");

        var track = await _context.Tracks.FirstOrDefaultAsync(t => t.Name == dto.TrackName);
        if (track == null) throw new NotFoundException("Track not found.");

        var trackRace = await _context.TrackRaces
            .Include(tr => tr.RaceParticipations)
            .FirstOrDefaultAsync(tr => tr.RaceId == race.RaceId && tr.TrackId == track.TrackId);

        if (trackRace == null)
        {
            trackRace = new Track_Race { RaceId = race.RaceId, TrackId = track.TrackId, BestTimeInSeconds = int.MaxValue };
            _context.TrackRaces.Add(trackRace);
            await _context.SaveChangesAsync();
        }

        foreach (var participation in dto.Participations)
        {
            var racer = await _context.Racers.FirstOrDefaultAsync(r => r.RacerId == participation.RacerId);
            if (racer == null) throw new NotFoundException($"Racer with ID {participation.RacerId} not found.");

            trackRace.RaceParticipations.Add(new Race_Participation()
            {
                RacerId = participation.RacerId,
                TrackRaceId = trackRace.TrackRaceId,
                Position = participation.Position,
                FinishTimeInSeconds = participation.FinishTimeInSeconds,
            });

            if (participation.FinishTimeInSeconds < trackRace.BestTimeInSeconds)
                trackRace.BestTimeInSeconds = participation.FinishTimeInSeconds;
        }

        await _context.SaveChangesAsync();
    }
}