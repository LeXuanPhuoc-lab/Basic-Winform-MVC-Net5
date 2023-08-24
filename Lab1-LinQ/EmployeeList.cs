using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_LinQ
{
    class EmployeeList
    {
        public static String filename = "Employee.txt";

        public List<Employee> list;

        public EmployeeList() {
            list = new List<Employee>();
            ReadFromFile(filename);
        }

        public EmployeeList(List<Employee> list)
        {
            this.list = list;
        }

        public Employee FindByID(int ID)
        {
            return (from e in list
                    where e.Id == ID
                    select e
                    ).First();
        }

        public List<Employee> FindByName(String name)
        {
            return (from e in list
                    where e.Name.Contains(name.ToLower()) || e.Name.Contains(name.ToUpper())
                    select e
                    ).ToList();
        }

        public List<Employee> FindByPositon(String position)
        {
            return (from e in list
                    where e.Position == position
                    select e
                    ).ToList();
        }

        public List<Employee> FindBySalary(double a, double b)
        {
            return (from e in list
                    where e.GetSalary(e.CalcSalaryByMonth) >= a 
                    && e.GetSalary(e.CalcSalaryByMonth) <= b
                    select e
                    ).ToList();
        }

        public void ReadFromFile(string filename)
        {
            try
            {
                using(StreamReader sr = File.OpenText(filename))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Employee e = new Employee();
                        e.ReadDataFromLine(line);
                        list.Add(e);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                GenerateFile(filename);
                ReadFromFile(filename);
            }
        }

        public void WriteFile(String filename)
        {
            try
            {
                using(StreamWriter sw = File.CreateText(filename))
                {
                    foreach (Employee e in list)
                    {
                        sw.WriteLine($"{e.Id}|{e.Name}|{e.BaseSalary}|{e.Position}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void GenerateFile(String filename)
        {
            // get output directory path
            String path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            // access directory
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists) { // if directory exist
                // get all files in directory
                FileInfo[] files = di.GetFiles();
                foreach(FileInfo f in files)// check each file
                {
                    if(f.Name == filename)// if filename already exist
                    {
                        return; // stop 
                    }
                    else // generate new file in directory
                    {
                        File.WriteAllText(Path.Combine(path,filename), "");
                    }
                }
            }
        }


    }
}
