using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.Logics
{
    public class SubjectManager
    {
        public static PRN211DemoADOContext context = new PRN211DemoADOContext();
        public Subject GetSubjectById(int SubjectId)
        {
            return context.Subjects.Where(x => x.SubjectId == SubjectId).FirstOrDefault();
        }

        public List<Subject> GetAllSubjects() {
            return context.Subjects.ToList();
        }

        public Subject GetSubjectByCourseId(int CourseId)
        {
            Course course = context.Courses.Where(x => x.CourseId == CourseId).FirstOrDefault();
            if (course == null) return null;
            return context.Subjects.Where(x => x.SubjectId == course.SubjectId).FirstOrDefault();
        }

    }
}
