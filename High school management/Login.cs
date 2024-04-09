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
        public static string Role;
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

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = User_Tbox.Text;
            user_password = Pass_Tbox.Text;
            if (username == username_student)
            {
                Role = "Student";
                Menu obj = new Menu();
                obj.Show();
                this.Hide();
            }
            else if (username == username_teacher){
                Role = "Teacher";
                Menu obj = new Menu();
                obj.Show();
                this.Hide();
            }else { MessageBox.Show("Tên đăng nhập hoặc mật khẩu không khả dụng!"); }
        }
    }
}
