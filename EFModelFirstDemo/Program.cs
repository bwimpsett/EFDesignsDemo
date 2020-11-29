using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new ModelFirstDemoDBContext())
            {
                Console.Write("Enter a name for a new Student: ");
                var firstName = Console.ReadLine();

                var student = new Student
                {
                    StudentID = 1,
                    FirstName = firstName
                };

                db.Students.Add(student);
                db.SaveChanges();

                var query = db.Students.OrderBy(x => x.FirstName);

                Console.WriteLine("All student in the database:");

                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
