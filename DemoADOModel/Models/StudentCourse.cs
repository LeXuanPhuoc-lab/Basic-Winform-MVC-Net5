using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    class StudentCourse
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public StudentCourse() { }

        public StudentCourse(int courseId, int studentId)
        {
            CourseId = courseId;
            StudentId = studentId;
        }
    }
}
