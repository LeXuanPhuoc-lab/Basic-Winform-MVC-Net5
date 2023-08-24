using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLambdaExpression
{
    delegate double SalaryCalculation(double salary, String position);

    class Employee
    {
        public static String[] positions = { 
            "Manager", 
            "Developer",
            "Tester", 
            "HA",
            "Other"};

        public static int[] salaries = { 16,12,12,10,8 };


        public String Id { get; set; }
        public String Name { get; set; }
        public double Salary { get; set; }
        public String Position { get; set; }

        public Employee(String id, string name, double salary, string position)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Position = position;
        }

        public Employee() { }

        public Employee(string id)
        {
            Id = id;
        }

        public void InputEmployeeInfo()
        {
            Id = Utils.GetString("[a-zA-Z_0-9]", "Input Employee Id");
            Name = Utils.GetString("[a-zA-Z_0-9]", "Input Employee Name");
            Console.Write("Input Employee Salary($): ");
            Salary = Convert.ToDouble(Console.ReadLine());
            Position = GetPosition();
        }

        public String GetPosition()
        {
            int choice = Utils.GetMenuChoice(positions);

            switch (choice)
            {
                case 1:
                    return "Manager";
                case 2:
                    return "Developer";
                case 3:
                    return "Tester";
                case 4:
                    return "HA";
                case 5:
                    return "Other";
            }

            return null;
        }

        public void Display(SalaryCalculation delobj)
        {
            Console.WriteLine(delobj(Salary, Position));
        }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Employee)obj).Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
