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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txt_username.Text; 
            user_password = txt_password.Text;
            try
            {
                String querry = "select * from Table where Username = '"+txt_username+"' and Password = '"+txt_password+"'";
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
