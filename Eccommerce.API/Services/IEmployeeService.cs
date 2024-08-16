using Eccommerce.API.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Eccommerce.API.Services;

public interface IEmployeeService
{
    Task<List<EmployeeViewModel>> GetAllEmployees(int? DepartmentId, string? FirstName, string? SortOrder, int PageNumber, int PageSize);
    Task<EmployeeViewModel> GetEmployeeById(int id);
    Task<EmployeeViewModel> AddEmployee(EmployeeModel employee);
    Task<EmployeeViewModel?> Update(int id, EmployeeModel request);
    Task<EmployeeViewModel?> Delete(int id);
    Task<List<EmployeeViewModel>?> DeleteAll();
}