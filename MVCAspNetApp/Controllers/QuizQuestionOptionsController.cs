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
    public class QuizQuestionOptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizQuestionOptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuizQuestionOptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QuizQuestionOptions.Include(q => q.QuizQuestion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QuizQuestionOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestionOption = await _context.QuizQuestionOptions
                .Include(q => q.QuizQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizQuestionOption == null)
            {
                return NotFound();
            }

            return View(quizQuestionOption);
        }

        // GET: QuizQuestionOptions/Create
        public IActionResult Create()
        {
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id");
            return View();
        }

        // POST: QuizQuestionOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QuizQuestionId,Text,IsCorrect")] QuizQuestionOption quizQuestionOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quizQuestionOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id", quizQuestionOption.QuizQuestionId);
            return View(quizQuestionOption);
        }

        // GET: QuizQuestionOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestionOption = await _context.QuizQuestionOptions.FindAsync(id);
            if (quizQuestionOption == null)
            {
                return NotFound();
            }
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id", quizQuestionOption.QuizQuestionId);
            return View(quizQuestionOption);
        }

        // POST: QuizQuestionOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuizQuestionId,Text,IsCorrect")] QuizQuestionOption quizQuestionOption)
        {
            if (id != quizQuestionOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quizQuestionOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuizQuestionOptionExists(quizQuestionOption.Id))
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
            ViewData["QuizQuestionId"] = new SelectList(_context.QuizQuestions, "Id", "Id", quizQuestionOption.QuizQuestionId);
            return View(quizQuestionOption);
        }

        // GET: QuizQuestionOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestionOption = await _context.QuizQuestionOptions
                .Include(q => q.QuizQuestion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quizQuestionOption == null)
            {
                return NotFound();
            }

            return View(quizQuestionOption);
        }

        // POST: QuizQuestionOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quizQuestionOption = await _context.QuizQuestionOptions.FindAsync(id);
            _context.QuizQuestionOptions.Remove(quizQuestionOption);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuizQuestionOptionExists(int id)
        {
            return _context.QuizQuestionOptions.Any(e => e.Id == id);
        }
    }
}
