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
    public partial class TeacherScore : Form
    {
        public TeacherScore()
        {
            InitializeComponent();
            if (Login.Role == "Teacher")
            {
                DSDiem_Lb.Enabled = true;
                Lich_Lb.Enabled = true;
                DSHS_Lb.Enabled = true;
            }
            GetLopID(); 
            DisplayStudentScore(); ScoreGridView.ClearSelection();
        }

        int key = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ADMINS\Source\Repos\High-School-Management1\High school management\School ahh Record.mdf"";Integrated Security=True");

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

        private void Clear()
        {
            Lop_Cbox.SelectedIndex = 0;
            TenGV_Tbox.Text = string.Empty;
            TenHS_Tbox.Text = string.Empty;
            key = 0;
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
        private void ScoreGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ScoreGridView.SelectedRows.Count > 0)
            {
                DiemMieng_Tbox.Text = ScoreGridView.SelectedRows[0].Cells[5].Value.ToString();
                Diem15p_Tbox.Text = ScoreGridView.SelectedRows[0].Cells[6].Value.ToString();
                Diem1Tiet_Tbox.Text = ScoreGridView.SelectedRows[0].Cells[7].Value.ToString();
                DiemGK_Tbox.Text = ScoreGridView.SelectedRows[0].Cells[8].Value.ToString();
                DiemCK_Tbox.Text = ScoreGridView.SelectedRows[0].Cells[9].Value.ToString();
                if (TenHS_Tbox.Text == string.Empty || TenGV_Tbox.Text == string.Empty) { key = 0; }
                else { key = Convert.ToInt32(ScoreGridView.SelectedRows[0].Cells[0].Value.ToString()); }
            }
            else { MessageBox.Show("Hãy chọn học sinh muốn thay đổi."); }
        }

        private void TenHS_Tbox_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = TenHS_Tbox.Text.Trim();
            string query = "SELECT * FROM StudentScore";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE TenHS LIKE '%" + searchTerm + "%'";
                // Thay 'StudentName' bằng tên cột bạn muốn tìm kiếm
            }

            SqlDataAdapter SDA = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(SDA);
            var ds = new DataSet();
            SDA.Fill(ds);
            ScoreGridView.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (DiemMieng_Tbox.Text == "" || Diem15p_Tbox.Text == "" || Diem1Tiet_Tbox.Text == "" ||  DiemGK_Tbox.Text == "" || DiemCK_Tbox.Text == "" )
            {
                MessageBox.Show("Xin hãy nhập điểm vào trước khi thay đổi!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update StudentScore set DiemMieng=@DM, Diem15p=@D15, Diem1Tiet=@D1T, DiemGK=@DGK, DiemCK=@DCK where MaDiem=@MD", Con);
                    cmd.Parameters.AddWithValue("@DM", DiemMieng_Tbox.Text);
                    cmd.Parameters.AddWithValue("@D15", Diem15p_Tbox.Text);
                    cmd.Parameters.AddWithValue("@D1T", Diem1Tiet_Tbox.Text);
                    cmd.Parameters.AddWithValue("@DGK", DiemGK_Tbox.Text);
                    cmd.Parameters.AddWithValue("@DCK", DiemCK_Tbox.Text);
                    cmd.Parameters.AddWithValue("@MD", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Score Edited");
                    Con.Close();
                    DisplayStudentScore();
                    Clear();
                }
                catch (Exception Ex) { MessageBox.Show(Ex.Message); }
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Hide();
        }

        private void Lich_Lb_Click(object sender, EventArgs e)
        {
            Schedule obj = new Schedule();
            obj.Show();
            this.Hide();
        }
    }
}
