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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender,EventArgs e)
        {
            display_data();
        }
       // public string conString = "Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void fillCB2()
        {
            String s = comboBox1.Text;
           // if (s == '') ;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.comman
            display_data();
        }
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string selected = this.comboBox1.GetItemText(this.comboBox2.SelectedItem);
            cmd.CommandText = "SELECT FacultyMember.designation  , FacultyMember.Department, Person.FirstName,Person.MiddleInitial ,Person.LastName,FacultyMember.OfficePhone ,FacultyMember.email, FacultyMember.PersonId FROM dbo.FacultyMember ,dbo.Person WHERE FacultyMember.PersonID = Person.PersonID AND FacultyMember.Department='" + selected + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var facultyList = new Form4();
            facultyList.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form6 f6= new Form6();
            f6.NametextBox.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString()+ this.dataGridView1.CurrentRow.Cells[3].Value.ToString()+ this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            f6.DesignationtextBox.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            f6.DepartmenttextBox.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            f6.OfficeNotextBox.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f6.PersonIDtextbox.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            //int tempPersonId= Int32.Parse(textBox1.Text);
            //    int TempPersonId = Int32.Parse(this.dataGridView1.CurrentRow.Cells[6].Value.ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           // int TempPersonId = Int32.Parse(this.dataGridView1.CurrentRow.Cells[6].Value.ToString());
            cmd.CommandText = "Select FacultyMember.MobileNumber FROM dbo.FacultyMember where FacultyMember.PersonId='" + this.dataGridView1.CurrentRow.Cells[7].Value.ToString() + "'";//not completed, TODO
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                f6.MobileNotextBox.Text = da.GetValue(0).ToString();
            }
            con.Close();
            // f6.MobileNotextBox.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            f6.emailtextBox.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            f6.AddresstextBox.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            f6.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected=="SOE")
            {
               comboBox2.Items.Add("CSE");
                comboBox2.Items.Add("EE");
                comboBox2.Items.Add("ECE");
                comboBox2.Items.Add("FE");
                comboBox2.Items.Add("ME");

            }
            if (selected == "SOS")
            {
                comboBox2.Items.Add("Chemical Sciences");
                comboBox2.Items.Add("Mathematical Sciences");
                comboBox2.Items.Add("Physics");
                comboBox2.Items.Add("MBBT");
                comboBox2.Items.Add("ES");

            }
            if (selected == "SHSS")
            {
                comboBox2.Items.Add("Foreign Language");
                comboBox2.Items.Add("English");
                comboBox2.Items.Add("Hindi");
                comboBox2.Items.Add("Law");
                comboBox2.Items.Add("MCA");
                comboBox2.Items.Add("Sociology");

            }
            if (selected == "SMS")
            {
                comboBox2.Items.Add("Business Administration");
                comboBox2.Items.Add("Commerce");
                comboBox2.Items.Add("Disaster Management");
              }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string searchName = textBox1.Text;
            cmd.CommandText = "SELECT FACULTYMEMBER.Designation  , FACULTYMEMBER.Department, PERSON.FirstName,PERSON.MiddleInitial ,PERSON.LastName,FACULTYMEMBER.OfficePhone ,FACULTYMEMBER.email, FACULTYMEMBER.PersonId FROM dbo.FACULTYMEMBER ,dbo.PERSON WHERE FACULTYMEMBER.PersonID = PERSON.PersonID AND PERSON.FirstName LIKE '" + searchName + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["PersonId"].Visible = false;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string searchID = textBox2.Text;
            cmd.CommandText = "SELECT FACULTYMEMBER.Designation  , FACULTYMEMBER.Department, PERSON.FirstName,PERSON.MiddleInitial ,PERSON.LastName,FACULTYMEMBER.OfficePhone ,FACULTYMEMBER.email, FACULTYMEMBER.PersonId FROM dbo.FACULTYMEMBER ,dbo.PERSON WHERE FACULTYMEMBER.PersonID = PERSON.PersonID AND FACULTYMEMBER.PersonID='" + searchID + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["PersonId"].Visible = false;
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
