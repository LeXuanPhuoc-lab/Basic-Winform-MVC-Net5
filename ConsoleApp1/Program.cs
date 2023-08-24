using System;
using System.Collections;
using System.Collections.Generic;
using Library;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student(1, "Phuoc");

            s.Name = "Hello con ga";
            Console.WriteLine(s.Name);

            s.Display();

            SEStudent s2 = new SEStudent(2, "Phuoc", "Spring Boot");
            //s2.Input();
            s2.Display();

            Student s3 = new SEStudent(3, "Phuoc", "Spring Boot");
            //s3.Display();

            // Override ToString()
            s3.ToString();

            // Override Equals
            Console.WriteLine(s3.Equals(new Student(3, "hello")));

            // Collections
            DemoArrayList();
            DemoList();
        }

        public static void DemoArrayList()
        {
            ArrayList list = new ArrayList();
            list.Add(2);
            list.Add("haha");
            list.Add(true);

            foreach (Object o in list)
            {
                Console.WriteLine(o);
            }
        }

        public static void DemoList()
        {
            List<int> list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            int count = 0;
            foreach (int i in list)
            {
                count += i;
                Console.WriteLine(count);
            }


            List<Student> list2 = new List<Student>();
            list2.Add(new Student(1, "haha"));
            list2.Add(new Student(2, "haha"));
            list2.Add(new Student(3, "haha"));
            list2.Add(new Student(4, "haha"));
            Console.WriteLine(list2.Contains(new Student(1, "haha")));
        }

    }
}
