using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_LinQ
{
    class Employee
    { 
        public int Id { get; set; }
        public String Name { get; set; }
        public double BaseSalary { get; set; }
        public String Position { get; set; }
        public double GetSalary(SalaryCalculation delobj) {
            return delobj(BaseSalary, Position);
        }

        public void ReadDataFromLine(String line)
        {
            String[] items = line.Split("|");
            Id = Convert.ToInt32(items[0]);
            Name = items[1];
            BaseSalary = Convert.ToDouble(items[2]);
            Position = items[3];
        }

        public  double CalcSalaryByMonth(double salary, string position)
        {
            PositionSalary ps = new PositionSalary();
            return salary * ps.keyValues.GetValueOrDefault(position);
        }

        public  double CalcSalaryByYear(double salary, string position)
        {
            PositionSalary ps = new PositionSalary();
            return salary * ps.keyValues.GetValueOrDefault(position)*12;
        }

        public  double CalcSalaryByQuarter(double salary, string position)
        {
            PositionSalary ps = new PositionSalary();
            return salary * ps.keyValues.GetValueOrDefault(position) * 3;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Base-Salary: {BaseSalary}, Positon: {Position}";
        }
    }

    delegate double SalaryCalculation(double salary, String positon);
}
