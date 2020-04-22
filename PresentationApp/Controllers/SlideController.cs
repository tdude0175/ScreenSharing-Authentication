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
    public class SlideController : Controller
    {
        private readonly PresentationContext _context;

        public SlideController(PresentationContext context)
        {
            _context = context;
        }

        // GET: Slide
        public async Task<IActionResult> Index()
        {
            return View(await _context.Slide.ToListAsync());
        }

        // GET: Slide/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slide
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        // GET: Slide/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slide/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Picture")] Slide slide)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(slide);
        }

        // GET: Slide/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slide.FindAsync(id);
            if (slide == null)
            {
                return NotFound();
            }
            return View(slide);
        }

        // POST: Slide/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Picture")] Slide slide)
        {
            if (id != slide.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlideExists(slide.Id))
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
            return View(slide);
        }

        // GET: Slide/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slide = await _context.Slide
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

        // POST: Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slide = await _context.Slide.FindAsync(id);
            _context.Slide.Remove(slide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlideExists(int id)
        {
            return _context.Slide.Any(e => e.Id == id);
        }
    }
}
