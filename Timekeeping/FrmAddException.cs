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
    public partial class FrmAddException : Form
    {
        //timesheet variables
        public int timeSheetID;

        private readonly FrmAddTimeSheet frmAddTimeSheet;
        private readonly FrmEditTimesheet frmEditTimesheet;

        public FrmAddException(FrmAddTimeSheet formAddTimeSheet, FrmEditTimesheet formEditTimesheet)
        {
            InitializeComponent();
            frmAddTimeSheet = formAddTimeSheet;
            frmEditTimesheet = formEditTimesheet;
        }

        private void FrmAddException_Load(object sender, EventArgs e)
        {
            getPayCodes();

            dateTimePickerStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartTime.CustomFormat = "hh:mm tt";
            dateTimePickerStartTime.ShowUpDown = true;

            dateTimePickerEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndTime.CustomFormat = "hh:mm tt";
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

                    cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblTimesheetExceptions]([TimesheetID],[PayCodeID],[ExceptionStartTime],[ExceptionEndTime],[Active])VALUES(@timesheetID,@payCodeID,@exceptionStartTime,@exceptionEndTime,1)";
                    cmd.Parameters.Add("@timesheetID", SqlDbType.Int).Value = timeSheetID;
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
    }
}
