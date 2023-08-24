using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.Logics
{
    public class StudentCoureManager
    {
        public static PRN211DemoADOContext context = new PRN211DemoADOContext();
        public List<Student> GetAllStudentByCourseId(int CourseId)
        {
            // init 
            List<Student> list = null;
            // get all student id in courses
            var studentsId =  context.StudentCourses.Where(x => x.CourseId == CourseId).ToList();
            if (studentsId.Count > 0)
            {
                list = new List<Student>();
                foreach (StudentCourse sc in studentsId)
                {
                    // get student
                    Student s 
                        = context.Students.Where(x => x.StudentId == sc.StudentId).FirstOrDefault();
                    //var courseSchedules
                    //    = context.CourseSchedules.Where(x => x.CourseId == CourseId).ToList();
                    //// get student course schedule
                    //var rollCallBooks 
                    //    = context.RollCallBooks.Where(x => x.StudentId == s.StudentId).ToList();
                    list.Add(s);
                }
            }
            return list;
        }

        public void AddStudent(int StudentId, int CourseId)
        {
            var checkExist = context.StudentCourses.Where(x => x.StudentId == StudentId && x.CourseId == CourseId).FirstOrDefault();
            if (checkExist != null) return;
            StudentCourse sc = new StudentCourse { CourseId = CourseId, StudentId = StudentId };
            context.StudentCourses.Add(sc);
            context.SaveChanges();
        }
    }
}
