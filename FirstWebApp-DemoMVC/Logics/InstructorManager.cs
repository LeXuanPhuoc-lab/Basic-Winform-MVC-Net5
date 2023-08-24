using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.Logics
{
    public class InstructorManager
    {
        public static PRN211DemoADOContext context = new PRN211DemoADOContext();
        public List<Instructor> GetAllInstructors()
        {
            return context.Instructors.ToList();
        }

        public Instructor GetInstructorById(int InstructorId)
        {
            return context.Instructors.Where(x => x.InstructorId == InstructorId).FirstOrDefault();
        }
    }
}
