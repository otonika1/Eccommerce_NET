using Eccommerce.API.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Eccommerce.API.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllEmployees();
    Task<Employee> GetEmployeeById(int id);
    Task<Employee> AddEmployee(EmployeeModel employee);
    Task<Employee?> Update(int id, EmployeeModel request);
    Task<Employee?> Delete(int id);
    Task<List<Employee>?> DeleteAll();
}