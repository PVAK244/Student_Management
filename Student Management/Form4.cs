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
    public partial class Form4 : Form
    {
        int result = -1;
        SqlConnection conn = null;
        string strconn = "server=localhost; database=STUDENT_MANAGEMENT;User id=sa;password=123456";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            lsvStudents.View = View.Details;
            lsvStudents.GridLines = true;
            lsvStudents.FullRowSelect = true;

            lsvStudents.Columns.Add("StudentID", 100);
            lsvStudents.Columns.Add("Name", 200);
            lsvStudents.Columns.Add("ClassID", 70);
            ViewListofStudents();
        }

        private void ViewListofStudents()
        {
            lsvStudents.Items.Clear();
            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmm = new SqlCommand("select * from Student", conn);

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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmm = new SqlCommand();
                cmm.CommandType = CommandType.Text;
                cmm.Connection = conn;
                cmm.CommandText = "insert into Student(StudentID, Name, ClassID) values (@StudentID,@Name,@ClassID)";

                SqlParameter parameter1 = new SqlParameter("@StudentID", txtStudentID.Text);
                cmm.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@Name", txtFullName.Text);
                cmm.Parameters.Add(parameter2);
                SqlParameter parameter3 = new SqlParameter("@ClassID", txtClassID.Text);
                cmm.Parameters.Add(parameter3);

                try
                {
                    result = cmm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nInsert a record failed!!");
                }
                if (result > 0)
                {
                    ViewListofStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lsvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvStudents.SelectedItems.Count > 0)
            {
                txtStudentID.Text = lsvStudents.SelectedItems[0].SubItems[0].Text;
                txtFullName.Text = lsvStudents.SelectedItems[0].SubItems[1].Text;
                txtClassID.Text = lsvStudents.SelectedItems[0].SubItems[2].Text;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmm = new SqlCommand($"update Student set Name = '{txtFullName.Text}', classID='{txtClassID.Text}' where StudentID = '{txtStudentID.Text}'", conn);

                try
                {
                    result = cmm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nUpdate failed!!");
                }

                if (result > 0)
                {
                    ViewListofStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmm = new SqlCommand($"delete from student where StudentID='{txtStudentID.Text}'", conn);

                try
                {
                    result = cmm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nDelete failed!!");
                }
                if (result > 0)
                {
                    ViewListofStudents();
                    txtStudentID.Text = "";
                    txtFullName.Text = "";
                    txtClassID.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
