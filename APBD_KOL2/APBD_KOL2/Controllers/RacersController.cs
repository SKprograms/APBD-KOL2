using APBD_KOL2.DTOs;
using APBD_KOL2.Exceptions;
using APBD_KOL2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_KOL2.Controllers;

[ApiController]
[Route("api/racers")]
public class RacersController : ControllerBase
{
    private readonly IDbService _dbService;
    public RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetParticipations(int id)
    {
        try
        {
            return Ok(await _dbService.GetRacerParticipations(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}

[ApiController]
[Route("api/track-races/participants")]
public class TrackRacesController : ControllerBase
{
    private readonly IDbService _dbService;
    public TrackRacesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddParticipants(AddTrackRaceParticipantsDTO dto)
    {
        try
        {
            await _dbService.AddTrackRaceParticipantsAsync(dto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}