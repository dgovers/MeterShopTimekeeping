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
    public partial class FrmAddUser : Form
    {

        public string empNbr;
        public string empName;
        public string empTitle;
        public string empLANID;
        public string empEmailAddress;
        

        private readonly FrmUsers frmUsers;
        

        public FrmAddUser(FrmUsers formUsers)
        {
            InitializeComponent();
            frmUsers = formUsers;
        }

        private void FrmAddUser_Load(object sender, EventArgs e)
        {
            textBoxEmployeeName.Enabled = false;
            textBoxEmployeeTitle.Enabled = false;
            textBoxLanID.Enabled = false;
            textBoxEmailAddress.Enabled = false;
            dateTimePickerShiftStart.Enabled = false;
            dateTimePickerShiftEnd.Enabled = false;

            btnSave.Enabled = false;

            getSecurityLevels();

            dateTimePickerShiftStart.Text = "1900-01-01 06:00:00.000";
            dateTimePickerShiftStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerShiftStart.CustomFormat = "hh:mm tt";
            dateTimePickerShiftStart.ShowUpDown = true;

            dateTimePickerShiftEnd.Text = "1900-01-01 15:30:00.000";
            dateTimePickerShiftEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerShiftEnd.CustomFormat = "hh:mm tt";
            dateTimePickerShiftEnd.ShowUpDown = true;
        }

        public void getSecurityLevels()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"select * from dbo.tblsecuritylevel", conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceSecurityLevels.DataSource = dt;
                comboBoxSecurityLevel.DataSource = bindingSourceSecurityLevels;
                comboBoxSecurityLevel.DisplayMember = "SecurityLevelDescription";
                comboBoxSecurityLevel.ValueMember = "SecurityLevelID";
            }
        }
     
        public void getUserInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler2.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = @"SELECT [EMP_NBR],RTRIM(LTRIM([FIRST_NAME])) + ' ' + RTRIM(LTRIM([LAST_NAME])) 'EMP_NAME',JOB_TITLE 'EMP_TITLE',RTRIM(LTRIM([SMTP_ADDR])) 'EMAIL_ADDR','CORP\' + RTRIM(LTRIM([LAN_USER_ID])) 'LAN_ID' FROM [MK6D].[dbo].[MK6TEMP_EMPLOYEE] WHERE EMP_NBR = @empNbr";
                        cmd.Parameters.Add("@empNbr", SqlDbType.VarChar).Value = empNbr;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                empName = reader.GetString(reader.GetOrdinal("EMP_NAME"));
                                empTitle = reader.GetString(reader.GetOrdinal("EMP_TITLE"));
                                empEmailAddress = reader.GetString(reader.GetOrdinal("EMAIL_ADDR"));
                                empLANID = reader.GetString(reader.GetOrdinal("LAN_ID"));
                                
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Cannot find employee.");
                            System.Windows.Forms.Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);//display error message with exception 
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                empNbr = textBoxEmployeeID.Text.ToString();
          
                getUserInfo();

                textBoxEmployeeName.Enabled = true;
                textBoxEmployeeTitle.Enabled = true;
                textBoxLanID.Enabled = true;
                textBoxEmailAddress.Enabled = true;

                dateTimePickerShiftStart.Enabled = true;
                dateTimePickerShiftEnd.Enabled = true;

                textBoxEmployeeName.Text = empName;
                textBoxEmployeeTitle.Text = empTitle;
                textBoxLanID.Text = empLANID;
                textBoxEmailAddress.Text = empEmailAddress;

                btnSave.Enabled = true;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"INSERT INTO [dbo].[tblUsers](EmpID,EmpName,EmpTitle,LanID,SecurityLevelID,EmailAddress,DefaultStartTime,DefaultEndTime)VALUES(@EmpID,@EmpName,@EmpTitle,@LanID,@SecurityLevelID,@EmailAddress,@DefaultStartTime,@DefaultEndTime)";
                    cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = textBoxEmployeeID.Text.ToString();
                    cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = textBoxEmployeeName.Text.ToString();
                    cmd.Parameters.Add("@EmpTitle", SqlDbType.VarChar).Value = textBoxEmployeeTitle.Text.ToString();

                    cmd.Parameters.Add("@LanID", SqlDbType.VarChar).Value = textBoxLanID.Text.ToString();
                    cmd.Parameters.Add("@SecurityLevelID", SqlDbType.Int).Value = comboBoxSecurityLevel.SelectedValue;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar).Value = textBoxEmailAddress.Text.ToString();

                    cmd.Parameters.Add("@DefaultStartTime", SqlDbType.DateTime).Value = dateTimePickerShiftStart.Value.ToString();
                    cmd.Parameters.Add("@DefaultEndTime", SqlDbType.DateTime).Value = dateTimePickerShiftEnd.Value.ToString();

                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"
                                        
                                            declare @cmd1 varchar(200)
                                            declare @cmd2 varchar(200)
                                            declare @cmd3 varchar(200)
                                            declare @cmd4 varchar(200)
                                            declare @userLANID varchar(50)

                                            set @userLANID = @LANID
                                            set @cmd1 = ' CREATE LOGIN ['++ @userLANID ++'] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]'

                                            set @cmd2 = 'USE [MeterShopTimekeeping] CREATE USER ['++ @userLANID ++'] FOR LOGIN ['++ @userLANID ++']'

                                            set @cmd3 = 'USE [MeterShopTimekeeping] ALTER ROLE [db_datareader] ADD MEMBER ['++ @userLANID ++']'

                                            set @cmd4 = 'USE [MeterShopTimekeeping] ALTER ROLE [db_datawriter] ADD MEMBER ['++ @userLANID ++']'

                                            --PRINT @cmd1
                                            EXEC (@cmd1)
                                            --PRINT @cmd2
                                            EXEC (@cmd2)
                                            --PRINT @cmd3
                                            EXEC (@cmd3)
                                            --PRINT @cmd4
                                            EXEC (@cmd4)                                        

                                       ";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            frmUsers.frmLoad();
            this.Dispose();
        }
    }
}
