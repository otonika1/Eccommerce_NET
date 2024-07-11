using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccommerce.API.Entities;

[Table("supertb")]
public class SuperHeroEntity
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }
    [Column("First_Name")]
    public string FirstName { get; set; }
    [Column("Last_Name")]
    public string LastName { get; set; }
    [Column("superheros")]
    public List<SuperHeroEntity> SuperHero { get; set; }
    
}