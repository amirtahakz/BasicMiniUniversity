using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
    public class SelectedLesson
    {
        [Key]
        public int IdSelectedLesson { get; set; }
        [ForeignKey("Lesson")]
        public int IdLesson { get; set; }
        [ForeignKey("MyUser")]
        public int UserId { get; set; }
        public MyUser MyUser { get; set; }
        public Lesson Lesson { get; set; }
    }
}