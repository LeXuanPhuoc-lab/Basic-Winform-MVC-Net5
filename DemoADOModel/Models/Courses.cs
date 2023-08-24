using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    class Courses
    {
        public int CourseId { get; set; }
        public String CourseCode { get; set; }
        public String CourseDescription { get; set; }  
        public int SubjectId { get; set; }
        public int InstructorId { get; set; }
        public int TempId { get; set; }
        public int CampusId { get; set; }

        public Courses() { }

        public Courses(int courseId, string courseCode,
            string courseDescription, int subjectId,
            int instructorId, int tempId,
            int campusId)
        {
            CourseId = courseId;
            CourseCode = courseCode;
            CourseDescription = courseDescription;
            SubjectId = subjectId;
            InstructorId = instructorId;
            TempId = tempId;
            CampusId = campusId;
        }

        public Courses(int courseId, string courseCode,
            string courseDescription, int subjectId)
        {
            CourseId = courseId;
            CourseCode = courseCode;
            CourseDescription = courseDescription;
            SubjectId = subjectId;
        }
    }

}
