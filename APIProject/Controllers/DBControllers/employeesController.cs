using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using DatabaseProvider;

namespace APIProject.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class employeesController : ControllerBase
  {
    private readonly APIProjectContext _context;

    public employeesController(APIProjectContext context)
    {
      _context = context;
    }

    /// <summary> Get a list of all employees </summary>
    /// <returns></returns>
    // GET: api/employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<employee>>> GetEmployee()
    {
      return await _context.employee.ToListAsync();
    }

    /// <summary> Get Employee by ID </summary>
    /// <returns></returns>
    // GET: api/employees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<employee>> GetEmployeeByID(int? id)
    {
      var employee = await _context.employee.FindAsync(id);

      if (employee == null || id == null)
      {
        //return NotFound();
        return BadRequest("Cannot find employee with id = " + id);
      }

      return employee;
    }

    /// <summary> Get Employee by a search String </summary>
    /// <returns></returns>
    // GET: api/employees/tuan
    //[HttpGet("{searchString}")]
    //public virtual async Task<ActionResult<employee>> GetEmployeeByName(string searchString)
    //{
    //  var employee = await _context.employee.Where(s => s.emp_name.Contains(searchString)).FirstOrDefaultAsync();

    //  if (employee == null || searchString == null)
    //  {
    //    //return NotFound();
    //    return BadRequest("Cannot find employee with search string = " + searchString);
    //  }

    //  return employee;
    //}

    /// <summary> Create a new Employee </summary>
    /// <returns></returns>
    // POST: api/employees
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<employee>> CreateEmployee(employee employee)
    {
      _context.employee.Add(employee);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (EmployeeExists(employee.emp_id))
        {
          return Conflict("Cannot create employee with id = " + employee.emp_id);
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("GetEmployee", new { id = employee.emp_id }, employee);
    }

    /// <summary> Update Employee with different info </summary>
    /// <returns></returns>
    // PUT: api/employees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> EditEmployee(int? id, employee employee)
    {
      if (id != employee.emp_id)
      {
        return BadRequest("Cannot find employee with id = " + id);
      }

      _context.Entry(employee).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EmployeeExists(id))
        {
          return NotFound("Cannot find employee with id = " + id);
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("GetEmployee", new { id = employee.emp_id }, employee);
    }

    /// <summary> Delete Employee by ID </summary>
    /// <returns></returns>
    // DELETE: api/employees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int? id)
    {
      var employee = await _context.employee.FindAsync(id);
      if (employee == null)
      {
        return NotFound("Cannot find employee with id = " + id);
      }

      _context.employee.Remove(employee);
      await _context.SaveChangesAsync();

      return Accepted("Delete successful employee with id = " + id);
    }

    private bool EmployeeExists(int? id)
    {
      return _context.employee.Any(e => e.emp_id == id);
    }
  }
}
