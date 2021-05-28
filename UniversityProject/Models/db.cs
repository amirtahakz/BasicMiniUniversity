using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityProject.Models
{
    public class db : DbContext
    {
        public db() : base("constrTest") { }
        public DbSet<MyUser> myusers { set; get; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<SelectedLesson> SelectedLessons { get; set; }
    }
}