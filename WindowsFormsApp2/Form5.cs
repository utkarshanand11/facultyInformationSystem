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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
            dataGridViewStyling();


        }
        public void dataGridViewStyling()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.Font = new Font("Cambria", 15);
            dataGridView1.RowTemplate.MinimumHeight = 20;


        }
        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ScrollBars = ScrollBars.Both;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string selected = this.comboBox1.GetItemText(this.comboBox2.SelectedItem);
            cmd.CommandText = "SELECT FACULTYMEMBER.Designation  , FACULTYMEMBER.Department, PERSON.FirstName,PERSON.MiddleInitial ,PERSON.LastName,FACULTYMEMBER.OfficePhone ,FACULTYMEMBER.email, FACULTYMEMBER.PersonId FROM dbo.FACULTYMEMBER ,dbo.PERSON WHERE FACULTYMEMBER.PersonID = PERSON.PersonID AND FACULTYMEMBER.Department='" + selected + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Columns["PersonId"].Visible = false;
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var addNewEntry = new Form7();
            addNewEntry.Show();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            adminUpdate_Delete adminUpdDel = new adminUpdate_Delete();
            adminUpdDel.NametextBox.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString() + this.dataGridView1.CurrentRow.Cells[3].Value.ToString() + this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            adminUpdDel.DesignationtextBox.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            adminUpdDel.DepartmenttextBox.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            adminUpdDel.OfficeNotextBox.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            adminUpdDel.PersonIDtextBox.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            //int tempPersonId= Int32.Parse(textBox1.Text);
            //    int TempPersonId = Int32.Parse(this.dataGridView1.CurrentRow.Cells[6].Value.ToString());
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select FacultyMember.MobileNumber FROM dbo.FacultyMember where FacultyMember.PersonId='" + this.dataGridView1.CurrentRow.Cells[7].Value.ToString() + "'";//not completed, TODO
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                adminUpdDel.MobileNotextBox.Text = da.GetValue(0).ToString();
            }
            con.Close();
            // adminUpdDel.MobileNotextBox.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            adminUpdDel.emailtextBox.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            adminUpdDel.AddresstextBox.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();

            adminUpdDel.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (selected == "SOE")
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form5_Load_1(object sender, EventArgs e)
        {

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
    }
}
