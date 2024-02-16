using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccommerce.API.Entities;
[Table("employee")]
public class EmployeeEntity
{   
    
    [Column("employee_id")]
    public int Id { get; set; }
    [Column("full_name")]
    public string FullName { get; set; }
    [Column("city")]
    [MaxLength(100)]
    public string City { get; set; }
    
}