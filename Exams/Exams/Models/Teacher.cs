using System.Security.Cryptography.X509Certificates;

namespace Exams.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LengthOfWork { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
