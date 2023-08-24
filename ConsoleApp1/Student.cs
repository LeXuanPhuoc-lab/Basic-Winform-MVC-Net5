using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        //private field

        //int id;
        //string name;

        // property

        //public int Id
        //{
        //    get{ return this.id; }
        //    set
        //    {
        //        if (id > 0)
        //        {
        //            id = value;
        //        }
        //        else id = 0;
        //    }
        //}

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        // short cut for declare field + get/set, and fields still private
        public string Name { get; set; }
        public int Id { get; set; }

        public Student()
        {
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // virtual -> give childred permission on override this method
        public virtual void Display()
        {
            //Console.WriteLine("Student: Id: " + Id + ", Name: " + Name);
            Console.WriteLine($"Student: Id: {Id}, Name: {Name}");
            //Console.WriteLine(String.Format("Student: Id:{0}, Name:{1}", Id, Name));
        }

        public void Input()
        {
            Console.WriteLine("Input Id: ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input Name: ");
            Name = Console.ReadLine();
        }

        public override string ToString()
        {
            return $"Student: Id: {Id}, Name: {Name}";
        }

        public override bool Equals(object obj)
        {
            return Id == ((Student)obj).Id;
        }
    }

    // : <-> "extends"
    class SEStudent : Student 
    {
        public SEStudent()
        {
        }

        public string Skill { get; set; }

        // father class : base <-> father's constructor
        public SEStudent(int id, string name, string skill) : base(id, name) // call create father's class
        {
            Skill = skill;
        }


        //public void Display()
        //{
        //    // call father's display method
        //    base.Display();
        //    // print out 
        //    Console.WriteLine($"Skill : {Skill}");
        //}

        public override void Display()
        {
            // call father's display method
            base.Display();
            // print out 
            Console.WriteLine($"Skill : {Skill}");
        }

        public void Input()
        {
            // call father's input method
            base.Input();
            // statement of children's input method
            Console.WriteLine("Input Skill: ");
            Skill = Console.ReadLine();
        }

        public override string ToString()
        {
            return base.ToString() + $"Skill : {Skill}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
