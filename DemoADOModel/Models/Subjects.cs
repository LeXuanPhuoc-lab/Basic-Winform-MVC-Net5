using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    class Subjects
    {
        public int SubjectId { get; set; }
        public String SubjectName { get; set; }

        public Subjects() { }

        public Subjects(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
    }
}
