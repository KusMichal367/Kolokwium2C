using Microsoft.AspNetCore.Mvc;
using Kolokwium2C.DTOs;
using Kolokwium2C.Models;

namespace Kolokwium2C.Services;

public interface IDbService
{
    Task<RacerParticipationDTO> GetRacerParticipationByIdAsync(int racerId);
    //Task AddRacer(InputDto inputDto);
}