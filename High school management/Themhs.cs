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
    public partial class Themhs : Form
    {
        classdatabase fn =  new classdatabase();
        string query;
        public Themhs()
        {
            InitializeComponent();
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
           
            string name = txtten.Text;
            string id = txtmahs.Text;
            string date = txtngaysinh.Text;
            string sdt = txtsdt.Text;
            string address = txtdiachi.Text;
            string tendn = txttendn.Text;
            string mk = txtmk.Text;
            string lop = txtlop.Text;

            try
            {
                query = "insert into user (username, id, date, sdt, address, tendn, mk, lop ) value ('" + name + "','" + id + "','" + date + "','" + sdt + "','" + address + "','" + tendn + "','" + mk + "','" + lop + "')";
                fn.setdata(query, "Dang ki thanh cong.");
            }catch (Exception)
            {
                //MessageBox.Show("Ten da duoc dung.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
         
            }
        }

        private void btntailai_Click(object sender, EventArgs e)
        {
            clearALL();
        }
        public void clearALL()
        {
            txtten.Clear();
            txtmahs.Clear();
            txtlop.Clear();
            txtdiachi.Clear();
            txttendn.Clear();
            txtmk.Clear();
            txtlop.Clear();
            txtngaysinh.ResetText();          
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            StudentRecords sr = new StudentRecords();
            sr.Show();
            this.Hide();
        }
    }
}
