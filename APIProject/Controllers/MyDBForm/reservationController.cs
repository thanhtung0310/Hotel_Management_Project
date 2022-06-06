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
  public class ReservationController : Controller
  {
    private readonly APIProjectContext _context;

    public ReservationController(APIProjectContext context)
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

    // GET: reservation
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(await _context.reservation.OrderByDescending(x => x.reservation_id).ToListAsync());
    }

    // GET: reservation/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var reservation = await _context.reservation
          .FirstOrDefaultAsync(m => m.reservation_id == id);
      if (reservation == null)
      {
        return NotFound();
      }

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(reservation);
    }

    // GET: reservation/Create
    public IActionResult Create()
    {
      GetSessionInfo();

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View();
    }

    // POST: reservation/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("reservation_id,customer_id,expected_check_in_date,day_stay_number,expected_room_type_id,reservation_status")] reservation reservation)
    {
      GetSessionInfo();

      if (ModelState.IsValid)
      {
        _context.Add(reservation);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(reservation);
    }

    // GET: reservation/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var reservation = await _context.reservation.FindAsync(id);
      if (reservation == null)
      {
        return NotFound();
      }

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(reservation);
    }

    // POST: reservation/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("reservation_id,customer_id,expected_check_in_date,day_stay_number,expected_room_type_id,reservation_status")] reservation reservation)
    {
      GetSessionInfo();

      if (id != reservation.reservation_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(reservation);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!reservationExists(reservation.reservation_id))
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
      return View(reservation);
    }

    // GET: reservation/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var reservation = await _context.reservation
          .FirstOrDefaultAsync(m => m.reservation_id == id);
      if (reservation == null)
      {
        return NotFound();
      }

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(reservation);
    }

    // POST: reservation/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      GetSessionInfo();

      var reservation = await _context.reservation.FindAsync(id);
      _context.reservation.Remove(reservation);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool reservationExists(int id)
    {
      return _context.reservation.Any(e => e.reservation_id == id);
    }
  }
}
