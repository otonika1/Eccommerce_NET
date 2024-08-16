using Eccommerce.API.Entities;

namespace Eccommerce.API.Model;

public class EmployeeViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<String> Addresses { get; set; }
    public int DepartmentId { get; set; }
    public DepartmentsModel Department { get; set; }
    public List<SuperHeroViewModel> SuperHeros { get; set; }
}