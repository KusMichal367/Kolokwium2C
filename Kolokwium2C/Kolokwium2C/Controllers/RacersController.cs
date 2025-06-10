using Microsoft.AspNetCore.Mvc;
using Kolokwium2C.DTOs;
using Kolokwium2C.Exceptions;
using Kolokwium2C.Services;

namespace Kolokwium2C.Controllers;

[ApiController]
[Route("api/[controller]")]

public class RacersController : ControllerBase
{
    private readonly IDbService _dbService;

    public RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{racerId}/participations")]
    public async Task<IActionResult> GetRacer(int racerId)
    {
        try
        {
            var dto = await _dbService.GetRacerParticipationByIdAsync(racerId);
            return Ok(dto);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}