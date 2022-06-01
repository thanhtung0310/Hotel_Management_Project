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
  public class AccountController : Controller
  {
    private readonly APIProjectContext _context;

    public AccountController(APIProjectContext context)
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

    // GET: account
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(await _context.account.ToListAsync());
    }

    // GET: account/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      GetSessionInfo();

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

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(account);
    }

    // GET: account/Create
    public IActionResult Create()
    {
      GetSessionInfo();

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View();
    }

    public string HashedPassword(string pwd)
    {
      int costParam = 13;
      return BCryptNet.HashPassword(pwd, costParam);
    }

    // POST: account/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("acc_id,emp_id,customer_id,acc_username,acc_password,role_id")] account account)
    {
      GetSessionInfo();

      account.acc_password = HashedPassword(account.acc_password);

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
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var account = await _context.account.FindAsync(id);
      if (account == null)
      {
        return NotFound();
      }

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(account);
    }

    // POST: account/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("acc_id,emp_id,customer_id,acc_username,acc_password,role_id")] account account)
    {
      GetSessionInfo();

      if (id != account.acc_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          account.acc_password = HashedPassword(account.acc_password);

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
      GetSessionInfo();

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

      if (!isManager())
        return RedirectToAction("Restrict", "Home");
      else
        return View(account);
    }

    // POST: account/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      GetSessionInfo();

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
