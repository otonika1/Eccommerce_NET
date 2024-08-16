using AutoMapper;
using Eccommerce.API.DB;
using Eccommerce.API.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Eccommerce.API.Services;
using Microsoft.EntityFrameworkCore;
public class EmployeeService:IEmployeeService
{
    private readonly DataContext _context;
    public readonly IMapper _mapper;
    public EmployeeService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<EmployeeViewModel>> GetAllEmployees(int? DepartmentId = null, string? FirstName = null, string? SortOrder = "asc", int PageNumber = 1, int PageSize = 10)
    {
        
        var query = _context.Employees
            .Include(e => e.SuperHeros)
            .Include(e => e.Department)
            .AsQueryable();
        if (DepartmentId.HasValue)
        {
            query = query.Where(e => e.DepartmentId == DepartmentId.Value);
        }
        if (!string.IsNullOrEmpty(FirstName))
        {
            query = query.Where(e => e.FirstName.Contains(FirstName));
        }
        if (!string.IsNullOrEmpty(SortOrder))
        {
            query = SortOrder.ToLower() == "desc"
                ? query.OrderByDescending(e => e.LastName)
                : query.OrderBy(e => e.LastName);
        }
        query = query.Skip((PageNumber - 1) * PageSize).Take(PageSize);
        var employees =await query.ToListAsync();
        var employeeModels = employees.Select(e => new EmployeeViewModel
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            PhoneNumber = e.PhoneNumber,
            Addresses = e.Addresses.ToList(), // Assuming Addresses is a collection
            DepartmentId = e.DepartmentId,
            Department = _mapper.Map<DepartmentsModel>(e.Department),
            SuperHeros = e.SuperHeros.Select(s => new SuperHeroViewModel
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Id = s.Id
            }).ToList()
        }).ToList();
            return employeeModels;
    }

    public async Task<EmployeeViewModel> GetEmployeeById(int id)
    {
        var employee = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        var employeeModels = new EmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.PhoneNumber,
            Addresses = employee.Addresses.ToList(), // Assuming Addresses is a collection
            DepartmentId = employee.DepartmentId,
            Department = _mapper.Map<DepartmentsModel>(employee.Department),
        };
        if (employee is null)
        {
            return null;
        }
        
        return employeeModels;
    }

    public async Task<EmployeeViewModel> AddEmployee(EmployeeModel employee)
    {
        var mappedEmployee = _mapper.Map<Employee>(employee);
        mappedEmployee.Department = await _context.Departments.FindAsync(employee.DepartmentId);
        if (mappedEmployee.Department is null)
        {
            throw new ArgumentException("Department Not Found");
        }
        _context.Employees.Add(mappedEmployee);
        await _context.SaveChangesAsync();
        var result = new EmployeeViewModel
        {
            Id = mappedEmployee.Id,
            FirstName = mappedEmployee.FirstName,
            LastName = mappedEmployee.LastName,
            PhoneNumber = mappedEmployee.FirstName,
            Addresses = mappedEmployee.Addresses,
            DepartmentId = mappedEmployee.DepartmentId,
            Department = _mapper.Map<DepartmentsModel>(mappedEmployee.Department)
        };
        return result;
    }

    public async Task<EmployeeViewModel?> Update(int id, EmployeeModel request)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee is null)
        {
            return null;
        }
        employee.FirstName = request.FirstName;
        employee.Id = id;
        employee.LastName = request.LastName;
        employee = _mapper.Map<Employee>(request);
        var result = new EmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.FirstName,
            Addresses = employee.Addresses,
            DepartmentId = employee.DepartmentId,
            Department = _mapper.Map<DepartmentsModel>(await _context.Departments.FindAsync(employee.DepartmentId))
        };
        await _context.SaveChangesAsync();
        
        return result;
    }

    public async Task<EmployeeViewModel?> Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        var result = new EmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            PhoneNumber = employee.PhoneNumber,
            Addresses = employee.Addresses.ToList(), // Assuming Addresses is a collection
            DepartmentId = employee.DepartmentId,
            Department = _mapper.Map<DepartmentsModel>(await _context.Departments.FindAsync(employee.DepartmentId))
        };
        if (employee is null)
        {
            return null;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<List<EmployeeViewModel>?> DeleteAll()
    {
        var employees = await _context.Employees.ToListAsync();
        var employeeModels = employees.Select(e => new EmployeeViewModel
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            PhoneNumber = e.PhoneNumber,
            Addresses = e.Addresses.ToList(), // Assuming Addresses is a collection
            DepartmentId = e.DepartmentId,
            Department = _mapper.Map<DepartmentsModel>(e.Department)
        }).ToList();
        _context.Employees.RemoveRange(employees);
        await _context.SaveChangesAsync();
        return employeeModels;
    }
}