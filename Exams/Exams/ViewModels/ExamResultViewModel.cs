using Exams.Models;
using System.ComponentModel.DataAnnotations;

namespace Exams.ViewModels
{
    public class ExamResultViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать студента.")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать преподавателя.")]
        public int TeacherId { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать предмет.")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Необходимо указать номер билета.")]
        public int ExamTicketNumber { get; set; }

        [Range(0, 10, ErrorMessage = "Неверная оценка")]
        public int Mark { get; set; }
    }
}
