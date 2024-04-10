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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            if (Login.Role == "Student")
            {
                DSDiem_Lb.Enabled = true;
                Lich_Lb.Enabled = true;
                DSHS_Lb.Enabled = false;
            }
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label3.Text = DateTime.Now.ToString();
        }

        private void DSDiem_Lb_Click(object sender, EventArgs e)
        {
            if(Login.Role == "Student")
            {
                StudentScore obj = new StudentScore();
                obj.Show();
                this.Hide();
            }else
            {
                TeacherScore obj = new TeacherScore();
                obj.Show();
                this.Hide();
            }
        }

        private void Lich_Lb_Click(object sender, EventArgs e)
        {
            Schedule obj = new Schedule();
            obj.Show();
            this.Hide();
        }

        private void DSHS_Lb_Click(object sender, EventArgs e)
        {

        }
    }
}
