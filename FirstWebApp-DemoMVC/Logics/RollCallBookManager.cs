using FirstWebApp_DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp_DemoMVC.Logics
{
    public class RollCallBookManager
    {
        public PRN211DemoADOContext context;
        public List<RollCallBook> GetRollCallBooksByTeachingDateId(int TeachingDateId)
        {
            using (context = new PRN211DemoADOContext())
            {
                List<RollCallBook> rcBooks
                    = context.RollCallBooks.Where(x => x.TeachingScheduleId == TeachingDateId).ToList();
                foreach (RollCallBook rcb in rcBooks)
                {
                    Student s
                        = context.Students.Where(x => x.StudentId == rcb.StudentId).FirstOrDefault();
                    rcb.Student = s;
                }
                return rcBooks;
            }
        }

        public void UpdateRollCallBook(RollCallBook rollCallBook)
        {
            if (rollCallBook == null) return;
            using (context = new PRN211DemoADOContext())
            {
                RollCallBook rcb
                    = context.RollCallBooks.Where(x => x.RollCallBookId == rollCallBook.RollCallBookId).FirstOrDefault();
                if (rcb != null)
                {
                    rcb.IsAbsence = rollCallBook.IsAbsence;
                    context.RollCallBooks.Update(rcb);
                    context.SaveChanges();
                }
            }
        }

        public void AddStudent(int StudentId, int CourseId)
        {
            using (context = new PRN211DemoADOContext())
            {
                var courseScheduels = context.CourseSchedules.Where(x => x.CourseId == CourseId).ToList();
                foreach (CourseSchedule cs in courseScheduels)
                {
                    RollCallBook isExist
                        = context.RollCallBooks.Where(x => x.StudentId == StudentId && x.TeachingScheduleId == cs.TeachingScheduleId).FirstOrDefault();
                    if (isExist == null)
                    {
                        RollCallBook rcb = new RollCallBook()
                        {
                            TeachingScheduleId = cs.TeachingScheduleId,
                            StudentId = StudentId,
                            IsAbsence = true
                        };
                        context.RollCallBooks.Add(rcb);
                        context.SaveChanges();
                    }
                }
            }
        }

        public bool CheckStudentCourseSchedule(int StudentId, int TeachingScheduleId)
        {
            using(context = new PRN211DemoADOContext())
            {
                RollCallBook isExist 
                    = context.RollCallBooks.Where(x => x.StudentId == StudentId && x.TeachingScheduleId == TeachingScheduleId).FirstOrDefault();
                if(isExist != null)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddRollCallBook(RollCallBook rollCallBook)
        {
            using (context = new PRN211DemoADOContext())
            {
                context.RollCallBooks.Add(rollCallBook);
                context.SaveChanges();
            }
        }
    }
}
