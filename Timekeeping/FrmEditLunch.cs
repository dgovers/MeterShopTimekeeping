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
    public partial class FrmEditLunch : Form
    {

        public int lunchID;
        public DateTime startTime;
        public DateTime endTime;

        private readonly FrmAddTimeSheet frmAddTimeSheet;
        private readonly FrmEditTimesheet frmEditTimesheet;

        public FrmEditLunch(FrmAddTimeSheet formAddTimeSheet,FrmEditTimesheet formEditTimesheet)
        {
            InitializeComponent();

            frmAddTimeSheet = formAddTimeSheet;
            frmEditTimesheet = formEditTimesheet;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditLunch_Load(object sender, EventArgs e)
        {
            dateTimePickerLunchStartTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerLunchStartTime.CustomFormat = "hh:mm tt";
            dateTimePickerLunchStartTime.ShowUpDown = true;

            dateTimePickerLunchEndTime.Format = DateTimePickerFormat.Custom;
            dateTimePickerLunchEndTime.CustomFormat = "hh:mm tt";
            dateTimePickerLunchEndTime.ShowUpDown = true;


            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT * FROM dbo.tblLunches WHERE LunchID = @lunchID";
                    cmd.Parameters.Add("@lunchID", SqlDbType.Int).Value = lunchID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            startTime = reader.GetDateTime(reader.GetOrdinal("LunchStartTime"));
                            endTime = reader.GetDateTime(reader.GetOrdinal("LunchEndTime"));

                        }
                    }

                    dateTimePickerLunchStartTime.Value = startTime;
                    dateTimePickerLunchEndTime.Value = endTime;

                    conn.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"UPDATE dbo.tblLunches SET LunchStartTime = @lunchStartTime, LunchEndTime = @lunchEndTime WHERE LunchID = @lunchID";
                    cmd.Parameters.Add("@lunchID", SqlDbType.Int).Value = lunchID;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this lunch?";
            string caption = "Confirm Deletion of Lunch";
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
                        cmd.CommandText = @"UPDATE dbo.tblLunches SET Active = 0 WHERE LunchID = @LunchID";
                        cmd.Parameters.Add("@LunchID", SqlDbType.Int).Value = lunchID;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Lunch deleted successfully!");
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
            else
            {
                //nothing
            }
        }
    }
}
