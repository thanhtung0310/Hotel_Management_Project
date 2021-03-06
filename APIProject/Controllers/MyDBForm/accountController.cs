using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using DatabaseProvider;
using Microsoft.AspNetCore.Http;
using BCryptNet = BCrypt.Net.BCrypt;

namespace APIProject.Controllers.MyDBForm
{  
  [Admin]
  public class AccountController : BaseController
  {
    private readonly APIProjectContext _context;

    public AccountController(APIProjectContext context)
    {
      _context = context;
    }

    // GET: account
    public async Task<IActionResult> Index()
    {
      return View(await _context.account.OrderByDescending(x => x.acc_session).ToListAsync());
    }

    // GET: account/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var account = await _context.account
          .FirstOrDefaultAsync(m => m.acc_id == id);
      if (account == null)
      {
        return NotFound();
      }

      return View(account);
    }

    // GET: account/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: account/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("acc_id,emp_id,role_id,acc_username,acc_password,acc_session")] account account)
    {
      account.acc_password = StaticVar.HashedPassword(account.acc_password);

      if (ModelState.IsValid)
      {
        _context.Add(account);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(account);
    }

    // GET: account/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var account = await _context.account.FindAsync(id);
      if (account == null)
      {
        return NotFound();
      }

      return View(account);
    }

    // POST: account/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("acc_id,emp_id,role_id,acc_username,acc_password,acc_session")] account account)
    {
      if (id != account.acc_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          account.acc_password = StaticVar.HashedPassword(account.acc_password);

          _context.Update(account);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!accountExists(account.acc_id))
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
      return View(account);
    }

    // GET: account/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var account = await _context.account
          .FirstOrDefaultAsync(m => m.acc_id == id);
      if (account == null)
      {
        return NotFound();
      }

      return View(account);
    }

    // POST: account/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var account = await _context.account.FindAsync(id);
      _context.account.Remove(account);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool accountExists(int id)
    {
      return _context.account.Any(e => e.acc_id == id);
    }
  }
}
