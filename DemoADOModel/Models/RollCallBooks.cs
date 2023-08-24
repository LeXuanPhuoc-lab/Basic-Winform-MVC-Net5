using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    class RollCallBooks
    {
        public int RollCallBookId { get; set; }
        public int TeachingScheduleId { get; set; }
        public int StudentId { get; set; }
        public Boolean IsAbsence { get; set; }
        public String Comment { get; set; }

        public RollCallBooks() { }

        public RollCallBooks(int rollCallBookId, int teachingScheduleId, 
            int studentId, bool isAbsence,
            string comment)
        {
            RollCallBookId = rollCallBookId;
            TeachingScheduleId = teachingScheduleId;
            StudentId = studentId;
            IsAbsence = isAbsence;
            Comment = comment;
        }
    }
}
