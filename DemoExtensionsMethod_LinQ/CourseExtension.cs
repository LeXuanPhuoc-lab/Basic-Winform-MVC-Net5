using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtensionsMethod_LinQ
{
    static class CourseExtension
    {
        public static void Display(this Course course, int count = 1)
        {
            Console.WriteLine($"Course Info {count} times");
            for (int i = 0; i < count; i++) {
                Console.WriteLine(course);
            }
        }
    }
}
