using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using DatabaseProvider;
using Microsoft.AspNetCore.Http;

namespace APIProject.Controllers.MyDBForm
{
  public class ReceptionController : Controller
  {
    private readonly APIProjectContext _context;

    public ReceptionController(APIProjectContext context)
    {
      _context = context;
    }

    const string SessionUsername = "_username";
    const string SessionRole = "Guest";
    const string SessionName = "_name";
    const string SessionToken = "_token";

    private void GetSessionInfo()
    {
      ViewBag.SessionUsername = HttpContext.Session.GetString(SessionUsername);
      ViewBag.SessionRole = HttpContext.Session.GetString(SessionRole);
      ViewBag.SessionName = HttpContext.Session.GetString(SessionName);
      ViewBag.Session = HttpContext.Session.GetString(SessionToken);
    }

    private bool isManager()
    {
      if (ViewBag.SessionRole == "Manager")
        return true;
      else
        return false;
    }

    // GET: reception
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(await _context.reception.OrderByDescending(x => x.reception_id).ToListAsync());
    }

    // GET: reception/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var reception = await _context.reception
          .FirstOrDefaultAsync(m => m.reception_id == id);
      if (reception == null)
      {
        return NotFound();
      }

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(reception);
    }

    // GET: reception/Create
    public IActionResult Create()
    {
      GetSessionInfo();

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View();
    }

    // POST: reception/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("reception_id,customer_id,reservation_id,room_id,check_in_date,expected_check_out_date,check_out_date,reception_status")] reception reception)
    {
      GetSessionInfo();

      if (ModelState.IsValid)
      {
        _context.Add(reception);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(reception);
    }

    // GET: reception/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var reception = await _context.reception.FindAsync(id);
      if (reception == null)
      {
        return NotFound();
      }

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(reception);
    }

    // POST: reception/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("reception_id,customer_id,reservation_id,room_id,check_in_date,expected_check_out_date,check_out_date,reception_status")] reception reception)
    {
      GetSessionInfo();

      if (id != reception.reception_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(reception);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!receptionExists(reception.reception_id))
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
      return View(reception);
    }

    // GET: reception/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var reception = await _context.reception
          .FirstOrDefaultAsync(m => m.reception_id == id);
      if (reception == null)
      {
        return NotFound();
      }

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(reception);
    }

    // POST: reception/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      GetSessionInfo();

      var reception = await _context.reception.FindAsync(id);
      _context.reception.Remove(reception);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool receptionExists(int id)
    {
      return _context.reception.Any(e => e.reception_id == id);
    }
  }
}
