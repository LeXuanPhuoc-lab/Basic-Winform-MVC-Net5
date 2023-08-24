using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADOModel.Models
{
    class Student
    {
        public int Id { get; set; }
        public String RollNumber { get; set; }
        public String FirstName { get; set; }
        public String MidName { get; set; }
        public String LastName { get; set; }

        public Student(int id, string rollNumber,
            string firstName, string midName,
            string lastName)
        {
            Id = id;
            RollNumber = rollNumber;
            FirstName = firstName;
            MidName = midName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"Id = {Id}, RoleNumber = {RollNumber} ,Name= {FirstName} {MidName} {LastName}";
        }
    }
}
