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
    
    public async Task<List<Employee>> GetAllEmployees()
    {
        
        var employees =await _context.Employees
            .Include(e => e.Department)
            .ToListAsync();
        return employees;
    }

    public async Task<Employee> GetEmployeeById(int id)
    {
        var employee = await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        if (employee is null)
        {
            return null;
        }
        return employee;
    }

    public async Task<Employee> AddEmployee(EmployeeModel employee)
    {
        var mappedEmployee = _mapper.Map<Employee>(employee);
        mappedEmployee.Department = await _context.Departments.FindAsync(employee.DepartmentId);
        if (mappedEmployee.Department is null)
        {
            throw new ArgumentException("Department Not Found");
        }
        _context.Employees.Add(mappedEmployee);
        await _context.SaveChangesAsync();
        return mappedEmployee;
    }

    public async Task<Employee?> Update(int id, EmployeeModel request)
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
        await _context.SaveChangesAsync();
        
        return employee;
    }

    public async Task<Employee?> Delete(int id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee is null)
        {
            return null;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<List<Employee>?> DeleteAll()
    {
        var employees = await _context.Employees.ToListAsync();
        _context.Employees.RemoveRange(employees);
        await _context.SaveChangesAsync();
        return employees;
    }
}