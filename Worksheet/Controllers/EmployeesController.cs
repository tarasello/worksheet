using Microsoft.AspNetCore.Mvc;
using Worksheet.Contracts;
using Worksheet.Model;

[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepo;
    public EmployeesController(IEmployeeRepository employeeRepo)
    {
        _employeeRepo = employeeRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var employees = await _employeeRepo.GetEmployees();
            return Ok(employees);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [Route("edit/{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        try
        {
            var employee = await _employeeRepo.GetEmployee(id);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [Route("save")]
    [HttpPut]
    public IActionResult SaveEmployee(Employee employee)
    {
        try
        {
            _employeeRepo.SaveEmployee(employee);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [Route("add")]
    [HttpPost]
    public IActionResult AddEmployee(Employee employee)
    {
        try
        {
            _employeeRepo.AddEmployee(employee);
            return Ok(employee);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }


    [Route("delete/{id}")]
    public IActionResult DeleteEmployee(int id)
    {
        try
        {
            _employeeRepo.DeleteEmployee(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [Route("restore/{id}")]
    public IActionResult RestoreEmployee(int id)
    {
        try
        {
            _employeeRepo.RestoreEmployee(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
