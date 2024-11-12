﻿using System.ComponentModel.DataAnnotations;

namespace Exams.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ExamTicketNumber { get; set; }
        [Range(0, 10, ErrorMessage = "Неверная оценка")]
        public int Mark {  get; set; }
    }
}
