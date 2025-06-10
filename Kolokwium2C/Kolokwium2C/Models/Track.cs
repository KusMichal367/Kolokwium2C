using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium2C.Models;

[Table("Track")]
public class Track
{
    [Key]
    public int TrackId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(5, 2)")]
    public double LengthInKm {get;set;}

    public List<TrackRace> TrackRaces { get; set; } = null!;
}