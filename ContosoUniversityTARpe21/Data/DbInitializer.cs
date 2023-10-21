using ContoseUniversity.Data;
using ContosoUniversityTARpe21.Models;
using System;
using System.Linq;

namespace ContosoUniversityTARpe21.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Kaarel-Martin", LastName = "Noole", EnrollmentDate = DateTime.Now },
                new Student { FirstMidName = "Palmi", LastName = "Lahe", EnrollmentDate = DateTime.Parse("2021-09-01") },
                new Student { FirstMidName = "Kommi", LastName = "Onu", EnrollmentDate = DateTime.Parse("2021-09-01") },
                new Student { FirstMidName = "Risto", LastName = "Koort", EnrollmentDate = DateTime.Parse("2021-09-01") },
                new Student { FirstMidName = "Kregor", LastName = "Latt", EnrollmentDate = DateTime.Parse("2021-09-01") },
                new Student { FirstMidName = "Joonas", LastName = "Õispuu", EnrollmentDate = DateTime.Parse("2021-09-01") }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Bob", LastName = "Boberson", HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Greg", LastName = "Men", HireDate = DateTime.Parse("1992-01-01") },
                new Instructor { FirstMidName = "Man", LastName = "Woman", HireDate = DateTime.Parse("1993-02-05") },
            };

            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Infotechnology", Budget = 350000, StartDate = DateTime.Parse("2001-09-01"), InstructorID = instructors.Single(i => i.LastName == "Boberson").ID },
                new Department { Name = "English", Budget = 350000, StartDate = DateTime.Parse("2006-09-01"), InstructorID = instructors.Single(i => i.LastName == "Men").ID },
                new Department { Name = "Mathematics", Budget = 350000, StartDate = DateTime.Parse("2002-09-01"), InstructorID = instructors.Single(i => i.LastName == "Woman").ID },
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course { DepartmentID = 1, Title = "Programming", Credits = 3 },
                new Course { DepartmentID = 3, Title = "Microeconomics", Credits = 3 },
                new Course { DepartmentID = 3, Title = "Macroeconomics", Credits = 3 },
                new Course { DepartmentID = 3, Title = "Calculus", Credits = 4 },
                new Course { DepartmentID = 3, Title = "Trigonometry", Credits = 4 },
                new Course { DepartmentID = 3, Title = "Composition", Credits = 3 },
                new Course { DepartmentID = 2, Title = "Literature", Credits = 4 }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Boberson").ID, Location = "A236" },
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Men").ID, Location = "A349" },
                new OfficeAssignment { InstructorID = instructors.Single(i => i.LastName == "Woman").ID, Location = "A66" },
            };

            context.OfficeAssignments.AddRange(officeAssignments);
            context.SaveChanges();

            var random = new Random();
            var courseIDs = courses.Select(c => c.CourseID).ToList();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment { CourseID = 1, InstructorID = instructors.Single(i => i.LastName == "Woman").ID },
                new CourseAssignment { CourseID = 2, InstructorID = instructors.Single(i => i.LastName == "Woman").ID },
                new CourseAssignment { CourseID = 3, InstructorID = instructors.Single(i => i.LastName == "Men").ID },
                new CourseAssignment { CourseID = 4, InstructorID = instructors.Single(i => i.LastName == "Men").ID },
                new CourseAssignment { CourseID = 5, InstructorID = instructors.Single(i => i.LastName == "Boberson").ID },
                new CourseAssignment { CourseID = 6, InstructorID = instructors.Single(i => i.LastName == "Boberson").ID },
            };

            context.CourseAssignments.AddRange(courseInstructors);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=2,Grade=Grade.B},
                new Enrollment{StudentID=1,CourseID=3,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=2,Grade=Grade.C},
                new Enrollment{StudentID=2,CourseID=2,Grade=Grade.D},
                new Enrollment{StudentID=3,CourseID=3,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=2,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=3,Grade=Grade.A},
                new Enrollment{StudentID=4,CourseID=4,Grade=Grade.C},
                new Enrollment{StudentID=4,CourseID=4,Grade=Grade.A},
                new Enrollment{StudentID=4,CourseID=5,Grade=Grade.A},
                new Enrollment{StudentID=5,CourseID=5,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=5,Grade=Grade.A},
                new Enrollment{StudentID=6,CourseID=6,Grade=Grade.B},
                new Enrollment{StudentID=6,CourseID=7,Grade=Grade.B},
                new Enrollment{StudentID=6,CourseID=7,Grade=Grade.A},
                new Enrollment{StudentID=6,CourseID=7,Grade=Grade.A}
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDatabase = context.Enrollments.Where(
                    s => s.StudentID == e.StudentID &&
                    s.CourseID == e.CourseID).SingleOrDefault();

                if (enrollmentInDatabase == null)
                {
                    context.Enrollments.Add(e);
                }
            }

            context.SaveChanges();
        }
    }
}
