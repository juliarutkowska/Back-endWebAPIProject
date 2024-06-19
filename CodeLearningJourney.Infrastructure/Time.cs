using System.ComponentModel.DataAnnotations.Schema;

namespace CodeLearningJourney.Infrastructure;

public class Time
{
    [Column("hours")]
    public int Times { get; set; }
    
    [Column("id")]
    public int Id { get; set; }
    
    [Column("date")]
    public DateTime DateColumn { get; set; }
}