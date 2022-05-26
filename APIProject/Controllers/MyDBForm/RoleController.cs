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
  public class RoleController : Controller
  {
    private readonly APIProjectContext _context;

    public RoleController(APIProjectContext context)
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

    // GET: Role
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      return View(await _context.role.ToListAsync());
    }

    // GET: Role/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var role = await _context.role
          .FirstOrDefaultAsync(m => m.role_id == id);
      if (role == null)
      {
        return NotFound();
      }

      return View(role);
    }

    // GET: Role/Create
    public IActionResult Create()
    {
      GetSessionInfo();

      return View();
    }

    // POST: Role/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("role_id,role_name")] role role)
    {
      GetSessionInfo();

      if (ModelState.IsValid)
      {
        _context.Add(role);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(role);
    }

    // GET: Role/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var role = await _context.role.FindAsync(id);
      if (role == null)
      {
        return NotFound();
      }
      return View(role);
    }

    // POST: Role/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("role_id,role_name")] role role)
    {
      GetSessionInfo();

      if (id != role.role_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(role);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!roleExists(role.role_id))
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
      return View(role);
    }

    // GET: Role/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var role = await _context.role
          .FirstOrDefaultAsync(m => m.role_id == id);
      if (role == null)
      {
        return NotFound();
      }

      return View(role);
    }

    // POST: Role/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      GetSessionInfo();

      var role = await _context.role.FindAsync(id);
      _context.role.Remove(role);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool roleExists(int id)
    {
      return _context.role.Any(e => e.role_id == id);
    }
  }
}
