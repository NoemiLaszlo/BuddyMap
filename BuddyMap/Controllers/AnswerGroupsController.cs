using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuddyMap.DataAccess;
using BuddyMap.Models;

namespace BuddyMap.Controllers
{
    public class AnswerGroupsController : Controller
    {
        private readonly Context _context;

        public AnswerGroupsController(Context context)
        {
            _context = context;
        }

        // GET: AnswerGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.AnswerGroup.ToListAsync());
        }

        // GET: AnswerGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerGroup = await _context.AnswerGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (answerGroup == null)
            {
                return NotFound();
            }

            answerGroup.Answers = await _context.Answer
                .Where(ans => ans.AnswerGroupId == answerGroup.Id)
                .ToListAsync();
            answerGroup.Answers.ForEach(
                ans =>
                {
                    ans.AnswerElements = _context.AnswerElement
                      .Where(anselem => anselem.AnswerId == ans.Id)
                      .ToList();
                });

            return View(answerGroup);
        }

        // GET: AnswerGroups/Create
        public IActionResult Create()
        {
            ViewBag.StudentList = _context.Student; //SG .Except(this.);
            ViewBag.Question = _context.Question; //QG

            return View();
        }

        // POST: AnswerGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubmitterId")] AnswerGroup AnswerGroup)
        {
            if (ModelState.IsValid)
            {
                var campaignAnswerDb = _context.Add(AnswerGroup);
                //_context.Add(new Student() { Name = "Blah" });
                var answerdb = _context.Add(new Answer()
                {
                    AnswerGroupId = campaignAnswerDb.Entity.Id,
                    QuestionId = 1
                });
                var answerelem = _context.Add(new AnswerElement()
                {
                    AnswerId = answerdb.Entity.Id,
                    StudentId = 22,
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(AnswerGroup);
        }

        // GET: AnswerGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AnswerGroup = await _context.AnswerGroup.FindAsync(id);
            if (AnswerGroup == null)
            {
                return NotFound();
            }
            return View(AnswerGroup);
        }

        // POST: AnswerGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] AnswerGroup AnswerGroup)
        {
            if (id != AnswerGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(AnswerGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnswerGroupExists(AnswerGroup.Id))
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
            return View(AnswerGroup);
        }

        // GET: AnswerGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AnswerGroup = await _context.AnswerGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (AnswerGroup == null)
            {
                return NotFound();
            }

            return View(AnswerGroup);
        }

        // POST: AnswerGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var AnswerGroup = await _context.AnswerGroup.FindAsync(id);
            _context.AnswerGroup.Remove(AnswerGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnswerGroupExists(int id)
        {
            return _context.AnswerGroup.Any(e => e.Id == id);
        }
    }
}
