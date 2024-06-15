using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstProject;

public class Time
{
    [Column("time")]
    public int Times { get; set; }
    
    [Column("id")]
    public int Id { get; set; }
    
    [Column("date")]
    public DateTime DateColumn { get; set; }
}