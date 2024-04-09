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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        int key = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ADMINS\Source\Repos\High-School-Management1\High school management\SchoolRecord.mdf"";Integrated Security=True");
        private void Clear()
        {
            TenGV_Tbox.Text = "";
            TenHS_Tbox.Text = "";
            Lop_Cbox.SelectedIndex = 0;
            key = 0;
        }
        private void DisplayStudentScore()
        {
            string Query = "SELECT MaDiem, TenHS, MaLop, TenGV, DiemMieng, Diem15p, Diem1Tiet, DiemGK, DiemCK FROM StudentScore";
            SqlDataAdapter SDA = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(SDA);
            var ds = new DataSet();
            SDA.Fill(ds);
            ScoreGridView.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void GetLopID()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select MaLop from ClassTb", Con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLop", typeof(int));
            dt.Load(dr);
            Lop_Cbox.ValueMember = "MaLop";
            Lop_Cbox.DataSource = dt;
            Con.Close();
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

        private void FindBtn_Click(object sender, EventArgs e)
        {
            string searchTerm1 = TenHS_Tbox.Text.Trim();
            string searchTerm2 = TenGV_Tbox.Text.Trim();
            string searchCondition = Lop_Cbox.SelectedItem?.ToString(); // Handle null selection

            if (!string.IsNullOrEmpty(searchTerm1) && !string.IsNullOrEmpty(searchTerm2))
            {
                string query = "SELECT MaDiem, TenHS, MaLop, TenGV, DiemMieng, Diem15p, Diem1Tiet, DiemGK, DiemCK " +
                               "FROM StudentScore WHERE TenHS = @TenHS AND TenGV = @TenGV";

                if (!string.IsNullOrEmpty(searchCondition))
                {
                    query += " AND MaLop LIKE '%@MaLop%'"; 
                }

                Con.Open();
                SqlCommand command = new SqlCommand(query, Con);
                command.Parameters.AddWithValue("@TenHS", searchTerm1);
                command.Parameters.AddWithValue("@TenGV", searchTerm2);

                if (!string.IsNullOrEmpty(searchCondition))
                {
                    command.Parameters.AddWithValue("@MaLop", searchCondition);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ScoreGridView.DataSource = dataTable;
                Con.Close(); Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị cho cả hai ô tìm kiếm.");
            }
        }

    }
}
