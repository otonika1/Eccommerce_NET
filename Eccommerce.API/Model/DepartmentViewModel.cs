namespace Eccommerce.API.Model;

public class DepartmentViewModel
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public int EmployeeCount { get; set; }
    public List<ViewModel> Employees { get; set; }
}
public class ViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<String> Addresses { get; set; }
}