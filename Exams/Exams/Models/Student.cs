using System.ComponentModel.DataAnnotations;

namespace Exams.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int GroupId { get; set; }
        [Required(ErrorMessage = "Не указана группа студента")]
        public Group Group { get; set; }
        public List<ExamResult> ExamResults {get;set;}
    }
}
