using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    class StudentCourseRoll
    {
        public int Id { get; set; }
        public String CourseCode { get; set; }
        public String StudentName { get; set; }
        //public bool IsAbsence { get; set; }
        public String Comment { get; set; }


        public StudentCourseRoll(int id, string courseCode, string studentName, string comment)
        {
            Id = id;
            CourseCode = courseCode;
            StudentName = studentName;
            Comment = comment;
        }
    }
}
