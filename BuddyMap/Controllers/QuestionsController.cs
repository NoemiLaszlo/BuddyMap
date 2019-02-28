using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuddyMap.DataAccess;
using BuddyMap.Models;
using BuddyMap.ViewModels;

namespace BuddyMap
{
    public class QuestionsController : Controller
    {
        private readonly Context _context;

        public QuestionsController(Context context)
        {
            _context = context;
        }

        public ActionResult GetQuestionCreate()
        {
            QuestionCreate questionCreate = new QuestionCreate();
            questionCreate.Question = GetQuestionModel();
            questionCreate.QuestionGroups = GetQuestionGroupModel();
            return View(questionCreate);
        }

        private Question GetQuestionModel()
        {
            Question q = new Question()
            {
                QuestionText = "Question1",
                NumOfAnswers = 3
            };
                                 
            return q;
        }

        private List<QuestionGroup> GetQuestionGroupModel()
        {
            List<QuestionGroup> qg = new List<QuestionGroup>();
            qg.Add(new QuestionGroup() { QuestionGroupName = "QuestionGroup1" });
            qg.Add(new QuestionGroup() { QuestionGroupName = "QuestionGroup2" });

            return qg;
        }

        

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            //QuestionGroup.Include(q => q.Questions)
            var fuckoyu = await _context.Question.Include(q => q.QQGConnection).ThenInclude(qqg => qqg.QuestionGroup).ToListAsync();
            return View(fuckoyu);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var question = await _context.Question.Include("QQGConnection.QuestionGroup")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            //var tuple = new Tuple<Question, QuestionGroup>(question, new QuestionGroup());
            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            IEnumerable<QuestionGroup> questionGroups = _context.QuestionGroup.ToList();
            ViewModels.QuestionCreate questionCreate = new ViewModels.QuestionCreate()
            {
                QuestionGroups = questionGroups
            };
            return View(questionCreate);
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionCreate questionCreate)
        {
            //questionCreate.Questions.QQGConnection.Add(questionCreate.QuestionGroups.First());
            if (ModelState.IsValid)
            {
                
                var qg = _context.QuestionGroup.Include(q => q.QQGConnections).ThenInclude(qqg => qqg.Question).First(q => questionCreate.SelectedQGId == q.Id);
                qg.QQGConnections.Add(new QQGConnection() { Question = questionCreate.Question, QuestionGroup = qg });
                _context.Entry(qg).State = EntityState.Modified;               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionCreate);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionText,NumOfAnswers")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Question
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Question.FindAsync(id);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}
