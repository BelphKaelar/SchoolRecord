using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
                Lich_Lb.Enabled = false;
                DSHS_Lb.Enabled = true;
                Appoint_Lb.Enabled = true;
            }
            GetLopID(); 
            DisplayStudentScore(); ApGridView1.ClearSelection();
        }

        int key = 0;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ADMINS\Source\Repos\High-School-Management1\High school management\SchoolRecord.mdf"";Integrated Security=True");

        private void DisplayStudentScore()
        {
            string Query = "Select * from StudentScoreTb";
            SqlDataAdapter SDA = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(SDA);
            var ds = new DataSet();
            SDA.Fill(ds);
            ApGridView1.DataSource = ds.Tables[0];
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
            SqlCommand cmd = new SqlCommand("Select MaLop from LopHoc", Con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DocID", typeof(int));
            dt.Load(dr);
            Lop_Cbox.ValueMember = "MaLop";
            Lop_Cbox.DataSource = dt;
            Con.Close();
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {

        }

        private void DSDiem_Lb_Click(object sender, EventArgs e)
        {

        }

        private void Lich_Lb_Click(object sender, EventArgs e)
        {

        }

        private void DSHS_Lb_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void ApGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ApGridView1.SelectedRows.Count > 0)
            {
                DiemMieng_Tbox.Text = ApGridView1.SelectedRows[0].Cells[8].Value.ToString();
                Diem15p_Tbox.Text = ApGridView1.SelectedRows[0].Cells[9].Value.ToString();
                Diem1Tiet_Tbox.Text = ApGridView1.SelectedRows[0].Cells[10].Value.ToString();
                DiemGK_Tbox.Text = ApGridView1.SelectedRows[0].Cells[11].Value.ToString();
                DiemCK_Tbox.Text = ApGridView1.SelectedRows[0].Cells[12].Value.ToString();
                if (TenHS_Tbox.Text == string.Empty || TenGV_Tbox.Text == string.Empty) { key = 0; }
                else { key = Convert.ToInt32(ApGridView1.SelectedRows[0].Cells[0].Value.ToString()); }
            }
            else { MessageBox.Show("Hãy chọn học sinh muốn thay đổi."); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
