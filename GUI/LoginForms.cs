using part2projectmta.DAC;
using part2projectmta.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part2projectmta
{
    public partial class LoginForms : Form

    {

        public LoginForms()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            using (var context = new TeacherCourseDBEntities()) ;
                string enteredUsername = textBoxuname.Text;
            string enteredPassword = textBoxpw.Text;

            if (AuthenticateUser(enteredUsername, enteredPassword))
            {
                MessageBox.Show("Login successful!");
                Form f2 = new CourseAssignmentForm();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
        private bool AuthenticateUser(string username, string password)
        {
            using (var context = new TeacherCourseDBEntities())
            {
                // Assuming you have a Users DbSet in your DbContext
                var user = context.Users
                    .FirstOrDefault(u => u.UserID == username && u.Password == password);

                return user != null;
            }

        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            textBoxuname.Clear();
            textBoxpw.Clear();
        }
    }
}
