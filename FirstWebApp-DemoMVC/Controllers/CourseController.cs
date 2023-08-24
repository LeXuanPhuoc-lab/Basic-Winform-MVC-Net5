using FirstWebApp_DemoMVC.Models;
using FirstWebApp_DemoMVC.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FirstWebApp_DemoMVC.Logics;

namespace FirstWebApp_DemoMVC.Controllers
{
    public class CourseController : Controller
    {

        // public properties 
        [BindProperty (SupportsGet = true)]
        public String Gender { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult List(int Id)
        //{
        //    ViewData["title"] = "List of Courses";
        //    //List<Courses> list = CourseDAO.GetALLCoursesBySubjectId(sid);
        //    List<Course> courses = null;
        //    using (var context = new PRN211DemoADOContext()) {
        //        Subject currSubject = context.Subjects.FirstOrDefault(x => x.SubjectId == Id);
        //        // LinQ: First() -> not found -> throw exception
        //        //     : FirstOrDefault() -> not found -> null
        //        if(currSubject != null)
        //        {
        //            courses = context.Courses.Where(x => x.SubjectId == Id).ToList();
        //            ViewBag.CurrSubj = context.Subjects.First(x => x.SubjectId == Id);
        //        }
        //    }
        //    return View(courses);
        //}

        public IActionResult List(int Id)
        {
            ViewData["title"] = "List Subjects";

            // init value
            List<Course> courses = null;
            SubjectManager sm = new SubjectManager();
            CourseManager cm = new CourseManager();

            // Get subject by Id
            Subject currSubj = sm.GetSubjectById(Id);
            if(currSubj != null)
            {
                courses = cm.GetCoursesBySubjectId(Id);
                ViewBag.CurrSubj = currSubj;
            }
            else
            {
                courses = cm.GetAllCourses();
            }
            // Get all subject for menubar
            ViewBag.Subjects = sm.GetAllSubjects();

            return View(courses);
        }

        public IActionResult Detail(int Id)
        {
            ViewData["title"] = "Course Detail";

            // init value
            CourseManager cm = new CourseManager();
            SubjectManager sm = new SubjectManager();
            InstructorManager im = new InstructorManager();
            StudentCoureManager scm = new StudentCoureManager();
            CourseScheduleManager csm = new CourseScheduleManager();

            Course course = cm.GetCourseById(Id);
            if(course != null)
            {
                course.Subject = sm.GetSubjectById(Convert.ToInt32(course.SubjectId));
                course.Instructor = im.GetInstructorById(Convert.ToInt32(course.InstructorId));

                // get all students in course
                ViewBag.CourseSchedules
                    = csm.GetAllCourseScheduleByCourseId(course.CourseId);
            }
            return View(course);
        }

        public IActionResult ScheduleDetail(int Id)
        {
            RollCallBookManager rcbm = new RollCallBookManager();
            List<RollCallBook> list 
                = rcbm.GetRollCallBooksByTeachingDateId(Id);
            return View(list);
        }

        public IActionResult Edit(int Id)
        {
            ViewData["title"] = "Edit Course";

            // init value
            CourseManager cm = new CourseManager();
            InstructorManager im = new InstructorManager();
                
            Course course = cm.GetCourseById(Id);
            if (course != null)
            {
                course.Instructor = im.GetInstructorById(Convert.ToInt32(course.InstructorId));
                ViewBag.Subjects = (new SubjectManager()).GetAllSubjects();
                ViewBag.Instructors = (new InstructorManager()).GetAllInstructors();
            }
            return View(course);
        }

        public IActionResult Add() {
            ViewData["title"] = "Add Course";

            // init value
            SubjectManager sm = new SubjectManager();
            InstructorManager im = new InstructorManager();

            // Get data
            List<Subject> subjects = sm.GetAllSubjects();
            List<Instructor> instructors = im.GetAllInstructors();

            // Set data
            ViewBag.SubjectList = subjects;
            ViewBag.InstructorList = instructors;
            ViewData["title"] = "Add Course";
  
            return View();
        }        
        

        public IActionResult AddStudent(int Id)
        {
            ViewData["Title"] = "Add Student";
            ViewBag.CourseId = Id;
            List<Student> students = (new StudentManager()).GetStudents();
            ViewBag.StudentInCourse = (new StudentCoureManager()).GetAllStudentByCourseId(Id);
            return View(students);
        }

        public IActionResult DoAddStudent(List<int> StudentsId, int CourseId)
        {
            StudentCoureManager scm = new StudentCoureManager();
            CourseManager cm = new CourseManager();
            CourseScheduleManager csm = new CourseScheduleManager();
            RollCallBookManager rcbm = new RollCallBookManager();

            foreach (int s in StudentsId)
            {
                scm.AddStudent(s, CourseId);
                rcbm.AddStudent(s, CourseId);
            }

            // create course schedule with particular month
            csm.AddCourseScheduleById(CourseId, 1);
            // add all course students and course schedule to call book
            List<CourseSchedule> courseSchedules = csm.GetAllCourseScheduleByCourseId(CourseId);
            List<Student> Students = scm.GetAllStudentByCourseId(CourseId);
            foreach (CourseSchedule cs in courseSchedules)
            {
                foreach (Student s in Students)
                {
                    bool isExistInRCBook
                    = rcbm.CheckStudentCourseSchedule(s.StudentId, cs.TeachingScheduleId);
                    if (!isExistInRCBook)
                    {
                        RollCallBook rcb = new RollCallBook()
                        {
                            TeachingScheduleId = cs.TeachingScheduleId,
                            StudentId = s.StudentId,
                            IsAbsence = true
                        };
                        rcbm.AddRollCallBook(rcb);
                    }
                }   
            }

            var subjectId = (new SubjectManager()).GetSubjectByCourseId(CourseId).SubjectId;
            return Redirect("/Course/List/" + subjectId);
        }
        
        //public RedirectToActionResult DoEdit(int CourseId, String CourseCode, String CourseDescription)
        //{
        //    Course prevCourse = null;
        //    using(var context = new PRN211DemoADOContext())
        //    {
        //        prevCourse = context.Courses.First(x => x.CourseId == CourseId);

        //        if (prevCourse != null)
        //        {
        //            prevCourse.CourseCode = CourseCode;
        //            prevCourse.CourseDescription = CourseDescription;

        //            context.SaveChanges();
        //            return RedirectToAction(
        //                "Detail", 
        //                new 
        //                {
        //                    sid = prevCourse.SubjectId
        //                });
        //        }
        //    }
        //    return null;
        //}

        public IActionResult DoEdit(Course NewCourse)
        {
            CourseManager cm = new CourseManager();
            cm.UpdateCourse(NewCourse);
            return Redirect("/Course/List/" + NewCourse.SubjectId);
        }

        public IActionResult DoAdd(Course course)
        {
            ViewData["msg"] = "Add Sucess";

            // init value
            CourseManager cm = new CourseManager();
            CourseScheduleManager csm = new CourseScheduleManager();
            RollCallBookManager rcbm = new RollCallBookManager();
            StudentCoureManager scm = new StudentCoureManager();

            // add new course to Courses
            cm.AddCouse(course);

            return Redirect("/Course/List/" + course.SubjectId);
        }
        
        public IActionResult DoEditAttendence(RollCallBook rollCallBook)
        {
            RollCallBookManager rcb = new RollCallBookManager();
            rcb.UpdateRollCallBook(rollCallBook);
            return Redirect("/Course/ScheduleDetail/" + rollCallBook.TeachingScheduleId);
        }

        public IActionResult Delete(int Id)
        {
            // init value
            CourseManager cm = new CourseManager();
            SubjectManager im = new SubjectManager();
            // Get subject by course Id
            Subject subject = im.GetSubjectByCourseId(Id);
            // Delete Course
            cm.DeleteCourseById(Id);
            // Redirect to List Course page
            return Redirect("/Course/List/" + subject.SubjectId);
        }

        public String Show(String name, int age) {
            //String name = Request.Query["name"];
            //int age = Convert.ToInt32(Request.Query["age"]);
            return $"Name : {name}, Age: {age}";
        }

        public String ShowGender()
        {
            return $"Gender : {Gender}";
        }
    }
}
