using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.Logics
{
    public class StudentManager
    {
        public PRN211DemoADOContext context;

        public List<Student> GetStudents()
        {
            using(context = new PRN211DemoADOContext())
            {
                return context.Students.ToList();
            }
        }
    }
}
