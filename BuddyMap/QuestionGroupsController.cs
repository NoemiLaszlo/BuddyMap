using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuddyMap.DataAccess;
using BuddyMap.Models;

namespace BuddyMap
{
    public class QuestionGroupsController : Controller
    {
        private readonly Context _context;

        public QuestionGroupsController(Context context)
        {
            _context = context;
        }

        // GET: QuestionGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestionGroup.ToListAsync());
        }

        // GET: QuestionGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionGroup = await _context.QuestionGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionGroup == null)
            {
                return NotFound();
            }

            return View(questionGroup);
        }

        // GET: QuestionGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuestionGroupName")] QuestionGroup questionGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionGroup);
        }

        // GET: QuestionGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionGroup = await _context.QuestionGroup.FindAsync(id);
            if (questionGroup == null)
            {
                return NotFound();
            }
            return View(questionGroup);
        }

        // POST: QuestionGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionGroupName")] QuestionGroup questionGroup)
        {
            if (id != questionGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionGroupExists(questionGroup.Id))
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
            return View(questionGroup);
        }

        // GET: QuestionGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionGroup = await _context.QuestionGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionGroup == null)
            {
                return NotFound();
            }

            return View(questionGroup);
        }

        // POST: QuestionGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionGroup = await _context.QuestionGroup.FindAsync(id);
            _context.QuestionGroup.Remove(questionGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionGroupExists(int id)
        {
            return _context.QuestionGroup.Any(e => e.Id == id);
        }
    }
}
