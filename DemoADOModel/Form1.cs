using DemoADOModel.DAL;
using DemoADOModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoADOModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = StudentDAO.GetAllStudent();
            //dataGridView1.DataSource = StudentDAO.GetStudentByID(2);
            //MessageBox.Show(StudentDAO.GetStudentByID(2).ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //TextBox textBox = (TextBox)sender;
            //String txtSearch = textBox.Text;
            //dataGridView2.DataSource = StudentDAO.SearchByName(txtSearch);
            //dataGridView2.Location = new Point(0, 100);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get comboBox event
            ComboBox comboBox = (ComboBox)sender;
            // get selected item
            String CourseCode = (String)comboBox.SelectedItem;
            // get all course scheduels of course selected
            List<CourseSchedules> courseSchedules 
                = CourseDAO.GetCourseSchedulesByCourseCode(CourseCode);
            // loop each course to get all teaching date of course
            comboBox2.Items.Clear();
            foreach (CourseSchedules cs in courseSchedules)
            {
                // add combox items
                comboBox2.Items.Add($"Id: {cs.TeachingScheduleId},  Date: {cs.TeachingDate}");
                //comboBox1.Items.Insert(i, courseSchedules[i].TeachingDate);
                //comboBox1.Items.Add(cs.TeachingDate);
            }
            // label config
            label3.Text = "Teaching Date";
            // comboBox config
            comboBox2.SelectedIndexChanged += new EventHandler(comboBox2_SelectedIndexChanged);
            comboBox2.Name = "DateComboBox";
            // add new comboBox, label to form1
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //comboBox1.Items = CourseDAO.GetAllCourse();
            List<Courses> courses = CourseDAO.GetAllCourse();
            foreach(Courses c in courses)
            {
                comboBox1.Items.Add(c.CourseCode);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set datagridview to default
            dataGridView1.Columns.Clear();

            // get comboBox event
            ComboBox comboBox = (ComboBox)sender;
            // get selected item
            String str = (String)comboBox.SelectedItem;
            int TeachingScheduleId = Convert.ToInt32(str.Substring(4, str.IndexOf(",") - 4));
            // get all students attendence
            DataTable dt 
                = RollCallBackDAO.GetRollCallBackByCourseScheduleId(TeachingScheduleId);

            // init list value
            List<StudentCourseRoll> list = new List<StudentCourseRoll>();
            List<bool> attendences = new List<bool>();
            foreach (DataRow dr in dt.Rows)
            {
                int Id = Convert.ToInt32(dr["Id"]);
                String CourseCode = dr["CourseCode"].ToString();
                String StudentName = dr["FullName"].ToString();
                bool CheckAttendence = 
                    Convert.ToInt32(dr["isAbsence"]) == 0 ? true : false;
                attendences.Add(CheckAttendence);
                String Comment = dr["Comment"].ToString();
                list.Add(new StudentCourseRoll(
                        Id,
                        CourseCode,
                        StudentName,
                        Comment
                        )
                    );
            }

            dataGridView1.DataSource = list;
            DataGridViewCheckBoxColumn PresentColumn = new DataGridViewCheckBoxColumn();
            PresentColumn.HeaderText = "Present";
            DataGridViewCheckBoxColumn AbsenceColumn = new DataGridViewCheckBoxColumn();
            AbsenceColumn.HeaderText = "Absence";

            dataGridView1.Columns.Insert(3, PresentColumn);
            dataGridView1.Columns.Insert(4, AbsenceColumn);

            for (int i= 0; i < dataGridView1.Rows.Count; ++i)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                if (attendences[i])
                {
                    row.Cells[3].Value = true;
                }
                else
                {
                    row.Cells[4].Value = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // init 
            List<StudentCourseRoll> list = new List<StudentCourseRoll>();
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                int Id = Convert.ToInt32(row.Cells[0].Value);
                bool IsPresent = Convert.ToBoolean(row.Cells[3].Value);
                bool IsAbsent = Convert.ToBoolean(row.Cells[4].Value);
                if (IsPresent && !IsAbsent)
                {
                    RollCallBackDAO.UpdateAttendencyById(Id, 0);
                }else if(!IsPresent && IsAbsent)
                {
                    RollCallBackDAO.UpdateAttendencyById(Id, 1);
                }
                else
                {
                    MessageBox.Show($"Attendence of '{row.Cells[2].Value}' must check present/absence only");
                    return;
                }
            }
            MessageBox.Show("Save Success");  
        }
    }
}
