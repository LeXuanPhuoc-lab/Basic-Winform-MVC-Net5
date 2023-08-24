using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class OnlineCourse : Course
    {
        public string Meet { get; set; }

        public OnlineCourse(int id, string title, DateTime startdate, string meet):base(id,title,startdate) // init father class
        {
            Meet = meet;
        }

        public OnlineCourse() {}

        public override void Input()
        {
            base.Input();
            // input meet
            Meet = Utils.GetString("[a-zA-Z]", "Input Online Course Meet");
        }

        public override string ToString()
        {
            return base.ToString() + $", Online Course meet: {Meet}";
        }

        public override void ReadDataFromLine(string line)// OC|Id|Title|StartDate|Meet
        {
            int lastIndex = line.LastIndexOf("|");
            base.ReadDataFromLine(line.Substring(0, lastIndex));
            Meet = line.Substring(lastIndex + 1);
        }
    }
}
