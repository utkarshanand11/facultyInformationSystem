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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True");
        WorkHistoryForm WkForm = new WorkHistoryForm();
        AwardsForm AwForm = new AwardsForm();
        PublicationsForm PuForm = new PublicationsForm();
        ProjCourConfForm PCCForm = new ProjCourConfForm();
        DegreesSpecializationForm DSForm = new DegreesSpecializationForm();
        
        public Form6()
        {
            InitializeComponent();
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            EducationalQualification_data();
            WorkExperience_data();
            Specialization_data();
            CoursesTaught_data();
            JournalsBooksPublished_data();
            Conferences_data();
            Awards_data();
        }

        public void EducationalQualification_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DEGREES.DegreeTitle  , DEGREES.DegreeInstitution, DEGREES.DegreeYear  FROM dbo.DEGREES  WHERE DEGREES.PersonId = '" + PersonIDtextbox.Text+ "' ORDER BY dbo.DEGREES.DegreeYear DESC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DSForm.dataGridView1.DataSource = dt;

            con.Close();
        }
        public void WorkExperience_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT WORKHISTORY.JobTitle ,WORKHISTORY.WorkPlace ,WORKHISTORY.JobBeginDate ,WORKHISTORY.JobEndDate FROM dbo.WORKHISTORY where WORKHISTORY.PersonID='" + PersonIDtextbox.Text + "' ORDER BY WORKHISTORY.JobEndDate DESC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            WkForm.dataGridView1.DataSource = dt;

            con.Close();
        }
        public void Specialization_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Area FROM dbo.AREASOFSPECIALIZATION where AREASOFSPECIALIZATION.PersonID='" + PersonIDtextbox.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            DSForm.dataGridView2.DataSource = dt;

            con.Close();
        }
        public void CoursesTaught_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT CourseId,CourseName FROM dbo.COURSES where COURSES.PersonID='" + PersonIDtextbox.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            PCCForm.dataGridView1.DataSource = dt;

            con.Close();
        }
        public void  JournalsBooksPublished_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PublicationTitle,PublisherName,PublicationDate,PublicationLocation FROM dbo.PUBLICATIONS where PUBLICATIONS.PersonID='" + PersonIDtextbox.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            PuForm.dataGridView1.DataSource = dt;

            con.Close();
        }
        public void Conferences_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Title,Year,Role,Year,Organiser FROM dbo.CONFERENCESATTENDED where CONFERENCESATTENDED.PersonID='" + PersonIDtextbox.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            PCCForm.dataGridView2.DataSource = dt;

            con.Close();
        }
        public void Awards_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT AwardTitle,AwardedBy,AwardDate FROM dbo.AWARDS where AWARDS.PersonID='" + PersonIDtextbox.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            AwForm.dataGridView1.DataSource = dt;

            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
          //  WorkHistoryForm WkForm = new WorkHistoryForm();
            WkForm.TopLevel = false;
            panel1.Controls.Add(WkForm);
            WkForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WkForm.Dock = DockStyle.Fill;
            WkForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //  WorkHistoryForm WkForm = new WorkHistoryForm();
            AwForm.TopLevel = false;
            panel1.Controls.Add(AwForm);
            AwForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            AwForm.Dock = DockStyle.Fill;
            AwForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //  WorkHistoryForm WkForm = new WorkHistoryForm();
            PuForm.TopLevel = false;
            panel1.Controls.Add(PuForm);
            PuForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PuForm.Dock = DockStyle.Fill;
            PuForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //  WorkHistoryForm WkForm = new WorkHistoryForm();
            PCCForm.TopLevel = false;
            panel1.Controls.Add(PCCForm);
            PCCForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PCCForm.Dock = DockStyle.Fill;
            PCCForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            //  WorkHistoryForm WkForm = new WorkHistoryForm();
            DSForm.TopLevel = false;
            panel1.Controls.Add(DSForm);
            DSForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DSForm.Dock = DockStyle.Fill;
            DSForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           Form6 reload = new Form6();
            reload.Show();
           // this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
