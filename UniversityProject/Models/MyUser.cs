using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
    public class MyUser
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage ="لطفا کد ملی خود را وارد کنید")]
        [MinLength(10 , ErrorMessage ="کد ملی باید 10 رقم باشد")]
        public string CodeMelly { get; set; }
        [Required(ErrorMessage ="لطفا نام و نام خانوادگی خود را کامل پر کنید")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "لطفا پسوورد خود را وارد کنید ")]
        [MinLength(8 , ErrorMessage ="پسوورد نباید کمتر از 8 رقم باشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا تکرار پسوورد خود را وارد کنید")]
        [MinLength(8, ErrorMessage = "پسوورد نباید کمتر از 8 رقم باشد")]
        [Compare("Password" , ErrorMessage ="لطفا تکرار پسوورد خود را درست وارد کنید")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        [ForeignKey("Role")]
        public int? IdRole { get; set; }
        public Role Role { get; set; }
        public List<SelectedLesson> SelectedLessons { get; set; }
    }
}