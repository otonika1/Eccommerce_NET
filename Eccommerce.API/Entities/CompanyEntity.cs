using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eccommerce.API.Entities;

[Table("company")]
public class CompanyEntity
{
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
    [Column("company_id")]
    public int Id { get; set; }
   //public List<EmployeeEntity> Employees { get; set; }
}