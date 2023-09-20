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
    public partial class FrmApproverAddSickDay : Form
    {
        //current user variables
        public string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;

        //user Info variables
        public string userEmpID;
        public DateTime userDefaultStartTime;
        public DateTime userDefaultEndTime;

        public DateTime startTime;
        public DateTime endTime;

        public int timeSheetID;


        private readonly FrmTimesheetsApprovers frmTimesheetsApprovers;

        public FrmApproverAddSickDay(FrmTimesheetsApprovers formTimesheetsApprovers)
        {
            InitializeComponent();
            frmTimesheetsApprovers = formTimesheetsApprovers;
        }

        private void FrmApproverAddSickDay_Load(object sender, EventArgs e)
        {
            getCurrentUserInfo();

            getUsers();

            dateTimePickerWorkDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerWorkDate.CustomFormat = "MM/dd/yyyy";


            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "hh:mm tt";
            dateTimePickerStartTime.ShowUpDown = true;

            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "hh:mm tt";
            dateTimePickerEndTime.ShowUpDown = true;
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
                        cmd.CommandText = "SELECT * FROM dbo.tblUsers WHERE LANID = @currentUserLANID";
                        cmd.Parameters.Add("@currentUserLANID", SqlDbType.VarChar).Value = currentUser;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                currentUserEmpID = reader.GetString(reader.GetOrdinal("EmpID"));
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

        public void getUsers()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM dbo.tblUsers WHERE SecurityLevelID = 1 ORDER BY EmpName", conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceUsers.DataSource = dt;
                comboBoxEmployeeName.DataSource = bindingSourceUsers;
                comboBoxEmployeeName.DisplayMember = "EmpName";
                comboBoxEmployeeName.ValueMember = "EmpID";

            }
        }

        public void getUserInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT * FROM dbo.tblUsers WHERE EmpID = @userEmpID";
                        cmd.Parameters.Add("@userEmpID", SqlDbType.VarChar).Value = comboBoxEmployeeName.SelectedValue.ToString();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                userEmpID = reader.GetString(reader.GetOrdinal("EmpID"));
                                userDefaultStartTime = reader.GetDateTime(reader.GetOrdinal("DefaultStartTime"));
                                userDefaultEndTime = reader.GetDateTime(reader.GetOrdinal("DefaultEndTime"));
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

        private void checkBoxAllDay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAllDay.Checked == true)
            {
                dateTimePickerStartTime.Enabled = false;
                dateTimePickerEndTime.Enabled = false;
            }
            else
            {
                dateTimePickerStartTime.Enabled = true;
                dateTimePickerEndTime.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (checkBoxAllDay.Checked == true)
            {
                getUserInfo();
                startTime = userDefaultStartTime;
                endTime = userDefaultEndTime;

            }
            else
            {
                getUserInfo();
                startTime = dateTimePickerStartTime.Value;
                endTime = dateTimePickerEndTime.Value;
            }

            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblTimesheet]([EmpID],[StatusID],[WorkDate],[StartTime],[EndTime],Notes,Active)VALUES(@EmpID,3,@WorkDate,@StartTime,@EndTime,'',1)";
                    cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = comboBoxEmployeeName.SelectedValue.ToString();
                    cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = dateTimePickerWorkDate.Value;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = startTime;
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = endTime;
                    cmd.ExecuteNonQuery();

                    //get top timesheetID query
                    cmd.CommandText = @"SELECT TOP 1 TimesheetID FROM tblTimesheet ORDER BY TimesheetID DESC";
                    timeSheetID = (Int32)cmd.ExecuteScalar();

                    //insert exception query
                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetExceptions](TimesheetID,[PayCodeID],ExceptionStartTime,ExceptionEndTime,Active)VALUES(@timeSheetID,16,@StartTime,@EndTime,1)";
                    cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                    cmd.ExecuteNonQuery();

                    //insert comment query
                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET(SICK DAY) CREATED BY APPROVER.')";
                    cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET SUBMITTED.')";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET APPROVED.')";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            frmTimesheetsApprovers.frmLoad();
            this.Dispose();
            MessageBox.Show("Timesheet created.");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
