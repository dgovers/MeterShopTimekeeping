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
    public partial class FrmEditVacation : Form
    {
        //current user variables
        public int currentUserNameSecurityLevel;
        public string currentUserNameLANID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;
        public string currentUserName;


        //vacation variables
        public int vacationID;
        public string employeeID;
        public DateTime vacationStartDateTime;
        public DateTime vacationEndDateTime;
        public int vacationStatusID;
        public string VacationStatusDesc;
        public string endUsersEmailAddress;


        public string approverDL;


        private readonly FrmTimesheetsUsers frmTimesheetsUsers;
        private readonly FrmTimesheetsApprovers frmTimesheetsApprovers;

        public FrmEditVacation(FrmTimesheetsUsers formTimesheetsUsers, FrmTimesheetsApprovers formTimesheetsApprovers)
        {
            InitializeComponent();
            frmTimesheetsUsers = formTimesheetsUsers;
            frmTimesheetsApprovers = formTimesheetsApprovers;

        }

        private void FrmEditVacation_Load(object sender, EventArgs e)
        {
            dateTimePickerStartDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartDate.CustomFormat = "MM/dd/yyyy";
            //dateTimePickerStartDate.ShowUpDown = true;

            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.CustomFormat = "MM/dd/yyyy";
            //dateTimePickerEndDate.ShowUpDown = true;


            textBoxVacationID.Enabled = false;

            getCurrentUserInfo();


            getVacationInfo();

            textBoxVacationID.Text = vacationID.ToString();

            getUsers();
            comboBoxEmployeeName.SelectedValue = employeeID;

            if (currentUserNameSecurityLevel == 1)
            {
                comboBoxEmployeeName.Enabled = false;
            }
            else
            {
                comboBoxEmployeeName.Enabled = true;
            }

            getVacationStautes();
            textBoxStatus.Text = VacationStatusDesc.ToString();
            textBoxStatus.Enabled = false;

            dateTimePickerStartDate.Value = vacationStartDateTime;
            dateTimePickerEndDate.Value = vacationEndDateTime;

            //getComments();

            //users
            if (currentUserNameSecurityLevel == 1)
            {
                btnUniversal3.Visible = false;

                //NEW
                if (vacationStatusID == 1)
                {
                    btnUniversal2.Text = "Cancel";
                    btnUniversal1.Text = "Save";
                }
                //APPROVED
                else if (vacationStatusID == 2)
                {
                    btnUniversal2.Text = "Cancel";
                    btnUniversal1.Visible = false;
                    //btnUniversal1.Text = "Save";
                }
                //DENIED
                else if (vacationStatusID == 3)
                {
                    btnUniversal2.Text = "Cancel";
                    btnUniversal1.Visible = false;
                }
                //CANCELED
                else
                {
                    btnUniversal1.Visible = false;
                    btnUniversal2.Visible = false;
                }
            }
            //approver
            else if (currentUserNameSecurityLevel == 2)
            {
                //NEW
                if (vacationStatusID == 1)
                {
                    btnUniversal3.Text = "Save";
                    btnUniversal2.Text = "Deny";
                    btnUniversal1.Text = "Approve";
                }
                else if (vacationStatusID == 2 || vacationStatusID == 3)
                {
                    btnUniversal2.Text = "Cancel";
                    btnUniversal1.Visible = false;
                    btnUniversal3.Visible = false;
                }
                else
                {
                    btnUniversal1.Visible = false;
                    btnUniversal2.Visible = false;
                    btnUniversal3.Visible = false;
                }
            }
            //timekeeper
            else
            {
                btnUniversal1.Visible = false;
                btnUniversal2.Visible = false;
                btnUniversal3.Visible = false;
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

        public void getVacationStautes()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT * FROM dbo.tblVacationStatuses WHERE VacationStatusID = @vacationStatusID";
                        cmd.Parameters.Add("@vacationStatusID", SqlDbType.Int).Value = vacationStatusID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                VacationStatusDesc = reader.GetString(reader.GetOrdinal("VacationStatusDescription"));
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

        public void getVacationInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT v.*,u.EmailAddress FROM [MeterShopTimekeeping].[dbo].[tblVacation] v JOIN[MeterShopTimekeeping].[dbo].tblUsers u ON v.EmpID = u.EmpID WHERE v.VacationID = @vacationID";
                        cmd.Parameters.Add("@vacationID", SqlDbType.Int).Value = vacationID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                employeeID = reader.GetString(reader.GetOrdinal("EmpID"));
                                vacationStatusID = reader.GetInt32(reader.GetOrdinal("VacationStatus"));
                                vacationStartDateTime = reader.GetDateTime(reader.GetOrdinal("VacationStartDateTime"));
                                vacationEndDateTime = reader.GetDateTime(reader.GetOrdinal("VacationEndDateTime"));
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddVacationComment frmAddVacationComment = new FrmAddVacationComment(this);
            frmAddVacationComment.vacationID = vacationID;
            frmAddVacationComment.Show();
        }


        private void btnUniversal1_Click(object sender, EventArgs e)
        {
            //users
            if (currentUserNameSecurityLevel == 1)
            {
                //NEW
                if (vacationStatusID == 1)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblVacation] SET VacationStartDateTime =@VacationStartDateTime , VacationEndDateTime = @VacationEndDateTime WHERE VacationID = @VacationID";
                            cmd.Parameters.Add("@VacationStartDateTime", SqlDbType.DateTime).Value = dateTimePickerStartDate.Value;
                            cmd.Parameters.Add("@VacationEndDateTime", SqlDbType.DateTime).Value = dateTimePickerEndDate.Value;
                            cmd.Parameters.Add("@VacationID", SqlDbType.Int).Value = vacationID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsUsers.getCurrentUserVacationDates();
                    this.Dispose();
                }
                //DENIED
                else if (vacationStatusID == 3)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblVacation] SET VacationStartDateTime =@VacationStartDateTime , VacationEndDateTime = @VacationEndDateTime , VacationStatus = 1 WHERE VacationID = @VacationID";
                            cmd.Parameters.Add("@VacationStartDateTime", SqlDbType.DateTime).Value = dateTimePickerStartDate.Value;
                            cmd.Parameters.Add("@VacationEndDateTime", SqlDbType.DateTime).Value = dateTimePickerEndDate.Value;
                            cmd.Parameters.Add("@VacationID", SqlDbType.Int).Value = vacationID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblVacationComments](VacationCommentsTimestamp,VacationID,EmpID,Comment)VALUES(getdate(),@VacationID,@EmpID,'VACATION RESUBMITTED.')";
                            cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsUsers.getCurrentUserVacationDates();
                    this.Dispose();
                }
                //CANCELED
                else
                {
                    //do nothing.
                }
            }
            //approver
            else
            {
                //NEW
                if (vacationStatusID == 1)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblVacation] SET VacationStatus = 2 WHERE VacationID = @VacationID";
                            cmd.Parameters.Add("@VacationID", SqlDbType.Int).Value = vacationID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }

                    getApproversDL();

                    //email
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.sempra.com");
                    mail.From = new MailAddress("NOREPLY-METERSHOPTIMEKEEPING@semprautilities.com");
                    mail.To.Add(endUsersEmailAddress);
                    mail.CC.Add(approverDL);
                    mail.Subject = "MeterShop Timekeeping - Vacation Request Approved.";
                    mail.IsBodyHtml = true;
                    mail.Body = "Per " + currentUserName.ToString() + ", your request vacation ( " + DateTime.Parse(dateTimePickerStartDate.Value.ToString()).ToString("MM/dd/yyyy") + " - " + DateTime.Parse(dateTimePickerEndDate.Value.ToString()).ToString("MM/dd/yyyy") + ") has been approved..";

                    SmtpServer.Port = 25;
                    SmtpServer.Send(mail);

                    frmTimesheetsApprovers.getVacations();
                    this.Dispose();
                    frmTimesheetsApprovers.getVacations();
                    this.Dispose();
                }
            }

        }

        private void btnUniversal2_Click(object sender, EventArgs e)
        {
            //users
            if (currentUserNameSecurityLevel == 1)
            {

                string message = "Are you sure you want to cancel this vacation?";
                string caption = "Confirm cancellation of vacation";
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

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblVacation] SET VacationStatus = 4 WHERE VacationID = @VacationID";
                            cmd.Parameters.Add("@VacationID", SqlDbType.Int).Value = vacationID;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblVacationComments](VacationCommentsTimestamp,VacationID,EmpID,Comment)VALUES(getdate(),@VacationID,@EmpID,'VACATION CANCELED.')";
                            cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }
                    frmTimesheetsUsers.getCurrentUserVacationDates();
                    this.Dispose();
                }
            }
            //approver
            else
            {
                //NEW
                if (vacationStatusID == 1)
                {
                    using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            conn.Open();

                            cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblVacation] SET VacationStatus = 3 WHERE VacationID = @VacationID";
                            cmd.Parameters.Add("@VacationID", SqlDbType.Int).Value = vacationID;
                            cmd.ExecuteNonQuery();

                            conn.Close();
                        }
                    }

                    getApproversDL();

                    //email
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.sempra.com");
                    mail.From = new MailAddress("NOREPLY-METERSHOPTIMEKEEPING@semprautilities.com");
                    mail.To.Add(endUsersEmailAddress);
                    mail.CC.Add(approverDL);
                    mail.Subject = "MeterShop Timekeeping - Vacation Request Denied.";
                    mail.IsBodyHtml = true;
                    mail.Body = "Per " + currentUserName.ToString() + ", your request vacation ( " + DateTime.Parse(dateTimePickerStartDate.Value.ToString()).ToString("MM/dd/yyyy") + " - " + DateTime.Parse(dateTimePickerEndDate.Value.ToString()).ToString("MM/dd/yyyy") + ") has been denied..";

                    SmtpServer.Port = 25;
                    SmtpServer.Send(mail);

                    frmTimesheetsApprovers.getVacations();
                    this.Dispose();
                }
                //APPROVED AND DENIED
                else if (vacationStatusID == 2 || vacationStatusID == 3)
                {
                    string message = "Are you sure you want to cancel this vacation?";
                    string caption = "Confirm cancellation of vacation";
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

                                cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblVacation] SET VacationStatus = 4 WHERE VacationID = @VacationID";
                                cmd.Parameters.Add("@VacationID", SqlDbType.Int).Value = vacationID;
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblVacationComments](VacationCommentsTimestamp,VacationID,EmpID,Comment)VALUES(getdate(),@VacationID,@EmpID,'VACATION CANCELED.')";
                                cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = currentUserEmpID;
                                cmd.ExecuteNonQuery();

                                conn.Close();
                            }
                        }
                        
                        frmTimesheetsApprovers.getVacations();
                        this.Dispose();
                    }
                    //CANCELED
                    else
                    {
                        //nothing
                    }
                }
            }
        }

        private void btnUniversal3_Click_1(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblVacation] SET EmpID = @EmpID,  VacationStartDateTime = @VacationStartDateTime , VacationEndDateTime = @VacationEndDateTime WHERE VacationID = @VacationID";
                    cmd.Parameters.Add("@VacationID", SqlDbType.Int).Value = vacationID;
                    cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = comboBoxEmployeeName.SelectedValue.ToString();
                    cmd.Parameters.Add("@VacationStartDateTime", SqlDbType.DateTime).Value = dateTimePickerStartDate.Value;
                    cmd.Parameters.Add("@VacationEndDateTime", SqlDbType.DateTime).Value = dateTimePickerEndDate.Value;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            frmTimesheetsApprovers.getVacations();
            this.Dispose();
        }
    }
}