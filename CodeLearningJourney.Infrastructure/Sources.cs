using System.ComponentModel.DataAnnotations.Schema;

namespace CodeLearningJourney.Infrastructure;

public class Sources
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("display_name")]
    public string DisplayName { get; set; }
    
}