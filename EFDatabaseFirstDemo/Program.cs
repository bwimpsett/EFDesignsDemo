using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new DatabaseFirstSchoolEntities())
            {
                var query = db.Students.OrderBy(s => s.FirstMidName);
                Console.WriteLine("All students.");
                foreach(var q in query)
                {
                    Console.WriteLine(string.Format("ID: {0}, First Name: {1}, Last Name: {2}, Enrollment Date: {3} ", 
                        q.Id, q.FirstMidName, q.LastName, q.EnrollmentDate));
                }
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
