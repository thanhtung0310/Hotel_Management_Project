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
  public class RoomController : BaseController
  {
    private readonly APIProjectContext _context;

    public RoomController(APIProjectContext context)
    {
      _context = context;
    }

    // GET: Room
    public async Task<IActionResult> Index()
    {
      return View(await _context.room.OrderByDescending(x => x.room_status_id).ToListAsync());
    }

    // GET: Room/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var room = await _context.room
          .FirstOrDefaultAsync(m => m.room_id == id);
      if (room == null)
      {
        return NotFound();
      }

      return View(room);
    }

    // GET: Room/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Room/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("room_id,room_number,room_type_id,room_status_id")] room room)
    {
      if (ModelState.IsValid)
      {
        _context.Add(room);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(room);
    }

    // GET: Room/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var room = await _context.room.FindAsync(id);
      if (room == null)
      {
        return NotFound();
      }

      return View(room);
    }

    // POST: Room/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("room_id,room_number,room_type_id,room_status_id")] room room)
    {
      if (id != room.room_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(room);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!roomExists(room.room_id))
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
      return View(room);
    }

    // GET: Room/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var room = await _context.room
          .FirstOrDefaultAsync(m => m.room_id == id);
      if (room == null)
      {
        return NotFound();
      }

      return View(room);
    }

    // POST: Room/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var room = await _context.room.FindAsync(id);
      _context.room.Remove(room);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool roomExists(int id)
    {
      return _context.room.Any(e => e.room_id == id);
    }
  }
}
