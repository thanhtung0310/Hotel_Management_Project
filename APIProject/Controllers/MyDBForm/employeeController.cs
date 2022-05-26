using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using DatabaseProvider;
using CommonData = APIProject.Data.CommonConstants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace APIProject.Controllers.MyDBForm
{
  [Authorize(Roles = "Admin")]
  public class EmployeeController : Controller
  {
    private readonly APIProjectContext _context;

    public EmployeeController(APIProjectContext context)
    {
      _context = context;
    }

    const string SessionUsername = "_username";
    const string SessionRole = "Guest";
    const string SessionName = "_name";
    const string SessionToken = "_token";

    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername);
      ViewBag.SessionRole = HttpContext.Session.GetString(SessionRole);
      ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
      ViewBag.Session = HttpContext.Session.GetString(SessionToken);
    }

    // GET: employee
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      return View(await _context.employee.ToListAsync());
    }

    // GET: employee/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var employee = await _context.employee
          .FirstOrDefaultAsync(m => m.emp_id == id);
      if (employee == null)
      {
        return NotFound();
      }

      return View(employee);
    }

    // GET: employee/Create
    public IActionResult Create()
    {
      GetSessionInfo();

      return View();
    }

    // POST: employee/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("emp_id,emp_name,emp_position,emp_dob,emp_contact_number")] employee employee)
    {
      GetSessionInfo();

      if (ModelState.IsValid)
      {
        _context.Add(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(employee);
    }

    // GET: employee/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var employee = await _context.employee.FindAsync(id);
      if (employee == null)
      {
        return NotFound();
      }
      return View(employee);
    }

    // POST: employee/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("emp_id,emp_name,emp_position,emp_dob,emp_contact_number")] employee employee)
    {
      GetSessionInfo();

      if (id != employee.emp_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(employee);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!employeeExists(employee.emp_id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(employee);
    }

    // GET: employee/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var employee = await _context.employee
          .FirstOrDefaultAsync(m => m.emp_id == id);
      if (employee == null)
      {
        return NotFound();
      }

      return View(employee);
    }

    // POST: employee/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      GetSessionInfo();

      var employee = await _context.employee.FindAsync(id);
      _context.employee.Remove(employee);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool employeeExists(int id)
    {
      return _context.employee.Any(e => e.emp_id == id);
    }
  }
}
