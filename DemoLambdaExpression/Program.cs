using System;
using System.Collections.Generic;

namespace DemoLambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            String[] options = { "Add Employee", "Salary" };
            String[] salaryOptions = { 
                "Salary a Month",
                "Salary a Year",
                "Salary a Quarter"};
            int choice = 0;
            do
            {
                choice = Utils.GetMenuChoice(options);

                switch (choice)
                {
                    case 1:
                        Employee employee = new Employee();
                        employee.InputEmployeeInfo();
                        list.Add(employee);
                        break;
                    case 2:
                        String id = Utils.GetString("[a-zA-Z_0-9]", "Input Employee Id");
                        int index = list.IndexOf(new Employee(id));
                        Employee e = list[index];
                        int salaryChoice = 0;
                        do
                        {
                            salaryChoice = Utils.GetMenuChoice(salaryOptions);

                            switch (salaryChoice)
                            {
                                case 1:
                                    e.Display(
                                        (Salary, Position)
                                        => Salary * Employee.salaries[Array.IndexOf(Employee.positions, Position)]);
                                    break;
                                case 2:
                                    e.Display(
                                        (Salary, Position)
                                        => Salary * 12 * Employee.salaries[Array.IndexOf(Employee.positions, Position)]);
                                    break;
                                case 3:
                                    e.Display(
                                        (Salary, Position)
                                        => Salary * 3 * Employee.salaries[Array.IndexOf(Employee.positions, Position)]);
                                    break;
                            }
                        } while (salaryChoice < salaryOptions.Length);

                        break;
                }
            } while (choice < options.Length);
        }
    }
}
