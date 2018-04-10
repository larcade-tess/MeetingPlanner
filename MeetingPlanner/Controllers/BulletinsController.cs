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
                .Include(s => s.Speakers)
                .AsNoTracking()
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
        public async Task<IActionResult> Create(
            [Bind("MeetingConductor,OpeningSongNumber,SacramentSongNumber,OpeningPrayerName,ClosingSongNumber,ClosingPrayerName,MeetingDate,Speakers")] Bulletin bulletin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(bulletin);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
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
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bulletinToUpdate = await _context.Bulletins.SingleOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Bulletin>(
                bulletinToUpdate,
                "",
                s => s.MeetingConductor, s => s.MeetingDate,
                s => s.OpeningPrayerName, s => s.OpeningSongNumber))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(bulletinToUpdate);
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
