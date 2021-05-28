using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
    public class Lesson
    {
        [Key]
        public int IdLesson { get; set; }
        public string Name { get; set; }
        public int Vahed { get; set; }
        public List<SelectedLesson> SelectedLessons { get; set; }
    }
}