using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork
{
    class CourseList
    {
        //public static String path = "C:\\Users\\USER\\Desktop\\DocnetDemo";
        public static string filename = "Course.txt";

        List<Course> list;

        public CourseList()
        {
            list = readFromFile();
            if (list == null) { 
                list = new List<Course>();
            }
        }

        public List<Course> List
        {
            get { return list; }
            set { list = value; }
        }

        private List<Course> readFromFile()
        {
            // init value
            List<Course> tempList = new List<Course>();
            try
            {
                // create directory
                //FileUtils.CreateDirectory(path);
                // create file if not exist
                //FileUtils.CreateFileInDirectory(path, filename);
                //sr = new StreamReader(path + "\\" + filename);
                using (StreamReader sr = new StreamReader(filename))
                {
                    int lineIndex = 0;
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // count line index
                        ++lineIndex;

                        // throw exception <Wrong format>
                        // firt char is C/OC
                        if (line[0] != 'C' && line[0] != 'O')
                            Console.WriteLine($"At Line {lineIndex} in {filename}. The error cause while processing: {line}. 'First character of data must be C/OC'");
                        // fields size not match
                        else if (line.Split("|").Length < 4)
                            Console.WriteLine($"At Line {lineIndex} in {filename}. The error cause while processing: {line}. 'Wrong total fields size format'");
                        else
                        {
                            // init course
                            Course course;

                            // get course fields from file
                            if (line[0] == 'C')
                                course = new Course();
                            else
                                course = new OnlineCourse();

                            course.ReadDataFromLine(line);

                            if(course.Id != -1 && !course.Startdate.Equals(new DateTime(01,01,0001)))
                            {
                                tempList.Add(course);
                            }
                        }
                    }
                    // if not found any Course --> new List<Course>
                    if (tempList.Count < 0) { return null; }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {filename} Not Found!");

                Console.WriteLine($"Do you want to create file {filename} (Yes/No)");
                String getYesNo = Console.ReadLine().ToUpper();
                if (getYesNo.Equals("YES"))
                {
                    String dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    DirectoryInfo di = new DirectoryInfo(dir);
                    File.WriteAllText(Path.Combine(dir, filename), "");
                    Console.WriteLine($"Create File {filename} sucess!");
                }
            }
            return tempList;
        }

        public void WriteFile()
        {
            // init value
            StreamWriter sw = null;
            try
            {
                //sw = new StreamWriter(path + "\\" + filename);
                sw = new StreamWriter(filename);
                foreach (Course c in list)
                {
                    Boolean isOnlineCourse = c.GetType() == typeof(OnlineCourse) ? true : false;
                    String line;
                    if (isOnlineCourse)
                    {
                        line = $"O|{c.Id}|{c.Title}|{c.Startdate}|{((OnlineCourse)c).Meet}";
                    }
                    else
                    {
                        line = $"C|{c.Id}|{c.Title}|{c.Startdate}";
                    }
                    sw.WriteLine(line);
                }
                Console.WriteLine("Save File Sucess!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if(sw != null)
                {
                    sw.Close();
                }
            }
        }

        public void InputListOfCourse()
        {
            // init value
            Course course;
            int choice = 0;

            // options list
            String[] options = { "Course", "Online Course", "Return" };

            do
            {
                // input choice number
                choice = Utils.GetMenuChoice(options);

                // select options
                switch (choice)
                {
                    case 1:
                        // init new course
                        course = new Course();
                        // input course fields
                        course.Input();
                        // add new course to course list
                        list.Add(course);
                        break;
                    case 2:
                        // init new online course
                        course = new OnlineCourse();
                        // input online course
                        course.Input();
                        // add new online course to course list
                        list.Add(course);
                        break;
                }
            } while (choice < options.Length);
        }

        public void DisplayListOfCourse()
        {
            foreach (Course c in list)
            {
                Console.WriteLine(c);
            }
        }

        public void SearchListOfCourse()
        {
            String[] options = { 
                "Search by preference", 
                "Search by Id", 
                "Search by Title", 
                "Search by Start Date and End Date",
                "Return"};
           
            // init value
            int choice = 0;
            Boolean isFound = false;
            String searchKey = null;
            DateTime startDate, endDate;

            do
            {
                choice = Utils.GetMenuChoice(options);

                switch (choice)
                {
                    case 1:
                        searchKey = Utils.GetString("[a-zA-Z_0-9]", "Input Search");
                        Console.WriteLine("\nResult Search");
                        foreach (Course c in list)
                        {
                            Match m = Regex.Match(Convert.ToString(c.Id), searchKey);
                            Match m1 = Regex.Match(c.Title, searchKey);
                            Match m2 = Regex.Match(Convert.ToString(c.Startdate), searchKey);

                            if (m.Success || m1.Success || m2.Success)
                            {
                                isFound = true;
                                Console.WriteLine(c);
                            }
                        }

                        // print out msg if not found
                        if (!isFound)
                        {
                            Console.WriteLine("Not Found!");
                        }
                        break;
                    case 2:
                        searchKey = Utils.GetString("[a-zA-Z_0-9]", "Input Search");
                        Console.WriteLine("\nResult Search");
                        foreach (Course c in list)
                        {
                            if(c.Id == Convert.ToInt32(searchKey))
                            {
                                isFound = true;
                                Console.WriteLine(c);
                            }
                        }

                        // print out msg if not found
                        if (!isFound)
                        {
                            Console.WriteLine("Not Found!");
                        }
                        break;
                    case 3:
                        searchKey = Utils.GetString("[a-zA-Z_0-9]", "Input Search").ToUpper();
                        Console.WriteLine("\nResult Search");
                        foreach (Course c in list)
                        {
                            Match m = Regex.Match(c.Title.ToUpper(), searchKey);
                            if (m.Success)
                            {
                                isFound = true;
                                Console.WriteLine(c);
                            }
                        }

                        // print out msg if not found
                        if (!isFound)
                        {
                            Console.WriteLine("Not Found!");
                        }
                        break;
                    case 4:
                        startDate = Utils.GetDateTime("dd/MM/yyyy", "Input Start Date");
                        endDate = Utils.GetDateTime("dd/MM/yyyy", "Input End Date");
                        Console.WriteLine("\nResult Search");
                        foreach (Course c in list)
                        {
                            if(c.Startdate >= startDate && c.Startdate <= endDate)
                            {
                                isFound = true;
                                Console.WriteLine(c);
                            }
                        }

                        // print out msg if not found
                        if (!isFound)
                        {
                            Console.WriteLine("Not Found!");
                        }
                        break;
                }
            } while (choice < options.Length);
        }

        public void SortListOfCourse(IComparer<Course> comparer)
        {
           list.Sort(comparer);
        }


        // Comparision Delegate to Sort
        public int CompareById(Course x, Course y)
        {
            return x.Id.CompareTo(y.Id);
        }
        public int CompareByTitle(Course x, Course y)
        {
            return x.Title.CompareTo(y.Title);
        } 
        public int CompareByStartDate(Course x, Course y)
        {
            return x.Startdate.CompareTo(y.Startdate);
        }


        public void SortById()
        {
            list.Sort(CompareById);
        }

        public void SortByTitle()
        {
            list.Sort(CompareByTitle);
            // (x,y) => x.Title.CompareTo(y.Title);
        }

        public void SortByStartDate() {
            list.Sort(CompareByStartDate);
        }

    }
}
