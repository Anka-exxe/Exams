using System.ComponentModel.DataAnnotations;

namespace Exams.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название предмета")]
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
