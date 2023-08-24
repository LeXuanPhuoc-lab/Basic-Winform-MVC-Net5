using System;
using System.Collections.Generic;

namespace DemoExtensionsMethod_LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoUsingListExtension();
            //DemoUsingCourseExtension();
            DemoUsingLinQ();
        }

        public static void DemoUsingListExtension()
        {
            List<Course> list = new List<Course>();
            list.Add(new Course(1, "CSD", new DateTime(1212,12,12)));
            //list.Add(new Course(2, "PRJ", new DateTime(1212, 12, 12)));
            //list.Add(new Course(3, "PRO", new DateTime(1212, 12, 12)));
            //list.Add(new Course(4, "PRF", new DateTime(1212, 12, 12)));

            list.Display();
        }

        public static void DemoUsingCourseExtension()
        {
            Course course = new Course(1, "CSD", new DateTime(1212, 12, 12));
            course.Display(3);
        }

        public static void DemoUsingLinQ()
        {
            DemoLinQ demoLinQ = new DemoLinQ();

            // Demo Using LinQ by Method
            Console.WriteLine("Demo LinQ Method");
            demoLinQ.GetCourseByIDUsingMethod(3).Display();

            demoLinQ.GetCourseByTitleUsingMethod("P").Display();

            demoLinQ.GetCourseByDateUsingMethod(new DateTime(2010, 1, 1), new DateTime(2022, 1, 1));

            // Demo Using LinQ by Query
            Console.WriteLine("Demo LinQ Query");
            demoLinQ.GetCourseByIDUsingQuery(3).Display();

            demoLinQ.GetCourseByTitleUsingQuery("P").Display();

            demoLinQ.GetCourseByDateUsingQuery(new DateTime(2010, 1, 1), new DateTime(2022, 1, 1));
        }
    }
}
