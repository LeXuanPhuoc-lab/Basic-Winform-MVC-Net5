using System;

namespace Library
{
    class Program
    {
        private static int unicode;

        static void Main(string[] args)
        {
            String test = "a";
            foreach(char c in test)
            {
                int unicode = c;
                Console.WriteLine(unicode);
            }
        }
    }
}
