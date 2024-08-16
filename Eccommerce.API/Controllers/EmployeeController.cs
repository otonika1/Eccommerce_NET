using AutoMapper;
using Eccommerce.API.Entities;
using Eccommerce.API.Model;
using Eccommerce.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Eccommerce.API.Controllers;
[Route(("api/[controller]"))]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        this._employeeService = employeeService;
    } 
    [HttpGet("all")]
    public async Task<ActionResult<List<Employee>>> GetAllEmployees(int? DepartmentId,string? FirstName, string? SortOrder = "asc", int PageNumber = 1, int PageSize = 10)
    {
        return Ok(await _employeeService.GetAllEmployees(DepartmentId, FirstName, SortOrder, PageNumber, PageSize));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeViewModel>> GetEmployeesById(int id)
    {
        var employee = await _employeeService.GetEmployeeById(id);
        if (employee is null)
        {
            return NotFound("employee Not Found");
        }

        return employee;
    }
    [HttpPost]
    public async Task<ActionResult<EmployeeViewModel>> AddEmployee(EmployeeModel employee)
    {

        
        try
        {
            var result = await _employeeService.AddEmployee(employee);
            return Ok(result);
        }
        catch (ArgumentNullException ex)
        {
            // Handle specific exception if id is null or other argument issues
            return BadRequest($"Invalid input: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            // Handle specific exception if the operation is invalid (e.g., trying to delete a non-existing entity)
            return BadRequest($"Operation failed: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle all other exceptions
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<EmployeeViewModel>> UpdateEmployee(int id,EmployeeModel employee)
    {
        
        var result = await _employeeService.Update(id,employee);
        if (result is null)
        {
            return NotFound("Employee Not Found");
        }
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<EmployeeViewModel>> Delete(int id)
    {
        var result = await _employeeService.Delete(id);
        if (result is null)
        {
            return NotFound("Employee Not Found");
        }
        return Ok(result);
    }
    [HttpDelete("all")]
    public async Task<ActionResult<EmployeeViewModel>> DeleteAll()
    {
        var result = await _employeeService.DeleteAll();
        if (result is null)
        {
            return NotFound("Employee Not Found");
        }
        return Ok(result);
    }
}