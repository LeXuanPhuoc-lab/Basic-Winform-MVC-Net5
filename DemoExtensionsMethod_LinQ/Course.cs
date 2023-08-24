using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoExtensionsMethod_LinQ
{
    class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime Startdate { get; set; }

        public Course(int id, string title, DateTime startdate)
        {
            Id = id;
            Title = title;
            Startdate = startdate;
        }

        public Course() { }

        // allow children override this method
        public virtual void Input()
        {
            // input id
            //Id = Utils.GetInt(1, 20000, "Input Course Id");
            //// input title
            //Title = Utils.GetString("[a-zA-Z_0-9]", "Input Course Title");
            //// input start date
            //Startdate = Utils.GetDateTime("dd/MM/yyyy", "Input Course Start-date");
        }

        public override string ToString()
        {
            return $"Course Id: {Id}, Title: {Title}, Start-date: {Startdate.ToString("dd/MM/yyyy")}";
        }

        public virtual void ReadDataFromLine(String line)// C|Id|Title|StartDate
        {
            String[] items = line.Split("|");

            try
            {
                Id = Convert.ToInt32(items[1].Trim());
                Title = items[2];
                Startdate = Convert.ToDateTime(items[3].Trim());
            }
            catch (FormatException fe)
            {
                // show exception and continue to readfile
                if (fe.ToString().Contains("ToInt32"))
                {
                    Console.WriteLine($"The error cause while processing: Id Format Exception. '{items[1]}'");
                    Id = -1;
                }
                else if (fe.ToString().Contains("ToDateTime"))
                {
                    Console.WriteLine($"The error cause while processing: Start-Date Format Exception. '{items[3]}'");
                }
            }
        }
    }
}
