using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallinnUniversity.Models;

namespace TallinnUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Haldja",LastName="Tooming",EnrollmentDate=DateTime.Parse("2007-09-01")},
            new Student{FirstMidName="Leedu",LastName="Antero",EnrollmentDate=DateTime.Parse("2006-09-01")},
            new Student{FirstMidName="Artur",LastName="Anni",EnrollmentDate=DateTime.Parse("2006-09-01")},
            new Student{FirstMidName="Frode",LastName="Ester",EnrollmentDate=DateTime.Parse("2007-09-01")},
            new Student{FirstMidName="Jan",LastName="Parve",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Jaak",LastName="Valge",EnrollmentDate=DateTime.Parse("2006-09-01")},
            new Student{FirstMidName="Laura",LastName="Oja",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Brenda",LastName="Jaup",EnrollmentDate=DateTime.Parse("2006-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
           {
                new Instructor { FirstMidName = "Sirje",     LastName = "Tekko",
                    HireDate = DateTime.Parse("1999-03-11") },
                new Instructor { FirstMidName = "Merike",    LastName = "Saar",
                    HireDate = DateTime.Parse("2004-07-06") },
                new Instructor { FirstMidName = "Kerli",   LastName = "Jarve",
                    HireDate = DateTime.Parse("1990-07-01") },
                new Instructor { FirstMidName = "Anne", LastName = "Kuusmaa",
                    HireDate = DateTime.Parse("2003-01-15") },
                new Instructor { FirstMidName = "Bruno",   LastName = "Nopponen",
                    HireDate = DateTime.Parse("2004-03-12") }
           };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Languages",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Saar").ID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Kuusmaa").ID },
                new Department { Name = "Sciences", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Tekko").ID },
                new Department { Name = "Sports",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructors.Single( i => i.LastName == "Nopponen").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();          

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3, DepartmentID = departments.Single( s => s.Name == "Sciences").DepartmentID},
            new Course{CourseID=4022,Title="Biology",Credits=3, DepartmentID = departments.Single( s => s.Name == "Sciences").DepartmentID},
            new Course{CourseID=4041,Title="Swimming",Credits=3, DepartmentID = departments.Single( s => s.Name == "Sports").DepartmentID},
            new Course{CourseID=1045,Title="Athletics",Credits=4, DepartmentID = departments.Single( s => s.Name == "Sports").DepartmentID},
            new Course{CourseID=3141,Title="Math",Credits=4, DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID},
            new Course{CourseID=2021,Title="English",Credits=3, DepartmentID = departments.Single( s => s.Name == "Languages").DepartmentID},
            new Course{CourseID=2042,Title="Estonian",Credits=4, DepartmentID = departments.Single( s => s.Name == "Languages").DepartmentID}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();


            var officeAssignments = new OfficeAssignment[]
           {
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Tekko").ID,
                    Location = "Sarapuu 17" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Jarve").ID,
                    Location = "Pihlaka 27" },
                new OfficeAssignment {
                    InstructorID = instructors.Single( i => i.LastName == "Kuusmaa").ID,
                    Location = "Toomepuu 304" },
           };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();


            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Tekko").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Biology" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Tekko").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Swimming" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Nopponen").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Estonian" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Saar").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "English" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Saar").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Math" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kuusmaa").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Athletics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Nopponen").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Athletics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Jarve").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Tooming").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.B
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Tooming").ID,
                    CourseID = courses.Single(c => c.Title == "Swimming" ).CourseID,
                    Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Tooming").ID,
                    CourseID = courses.Single(c => c.Title == "English" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Parve").ID,
                    CourseID = courses.Single(c => c.Title == "Estonian" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Parve").ID,
                    CourseID = courses.Single(c => c.Title == "Athletics" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Parve").ID,
                    CourseID = courses.Single(c => c.Title == "Biology" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Oja").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Oja").ID,
                    CourseID = courses.Single(c => c.Title == "Swimming").CourseID,
                    Grade = Grade.A
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Jaup").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Valge").ID,
                    CourseID = courses.Single(c => c.Title == "English").CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Valge").ID,
                    CourseID = courses.Single(c => c.Title == "Estonian").CourseID,
                    Grade = Grade.A
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
