using Exams.Models;

namespace Exams.DB
{
    public static class ExamsDbInitializer
    {
        public static void Initialize(ExamsContext context)
        {
            // Создание базы данных, если она не существует
            context.Database.EnsureCreated();

            // Проверка наличия данных в таблицах
            if (context.Groups.Any())
            {
                return; // База данных уже инициализирована
            }

            // Создание начальных данных
            var groups = new Group[]
            {
                new Group { Name = "A" },
                new Group { Name = "B" },
                new Group { Name = "C" }
            };
            context.Groups.AddRange(groups);

            var subjects = new Subject[]
            {
                new Subject { Name = "Mathematics" },
                new Subject { Name = "Physics" },
                new Subject { Name = "Chemistry" }
            };
            context.Subjects.AddRange(subjects);

            var teachers = new Teacher[]
            {
                new Teacher { Name = "Sadovski V.T.", LengthOfWork = "5 years", Subjects = subjects.ToList() },
                new Teacher { Name = "Plisko I.G.", LengthOfWork = "3 years", Subjects = new List<Subject> { subjects[0] } },
                new Teacher { Name = "Yakimov A.I.", LengthOfWork = "4 years", Subjects = new List<Subject> { subjects[1], subjects[2] } }
            };
            context.Teachers.AddRange(teachers);

            var students = new Student[]
            {
                new Student { Surname = "Zaitsev", Name = "Dzimitriu", SecondName = "SerGEEvich", Group = groups[0] },
                new Student { Surname = "Zaitsev", Name = "Andrew2004", SecondName = "Alexandrovich", Group = groups[0] },
                new Student { Surname = "Petrova", Name = "Anna", SecondName = "Alexandrovna", Group = groups[1] },
                new Student { Surname = "Savitskiu", Name = "Evgeniu", SecondName = "Igorevich", Group = groups[2] }
            };
            context.Students.AddRange(students);

            context.SaveChanges(); // Сохранение изменений в базе данных
        }
    }
}