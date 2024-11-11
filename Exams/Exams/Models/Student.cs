namespace Exams.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public List<ExamResult> ExamResults {get;set;}
    }
}
