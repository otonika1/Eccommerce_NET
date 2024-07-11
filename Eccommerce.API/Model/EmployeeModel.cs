using Eccommerce.API.Entities;

namespace Eccommerce.API.Model;

public class EmployeeModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<String> Addresses { get; set; }
    public int DepartmentId { get; set; }
}