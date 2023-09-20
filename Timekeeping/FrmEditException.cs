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
    public partial class FrmEditException : Form
    {
        //exceptiom variables
        public int timesheetExceptionID;
        public int payCodeID;
        public DateTime exceptionStartTime;
        public DateTime exceptionEndTime;


        private readonly FrmAddTimeSheet frmAddTimeSheet;
        private readonly FrmEditTimesheet frmEditTimesheet;

        public FrmEditException(FrmAddTimeSheet formAddTimeSheet,FrmEditTimesheet formEditTimesheet)
        {
            InitializeComponent();
            frmAddTimeSheet = formAddTimeSheet;
            frmEditTimesheet = formEditTimesheet;
        }

        private void FrmEditException_Load(object sender, EventArgs e)
        {
            getPayCodes();

            getExceptionInfo();


            comboBoxPayCodes.SelectedValue = payCodeID.ToString();
            dateTimePickerStartTime.Value = exceptionStartTime;
            dateTimePickerEndTime.Value = exceptionEndTime;

            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "hh:mm tt";
            dateTimePickerStartTime.ShowUpDown = true;

            dateTimePickerEndTime.CustomFormat = "hh:mm tt";
            dateTimePickerEndTime.ShowUpDown = true;
            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;

            dateTimePickerEndTime.ShowUpDown = true;

        }

        public void getPayCodes()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM dbo.tblPayCodes ORDER BY PayCodeDescription", conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourcePayCodes.DataSource = dt;
                comboBoxPayCodes.DataSource = bindingSourcePayCodes;
                comboBoxPayCodes.DisplayMember = "PayCodeDescription";
                comboBoxPayCodes.ValueMember = "PayCodeID";
            }
        }

        public void getExceptionInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT * FROM [MeterShopTimekeeping].[dbo].[tblTimesheetExceptions] WHERE TimesheetExceptionID = @timesheetExceptionID";
                        cmd.Parameters.Add("@timesheetExceptionID", SqlDbType.Int).Value = timesheetExceptionID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                payCodeID = reader.GetInt32(reader.GetOrdinal("PayCodeID"));
                                exceptionStartTime = reader.GetDateTime(reader.GetOrdinal("ExceptionStartTime"));
                                exceptionEndTime = reader.GetDateTime(reader.GetOrdinal("ExceptionEndTime"));
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"UPDATE[dbo].[tblTimesheetExceptions] SET PayCodeID = @payCodeID,ExceptionStartTime = @exceptionStartTime ,ExceptionEndTime = @exceptionEndTime WHERE TimesheetExceptionID = @timesheetExceptionID";
                    cmd.Parameters.Add("@timesheetExceptionID", SqlDbType.Int).Value = timesheetExceptionID;
                    cmd.Parameters.Add("@payCodeID", SqlDbType.Int).Value = Int32.Parse(comboBoxPayCodes.SelectedValue.ToString());
                    cmd.Parameters.Add("@exceptionStartTime", SqlDbType.DateTime).Value = dateTimePickerStartTime.Value;
                    cmd.Parameters.Add("@exceptionEndTime", SqlDbType.DateTime).Value = dateTimePickerEndTime.Value;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            if (frmAddTimeSheet != null)
            {
                frmAddTimeSheet.getExceptions();
            }
            else
            {
                frmEditTimesheet.getExceptions();
            }

            this.Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this exception?";
            string caption = "Confirm Deletion of Exception";
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
                        cmd.CommandText = @"UPDATE[dbo].[tblTimesheetExceptions] SET Active = 0 WHERE TimesheetExceptionID = @timesheetExceptionID";
                        cmd.Parameters.Add("@timesheetExceptionID", SqlDbType.Int).Value = timesheetExceptionID;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    if (frmAddTimeSheet != null)
                    {
                        frmAddTimeSheet.getExceptions();
                    }
                    else
                    {
                        frmEditTimesheet.getExceptions();
                    }

                    this.Dispose();
                }
            }
        }
    }
}
