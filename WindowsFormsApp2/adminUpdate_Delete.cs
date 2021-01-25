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
    public partial class adminUpdate_Delete : Form
    {
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True");
        SqlDataAdapter da1;
        DataTable dt1;
        SqlDataAdapter da2;
        DataTable dt2;
        SqlDataAdapter da3;
        DataTable dt3;
        SqlDataAdapter da4;
        DataTable dt4;
        SqlDataAdapter da5;
        DataTable dt5;
        SqlDataAdapter da6;
        DataTable dt6;
        SqlDataAdapter da7;
        DataTable dt7;
        public adminUpdate_Delete()
        {
            InitializeComponent();
           


        }

        private void adminUpdate_Delete_Load(object sender, EventArgs e)
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
            string personID = PersonIDtextBox.Text;
            cmd.CommandText = "SELECT DEGREES.PersonID  ,DEGREES.DegreeTitle  , DEGREES.DegreeInstitution, DEGREES.DegreeYear  FROM dbo.DEGREES  WHERE DEGREES.PersonId = '" + PersonIDtextBox.Text + "' ORDER BY dbo.DEGREES.DegreeYear DESC";
            cmd.ExecuteNonQuery();
             dt1 = new DataTable();
             da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            //this.dataGridView1.Columns["PersonID"].Visible = false;

            con.Close();
        }
        public void WorkExperience_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT WORKHISTORY.PersonID ,WORKHISTORY.JobTitle ,WORKHISTORY.WorkPlace ,WORKHISTORY.JobBeginDate ,WORKHISTORY.JobEndDate,WORKHISTORY.WorkHistoryID FROM dbo.WORKHISTORY where WORKHISTORY.PersonID='" + PersonIDtextBox.Text + "' ORDER BY WORKHISTORY.JobEndDate DESC";
            cmd.ExecuteNonQuery();
             dt2 = new DataTable();
             da2 = new SqlDataAdapter(cmd);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            this.dataGridView2.Columns["WorkHistoryID"].Visible = false;
           // this.dataGridView2.Columns["PersonID"].Visible = false;
            con.Close();
        }
        public void Specialization_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PersonId,Area,AreasOfSpecializationID FROM dbo.AREASOFSPECIALIZATION where AREASOFSPECIALIZATION.PersonID='" + PersonIDtextBox.Text + "' ";
            cmd.ExecuteNonQuery();
           dt3 = new DataTable();
             da3 = new SqlDataAdapter(cmd);
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
            //this.dataGridView3.Columns["AreasOfSpecializationID"].Visible = false;

            con.Close();
        }
        public void CoursesTaught_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COURSES.PersonId,CourseId,CourseName FROM dbo.COURSES where COURSES.PersonID='" + PersonIDtextBox.Text + "' ";
            cmd.ExecuteNonQuery();
             dt4 = new DataTable();
            da4 = new SqlDataAdapter(cmd);
            da4.Fill(dt4);
            dataGridView4.DataSource = dt4;
            //this.dataGridView4.Columns["PersonId"].Visible = false;
            con.Close();
        }
        public void JournalsBooksPublished_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PersonId,PublicationTitle,PublisherName,PublicationDate,PublicationLocation FROM dbo.PUBLICATIONS where PUBLICATIONS.PersonID='" + PersonIDtextBox.Text + "' ";
            cmd.ExecuteNonQuery();
            dt5 = new DataTable();
             da5 = new SqlDataAdapter(cmd);
            da5.Fill(dt5);
            dataGridView5.DataSource = dt5;
            //this.dataGridView5.Columns["PersonId"].Visible = false;

            con.Close();
        }
        public void Conferences_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PersonId,Title,Year,Role,Organiser,ConferenceID FROM dbo.CONFERENCESATTENDED where CONFERENCESATTENDED.PersonID='" + PersonIDtextBox.Text + "' ";
            cmd.ExecuteNonQuery();
            dt6 = new DataTable();
             da6 = new SqlDataAdapter(cmd);
            da6.Fill(dt6);
            dataGridView6.DataSource = dt6;
            //this.dataGridView6.Columns["ConferenceID"].Visible = false;
            con.Close();
        }
        public void Awards_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT PersonID,AwardTitle,AwardedBy,AwardDate,AwardID FROM dbo.AWARDS where AWARDS.PersonID='" + PersonIDtextBox.Text + "' ";
            cmd.ExecuteNonQuery();
             dt7 = new DataTable();
             da7 = new SqlDataAdapter(cmd);
            da7.Fill(dt7);
            dataGridView7.DataSource = dt7;
           // this.dataGridView7.Columns["AwardID"].Visible = false;



            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb1 = new SqlCommandBuilder(da1);
            da1.Update(dt1);
            
            SqlCommandBuilder scb2 = new SqlCommandBuilder(da2);
            da1.Update(dt2);

            SqlCommandBuilder scb3 = new SqlCommandBuilder(da3);
            da1.Update(dt3);
            
            SqlCommandBuilder scb4 = new SqlCommandBuilder(da4);
            da1.Update(dt4);
            
            SqlCommandBuilder scb5 = new SqlCommandBuilder(da5);
            da1.Update(dt5);
            
            SqlCommandBuilder scb6 = new SqlCommandBuilder(da6);
            da1.Update(dt6);
           
           // SqlCommandBuilder scb7 = new SqlCommandBuilder(da7);
            //da1.Update(dt7);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlCommandBuilder scb1 = new SqlCommandBuilder(da1);
            da1.Update(dt1);

            SqlCommandBuilder scb2 = new SqlCommandBuilder(da2);
            da2.Update(dt2);

            SqlCommandBuilder scb3 = new SqlCommandBuilder(da3);
            da3.Update(dt3);

            SqlCommandBuilder scb4 = new SqlCommandBuilder(da4);
            da4.Update(dt4);

            SqlCommandBuilder scb5 = new SqlCommandBuilder(da5);
            da5.Update(dt5);

            SqlCommandBuilder scb6 = new SqlCommandBuilder(da6);
            da6.Update(dt6);

            SqlCommandBuilder scb7 = new SqlCommandBuilder(da7);
            da7.Update(dt7);

            string message1 = "Record successfully updated.";
            string title1 = "UPDATE STATUS";
            MessageBox.Show(message1, title1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this entry.";
            string title = "DELETE CONFIRMATION";
            MessageBox.Show(message, title);
           
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM PERSON WHERE PERSON.PersonID='" + PersonIDtextBox.Text + "' ";
            cmd.ExecuteNonQuery();

            string message1 = "Record successfully deleted.";
            string title1 = "DELETE STATUS";
            MessageBox.Show(message1, title1);
        }
    }
}
