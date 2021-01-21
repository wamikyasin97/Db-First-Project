using System;
using Microsoft.EntityFrameworkCore;

namespace Database_First_App
{
    //Entity classes
    public class Student
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
    }

    public class Course
    {
        public int courseId { get; set; }
        public string courseName { get; set; }
    }

    //Context Class
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SchoolDB;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {

                var std = new Student()
                {
                    studentName = "Wamik"
                };

                var ctd = new Course()
                {
                    courseName = "ICT"
                };

                var std1 = new Student()
                {
                    studentName = "Wamik1"
                };

                var ctd1 = new Course()
                {
                    courseName = "Computing"
                };

                var std2 = new Student()
                {
                    studentName = "Wamik2"
                };

                var ctd2 = new Course()
                {
                    courseName = "C#"
                };

                context.Students.Add(std);
                context.Courses.Add(ctd);
                context.Students.Add(std1);
                context.Courses.Add(ctd1);
                context.Students.Add(std2);
                context.Courses.Add(ctd2);
                context.SaveChanges();
            }
        }
    }
}
