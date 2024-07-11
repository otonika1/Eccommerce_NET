using AutoMapper;
using Eccommerce.API.DB;
using Eccommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eccommerce.API.Services;

public class DepartmentService : IDepartmentService
{
    private readonly DataContext _context;
    public readonly IMapper _mapper;
    public DepartmentService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<Department>> GetAll()
    {
        var departments = await _context.Departments.Include(e => e.Employees).ToListAsync();
        return departments;
    }

    public async Task<Department> GetById(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        return department;
    }

    public async Task<Department> Post(DepartmentsModel department)
    {
        var mappedDep = _mapper.Map<Department>(department);
        _context.Departments.Add(mappedDep);
        await _context.SaveChangesAsync();
        return mappedDep;
    }

    public async Task<Department?> Put(int id, Department request)
    {
        var d = await _context.Departments.FindAsync(id);
        if (d is null)
        {
            return null;
        }
        var mappedD = _mapper.Map<Department>(d);
        await _context.SaveChangesAsync();
        return mappedD;
    }

    public async Task<Department?> Delete(int id)
    {
        var d =await _context.Departments.FindAsync(id);
        if (d is null)
        {
            return null;
        }

        _context.Departments.Remove(d);
        await _context.SaveChangesAsync();
        return d;
    }

    public async Task<List<Department>?> DeleteAll()
    {
        var departments = await _context.Departments.ToListAsync();
        _context.Departments.RemoveRange(departments);
        await _context.SaveChangesAsync();
        return departments;
    }
}