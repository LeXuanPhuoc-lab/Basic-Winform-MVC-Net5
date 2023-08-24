using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtensionsMethod_LinQ
{
    class DemoLinQ
    {
        List<Course> courses;

        public DemoLinQ()
        {
            this.courses = new List<Course>();
            courses.Add(new Course(1, "CSD", new DateTime(2012, 12, 12)));
            courses.Add(new Course(2, "PRJ", new DateTime(2012, 12, 12)));
            courses.Add(new Course(3, "PRO", new DateTime(2010, 12, 12)));
            courses.Add(new Course(4, "PRF", new DateTime(2008, 12, 12))); 
            courses.Add(new Course(5, "DBI", new DateTime(1998, 12, 12))); 
            courses.Add(new Course(6, "SWP", new DateTime(2012, 12, 12))); 
            courses.Add(new Course(7, "SWR", new DateTime(2023, 12, 12))); 
        }

        public List<Course> listAllCourse()
        {
            return courses;
        }

        public Course GetCourseByIDUsingMethod(int ID)
        {
            return courses.First(x => x.Id == ID);
        }
        public List<Course> GetCourseByTitleUsingMethod(string pattern)
        {
            return courses.Where(x => x.Title.Contains(pattern)).ToList();
        }

        public void GetCourseByDateUsingMethod(DateTime start, DateTime end)
        {
            var result = courses.Where(x => (x.Startdate >= start && x.Startdate <= end))
                                .Select(x => (x.Title, x.Startdate));
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Title} - {item.Startdate}");
            }

        }

        public Course GetCourseByIDUsingQuery(int ID)
        {
            return (from c in courses
                    where c.Id == ID
                    select c
                    ).First();
        }

        public List<Course> GetCourseByTitleUsingQuery(string pattern)
        {
            //return courses.Where(x => x.Title.Contains(pattern)).ToList();
            return (from c in courses
                    where c.Title.Contains(pattern)
                    select c
                    ).ToList();
        }

        public void GetCourseByDateUsingQuery(DateTime start, DateTime end)
        {
            //var result = courses.Where(x => (x.Startdate >= start && x.Startdate <= end))
            //                    .Select(x => (x.Title, x.Startdate));
            var result = (from c in courses
                          where c.Startdate >= start && c.Startdate <= end
                          select new
                          {
                              Title = c.Title,
                              Date = c.Startdate
                          }
                          ); // Anonymous Constructor

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Title} - {item.Date}");
            }

        }
    }
}
