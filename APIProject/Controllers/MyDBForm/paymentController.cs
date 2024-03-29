﻿using System;
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
  public class PaymentController : BaseController
  {
    private readonly APIProjectContext _context;

    public PaymentController(APIProjectContext context)
    {
      _context = context;
    }

    // GET: payment
    public async Task<IActionResult> Index()
    {
      return View(await _context.payment.OrderByDescending(x => x.payment_id).ToListAsync());
    }

    // GET: payment/Details/5
    public async Task<IActionResult> Details(int? id)
    {
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
      return View();
    }

    // POST: payment/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("payment_id,payment_type_id,reservation_id,payment_amount,payment_date")] payment payment)
    {
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
    public async Task<IActionResult> Edit(int id, [Bind("payment_id,payment_type_id,reservation_id,payment_amount,payment_date")] payment payment)
    {
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
