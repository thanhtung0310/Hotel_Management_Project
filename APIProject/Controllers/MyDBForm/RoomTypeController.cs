﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIProject.Data;
using DatabaseProvider;
using CommonData = APIProject.Data.CommonConstants;

namespace APIProject.Controllers.MyDBForm
{
  public class RoomTypeController : Controller
  {
    private readonly APIProjectContext _context;

    public RoomTypeController(APIProjectContext context)
    {
      _context = context;
    }

    public void GetSessionInfo()
    {
      ViewBag.SessionUsername = CommonData.USER_USERNAME;
      ViewBag.SessionRole = CommonData.USER_ROLE;
      ViewBag.SessionName = CommonData.USER_NAME;
    }

    // GET: RoomType
    public async Task<IActionResult> Index()
    {
      GetSessionInfo();

      return View(await _context.roomType.ToListAsync());
    }

    // GET: RoomType/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var roomType = await _context.roomType
          .FirstOrDefaultAsync(m => m.room_type_id == id);
      if (roomType == null)
      {
        return NotFound();
      }

      return View(roomType);
    }

    // GET: RoomType/Create
    public IActionResult Create()
    {
      GetSessionInfo();

      return View();
    }

    // POST: RoomType/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("room_type_id,room_type_name")] roomType roomType)
    {
      GetSessionInfo();

      if (ModelState.IsValid)
      {
        _context.Add(roomType);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(roomType);
    }

    // GET: RoomType/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var roomType = await _context.roomType.FindAsync(id);
      if (roomType == null)
      {
        return NotFound();
      }
      return View(roomType);
    }

    // POST: RoomType/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("room_type_id,room_type_name")] roomType roomType)
    {
      GetSessionInfo();

      if (id != roomType.room_type_id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(roomType);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!roomTypeExists(roomType.room_type_id))
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
      return View(roomType);
    }

    // GET: RoomType/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      GetSessionInfo();

      if (id == null)
      {
        return NotFound();
      }

      var roomType = await _context.roomType
          .FirstOrDefaultAsync(m => m.room_type_id == id);
      if (roomType == null)
      {
        return NotFound();
      }

      return View(roomType);
    }

    // POST: RoomType/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      GetSessionInfo();

      var roomType = await _context.roomType.FindAsync(id);
      _context.roomType.Remove(roomType);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool roomTypeExists(int id)
    {
      return _context.roomType.Any(e => e.room_type_id == id);
    }
  }
}
