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
    public partial class FrmAddTimeSheet : Form
    {
        //current user variables
        public string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;
        public string currentUserEmpName;
        public string currentUserLanID;
        public int currentUserSecurityLevelID;


        //user Info variables
        public string userEmpID;
        public string userEmpName;
        public string userLanID;
        public int userSecurityLevelID;
        public DateTime userDefaultStartTime;
        public DateTime userDefaultEndTime;

        //timesheet variables
        public int timeSheetID;

        public int timesheetStartToLunchStartTime;

        //other forms objects
        private readonly FrmTimesheetsUsers frmTimesheetsUsers;
        private readonly FrmTimesheetsApprovers frmTimesheetsApprovers;

        public FrmAddTimeSheet(FrmTimesheetsUsers formTimesheetsUsers, FrmTimesheetsApprovers formTimesheetsApprovers)
        {
            InitializeComponent();
            frmTimesheetsUsers = formTimesheetsUsers;
            frmTimesheetsApprovers = formTimesheetsApprovers;
        }

        private void FrmAddTimeSheet_Load(object sender, EventArgs e)
        {
            textBoxLunchCount.Visible = false;
            buttonAddLunch.Enabled = false;

            //disable all buttons expcet Create and Close Button. Buttons will be enabled after Create button is clicked.
            btnAddException.Enabled = false;
            btnSubmit.Enabled = false;
            btnSave.Enabled = false;
            checkBoxLateLunch.Enabled = false;
            checkBoxLunchNotTaken.Enabled = false;
            richTextBoxNotes.Enabled = false;
            dateTimePickerStartTime.Enabled = true;
            dateTimePickerEndTime.Enabled = true;

            //used for form control logic
            getCurrentUserInfo();

            if (currentUserSecurityLevelID == 1)//users
            {
                //populates the employee drop-down menu
                getUsers();

                comboBoxEmployeeName.Enabled = false;
                comboBoxEmployeeName.SelectedValue = currentUserEmpID;

                getUserInfo();
            }
            else //approvers adn timekeepers
            {
                comboBoxEmployeeName.Enabled = true;

                //populates the employee drop-down menu
                getUsers();
                getUserInfo();

            }

            //sets the shift start and end times based on what user is selected.
            dateTimePickerStartTime.Text = userDefaultStartTime.ToString();
            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "hh:mm tt";
            dateTimePickerStartTime.ShowUpDown = true;

            dateTimePickerEndTime.Text = userDefaultEndTime.ToString();
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
                        cmd.CommandText = "SELECT EmpID,EmpName,SecurityLevelID,DefaultStartTime,DefaultEndTime FROM dbo.tblUsers WHERE LANID = @currentUserLANID";
                        cmd.Parameters.Add("@currentUserLANID", SqlDbType.VarChar).Value = currentUser;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                currentUserEmpID = reader.GetString(reader.GetOrdinal("EmpID"));
                                currentUserEmpName = reader.GetString(reader.GetOrdinal("EmpName"));
                                currentUserSecurityLevelID = reader.GetInt32(reader.GetOrdinal("SecurityLevelID"));
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


        public void getUserInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT EmpID,EmpName,SecurityLevelID,DefaultStartTime,DefaultEndTime FROM dbo.tblUsers WHERE EmpID = @userEmpID";
                        cmd.Parameters.Add("@userEmpID", SqlDbType.VarChar).Value = comboBoxEmployeeName.SelectedValue.ToString();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                userEmpID = reader.GetString(reader.GetOrdinal("EmpID"));
                                userEmpName = reader.GetString(reader.GetOrdinal("EmpName"));
                                userSecurityLevelID = reader.GetInt32(reader.GetOrdinal("SecurityLevelID"));
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

        public void getLunches()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM dbo.vwTimeSheetLunches WHERE TimesheetID = @timeSheetID", conn);
                sda.SelectCommand.Parameters.AddWithValue("@timeSheetID", timeSheetID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceLunches.DataSource = dt;
                advancedDataGridViewLunch.DataSource = bindingSourceLunches;
                advancedDataGridViewLunch.Columns["LunchID"].Visible = false;
                advancedDataGridViewLunch.Columns["TimesheetID"].Visible = false;
                advancedDataGridViewLunch.Columns["LunchNumber"].Visible = false;

                textBoxLunchCount.Text = advancedDataGridViewLunch.RowCount.ToString();

                if (Int32.Parse(textBoxLunchCount.Text.ToString()) == 0)
                {
                    buttonAddLunch.Enabled = true;
                    checkBoxLunchNotTaken.Checked = true;
                    checkBoxLateLunch.Checked = false;
                }
                else
                {
                    checkBoxLunchNotTaken.Checked = false;

                    buttonAddLunch.Enabled = false;
                    if (Int32.Parse(textBoxLunchCount.Text.ToString()) == 1)
                    {
                        //get lunch start time for delayed lunch
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "SELECT DATEDIFF(MINUTE,CAST(t.StartTime as time),CAST(l.[LunchStartTime] as time)) AS 'DIFF'FROM [MeterShopTimekeeping].[dbo].[tblLunches] l JOIN [dbo].[tblTimesheet] t ON l.TimesheetID = t.TimesheetID WHERE l.Active = 1 AND t.TimesheetID = @timesheetID";
                            cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    timesheetStartToLunchStartTime = reader.GetInt32(reader.GetOrdinal("DIFF"));
                                }
                            }
                        }
                        conn.Close();
                        //if (Decimal.Parse(timesheetStartToLunchStartTime.ToString()) > 5)
                        if(timesheetStartToLunchStartTime > 300)
                        {
                            checkBoxLateLunch.Checked = true;
                        }
                        else
                        {
                            checkBoxLateLunch.Checked = false;
                        }
                    }
                }
            }
        }

        public void getExceptions()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM dbo.vwTimesheetExceptions WHERE TimesheetID = @timeSheetID", conn);
                sda.SelectCommand.Parameters.AddWithValue("@timeSheetID", timeSheetID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceExceptions.DataSource = dt;
                advancedDataGridViewExceptions.DataSource = bindingSourceExceptions;
            }
        }

        //button functions
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (frmTimesheetsUsers != null)
            {
                frmTimesheetsUsers.frmLoad();
            }
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            btnCreate.Enabled = false;

            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblTimesheet]([EmpID],[StatusID],[WorkDate],[StartTime],[EndTime],Notes,Active)VALUES(@EmpID,1,@WorkDate,@StartTime,@EndTime,'',1)";
                    cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = comboBoxEmployeeName.SelectedValue.ToString();
                    cmd.Parameters.Add("@WorkDate", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = dateTimePickerStartTime.Value;
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = dateTimePickerEndTime.Value;
                    cmd.ExecuteNonQuery();

                    //get top timesheetID query
                    cmd.CommandText = @"SELECT TOP 1 TimesheetID FROM tblTimesheet ORDER BY TimesheetID DESC";
                    timeSheetID = (Int32)cmd.ExecuteScalar();

                    //insert lunch query
                    cmd.CommandText = @"INSERT INTO [dbo].[tblLunches](TimesheetID,LunchStartTime,LunchEndTime,Active)VALUES(@timeSheetID,DATEADD(n,300,@StartTime),DATEADD(n,330,@StartTime),1)";
                    cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                    cmd.ExecuteNonQuery();

                    //insert comment query
                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET CREATED.')";
                    cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                    cmd.ExecuteNonQuery();

                    getLunches();

                    conn.Close();
                }
            }

            btnAddException.Enabled = true;
            btnSubmit.Enabled = true;
            btnSave.Enabled = true;
            checkBoxLateLunch.Enabled = false;
            checkBoxLunchNotTaken.Enabled = false;
            richTextBoxNotes.Enabled = true;
            dateTimePickerStartTime.Enabled = true;
            dateTimePickerEndTime.Enabled = true;

        }

        private void btnAddException_Click(object sender, EventArgs e)
        {
            FrmAddException frmAddException = new FrmAddException(this,null);
            frmAddException.timeSheetID = this.timeSheetID;
            frmAddException.Show();
        }

        private void comboBoxEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getUserInfo();
            dateTimePickerStartTime.Text = userDefaultStartTime.ToString();
            dateTimePickerEndTime.Text = userDefaultEndTime.ToString();
        }

        private void advancedDataGridViewLunch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditLunch frmEditLunch = new FrmEditLunch(this,null);
            frmEditLunch.lunchID = Int32.Parse(advancedDataGridViewLunch.CurrentRow.Cells["LunchID"].Value.ToString());
            frmEditLunch.Show();
        }

        private void advancedDataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditException frmEditException = new FrmEditException(this,null);
            frmEditException.timesheetExceptionID = Int32.Parse(advancedDataGridViewExceptions.CurrentRow.Cells["TimesheetExceptionID"].Value.ToString());
            frmEditException.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    int LateLunch;
                    if (checkBoxLateLunch.Checked == true)
                    {
                        LateLunch = 1;
                    }
                    else
                    {
                        LateLunch = 0;
                    }

                    int LunchNotTaken;
                    if (checkBoxLunchNotTaken.Checked == true)
                    {
                        LunchNotTaken = 1;
                    }
                    else
                    {
                        LunchNotTaken = 0;
                    }


                    cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET WorkDate = @workDate, StartTime = @startTime, EndTime = @endTime, Notes = @notes, LateLunch= @lateLunch, LunchNotTaken =@lunchNotTaken WHERE TimesheetID = @timesheetID";
                    cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                    cmd.Parameters.Add("@workDate", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@startTime", SqlDbType.DateTime).Value = dateTimePickerStartTime.Value;
                    cmd.Parameters.Add("@endTime", SqlDbType.DateTime).Value = dateTimePickerEndTime.Value;
                    cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = richTextBoxNotes.Text.ToString();
                    cmd.Parameters.Add("@lateLunch", SqlDbType.Int).Value = LateLunch;
                    cmd.Parameters.Add("@lunchNotTaken", SqlDbType.Int).Value = LunchNotTaken;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }

            if (frmTimesheetsUsers != null)
            {
                frmTimesheetsUsers.frmLoad();
            }
            else
            {
                frmTimesheetsApprovers.frmLoad();
            }
            this.Dispose();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    int LateLunch;
                    if (checkBoxLateLunch.Checked == true)
                    {
                        LateLunch = 1;
                    }
                    else
                    {
                        LateLunch = 0;
                    }

                    int LunchNotTaken;
                    if (checkBoxLunchNotTaken.Checked == true)
                    {
                        LunchNotTaken = 1;
                    }
                    else
                    {
                        LunchNotTaken = 0;
                    }

                    cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET WorkDate = @workDate, StartTime = @startTime, EndTime = @endTime, Notes = @notes, StatusID = 2, LateLunch= @lateLunch, LunchNotTaken =@lunchNotTaken WHERE TimesheetID = @timesheetID";
                    cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                    cmd.Parameters.Add("@workDate", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@startTime", SqlDbType.DateTime).Value = dateTimePickerStartTime.Value;
                    cmd.Parameters.Add("@endTime", SqlDbType.DateTime).Value = dateTimePickerEndTime.Value;
                    cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = richTextBoxNotes.Text.ToString();
                    cmd.Parameters.Add("@lateLunch", SqlDbType.Int).Value = LateLunch;
                    cmd.Parameters.Add("@lunchNotTaken", SqlDbType.Int).Value = LunchNotTaken;
                    cmd.ExecuteNonQuery();

                    //insert comment query
                    cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET SUBMITTED.')";
                    cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }

            if (frmTimesheetsUsers != null)
            {
                frmTimesheetsUsers.frmLoad();
            }
            else
            {
                frmTimesheetsApprovers.frmLoad();
            }
            this.Dispose();
        }

        private void buttonAddLunch_Click(object sender, EventArgs e)
        {
            FrmAddLunch frmAddLunch = new FrmAddLunch(this, null);
            frmAddLunch.timeSheetID = timeSheetID;
            frmAddLunch.Show();
        }
    }
}
