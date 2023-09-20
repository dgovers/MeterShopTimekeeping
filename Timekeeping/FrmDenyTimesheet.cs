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
using System.IO;
using System.Net;
using System.Net.Mail;


namespace MeterShopTimekeeping
{
    public partial class FrmDenyTimesheet : Form
    {
        //current user variables
        public int currentUserNameSecurityLevel;
        public string currentUserNameLANID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;
        public string currentUserName;
        public string currentUserEmailAddress;

        //timesheet variables
        public int timeSheetID;
        public string endUsersEmailAddress;

        public string approversDL;

        private readonly FrmEditTimesheet frmEditTimesheet;
        private readonly FrmTimesheetsApprovers frmTimesheetsApprovers;

        public FrmDenyTimesheet(FrmEditTimesheet formEditTimesheet, FrmTimesheetsApprovers formTimesheetsApprovers)
        {
            InitializeComponent();
            frmEditTimesheet = formEditTimesheet;
            frmTimesheetsApprovers = formTimesheetsApprovers;
        }

        private void FrmDenyTimesheet_Load(object sender, EventArgs e)
        {
            getCurrentUserInfo();
            getTimesheetInfo();
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
                                currentUserName = reader.GetString(reader.GetOrdinal("EmpName"));
                                currentUserNameSecurityLevel = reader.GetInt32(reader.GetOrdinal("SecurityLevelID"));
                                currentUserEmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
                            }
                        }
                        else
                        {
                            //nothing
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

        public void getTimesheetInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT ts.TimesheetID,usr.EmpID, usr.EmailAddress FROM dbo.tblTimesheet ts JOIN dbo.tblUsers usr ON ts.EmpID = usr.EmpID WHERE ts.TimesheetID = @timeSheetID";
                        cmd.Parameters.Add("@timeSheetID", SqlDbType.VarChar).Value = timeSheetID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                endUsersEmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
                            }
                        }
                        else
                        {
                            //nothing
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

        public void getApproversDL()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT * FROM dbo.vw_ApproverDL";
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                approversDL = reader.GetString(reader.GetOrdinal("Approver_DL"));
                            }
                        }
                        else
                        {
                            //nothing
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Update and insert comment
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 4 WHERE TimesheetID = @TimesheetID";
                    cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = timeSheetID; ;
                    cmd.ExecuteNonQuery();


                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET DENIED.')";
                    cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,@Comment)";
                    cmd.Parameters.Add("@Comment", SqlDbType.Text).Value = richTextBoxComment.Text.ToString();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }

            getApproversDL();

            //email message to SUP
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.sempra.com");
            mail.From = new MailAddress("NOREPLY-METERSHOPTIMEKEEPING@semprautilities.com");
            mail.To.Add(endUsersEmailAddress);
            mail.CC.Add(approversDL);
            mail.Subject = "MeterShop Timekeeping - Timesheet #" + timeSheetID.ToString() + " - DENIED";
            mail.IsBodyHtml = true;
            mail.Body = "Timesheet #" + timeSheetID.ToString() + " has been denied per " + currentUserName.ToString() + " because ,\"" + richTextBoxComment.Text.ToString().ToString() + "\".";

            SmtpServer.Port = 25;
            SmtpServer.Send(mail);


            frmEditTimesheet.Close();

            frmTimesheetsApprovers.frmLoad();
            this.Dispose();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
