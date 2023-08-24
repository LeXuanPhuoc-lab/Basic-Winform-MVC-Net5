using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class CourseCompare : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            if (x.Id == 0 || y.Id == 0)
            {
                if (x.Title == null || y.Title == null)
                {
                    return x.Startdate.CompareTo(y.Startdate);
                }
                else
                {
                    return x.Title.CompareTo(y.Title);
                }
            }
            else
            {
                return x.Id.CompareTo(y.Id);
            }
        }
    }

    class IdComperer : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            return x.Id.CompareTo(y.Id);
        }
    }

    class TitleComperer : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            return x.Title.CompareTo(y.Title);
        }
    }

    class StartDateComperer : IComparer<Course>
    {
        public int Compare(Course x, Course y)
        {
            return x.Startdate.CompareTo(y.Startdate);
        }
    }
}
