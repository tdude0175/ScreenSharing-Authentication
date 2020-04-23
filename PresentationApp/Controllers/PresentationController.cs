using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresentationApp.Data;
using PresentationApp.Models;

namespace PresentationApp.Controllers
{
    public class PresentationController : Controller
    {
        private readonly PresentationContext _context;

        public PresentationController(PresentationContext context)
        {
            _context = context;
        }

        // GET: Presentation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Presentation.ToListAsync());
        }

        // GET: Presentation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var presentation = await _context.Presentation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentation == null)
            {
                return NotFound();
            }

            return View(presentation);
        }

        // GET: Presentation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Presentation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VideoToken,CurrentSlide")] Presentation presentation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presentation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presentation);
        }

        // GET: Presentation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentation = await _context.Presentation.FindAsync(id);
            if (presentation == null)
            {
                return NotFound();
            }
            return View(presentation);
        }

        // POST: Presentation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VideoToken,CurrentSlide")] Presentation presentation)
        {
            if (id != presentation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presentation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresentationExists(presentation.Id))
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
            return View(presentation);
        }

        // GET: Presentation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentation = await _context.Presentation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presentation == null)
            {
                return NotFound();
            }

            return View(presentation);
        }

        // POST: Presentation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presentation = await _context.Presentation.FindAsync(id);
            _context.Presentation.Remove(presentation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresentationExists(int id)
        {
            return _context.Presentation.Any(e => e.Id == id);
        }
    }
}
