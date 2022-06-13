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
  public class RoomStatusController : BaseController
  {
    private readonly APIProjectContext _context;

    public RoomStatusController(APIProjectContext context)
    {
      _context = context;
    }

    // GET: RoomStatus
    public async Task<IActionResult> Index()
    {
      return View(await _context.roomStatus.ToListAsync());
    }

    // GET: RoomStatus/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var roomStatus = await _context.roomStatus
          .FirstOrDefaultAsync(m => m.room_status_id == id);
      if (roomStatus == null)
      {
        return NotFound();
      }

      return View(roomStatus);
    }

    // GET: RoomStatus/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: RoomStatus/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("room_status_id,room_status_name")] roomStatus roomStatus)
    {
      if (ModelState.IsValid)
      {
        _context.Add(roomStatus);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(roomStatus);
    }

    // GET: RoomStatus/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var roomStatus = await _context.roomStatus.FindAsync(id);
      if (roomStatus == null)
      {
        return NotFound();
      }
      
      return View(roomStatus);
    }

    // POST: RoomStatus/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("room_status_id,room_status_name")] roomStatus roomStatus)
    {
      if (id != roomStatus.room_status_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(roomStatus);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!roomStatusExists(roomStatus.room_status_id))
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
      return View(roomStatus);
    }

    // GET: RoomStatus/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var roomStatus = await _context.roomStatus
          .FirstOrDefaultAsync(m => m.room_status_id == id);
      if (roomStatus == null)
      {
        return NotFound();
      }

      return View(roomStatus);
    }

    // POST: RoomStatus/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var roomStatus = await _context.roomStatus.FindAsync(id);
      _context.roomStatus.Remove(roomStatus);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool roomStatusExists(int id)
    {
      return _context.roomStatus.Any(e => e.room_status_id == id);
    }
  }
}
