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
    public partial class FrmAddLunch : Form
    {
        //timesheet variables
        public int timeSheetID;

        private readonly FrmAddTimeSheet frmAddTimeSheet;
        private readonly FrmEditTimesheet frmEditTimesheet;


        public FrmAddLunch(FrmAddTimeSheet formAddTimeSheet, FrmEditTimesheet formEditTimesheet)
        {
            InitializeComponent();
            frmAddTimeSheet = formAddTimeSheet;
            frmEditTimesheet = formEditTimesheet;
        }

        private void FrmAddLunch_Load(object sender, EventArgs e)
        {
            dateTimePickerLunchStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerLunchStartTime.CustomFormat = "hh:mm tt";
            dateTimePickerLunchStartTime.ShowUpDown = true;

            dateTimePickerLunchEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerLunchEndTime.CustomFormat = "hh:mm tt";
            dateTimePickerLunchEndTime.ShowUpDown = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblLunches](TimesheetID,LunchStartTime,LunchEndTime,Active)VALUES(@timeSheetID,@lunchStartTime,@lunchEndTime,1)";
                    cmd.Parameters.Add("@timeSheetID", SqlDbType.Int).Value = timeSheetID;
                    cmd.Parameters.Add("@lunchStartTime", SqlDbType.DateTime).Value = dateTimePickerLunchStartTime.Value.ToString();
                    cmd.Parameters.Add("@lunchEndTime", SqlDbType.DateTime).Value = dateTimePickerLunchEndTime.Value.ToString();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            if (frmAddTimeSheet != null)
            {
                frmAddTimeSheet.getLunches();
            }
            else
            {
                frmEditTimesheet.getLunches();
            }
            this.Dispose();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
