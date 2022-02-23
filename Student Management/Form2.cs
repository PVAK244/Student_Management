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

namespace Student_Management
{
    public partial class Form2 : Form
    {
        SqlConnection conn = null;
        string strconn = "server=localhost; database=STUDENT_MANAGEMENT;User id=sa;password=123456";
        public Form2()
        {
            InitializeComponent();
        }

        private void btnViewClass_Click(object sender, EventArgs e)
        {
            txtClassID.Text = "";
            txtClassName.Text = "";
            txtYear.Text = "";
            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmm = new SqlCommand();
                cmm.CommandType = CommandType.Text;
                cmm.CommandText = $"select * from Class where ClassID = '{txtEnterClassID.Text}'";
                cmm.Connection = conn;
                SqlDataReader reader = cmm.ExecuteReader();
                if (reader.Read())
                {
                    txtClassID.Text = reader.GetString(0);
                    txtClassName.Text = reader.GetString(1);
                    txtYear.Text = reader.GetInt32(2).ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            try
            {
                lsvStudents.Items.Clear();
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmm = new SqlCommand($"select * from student where ClassID='{txtEnterClassID.Text}'", conn);

                SqlDataReader reader = cmm.ExecuteReader();
                while (reader.Read())
                {
                    string[] arr = new string[4];
                    ListViewItem itm;

                    arr[0] = reader.GetString(0);
                    arr[1] = reader.GetString(1);
                    arr[2] = reader.GetString(2);
                    itm = new ListViewItem(arr);
                    lsvStudents.Items.Add(itm);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lsvStudents.View = View.Details;
            lsvStudents.GridLines = true;
            lsvStudents.FullRowSelect = true;

            lsvStudents.Columns.Add("StudentID", 100);
            lsvStudents.Columns.Add("Name", 200);
            lsvStudents.Columns.Add("ClassID", 70);
        }
    }
}
