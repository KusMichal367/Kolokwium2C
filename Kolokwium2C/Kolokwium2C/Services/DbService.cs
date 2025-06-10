using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kolokwium2C.Data;
using Kolokwium2C.DTOs;
using Kolokwium2C.Models;
using Kolokwium2C.Exceptions;

namespace Kolokwium2C.Services;

public class DbService: IDbService
{
    private readonly DatabaseContext _dbContext;

    public DbService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RacerParticipationDTO> GetRacerParticipationByIdAsync(int racerId)
    {
        var exists = await _dbContext.Racers.AnyAsync
            (r => r.RacerId == racerId);

        if (!exists)
        {
            throw new NotFoundException($"Driver with id {racerId} not found");
        }

        var dto = await _dbContext.Racers.Select(
            r => new RacerParticipationDTO
            {
                RacerId = r.RacerId,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Participations = r.RaceParticipations.Select( p => new ParticipationDTO
                    {
                        Race = new RaceDTO
                        {
                            Name = p.TrackRace.Race.Name,
                            Location = p.TrackRace.Race.Location,
                            Date = p.TrackRace.Race.Date,
                        },
                        Track = new TrackDTO
                        {
                            Name = p.TrackRace.Track.Name,
                            LengthInKm = p.TrackRace.Track.LengthInKm
                        },
                        Laps = p.TrackRace.Laps,
                        FinishTimeInSeconds = p.FinishTimeInSeconds,
                        Position = p.Position,
                    }
                    ).ToList()
            }
            ).FirstOrDefaultAsync();

        if (dto is null)
        {
            throw new NotFoundException($"Driver with id {racerId} not found");
        }

        return dto;
    }

    /*public async Task AddRacer(InputDto inputDto)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            var checkRace = await _dbContext.Races
                .FirstOrDefaultAsync(r=> r.Name == inputDto.RaceName);

            if (checkRace == null)
            {
                throw new NotFoundException($"Race {inputDto.RaceName} not found");
            }

            var checkTrack = await _dbContext.Tracks
                .FirstOrDefaultAsync(t => t.Name == inputDto.TrackName);

            if (checkTrack == null)
            {
                throw new NotFoundException($"Track {inputDto.TrackName} not found");
            }

            var dto = new InputDto
            {
                RaceName = inputDto.RaceName,
                TrackName = inputDto.TrackName,
                Participations = new List<ParticipationInputDto>()
                {

                }



        }

    }
*/

}