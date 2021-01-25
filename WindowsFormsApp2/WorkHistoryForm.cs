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
    public partial class WorkHistoryForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-N12FH7A;Initial Catalog=facultyInfoSys;Integrated Security=True");
      
        public WorkHistoryForm()
        {
            InitializeComponent();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
           
          
            
        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
