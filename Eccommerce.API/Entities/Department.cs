namespace Eccommerce.API.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
[Table("Departments")]
public class Department
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int EmployeeCount { get; set; }
    public List<Employee> Employees { get; set; }
}