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
  public class PaymentController : Controller
  {
    private readonly APIProjectContext _context;

    public PaymentController(APIProjectContext context)
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

    // GET: payment
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      return View(await _context.payment.ToListAsync());
    }

    // GET: payment/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var payment = await _context.payment
          .FirstOrDefaultAsync(m => m.payment_id == id);
      if (payment == null)
      {
        return NotFound();
      }

      return View(payment);
    }

    // GET: payment/Create
    public IActionResult Create()
    {
      GetSessionInfo();

      return View();
    }

    // POST: payment/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("payment_id,payment_type_id,reception_id,payment_amount,payment_date")] payment payment)
    {
      GetSessionInfo();

      if (ModelState.IsValid)
      {
        _context.Add(payment);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(payment);
    }

    // GET: payment/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var payment = await _context.payment.FindAsync(id);
      if (payment == null)
      {
        return NotFound();
      }
      return View(payment);
    }

    // POST: payment/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("payment_id,payment_type_id,reception_id,payment_amount,payment_date")] payment payment)
    {
      GetSessionInfo();

      if (id != payment.payment_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(payment);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!paymentExists(payment.payment_id))
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
      return View(payment);
    }

    // GET: payment/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var payment = await _context.payment
          .FirstOrDefaultAsync(m => m.payment_id == id);
      if (payment == null)
      {
        return NotFound();
      }

      return View(payment);
    }

    // POST: payment/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      GetSessionInfo();

      var payment = await _context.payment.FindAsync(id);
      _context.payment.Remove(payment);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool paymentExists(int id)
    {
      return _context.payment.Any(e => e.payment_id == id);
    }
  }
}
