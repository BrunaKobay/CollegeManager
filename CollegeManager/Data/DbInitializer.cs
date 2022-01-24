using CollegeManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CollegeManager.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {

            //Seed courses
            var courses = new List<Course>
            {
                new Course{Name = "Electrical Engineering"},
                new Course{Name = "Web Development"},
                new Course{Name = "Medicine"}
            };
            courses.ForEach(c => context.Coursers.Add(c));
            context.SaveChanges();

            //Seed teachers
            var teachers = new List<Teacher>
           {
                new Teacher{Name = "João Roberto", Birthday = DateTime.Parse("1994-03-23"), Salary = 230.12},
                new Teacher{Name = "Maria Antonieta", Birthday = DateTime.Parse("1984-09-13"), Salary = 130.52},
                new Teacher{Name = "Carlos Silva", Birthday = DateTime.Parse("2000-05-18"), Salary = 100.2},
                new Teacher{Name = "Ana Luiza", Birthday = DateTime.Parse("1990-12-25"), Salary = 200.72},
                new Teacher{Name = "Eduardo Monteiro", Birthday = DateTime.Parse("1980-12-25"), Salary = 250.72},
                new Teacher{Name = "Manoel Joaquin", Birthday = DateTime.Parse("1985-02-25"), Salary = 202.72},
           };
            teachers.ForEach(c => context.Teachers.Add(c));
            context.SaveChanges();

            //Seed students
            var students = new List<Student>
           {
                new Student{Name = "Mikey Mouse", Birthday = DateTime.Parse("1994-03-23"), RegistrationId = 2302},
                new Student{Name = "Peter Pan", Birthday = DateTime.Parse("1984-09-13"), RegistrationId = 2304},
                new Student{Name = "Snow White", Birthday = DateTime.Parse("2000-05-18"), RegistrationId = 2323},
                new Student{Name = "Ana Maria", Birthday = DateTime.Parse("1990-12-25"), RegistrationId = 2334},
                new Student{Name = "Moana Augusta", Birthday = DateTime.Parse("1995-02-25"), RegistrationId = 2335},
                new Student{Name = "Diego Lopes", Birthday = DateTime.Parse("2000-10-15"), RegistrationId = 2344},
                new Student{Name = "Roberto Dias", Birthday = DateTime.Parse("1996-02-05"), RegistrationId = 2347},
                new Student{Name = "Bruna Freitas", Birthday = DateTime.Parse("1993-05-18"), RegistrationId = 2147},
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
                new Subject{Name = "AngularJs Basics", TeacherId = 3, CourseId = 2 },
                new Subject{Name = "Anatomy", TeacherId = 5, CourseId = 3 },
                new Subject{Name = "Biochemistry", TeacherId = 6, CourseId = 3 },
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
                new Enrollment{Grade = 10, StudentId = 5, SubjectId = 4},
                new Enrollment{Grade = 60, StudentId = 6, SubjectId = 5},
                new Enrollment{Grade = 95, StudentId = 7, SubjectId = 7},
                new Enrollment{Grade = 95, StudentId = 8, SubjectId = 8},
                new Enrollment{Grade = 15, StudentId = 5, SubjectId = 9},
                new Enrollment{Grade = 65, StudentId = 6, SubjectId = 10},
                new Enrollment{Grade = 85, StudentId = 7, SubjectId = 9},
           };
            enrollments.ForEach(c => context.Enrollments.Add(c));
            context.SaveChanges();

        }
    }
}

