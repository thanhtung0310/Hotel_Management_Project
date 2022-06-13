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
  [Admin]
  public class PaymentTypeController : BaseController
  {
    private readonly APIProjectContext _context;

    public PaymentTypeController(APIProjectContext context)
    {
      _context = context;
    }

    // GET: paymentType
    public async Task<IActionResult> Index()
    {
      return View(await _context.paymentType.ToListAsync());
    }

    // GET: paymentType/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var paymentType = await _context.paymentType
          .FirstOrDefaultAsync(m => m.payment_type_id == id);
      if (paymentType == null)
      {
        return NotFound();
      }

      return View(paymentType);
    }

    // GET: paymentType/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: paymentType/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("payment_type_id,payment_type_name")] paymentType paymentType)
    {
      if (ModelState.IsValid)
      {
        _context.Add(paymentType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(paymentType);
    }

    // GET: paymentType/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var paymentType = await _context.paymentType.FindAsync(id);
      if (paymentType == null)
      {
        return NotFound();
      }

      return View(paymentType);
    }

    // POST: paymentType/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("payment_type_id,payment_type_name")] paymentType paymentType)
    {
      if (id != paymentType.payment_type_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(paymentType);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!paymentTypeExists(paymentType.payment_type_id))
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
      return View(paymentType);
    }

    // GET: paymentType/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var paymentType = await _context.paymentType
          .FirstOrDefaultAsync(m => m.payment_type_id == id);
      if (paymentType == null)
      {
        return NotFound();
      }

      return View(paymentType);
    }

    // POST: paymentType/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var paymentType = await _context.paymentType.FindAsync(id);
      _context.paymentType.Remove(paymentType);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool paymentTypeExists(int id)
    {
      return _context.paymentType.Any(e => e.payment_type_id == id);
    }
  }
}
