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
  public class CustomerController : BaseController
  {
    private readonly APIProjectContext _context;

    public CustomerController(APIProjectContext context)
    {
      _context = context;
    }

    // GET: customer
    public async Task<IActionResult> Index()
    {
      return View(await _context.customer.ToListAsync());
    }

    // GET: customer/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _context.customer
          .FirstOrDefaultAsync(m => m.customer_id == id);
      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // GET: customer/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: customer/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("customer_id,customer_first_name,customer_last_name,customer_address,customer_contact_number")] customer customer)
    {
      if (ModelState.IsValid)
      {
        _context.Add(customer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(customer);
    }

    // GET: customer/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _context.customer.FindAsync(id);
      if (customer == null)
      {
        return NotFound();
      }

        return View(customer);
    }

    // POST: customer/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("customer_id,customer_first_name,customer_last_name,customer_address,customer_contact_number")] customer customer)
    {
      if (id != customer.customer_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(customer);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!customerExists(customer.customer_id))
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
      return View(customer);
    }

    // GET: customer/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var customer = await _context.customer
          .FirstOrDefaultAsync(m => m.customer_id == id);
      if (customer == null)
      {
        return NotFound();
      }

      return View(customer);
    }

    // POST: customer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var customer = await _context.customer.FindAsync(id);
      _context.customer.Remove(customer);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool customerExists(int id)
    {
      return _context.customer.Any(e => e.customer_id == id);
    }
  }
}
