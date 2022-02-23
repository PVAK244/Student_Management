using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Management
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;
        string strconn = "server=localhost; database=STUDENT_MANAGEMENT;User id=sa;password=123456";
        //string strconn = "Data Source=localhost1;Initial Catalog=STUDENT_MANAGEMENT;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn == null) conn = new SqlConnection(strconn);
                if (conn.State == ConnectionState.Closed) conn.Open();

                SqlCommand cmd = new SqlCommand($"Select count(*) from STUDENT Where ClassID = '{txtClassID.Text}'", conn);
                int result = (int)cmd.ExecuteScalar();
                txtResult.Text = result.ToString();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to server \n" + ex.Message);
            }
        }
    }
}
