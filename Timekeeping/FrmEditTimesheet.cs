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
    public partial class FrmEditTimesheet : Form
    {
        //current user variables
        public int currentUserNameSecurityLevel;
        public string currentUserNameLANID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;
        public string currentUserName;

        //timesheet variables
        public int timeSheetID;
        public string employeeID;
        public string employeeEmailAddress;
        public DateTime workDate;
        public DateTime startTime;
        public DateTime endTime;
        public int approved;
        public DateTime approvedDate;
        public string approvedBy;
        public string notes;
        public int statusID;
        public int lateLunch;
        public int lunchNotTaken;
        public string endUsersEmailAddress;

        public int timesheetStartToLunchStartTime;


        public string approverDL;

        private readonly FrmTimesheetsUsers frmTimesheetsUsers;
        private readonly FrmTimesheetsApprovers frmTimesheetsApprovers;
        private readonly FrmTimesheetsTimeKeepers frmTimesheetsTimeKeepers;

        public FrmEditTimesheet(FrmTimesheetsUsers formTimesheetsUsers, FrmTimesheetsApprovers formTimesheetsApprovers, FrmTimesheetsTimeKeepers formTimesheetsTimeKeepers)
        {
            InitializeComponent();
            frmTimesheetsUsers = formTimesheetsUsers;
            frmTimesheetsApprovers = formTimesheetsApprovers;
            frmTimesheetsTimeKeepers = formTimesheetsTimeKeepers;
        }

        private void FrmEditTimesheet_Load(object sender, EventArgs e)
        {
            frmLoad();
        }

        public void frmLoad()
        {
            textBoxLunchCount.Visible = false;
            buttonAddLunch.Enabled = false;

            getCurrentUserInfo();

            checkBoxLateLunch.Enabled = false;
            checkBoxLunchNotTaken.Enabled = false;

            if (currentUserNameSecurityLevel == 1)
            {
                comboBoxEmployeeName.Enabled = false;
            }
            else
            {
                comboBoxEmployeeName.Enabled = true;
            }

            getUsers();

            getTimesheetInfo();

            textBoxID.Text = timeSheetID.ToString();
            textBoxID.Enabled = false;

            richTextBoxNotes.Text = notes.ToString();

            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT StatusDescription FROM dbo.tblStatus WHERE StatusID = @statusID";
                    cmd.Parameters.Add("@statusID", SqlDbType.VarChar).Value = statusID.ToString();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            textBoxStatus.Text = reader.GetString(reader.GetOrdinal("StatusDescription"));
                        }
                    }
                    else
                    {
                        //nothing
                    }
                    conn.Close();
                }
            }

            textBoxStatus.Enabled = false;

            getLunches();

            getExceptions();

            getComments();

            comboBoxEmployeeName.SelectedValue = employeeID;
            dateTimePickerWorkDate.Value = workDate;

            dateTimePickerStartTime.Value = startTime;
            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "hh:mm tt";
            dateTimePickerStartTime.ShowUpDown = true;

            dateTimePickerEndTime.Value = endTime;
            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "hh:mm tt";
            dateTimePickerEndTime.ShowUpDown = true;

            //USER
            if (currentUserNameSecurityLevel == 1)
            {
                button4.Visible = false;

                //NOT SUBMITTED
                if (statusID == 1)
                {
                    button3.Enabled = true;
                    button3.Text = "Submit";

                    button2.Enabled = true;
                    button2.Text = "Save";

                    buttonDeleteTimesheet.Visible = true;
                }
                //PENDING APPROVAL
                else if (statusID == 2)
                {
                    button3.Visible = false;

                    button2.Enabled = true;
                    button2.Text = "Save";

                    buttonDeleteTimesheet.Visible = true;
                }
                //APPROVED
                else if (statusID == 3)
                {
                    button3.Visible = false;

                    button2.Enabled = true;
                    button2.Text = "Recall";

                    dateTimePickerWorkDate.Enabled = false;
                    dateTimePickerStartTime.Enabled = false;
                    dateTimePickerEndTime.Enabled = false;
                    btnAddException.Enabled = false;
                    advancedDataGridViewExceptions.Enabled = false;
                    advancedDataGridViewLunch.Enabled = false;
                    richTextBoxNotes.Enabled = false;

                    buttonDeleteTimesheet.Visible = false;
                }
                //DENIED
                else if (statusID == 4)
                {
                    button3.Enabled = true;
                    button3.Text = "Submit";

                    button2.Enabled = true;
                    button2.Text = "Save";

                    buttonDeleteTimesheet.Visible = true;
                }
                //ENTERED
                else if (statusID == 5)
                {
                    button3.Visible = false;

                    button2.Enabled = true;
                    button2.Text = "Recall";

                    dateTimePickerWorkDate.Enabled = false;
                    dateTimePickerStartTime.Enabled = false;
                    dateTimePickerEndTime.Enabled = false;
                    btnAddException.Enabled = false;
                    advancedDataGridViewExceptions.Enabled = false;
                    advancedDataGridViewLunch.Enabled = false;
                    richTextBoxNotes.Enabled = false;

                    buttonDeleteTimesheet.Visible = false;
                }
                //RECALL REQUESTED
                else if (statusID == 6)
                {
                    button3.Visible = false;

                    button2.Visible = false;

                    dateTimePickerWorkDate.Enabled = false;
                    dateTimePickerStartTime.Enabled = false;
                    dateTimePickerEndTime.Enabled = false;
                    btnAddException.Enabled = false;
                    advancedDataGridViewExceptions.Enabled = false;
                    advancedDataGridViewLunch.Enabled = false;
                    richTextBoxNotes.Enabled = false;

                    buttonDeleteTimesheet.Visible = false;
                }
                //RECALLED
                else
                {
                    button3.Enabled = true;
                    button3.Text = "Submit";

                    button2.Enabled = true;
                    button2.Text = "Save";

                    buttonDeleteTimesheet.Visible = true;
                }
            }
            //APPROVER
            else if (currentUserNameSecurityLevel == 2)
            {
                //NOT SUBMITTED
                if (statusID == 1)
                {
                    button3.Enabled = true;
                    button3.Text = "Submit";

                    button2.Enabled = true;
                    button2.Text = "Save";

                    button4.Visible = false;
                }
                //PENDING APPROVAL
                else if (statusID == 2)
                {
                    button2.Enabled = true;
                    button2.Text = "Deny";

                    button3.Enabled = true;
                    button3.Text = "Approve";

                    button4.Enabled = true;
                    button4.Text = "Save";
                }
                //APPROVED
                else if (statusID == 3)
                {
                    comboBoxEmployeeName.Enabled = false;
                    dateTimePickerWorkDate.Enabled = false;
                    dateTimePickerStartTime.Enabled = false;
                    dateTimePickerEndTime.Enabled = false;

                    buttonAddLunch.Enabled = false;
                    btnAddException.Enabled = false;

                    button3.Visible = true;
                    button3.Text = "Undo";

                    button2.Enabled = true;
                    button2.Text = "Save";

                    button4.Visible = false;
                }
                //DENIED
                else if (statusID == 4)
                {
                    comboBoxEmployeeName.Enabled = false;
                    dateTimePickerWorkDate.Enabled = false;
                    dateTimePickerStartTime.Enabled = false;
                    dateTimePickerEndTime.Enabled = false;

                    buttonAddLunch.Enabled = false;
                    btnAddException.Enabled = false;

                    button3.Enabled = true;
                    button3.Text = "Submit";

                    button2.Enabled = true;
                    button2.Text = "Save";

                    button4.Visible = false;
                }
                //ENTERED
                else if (statusID == 5)
                {
                    comboBoxEmployeeName.Enabled = false;
                    dateTimePickerWorkDate.Enabled = false;
                    dateTimePickerStartTime.Enabled = false;
                    dateTimePickerEndTime.Enabled = false;

                    buttonAddLunch.Enabled = false;
                    btnAddException.Enabled = false;

                    button3.Visible = false;

                    button2.Enabled = true;
                    button2.Text = "Recall";

                    button4.Visible = false;
                }
                //RECALL REQUESTED
                else if (statusID == 6)
                {
                    comboBoxEmployeeName.Enabled = false;
                    dateTimePickerWorkDate.Enabled = false;
                    dateTimePickerStartTime.Enabled = false;
                    dateTimePickerEndTime.Enabled = false;

                    buttonAddLunch.Enabled = false;
                    btnAddException.Enabled = false;

                    button4.Visible = false;

                    button3.Visible = true;
                    button3.Text = "Approve Recall";
                    button3.Left = 795;
                    button3.Width = 100;
                

                    button2.Visible = true;
                    button2.Text = "Deny Recall";
                    //button2.Left = 610;
                    //button2.Width = 100;
                }
                //RECALLED
                else
                {
                    button4.Visible = false;

                    button3.Enabled = true;
                    button3.Text = "Submit";

                    button2.Enabled = true;
                    button2.Text = "Save";
                }
            }
            //TIMEKEEPER
            else
            {
                comboBoxEmployeeName.Enabled = false;
                dateTimePickerWorkDate.Enabled = false;
                dateTimePickerStartTime.Enabled = false;
                dateTimePickerEndTime.Enabled = false;

                buttonAddLunch.Enabled = false;
                btnAddException.Enabled = false;

                button4.Visible = false;

                //NOT SUBMITTED
                if (statusID == 1)
                {
                    button3.Visible = false;

                    button2.Visible = false;
                }
                //PENDING APPROVAL
                else if (statusID == 2)
                {
                    button3.Visible = false;

                    button2.Visible = false;
                }
                //APPROVED
                else if (statusID == 3)
                {
                    button3.Visible = false;

                    button2.Enabled = true;
                    button2.Text = "Enter";
                }
                //DENIED
                else if (statusID == 4)
                {
                    button3.Visible = false;

                    button2.Visible = false;
                }
                //ENTERED
                else if (statusID == 5)
                {
                    button3.Visible = false;

                    button2.Enabled = true;
                    button2.Text = "Undo";
                }
                //RECALL REQUESTED
                else if (statusID == 6)
                {
                    button3.Visible = false;

                    button2.Visible = false;
                }
                //RECALLED
                else
                {
                    button3.Visible = false;

                    button2.Visible = false;
                }
            }
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
                        cmd.CommandText = "SELECT ts.*,usr.EmpID, usr.EmailAddress FROM dbo.tblTimesheet ts JOIN dbo.tblUsers usr ON ts.EmpID = usr.EmpID WHERE ts.TimesheetID = @timeSheetID";
                        cmd.Parameters.Add("@timesheetID", SqlDbType.Int).Value = timeSheetID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employeeID = reader.GetString(reader.GetOrdinal("EmpID"));
                                statusID = reader.GetInt32(reader.GetOrdinal("StatusID"));
                                workDate = reader.GetDateTime(reader.GetOrdinal("WorkDate"));
                                startTime = reader.GetDateTime(reader.GetOrdinal("StartTime"));
                                endTime = reader.GetDateTime(reader.GetOrdinal("EndTime"));
                                notes = reader.GetString(reader.GetOrdinal("Notes"));
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
                        if (Int32.Parse(timesheetStartToLunchStartTime.ToString()) > 300)
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
                advancedDataGridViewExceptions.Columns["TimesheetExceptionID"].Visible = false;
                advancedDataGridViewExceptions.Columns["TimesheetID"].Visible = false;
                advancedDataGridViewExceptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            }
        }

        public void getComments()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM dbo.vwTimeSheetComments WHERE TimesheetID = @timeSheetID ORDER BY TimeStamp", conn);
                sda.SelectCommand.Parameters.AddWithValue("@timeSheetID", timeSheetID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceComments.DataSource = dt;
                advancedDataGridViewComments.DataSource = bindingSourceComments;
                advancedDataGridViewComments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                advancedDataGridViewComments.Columns["CommentID"].Visible = false;
                advancedDataGridViewComments.Columns["TimesheetID"].Visible = false;
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
                                approverDL = reader.GetString(reader.GetOrdinal("Approver_DL"));
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

        public void getEndUsersInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT * FROM dbo.tblUsers WHERE EmplID = @empID;";
                        cmd.Parameters.Add("@empID", SqlDbType.Int).Value = employeeID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employeeEmailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
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

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            FrmAddTimesheetComment frmAddTimesheetComment = new FrmAddTimesheetComment(this);
            frmAddTimesheetComment.timeSheetID = timeSheetID;
            frmAddTimesheetComment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int lateLunch;
            if (checkBoxLateLunch.Checked == true)
            {
                lateLunch = 1;
            }
            else
            {
                lateLunch = 0;
            }

            int lunchNotTaken;
            if (checkBoxLunchNotTaken.Checked == true)
            {
                lunchNotTaken = 1;
            }
            else
            {
                lunchNotTaken = 0;
            }

            //User
            if (currentUserNameSecurityLevel == 1)
            {

                //NOT SUBMITTED OR DENIED OR PENDING APPROVAL OR RECALLED (Save Button)
                if (statusID == 1 || statusID == 2 || statusID == 4 || statusID == 7)
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
                            cmd.Parameters.Add("@workDate", SqlDbType.DateTime).Value = dateTimePickerWorkDate.Value;
                            cmd.Parameters.Add("@startTime", SqlDbType.DateTime).Value = dateTimePickerStartTime.Value;
                            cmd.Parameters.Add("@endTime", SqlDbType.DateTime).Value = dateTimePickerEndTime.Value;
                            cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = richTextBoxNotes.Text.ToString();
                            cmd.Parameters.Add("@lateLunch", SqlDbType.Int).Value = LateLunch;
                            cmd.Parameters.Add("@lunchNotTaken", SqlDbType.Int).Value = LunchNotTaken;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsUsers.frmLoad();
                    this.Dispose();
                }
                //APPROVED OR ENTERED (RECALL Button)
                else if (statusID == 3 || statusID == 5)
                {
                    FrmRecallRequest frmRecallRequest = new FrmRecallRequest(this);
                    frmRecallRequest.timeSheetID = timeSheetID;
                    frmRecallRequest.Show();
                }
                else
                {
                    //RECALL REQUESTED
                }
            }
            //Approver
            else if (currentUserNameSecurityLevel == 2)
            {
                if (statusID == 1 || statusID == 3 ||statusID == 4 || statusID == 7)
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
                            cmd.Parameters.Add("@workDate", SqlDbType.DateTime).Value = dateTimePickerWorkDate.Value;
                            cmd.Parameters.Add("@startTime", SqlDbType.DateTime).Value = dateTimePickerStartTime.Value;
                            cmd.Parameters.Add("@endTime", SqlDbType.DateTime).Value = dateTimePickerEndTime.Value;
                            cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = richTextBoxNotes.Text.ToString();
                            cmd.Parameters.Add("@lateLunch", SqlDbType.Int).Value = LateLunch;
                            cmd.Parameters.Add("@lunchNotTaken", SqlDbType.Int).Value = LunchNotTaken;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsApprovers.frmLoad();
                    this.Dispose();
                }
                else if (statusID == 2)
                {
                    //add confirmation MessageBox
                    FrmDenyTimesheet frmDenyTimesheet = new FrmDenyTimesheet(this,frmTimesheetsApprovers);
                    frmDenyTimesheet.timeSheetID = timeSheetID;
                    frmDenyTimesheet.Show();
                }
                else if (statusID == 6)
                {
                    FrmDenyRecall frmDenyRecall = new FrmDenyRecall(this, frmTimesheetsApprovers);
                    frmDenyRecall.timeSheetID = timeSheetID;
                    frmDenyRecall.Show();
                }
            }
            //Timekeeper
            else
            {
                if (statusID == 3)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 5 WHERE TimesheetID = @timesheetID";
                            cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET ENTERED.')";
                            cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsTimeKeepers.frmLoad();
                    this.Dispose();
                }
                else if (statusID == 5)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 3 WHERE TimesheetID = @timesheetID";
                            cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET UNDO ENTRY.')";
                            cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsTimeKeepers.frmLoad();
                    this.Dispose();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //User
            if (currentUserNameSecurityLevel == 1)
            {

                //NOT SUBMITTED OR DENIED OR PENDING APPROVAL OR RECALLED (Submit Button)
                if (statusID == 1 || statusID == 4 || statusID == 7)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 2 WHERE TimesheetID = @TimesheetID";
                            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = timeSheetID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET SUBMITTED.')";
                            cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsUsers.frmLoad();
                    this.Dispose();
                }
            }
            //Approver
            else if (currentUserNameSecurityLevel == 2)
            {
                //PENDING APPROVAL (approve button)
                if (statusID == 2)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 3,Approved = 1,ApprovedDate = getdate(),ApprovedBy = @currentEmpID WHERE TimesheetID = @TimesheetID";
                            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = timeSheetID;
                            cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET APPROVED.')";
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsApprovers.frmLoad();
                    this.Dispose();
                }
                else if (statusID == 3)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 2,Approved = 0,ApprovedDate = NULL,ApprovedBy = NULL WHERE TimesheetID = @TimesheetID";
                            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = timeSheetID;
                            cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET APPROVAL REMOVED.')";
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsApprovers.frmLoad();
                    this.Dispose();
                }
                else if (statusID == 4 || statusID == 1)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 2 WHERE TimesheetID = @TimesheetID";
                            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = timeSheetID;
                            cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET SUBMITTED BY APPROVER.')";
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsApprovers.frmLoad();
                    this.Dispose();
                }
                else if (statusID == 6)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET StatusID = 7 WHERE TimesheetID = @TimesheetID";
                            cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = timeSheetID;
                            cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET RECALLED APPROVED.')";
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    getApproversDL();
                    
                    //add email
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.sempra.com");
                    mail.From = new MailAddress("NOREPLY-METERSHOPTIMEKEEPING@semprautilities.com");
                    mail.To.Add(endUsersEmailAddress);
                    mail.CC.Add(approverDL);
                    mail.Subject = "MeterShop Timekeeping - Timesheet #" + timeSheetID.ToString() + " - RECALL REQUEST APPROVED.";
                    mail.IsBodyHtml = true;
                    mail.Body = "" + currentUserName.ToString() + " has approved the recall of timesheet # " + timeSheetID.ToString() + ".";

                    SmtpServer.Port = 25;
                    SmtpServer.Send(mail);

                    frmTimesheetsApprovers.frmLoad();
                    this.Dispose();
                }
            }
            //Timekeeper
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridViewLunch_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditLunch frmEditLunch = new FrmEditLunch(null, this);
            frmEditLunch.lunchID = Int32.Parse(advancedDataGridViewLunch.CurrentRow.Cells["LunchID"].Value.ToString());
            frmEditLunch.Show();
        }

        private void btnAddException_Click(object sender, EventArgs e)
        {
            FrmAddException frmAddException = new FrmAddException(null, this);
            frmAddException.timeSheetID = timeSheetID;
            frmAddException.Show();
        }

        private void advancedDataGridViewExceptions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (statusID != 3 && statusID != 5 && statusID != 6)
            {
                FrmEditException frmEditException = new FrmEditException(null, this);
                frmEditException.timesheetExceptionID = Int32.Parse(advancedDataGridViewExceptions.CurrentRow.Cells["TimesheetExceptionID"].Value.ToString());
                frmEditException.Show();
            }
        }

        private void buttonDeleteTimesheet_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this timesheet?";
            string caption = "Confirm Deletion of Timesheet";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
            MessageBoxOptions.RightAlign);

            if (result == DialogResult.Yes)

            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblTimesheet] SET Active = 0 WHERE TimesheetID = @TimesheetID";
                        cmd.Parameters.Add("@TimesheetID", SqlDbType.Int).Value = timeSheetID;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = @"INSERT INTO [dbo].[tblTimesheetComments](TimesheetID,CommentsTimestamp,EmpID,Comment)VALUES(@timeSheetID,getdate(),@currentEmpID,'TIMESHEET DELETED.')";
                        cmd.Parameters.Add("@currentEmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                        cmd.ExecuteNonQuery();

                        conn.Close();
                        conn.Close();
                    }
                }
                if (frmTimesheetsApprovers != null)
                {
                    frmTimesheetsApprovers.frmLoad();
                }
                else
                {
                    frmTimesheetsUsers.frmLoad();
                }
            }

            this.Dispose();
        }

        private void buttonAddLunch_Click(object sender, EventArgs e)
        {
            FrmAddLunch frmAddLunch = new FrmAddLunch(null,this);
            frmAddLunch.timeSheetID = timeSheetID;
            frmAddLunch.Show();
        }

        private void FrmEditTimesheet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmTimesheetsUsers != null)
            {
                frmTimesheetsUsers.frmLoad();
            }
            else if (frmTimesheetsApprovers != null)
            {
                frmTimesheetsApprovers.frmLoad();
            }
            else
            {
                frmTimesheetsTimeKeepers.frmLoad();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                    cmd.Parameters.Add("@workDate", SqlDbType.DateTime).Value = dateTimePickerWorkDate.Value;
                    cmd.Parameters.Add("@startTime", SqlDbType.DateTime).Value = dateTimePickerStartTime.Value;
                    cmd.Parameters.Add("@endTime", SqlDbType.DateTime).Value = dateTimePickerEndTime.Value;
                    cmd.Parameters.Add("@notes", SqlDbType.VarChar).Value = richTextBoxNotes.Text.ToString();
                    cmd.Parameters.Add("@lateLunch", SqlDbType.Int).Value = LateLunch;
                    cmd.Parameters.Add("@lunchNotTaken", SqlDbType.Int).Value = LunchNotTaken;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            frmTimesheetsApprovers.frmLoad();
            this.Dispose();
        }
    }
}
