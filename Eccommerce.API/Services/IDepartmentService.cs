using Eccommerce.API.Entities;

namespace Eccommerce.API.Services;

public interface IDepartmentService
{
    Task<List<Department>> GetAll();
    Task<Department> GetById(int id);
    Task<Department> Post(DepartmentsModel employee);
    Task<Department?> Put(int id, Department request);
    Task<Department?> Delete(int id);
    Task<List<Department>?> DeleteAll();
}