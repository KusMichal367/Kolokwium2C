using Kolokwium2C.Models;

namespace Kolokwium2C.DTOs;

public class InputDto
{
    public string RaceName { get; set; } = null!;
    public string TrackName { get; set; } = null!;

    public List<ParticipationInputDto> Participations { get; set; } = null!;
}

public class ParticipationInputDto
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}

