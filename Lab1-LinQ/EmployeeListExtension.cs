using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_LinQ
{
    static class EmployeeListExtension
    {
        public static void Display(this List<Employee> list)
        {
            foreach(Employee e in list)
            {
                Console.WriteLine($"Id: {e.Id}, Name: {e.Name}, Base-Salary: {e.BaseSalary}, Positon: {e.Position}");
            }
        }
    }
}
