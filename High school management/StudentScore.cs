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
    public partial class StudentScore : Form
    {
        public StudentScore()
        {
            InitializeComponent();
            if (Login.Role == "Student")
            {
                DSDiem_Lb.Enabled = true;
                Lich_Lb.Enabled = true;
                DSHS_Lb.Enabled = true;
            }
            GetLopID();
            DisplayStudentScore(); ScoreGridView.ClearSelection();
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
    }
}
