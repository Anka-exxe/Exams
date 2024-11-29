using Exams.DB;
using Exams.Models;
using Exams.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Exams.Controllers
{
    public class ExamController : Controller
    {
        private readonly ExamsContext _context;

        public ExamController(ExamsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var examResults = _context.ExamResults
                .Include(e => e.Student)
                .Include(e => e.Teacher)
                .Include(e => e.Subject)
                .ToList();

            return View(examResults);
        }

        public IActionResult AddExam()
        {
            ViewBag.Students = new SelectList(
         _context.Students.Select(s => new
         {
             Id = s.Id,
             FullName = s.Surname + " " + s.Name // Комбинируем фамилию и имя
         }).ToList(), "Id", "FullName");

            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "Name");
            ViewBag.Subjects = new SelectList(_context.Subjects, "Id", "Name");
            return View(new ExamResultViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(ExamResultViewModel examResult)
        {
            if (ModelState.IsValid)
            {
                ExamResult exam = new ExamResult
                {
                    StudentId = examResult.StudentId,
                    TeacherId = examResult.TeacherId,
                    SubjectId = examResult.SubjectId,
                    ExamTicketNumber = examResult.ExamTicketNumber,
                    Mark = examResult.Mark
                };

                _context.ExamResults.Add(exam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Заполнение ViewBag для возвращения в представление с ошибками
            ViewBag.Students = new SelectList(_context.Students, "Id", "Surname", examResult.StudentId);
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "Name", examResult.TeacherId);
            ViewBag.Subjects = new SelectList(_context.Subjects, "Id", "Name", examResult.SubjectId);

            // Если ModelState не валиден, можно вывести ошибки в консоль или лог
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    // Здесь вы можете логировать ошибки, например:
                    Console.WriteLine($"Ошибка для {entry.Key}: {error.ErrorMessage}");
                }
            }

            // Возвращаем представление с текущей моделью, чтобы показать ошибки пользователю
            return View(examResult);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var examResult = await _context.ExamResults.FindAsync(id);
            if (examResult != null)
            {
                _context.ExamResults.Remove(examResult);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditExam(int id)
        {
            var examResult = _context.ExamResults
                .Include(e => e.Student)
                .Include(e => e.Teacher)
                .Include(e => e.Subject)
                .FirstOrDefault(e => e.Id == id);

            if (examResult == null)
            {
                return NotFound();
            }

            ViewBag.Students = new SelectList(_context.Students, "Id", "Surname");
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "Name");
            ViewBag.Subjects = new SelectList(_context.Subjects, "Id", "Name");

            return View(examResult);
        }

        [HttpPost]
        public async Task<IActionResult> EditExam(ExamResult examResult)
        {
            if (ModelState.ErrorCount <= 3)
            {
                _context.ExamResults.Update(examResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Если валидация не прошла, повторно заполняем ViewBag
            ViewBag.Students = new SelectList(_context.Students, "Id", "Surname", examResult.StudentId);
            ViewBag.Teachers = new SelectList(_context.Teachers, "Id", "Name", examResult.TeacherId);
            ViewBag.Subjects = new SelectList(_context.Subjects, "Id", "Name", examResult.SubjectId);

            return View(examResult);
        }
    }
}
