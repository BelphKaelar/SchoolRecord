using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace High_school_management
{
    internal class DB
    {
        protected SqlConnection getconnection()
        {
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "data source =Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\admin\\Documents\\Dulieuhs.mdf;Integrated Security=True;Connect Timeout=30 ";
            //return con;
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ADMINS\\Source\\Repos\\SchoolRecord\\High school management\\Database1.mdf\";Integrated Security=True");
            return con;
        }
        public DataSet getdata(string query)
        {
            SqlConnection con = getconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void setdata(String query, string msg)
        {
            SqlConnection con = getconnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
