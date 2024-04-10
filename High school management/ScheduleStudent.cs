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

namespace High_school_management
{
    public partial class ScheduleStudent : Form
    {
        public ScheduleStudent()
        {
            InitializeComponent();
            if(Login.Role == "Student")
            {
                DSDiem_Lb.Enabled = true;
                Lich_Lb.Enabled = false;
                DSHS_Lb.Enabled = false;
            }
            TKBGridView.ClearSelection();
        }

        int key = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ADMINS\Source\Repos\SchoolRecord\High school management\Database1.mdf"";Integrated Security=True");
        
        private void DisplayTKB(DateTime selectedDate)
        {
            string Query = "SELECT Tiet, Thu2, Thu3, Thu4, Thu5, Thu6, Thu7, CN FROM StudentTimeTb WHERE Ngay = @Ngay";
            SqlDataAdapter SDA = new SqlDataAdapter(Query, Con);
            SDA.SelectCommand.Parameters.AddWithValue("@Ngay", selectedDate);
            SqlCommandBuilder builder = new SqlCommandBuilder(SDA);
            var ds = new DataSet();
            SDA.Fill(ds);
            TKBGridView.DataSource = ds.Tables[0]; 
        }

        private void GetDate()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select Ngay from TeacherTimeTb", Con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                // Lấy giá trị ngày từ cột Ngay của dòng đầu tiên
                DateTime ngay = Convert.ToDateTime(dr["Ngay"]);

                // Gán giá trị ngày cho DateTimePicker
                dateTimePicker1.Value = ngay;
            }
            Con.Close();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void DSDiem_Lb_Click(object sender, EventArgs e)
        {
            StudentScore obj = new StudentScore();
            obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            DisplayTKB(selectedDate);
        }
    }
}
