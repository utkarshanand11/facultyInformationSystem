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
    public partial class Form7 : Form
    {


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True");

        public Form7()
        {
            InitializeComponent();
            PersonIdtextBox.Text = IDGenerator5().ToString();



        }

        private void Form7_Load(object sender, EventArgs e)
        {


        }
        int _minG = 100000;
        int _maxG = 999999;
        Random _rdmG = new Random();
        public int IDGenerator5()
        {
            int _min = 10000;
            int _max = 99999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        public int IDGenerator6()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "SELECT FacultyMember.designation  , FacultyMember.Department, Person.FirstName,Person.MiddleInitial ,Person.LastName,FacultyMember.OfficePhone ,FacultyMember.email, FacultyMember.PersonId FROM dbo.FacultyMember ,dbo.Person WHERE FacultyMember.PersonID = Person.PersonID AND FacultyMember.Department=''";
            //cmd.ExecuteNonQuery();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string StrQuery;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            StrQuery = "INSERT INTO PERSON VALUES ('" + PersonIdtextBox.Text + "', '" + FnametextBox.Text + "','" + MnametextBox.Text + "','" + LnametextBox.Text + "' )";
            cmd.CommandText = StrQuery;
            cmd.ExecuteNonQuery();

            StrQuery = "INSERT INTO FACULTYMEMBER VALUES ('" + PersonIdtextBox.Text + "', '" + AddresstextBox.Text + "','" + OfficeNotextBox.Text + "','" + MobileNotextBox.Text + "','" + emailtextBox.Text + "','" + DOBtextBox.Text + "','" + DesignationtextBox.Text + "','" + DepartmenttextBox.Text + "')";
            cmd.CommandText = StrQuery;
            cmd.ExecuteNonQuery();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                StrQuery = "INSERT INTO DEGREES VALUES ('" + PersonIdtextBox.Text + "', '" + dataGridView1.Rows[i].Cells["col1"].Value + "','" + dataGridView1.Rows[i].Cells["col2"].Value + "','" + dataGridView1.Rows[i].Cells["col3"].Value + "' )";
                cmd.CommandText = StrQuery;
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {


                //string WH_ID = String.Concat("WH", IDGenerator6().ToString());
                string WH_ID = String.Concat("WH", _rdmG.Next(_minG, _maxG).ToString());
                StrQuery = "INSERT INTO WORKHISTORY VALUES ('" + PersonIdtextBox.Text + "','" + dataGridView2.Rows[i].Cells["Column1"].Value + "', '" + dataGridView2.Rows[i].Cells["Column2"].Value + "','" + dataGridView2.Rows[i].Cells["Column3"].Value + "','" + dataGridView2.Rows[i].Cells["Column4"].Value + "' ,' " + WH_ID + "')";
                cmd.CommandText = StrQuery;
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                string AoS_ID = String.Concat("AS", _rdmG.Next(_minG, _maxG).ToString());
                StrQuery = "INSERT INTO AREASOFSPECIALIZATION VALUES ('" + PersonIdtextBox.Text + "','" + dataGridView3.Rows[i].Cells["d3c1"].Value + "',' " + AoS_ID + "' )";
                cmd.CommandText = StrQuery;
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView4.Rows.Count; i++)
            {
                StrQuery = "INSERT INTO COURSES VALUES ('" + PersonIdtextBox.Text + "','" + dataGridView4.Rows[i].Cells["d4c1"].Value + "', '" + dataGridView4.Rows[i].Cells["d4c2"].Value + "')";
                cmd.CommandText = StrQuery;
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                string P_ID = String.Concat("PB", _rdmG.Next(_minG, _maxG).ToString());
                StrQuery = "INSERT INTO PUBLICATIONS VALUES ('" + PersonIdtextBox.Text + "','" + dataGridView5.Rows[i].Cells["d5c1"].Value + "', '" + dataGridView5.Rows[i].Cells["d5c2"].Value + "', '" + dataGridView5.Rows[i].Cells["d5c3"].Value + "', '" + dataGridView5.Rows[i].Cells["d5c4"].Value + "',' " + P_ID + "')";
                cmd.CommandText = StrQuery;
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView6.Rows.Count - 1; i++)
            {
                string C_ID = String.Concat("CA", _rdmG.Next(_minG, _maxG).ToString());
                StrQuery = "INSERT INTO CONFERENCESATTENDED VALUES ('" + PersonIdtextBox.Text + "','" + dataGridView6.Rows[i].Cells["d6c1"].Value + "', '" + dataGridView6.Rows[i].Cells["d6c2"].Value + "', '" + dataGridView6.Rows[i].Cells["d6c3"].Value + "', '" + dataGridView6.Rows[i].Cells["d6c4"].Value + "',' " + C_ID + "')";
                cmd.CommandText = StrQuery;
                cmd.ExecuteNonQuery();
            }

            for (int i = 0; i < dataGridView7.Rows.Count - 1; i++)
            {
                string A_ID = String.Concat("AW", _rdmG.Next(_minG, _maxG).ToString());
                StrQuery = "INSERT INTO AWARDS VALUES ('" + PersonIdtextBox.Text + "','" + dataGridView7.Rows[i].Cells["d7c1"].Value + "', '" + dataGridView7.Rows[i].Cells["d7c2"].Value + "', '" + dataGridView7.Rows[i].Cells["d7c3"].Value + "',' " + A_ID + "' )";
                cmd.CommandText = StrQuery;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            string message = "Entry registered successfully.";
            string title = "Register Status";
            MessageBox.Show(message, title);
        }


        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form7_Load_1(object sender, EventArgs e)
        {

        }
    }
}
