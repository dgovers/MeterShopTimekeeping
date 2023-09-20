using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace MeterShopTimekeeping
{
    public partial class FrmAddTimesheetComment : Form
    {
        //current user variables
        public string currentUserNameLANID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;

        //timesheet variables
        public int timeSheetID;

        private readonly FrmEditTimesheet frmEditTimesheet;

        public FrmAddTimesheetComment(FrmEditTimesheet formEditTimesheet)
        {
            InitializeComponent();
            frmEditTimesheet = formEditTimesheet;
        }

        private void FrmAddTimesheetComment_Load(object sender, EventArgs e)
        {
            getCurrentUserInfo();
        }

        public void getCurrentUserInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT * FROM dbo.tblUsers WHERE LANID = @userLANID";
                        cmd.Parameters.Add("@userLANID", SqlDbType.VarChar).Value = currentUserNameLANID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                currentUserEmpID = reader.GetString(reader.GetOrdinal("EmpID"));
                            }
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);//display error message with exception 
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,@comment)";
                    cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                    cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                    cmd.Parameters.Add("@comment", SqlDbType.VarChar).Value = richTextBoxComment.Text.ToString();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            frmEditTimesheet.getComments();
            this.Dispose();
        }
    }
}
