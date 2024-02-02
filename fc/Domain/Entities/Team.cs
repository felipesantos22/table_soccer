using System.ComponentModel.DataAnnotations;

namespace fc.Domain.Entities;

public class Team
{
    [Key]
    public int id { get; set; }
    
    public string teamName { get; set; }
}