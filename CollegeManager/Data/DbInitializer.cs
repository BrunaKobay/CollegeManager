using CollegeManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CollegeManager.Data
{
    public class DbInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            //Seed courses
            var courses = new List<Course>
            {
                new Course{Name = "Electrical Engineering"},
                new Course{Name = "Web Development"}
            };
            courses.ForEach(c => context.Coursers.Add(c));
            context.SaveChanges();

            //Seed teachers
            var teachers = new List<Teacher>
           {
                new Teacher{Name = "João Roberto", Birthday = DateTime.Parse("1994-03-23"), Salary = 230.12},
                new Teacher{Name = "Maria Antonieta", Birthday = DateTime.Parse("1984-09-13"), Salary = 130.52},
                new Teacher{Name = "Carlos Silva", Birthday = DateTime.Parse("2000-05-18"), Salary = 100.2},
                new Teacher{Name = "Ana Luiza", Birthday = DateTime.Parse("1990-12-25"), Salary = 200.72}
           };
            teachers.ForEach(c => context.Teachers.Add(c));
            context.SaveChanges();

            //Seed students
            var students = new List<Student>
           {
                new Student{Name = "Mikey Mouse", Birthday = DateTime.Parse("1994-03-23"), RegistrationId = 2302},
                new Student{Name = "Peter Pan", Birthday = DateTime.Parse("1984-09-13"), RegistrationId = 2304},
                new Student{Name = "Snow White", Birthday = DateTime.Parse("2000-05-18"), RegistrationId = 2323},
                new Student{Name = "Ana Maria", Birthday = DateTime.Parse("1990-12-25"), RegistrationId = 2334}
           };
            students.ForEach(c => context.Students.Add(c));
            context.SaveChanges();

            //Seed subjects
            var subjects = new List<Subject>
           {
                new Subject{Name = "Calculus", TeacherId = 4, CourseId = 1 },
                new Subject{Name = "Physics", TeacherId = 4, CourseId = 1 },
                new Subject{Name = "Electrical Networks", TeacherId = 3, CourseId = 1 },
                new Subject{Name = "Renewable Energies", TeacherId = 3, CourseId = 1 },
                new Subject{Name = "Python", TeacherId = 1, CourseId = 2 },
                new Subject{Name = "Django", TeacherId = 1, CourseId = 2 },
                new Subject{Name = "Angular", TeacherId = 2, CourseId = 2 },
           };
            subjects.ForEach(c => context.Subjects.Add(c));
            context.SaveChanges();

            //Seed enrollments
            var enrollments = new List<Enrollment>
           {
                new Enrollment{Grade = 100, StudentId = 1, SubjectId = 1},
                new Enrollment{Grade = 40, StudentId = 1, SubjectId = 2},
                new Enrollment{Grade = 80, StudentId = 1, SubjectId = 3},
                new Enrollment{Grade = 0, StudentId = 2, SubjectId = 5},
                new Enrollment{Grade = 30, StudentId = 2, SubjectId = 6},
                new Enrollment{StudentId = 3, SubjectId = 5},
                new Enrollment{Grade = 70, StudentId = 4, SubjectId = 3},
                new Enrollment{Grade = 100, StudentId = 4, SubjectId = 4},
           };
            enrollments.ForEach(c => context.Enrollments.Add(c));
            context.SaveChanges();

        }
    }
}

