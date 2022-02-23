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
    public partial class Form3 : Form
    {
        SqlConnection conn = null;
        string strconn = "server=localhost; database=STUDENT_MANAGEMENT;User id=sa;password=123456";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lsvStudents.View = View.Details;
            lsvStudents.GridLines = true;
            lsvStudents.FullRowSelect = true;

            lsvStudents.Columns.Add("StudentID", 100);
            lsvStudents.Columns.Add("Name", 200);
            lsvStudents.Columns.Add("ClassID", 70);

            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmm = new SqlCommand("Select * from Class", conn);

                lsbClass.ClearSelected();
                SqlDataReader reader = cmm.ExecuteReader();
                while (reader.Read())
                {
                    string classID = reader.GetString(0);
                    string className = reader.GetString(1);
                    string year = reader.GetInt32(2).ToString();

                    string line = classID + "-" + className + "-" + year.ToString();
                    lsbClass.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }

        private void lsbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsvStudents.Items.Clear();
            if (lsbClass.SelectedIndex == -1) return;
            string line = lsbClass.SelectedItem.ToString();
            string[] array = line.Split('-');
            string classID = array[0];

            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmm = new SqlCommand($"select * from student where ClassID= '{classID}'", conn);

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
    }
}
