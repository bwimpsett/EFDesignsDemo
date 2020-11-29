using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCodeFirstDemo.Models;

namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                Console.WriteLine("Add new students");

                var student = new Student
                {
                    FirstMidName = "Alain",
                    LastName = "Bomer",
                    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.Students.Add(student);
                var student1 = new Student 
                { 
                    FirstMidName = "Brian", 
                    LastName = "Wimpsett", 
                    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString()) 
                };
                context.Students.Add(student1);
                context.SaveChanges();

                var students = context.Students.OrderBy(x => x.FirstMidName).ToList();
                Console.WriteLine("Retrieve all Students from the database:");
                foreach(var std in students)
                {
                    string name = std.FirstMidName + " " + std.LastName;
                    Console.WriteLine(string.Format("Id: {0}, Name: {1}", std.ID, name));
                }
                context.Students.RemoveRange(context.Students);
                context.SaveChanges();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    

}
