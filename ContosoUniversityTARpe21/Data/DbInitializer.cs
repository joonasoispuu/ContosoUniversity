using ContosoUniversityTARpe21.Models;

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
                new Student() {FirstMidName="Kaarel-Martin",LastName="Noole",EnrollmentDate=DateTime.Now},
                new Student() {FirstMidName="Palmi",LastName="Lahe",EnrollmentDate=DateTime.Parse("2021-09-01")},
                new Student() {FirstMidName="Kommi",LastName="Onu",EnrollmentDate=DateTime.Parse("2021-09-01")},
                new Student() {FirstMidName="Risto",LastName="Koort",EnrollmentDate=DateTime.Parse("2021-09-01")},
                new Student() {FirstMidName="Kregor",LastName="Latt",EnrollmentDate=DateTime.Parse("2021-09-01")},
                new Student() {FirstMidName="Joonas",LastName="Õispuu",EnrollmentDate=DateTime.Parse("2021-09-01")}
            };
            //context.Students.AddRange(students);
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course() {CourseID=1050,Title="Programmeerimine",Credits=160},
                new Course() {CourseID=6900,Title="Keemia",Credits=160},
                new Course() {CourseID=1420,Title="Matemaatika",Credits=160},
                new Course() {CourseID=6666,Title="Testimine",Credits=160},
                new Course() {CourseID=1234,Title="Riigikaitse",Credits=160}
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[] 
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=6900,Grade=Grade.B},
                new Enrollment{StudentID=1,CourseID=1420,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=2,CourseID=1050,Grade=Grade.C},
                new Enrollment{StudentID=2,CourseID=6900,Grade=Grade.D},
                new Enrollment{StudentID=3,CourseID=1420,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=6900,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=1420,Grade=Grade.A},
                new Enrollment{StudentID=4,CourseID=1050,Grade=Grade.D},
                new Enrollment{StudentID=5,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=5,CourseID=6900,Grade=Grade.A},
                new Enrollment{StudentID=5,CourseID=1420,Grade=Grade.F},
            }; 
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();


        }
    }
}
