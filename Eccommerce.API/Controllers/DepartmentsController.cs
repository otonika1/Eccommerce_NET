using Eccommerce.API.Entities;
using Eccommerce.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eccommerce.API.Controllers;
[Route(("api/[controller]"))]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    [HttpGet("all")]
    public async Task<ActionResult<List<Department>>> GetAllDepartments()
    {
        var result = await _departmentService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartmentById(int id)
    {
        var department = await _departmentService.GetById(id);
        if (department is null)
        {
            return NotFound("employee Not Found");
        }

        return department;
    }
    [HttpPost]
    public async Task<ActionResult<Employee>> AddDepartment(DepartmentsModel department)
    {
        
        var result = await _departmentService.Post(department);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Department>> EditDepartment(int id, Department department)
    {
        var d = await _departmentService.Put(id, department);
        if (d is null)
        {
            return NotFound("employee Not Found");
        }
        return Ok(d);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Department>> Delete(int id)
    {
        var d = await _departmentService.Delete(id);
        if (d is null)
        {
            return NotFound("employee Not Found");
        }
        return Ok(d);
    }
    [HttpDelete]
    public async Task<ActionResult<Department>> DeleteAll()
    {
        var d = await _departmentService.DeleteAll();
        if (d is null)
        {
            return NotFound("employee Not Found");
        }
        return Ok(d);
    }
}