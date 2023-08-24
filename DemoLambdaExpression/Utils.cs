using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;

namespace DemoLambdaExpression
{
    class Utils
    {
        public static int GetMenuChoice(String[] options)
        {
            int result;

            while (true)
            {

                // list all options
                for (int i = 0; i < options.Length; ++i)
                {
                    Console.WriteLine($"{i + 1}.{options[i]}");
                }
                Console.WriteLine($"Choose options 1 - {options.Length}:");

                try
                {
                    // input options choice
                    result = Convert.ToInt32(Console.ReadLine());
                    // check if valid input number
                    if(result > 0 || result <= options.Length)
                    {
                        return result;
                    }
                }catch(FormatException){
                    Console.WriteLine("Please input number!");
                }catch(OverflowException){
                    Console.WriteLine("Overflow number input");
                }
            }
        }

        public static int GetInt(int min, int max, String msg)
        {
            // init result value
            int result;

            // input number while validated
            while (true)
            {
                try
                {
                    // print out input message
                    Console.Write(msg + ":");
                    // input number
                    result = Convert.ToInt32(Console.ReadLine());
                    // check number match domain or not
                    if (result < min || result > max) // if number not match domain
                        // throw exception
                        throw new OverflowException($"Number must < {min} and > {max}");
                    // return if validated sucess
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please input number!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow number input!");
                }
            }
        }

        public static String GetString(String pattern, String msg)
        {
            // init value
            String result;
            Boolean isSucess = false;
            do
            {
                try
                {
                    Console.Write(msg + ": ");
                    result = Console.ReadLine();
                    Match m = Regex.Match(result, pattern, RegexOptions.IgnoreCase);
                    if (m.Success)
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Wrong format, please input again!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (isSucess);

            return null;
        }

        public static DateTime GetDateTime(String pattern, String msg)
        {
            DateTime result;
            while (true)
            {
                try
                {
                    Console.Write(msg + ": ");
                    result = DateTime.ParseExact(Console.ReadLine(), pattern, null);
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Input wrong format date, format date is '{pattern}'" );
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Not found any date format");
                }
            }
        }

        
    }
}
