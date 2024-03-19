#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCAspNetApp.Data;
using MVCAspNetApp.Models;

namespace MVCAspNetApp.Controllers
{
    public class QuizUserAnswersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizUserAnswersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuizUserAnswers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QuizUserAnswers.Include(q => q.QuizQuestion).Include(q => q.QuizQuestionOption);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuizUserAnswers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizUserAnswer = await _context.QuizUserAnswers
                .Include(q => q.QuizQuestion)
                .Include(q => q.QuizQuestionOption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizUserAnswer == null)
            {
                return NotFound();
            }

            return View(quizUserAnswer);
        }

        // GET: QuizUserAnswers/Create
        public IActionResult Create()
        {
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id");
            ViewData["QuizQuestionOptionId"] = new SelectList(_context.QuizQuestionOptions, "Id", "Id");
            return View();
        }

        // POST: QuizUserAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuizQuestionId,QuizQuestionOptionId")] QuizUserAnswer quizUserAnswer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizUserAnswer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id", quizUserAnswer.QuizQuestionId);
            ViewData["QuizQuestionOptionId"] = new SelectList(_context.QuizQuestionOptions, "Id", "Id", quizUserAnswer.QuizQuestionOptionId);
            return View(quizUserAnswer);
        }

        // GET: QuizUserAnswers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizUserAnswer = await _context.QuizUserAnswers.FindAsync(id);
            if (quizUserAnswer == null)
            {
                return NotFound();
            }
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id", quizUserAnswer.QuizQuestionId);
            ViewData["QuizQuestionOptionId"] = new SelectList(_context.QuizQuestionOptions, "Id", "Id", quizUserAnswer.QuizQuestionOptionId);
            return View(quizUserAnswer);
        }

        // POST: QuizUserAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuizQuestionId,QuizQuestionOptionId")] QuizUserAnswer quizUserAnswer)
        {
            if (id != quizUserAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizUserAnswer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizUserAnswerExists(quizUserAnswer.Id))
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
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id", quizUserAnswer.QuizQuestionId);
            ViewData["QuizQuestionOptionId"] = new SelectList(_context.QuizQuestionOptions, "Id", "Id", quizUserAnswer.QuizQuestionOptionId);
            return View(quizUserAnswer);
        }

        // GET: QuizUserAnswers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizUserAnswer = await _context.QuizUserAnswers
                .Include(q => q.QuizQuestion)
                .Include(q => q.QuizQuestionOption)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizUserAnswer == null)
            {
                return NotFound();
            }

            return View(quizUserAnswer);
        }

        // POST: QuizUserAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizUserAnswer = await _context.QuizUserAnswers.FindAsync(id);
            _context.QuizUserAnswers.Remove(quizUserAnswer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizUserAnswerExists(int id)
        {
            return _context.QuizUserAnswers.Any(e => e.Id == id);
        }
    }
}
