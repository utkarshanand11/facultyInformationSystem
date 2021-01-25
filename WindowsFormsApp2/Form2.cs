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

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var adminDashboard = new Form5();        //code below is of checking correct credentials, coded out as have to enter every time while testing
            //adminDashboard.Show();
             string loginID = textBox1.Text;
             string password = textBox2.Text;

             con.Open();
             SqlCommand cmd = con.CreateCommand();
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = "SELECT Password FROM dbo.ADMINAUTHENTICATION WHERE LoginID = '"+loginID+ "' ";
             SqlDataReader da = cmd.ExecuteReader();
             while (da.Read())
             {
                 if(password== da.GetValue(0).ToString())
                 {
                     var adminDashboard = new Form5();
                     adminDashboard.Show();
                 }
                 else
                 {
                     string message = "Wrong credentials";
                     string title = "Login Error ";
                     MessageBox.Show(message, title);
                 }
             }
             con.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
