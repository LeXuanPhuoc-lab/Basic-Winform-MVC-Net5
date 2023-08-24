using HomeWork;
using System;

namespace DemoDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //DemoBasicDelegate();

            //Calculate(10, 20, Add);  // determine which type of function be call

            //DemoMulticast(); 

            //DemoUsingComparision();  

            //DemoLambdaExpression();
        }

        public static int Add(int a, int b)
        {
            Console.WriteLine("Add Function");
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            Console.WriteLine("Sub Function");
            return a - b;
        }

        public static void Calculate(int a, int b, Calculation delobj)
        {
            delobj(a, b); // call method
        }

        public static void DemoBasicDelegate() 
        {
            Calculation delegateObj; // declare a variable instance of Calculation
            delegateObj = new Calculation(Add);
            Console.WriteLine("Output: " + delegateObj(5, 4));

            delegateObj = new Calculation(Sub);
            Console.WriteLine("Output: " + delegateObj(5,4));
        }

        public static void DemoMulticast()
        {
            Console.WriteLine("Demo Multicast");
            Calculation delegateobj = Add;
            delegateobj += Sub; // Add Sub Function to List of call functions
            delegateobj += Add; // Add Add Function to List of call fucntions
            Console.WriteLine("Output:" + delegateobj(5,4)); // Add(5,4), Sub(5,4)
                                                             // -> last function in list in return 
            Console.WriteLine("After remove");
            delegateobj -= Add; // Remove last Add Function in list
            delegateobj -= Add; // Remove last Add Function in list
            delegateobj -= Sub; // Now list only reference Sub, Remove Sub here --> NullReferenceException
            Console.WriteLine("Output:" + delegateobj(5,4)); // Add(5,4), Sub(5,4)
        }

        public static void DemoUsingComparision()
        {
            // Demo Comparision<T> Delegate
            CourseList cList = new CourseList();
            cList.SortByTitle();
            cList.DisplayListOfCourse();
        }

        public static void DemoLambdaExpression()
        {
            // Lambda Expression
            CourseList courseManagement = new CourseList();
            courseManagement.List.Sort(
                (x, y) => x.Title.CompareTo(y.Title)
                );
            courseManagement.DisplayListOfCourse();
        }
    }
}
