using Alkemy_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_1.Data
{

        public static class DbInitializer
        {
            public static void Initialize(dBaseContext context)
            {
                context.Database.EnsureCreated();
                           
                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                var students = new student[]
                {
                    new student{FirstName="Carson",LastName="Alexander",dni=1234, Age=22, active=1},
                    new student{FirstName="Meredith",LastName="Alonso",dni=4321, Age=23, active=0},
                    new student{FirstName="Arturo",LastName="Anand",dni=5432, Age=24, active=1},
                    new student{FirstName="Gytis",LastName="Barzdukas",dni=2345, Age=25, active=1},
                    new student{FirstName="Yan",LastName="Li",dni=6667, Age=26, active=0},
                    new student{FirstName="Peggy",LastName="Justice",dni=9990, Age=27, active=1},
                    new student{FirstName="Laura",LastName="Norman",dni=2222, Age=28, active=1},
                    new student{FirstName="Nino",LastName="Olivetto",dni=1441, Age=29, active=1}
                };
                foreach (student s in students)
                {
                    context.Students.Add(s);
                }
                context.SaveChanges();

                var Professor_ = new professor[]
                {
                        new professor{FirstName="Joseph",LastName="Oreilly",dni=5674, Age=62, active=1},
                        new professor{FirstName="Margaret",LastName="Stevens",dni=7392, Age=51, active=0},
                        new professor{FirstName="Jason",LastName="Bourne",dni=7859, Age=49, active=1},
                        new professor{FirstName="Anthony",LastName="Hopkins",dni=1249, Age=38, active=1},
                        new professor{FirstName="Kim",LastName="Young",dni=6382, Age=71, active=0},
                        new professor{FirstName="Jhonatan",LastName="Puertolas",dni=2099, Age=57, active=1},
                        new professor{FirstName="Esteban",LastName="Laundry",dni=6768, Age=36, active=1},
                        new professor{FirstName="Joaquim",LastName="Ronaldo",dni=4114, Age=29, active=1}
                };

                foreach (professor s in Professor_)
                {
                    context.Professors.Add(s);
                }
                context.SaveChanges();


                var MUser = new Login[]
                 {
                       new Login{master_user="Robert Wright",pass_="MASTERS1000"}
                };

                foreach (Login L in MUser)
                {
                    context.Log.Add(L);
                }
                context.SaveChanges();


            var courses = new course[]
             {
                    new course{courseId=1050,Title="Chemistry",Credits=3, maximum_quantity_students=28, professorId=3},
                    new course{courseId=4022,Title="Microeconomics",Credits=3, maximum_quantity_students=28, professorId=3},
                    new course{courseId=4041,Title="Macroeconomics",Credits=3, maximum_quantity_students=29, professorId=1},
                    new course{courseId=1045,Title="Calculus",Credits=4, maximum_quantity_students=27, professorId=2},
                    new course{courseId=3141,Title="Trigonometry",Credits=4, maximum_quantity_students=25, professorId=4},
                    new course{courseId=2021,Title="Composition",Credits=3, maximum_quantity_students=31, professorId=1},
                    new course{courseId=2042,Title="Literature",Credits=4, maximum_quantity_students=33, professorId=5 
        }
            };
            foreach (course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var inscriptions = new inscription[]
                {
                    new inscription{studentId=1,courseId=1050},
                    new inscription{studentId=1,courseId=4022},
                    new inscription{studentId=1,courseId=4041},
                    new inscription{studentId=2,courseId=1045},
                    new inscription{studentId=2,courseId=3141},
                    new inscription{studentId=2,courseId=2021},
                    new inscription{studentId=3,courseId=1050},
                    new inscription{studentId=4,courseId=1050},
                    new inscription{studentId=4,courseId=4022},
                    new inscription{studentId=5,courseId=4041},
                    new inscription{studentId=6,courseId=1045},
                    new inscription{studentId=7,courseId=3141}
                };

            foreach (inscription e in inscriptions)
            {
                context.Inscriptions.Add(e);
            }
            context.SaveChanges();

        }
    }
   }

