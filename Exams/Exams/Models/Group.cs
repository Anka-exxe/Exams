using System.ComponentModel.DataAnnotations;

namespace Exams.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Не указано название группы")]
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
