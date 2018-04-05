using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingPlanner.Data;
using MeetingPlanner.Models;

namespace MeetingPlanner.Controllers
{
    public class BulletinsController : Controller
    {
        private readonly MeetingContext _context;

        public BulletinsController(MeetingContext context)
        {
            _context = context;
        }

        // GET: Bulletins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bulletins.ToListAsync());
        }

        // GET: Bulletins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bulletin = await _context.Bulletins
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bulletin == null)
            {
                return NotFound();
            }

            return View(bulletin);
        }

        // GET: Bulletins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bulletins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MeetingConductor,OpeningSongNumber,OpeningPrayerName,ClosingSongNumber,ClosingPrayerName,MeetingDate")] Bulletin bulletin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bulletin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bulletin);
        }

        // GET: Bulletins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bulletin = await _context.Bulletins.SingleOrDefaultAsync(m => m.ID == id);
            if (bulletin == null)
            {
                return NotFound();
            }
            return View(bulletin);
        }

        // POST: Bulletins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MeetingConductor,OpeningSongNumber,OpeningPrayerName,ClosingSongNumber,ClosingPrayerName,MeetingDate")] Bulletin bulletin)
        {
            if (id != bulletin.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bulletin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BulletinExists(bulletin.ID))
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
            return View(bulletin);
        }

        // GET: Bulletins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bulletin = await _context.Bulletins
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bulletin == null)
            {
                return NotFound();
            }

            return View(bulletin);
        }

        // POST: Bulletins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bulletin = await _context.Bulletins.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bulletins.Remove(bulletin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BulletinExists(int id)
        {
            return _context.Bulletins.Any(e => e.ID == id);
        }
    }
}
