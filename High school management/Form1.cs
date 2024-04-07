using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_school_management
{
    // Push thử
    public partial class Login : Form
    {
        string username_student = "student";
        string password_student = "123";
        string username_teacher = "teacher";
        string password_teacher = "1234";
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Close_Form(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txt_username.Text;
            user_password = txt_password.Text;
            try
            {
                if (username == username_student)
                {
                    Form frmView = new Menu();
                    frmView.Show();
                    frmView.FormClosed += new FormClosedEventHandler(Close_Form);
                    this.Hide();
                }
                else
                if (username == username_teacher)
                {
                    Form frmView = new Menu();
                    frmView.Show();
                    frmView.FormClosed += new FormClosedEventHandler(Close_Form);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Fault");
                }
            }
            catch
            {
                MessageBox.Show("Error Login");
            }
            finally
            {

            }
        }
    }
}
