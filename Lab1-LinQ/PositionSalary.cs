using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_LinQ
{
    class PositionSalary
    {
        public static String[] positions = {
            "Manager", 
            "Developer",
            "Tester",
            "Other" };

        public static int MANAGER_SALARY = 4;
        public static int DEVELOPER_SALARY = 3;
        public static int TESTER_SALARY = 2;
        public static int OTHER_SALARY = 1;


        public Dictionary<string, double> keyValues;

        public PositionSalary()
        {
            keyValues = new Dictionary<string, double>();
            keyValues.Add("Manager", MANAGER_SALARY) ;
            keyValues.Add("Developer", DEVELOPER_SALARY) ;
            keyValues.Add("Tester", TESTER_SALARY) ;
            keyValues.Add("Other", OTHER_SALARY) ;
        }

        public PositionSalary(Dictionary<string, double> keyValues)
        {
            this.keyValues = keyValues;
        }
    }
}
