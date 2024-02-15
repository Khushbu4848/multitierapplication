using part2projectmta.DAC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part2projectmta.GUI
{
    public partial class CourseAssignmentForm : Form
    {
        public CourseAssignmentForm()
        {
            InitializeComponent();
            addCoursesToDataList();
            addTeachersToDataList();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        private void addTeachersToDataList()
        {
            // select Teachers from database 
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var selectTeacher = from Teachers in context.Teachers select Teachers;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("TeacherID");
                    dt.Columns.Add("FirstName");
                    dt.Columns.Add("LastName");
                    dt.Columns.Add("Email");

                    foreach (var emp in selectTeacher)
                    {
                        dt.Rows.Add(emp.TeacherID, emp.FirstName, emp.LastName
                                    , emp.Email);
                    }

                    dataGridView1.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            private void label29_Click(object sender, EventArgs e)
        {

        }

        private void addCoursesToDataList()
        {
            // select Courses from database 
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var selectCourse = from Courses in context.Courses select Courses;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CourseNumber");
                    dt.Columns.Add("CourseTitle");
                    dt.Columns.Add("Duration");

                    foreach (var s in selectCourse)
                    {
                        dt.Rows.Add(s.CourseNumber, s.CourseTitle, s.Duration);

                    }

                    dataGridView2.DataSource = dt;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void buttonadd_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonadd_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                
                {
                    // add Teacher to database 
                    var TeacherToAdd = new Teacher();
                    TeacherToAdd.TeacherID = Int32.Parse(textboxtid.Text);
                    TeacherToAdd.FirstName = textBoxfn.Text;
                    TeacherToAdd.LastName = textboxln.Text;
                    TeacherToAdd.Email = textboxemail.Text;

                    context.Teachers.Add(TeacherToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Teacher Added Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersToDataList();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var TeacherToEdit = from Teachers
                                        in context.Teachers
                                        where Teachers.TeacherID.ToString() == textboxtid.Text
                                        select Teachers;

                    foreach (var Tcher in TeacherToEdit)
                    {
                        Tcher.FirstName = textBoxfn.Text;
                        Tcher.LastName = textboxln.Text;
                        Tcher.Email = (textboxemail.Text);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Teacher Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var teacherTodelete = from Teachers
                                          in context.Teachers
                                          where Teachers.TeacherID.ToString() == textboxtid.Text
                                          select Teachers;

                    foreach (var s in teacherTodelete)
                    {
                        context.Teachers.Remove(s);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Teacher Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeachersToDataList();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void buttoncadd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    // add Coueses to database 
                    var courseToAdd = new Cours();
                    courseToAdd.CourseNumber = textBoxcnum.Text;
                    courseToAdd.CourseTitle = textBoxCoursetitle.Text;
                    courseToAdd.Duration = Int32.Parse(textBoxduration.Text);

                    context.Courses.Add(courseToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Course Added Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCoursesToDataList();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttoncedit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var CourseToEdit = from Cours
                                        in context.Courses
                                       where Cours.CourseNumber.ToString() == textBoxcnum.Text
                                       select Cours;

                    foreach (var cedit in CourseToEdit)
                    {
                        cedit.CourseNumber = textBoxcnum.Text;
                        cedit.CourseTitle = textBoxCoursetitle.Text;
                        cedit.Duration = Int32.Parse(textBoxduration.Text);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCoursesToDataList();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttoncdelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var courseTodelete = from Cours
                                          in context.Courses
                                         where Cours.CourseNumber.ToString() == textboxtid.Text
                                         select Cours;

                    foreach (var cdelete in courseTodelete)
                    {
                        context.Courses.Remove(cdelete);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCoursesToDataList();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttoncsearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var TeacherToserach = from Teachers
                                          in context.Teachers
                                          where Teachers.TeacherID.ToString() == textBoxsearchid.Text
                                          select Teachers;

                    foreach (var Sch in TeacherToserach)
                    {
                        label19.Text = Sch.FirstName + " " + Sch.LastName + " ";
                        label4.Text = Sch.Email;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxctitle_TextChanged(object sender, EventArgs e)
        {

        }

        //private void PopulateCoursesGrid()
        //{
        //    using (var context = new TeacherCourseDBEntities())
        //    {



        //    var teacherCourse = context.CourseTeachers
        //        .Where(tc => tc.TeacherID == TeacherId)
        //        .Select(tc => new
        //        {
        //            CourseNumber = tc.Courses.CourseNumber,
        //            CourseTitle = tc.Course.CourseTitle,
        //            TeacherID =tc.Teachers.TeacherID
        //        })
        //        .ToList();

        //    dataGridView3.DataSource = dataGridView3;
        //    }
        //}
        //private void addAssignCourseToDataList()
        //{
        //    try
        //    {
        //        using (var context = new TeacherCourseDBEntities())
        //        {
        //            var selectCourses = from s in context.Courses
        //                                join s in context.Courses on s.CourseNumber equals s.CourseNumber
        //                                join t in context.Teachers on t.TeacherID equals t.TeacherID
        //                                select new
        //                                {
        //                                    CourseNumber = s.CourseNumber,
        //                                    CourseTitle = s.CourseTitle,
        //                                    TeacherID = t.TeacherId,
        //                                    FirstName = t.FirstName
        //                                };

        //            DataTable dt = new DataTable();
        //            dt.Columns.Add("CourseNumber");
        //            dt.Columns.Add("CourseTitle");
        //            dt.Columns.Add("TeacherID");
        //            dt.Columns.Add("FirstName");

        //            foreach (var s in selectCourses)
        //            {
        //                dt.Rows.Add(s.CourseNumber, s.CourseTitle, s.TeacherID, s.FirstName);
        //            }

        //            dataGridView2.DataSource = dt;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        private void AssignCourse(int teacherId, string courseNumber)
        {
           
            
            using (var context = new TeacherCourseDBEntities())
            {
                if (context.CourseTeachers.Any(tc => tc.TeacherID.Equals(teacherId) && tc.CourseNumber == courseNumber))

                
                {
                    MessageBox.Show("A teacher cannot be assigned more than 4 courses.");
                    return;
                }

                
                if (context.CourseTeachers.Any(tc => tc.TeacherID == teacherId && tc.CourseNumber == courseNumber))
                {
                    MessageBox.Show("The course is already assigned to the teacher.");
                    return;
                }

               
                var teacherCourse = new CourseTeacher
                {
                    TeacherID = teacherId,
                    CourseNumber = courseNumber
                    
                };

                context.CourseTeachers.Add(teacherCourse);
                context.SaveChanges();

                MessageBox.Show("Course assigned successfully!");
            }
        }

        private void textBoxcnumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonctadd_Click(object sender, EventArgs e)
        {

        }

        private void buttoneditteachercourse_Click(object sender, EventArgs e)
        {
            
        }
    }

        
    }

