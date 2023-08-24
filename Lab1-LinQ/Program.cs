using System;

namespace Lab1_LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeList eManagement = new EmployeeList();
            eManagement.list.Display();

            Console.WriteLine("Enter a:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter b:");
            double b = Convert.ToDouble(Console.ReadLine());
            eManagement.FindBySalary(a, b).Display();
            //int ID = Convert.ToInt32(Console.ReadLine());
            //eManagement.FindByPositon("Developer").Display();

        }
    }
}
