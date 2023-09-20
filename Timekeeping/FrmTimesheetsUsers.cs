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
    public partial class FrmTimesheetsUsers : Form
    {
        public int securityGroup;
        public string userLanID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string empID;
        public string empName;
        public int timeSheetID;


        public FrmTimesheetsUsers()
        {
            InitializeComponent();
        }

        private void FrmTimesheets_Load(object sender, EventArgs e)
        {
            frmLoad();
        }

        public void frmLoad()
        {
            getUserInfo();
            getCurrentUserTimesheets();
            getCurrentUserVacationDates();
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
                        cmd.CommandText = "SELECT EmpID,EmpName,SecurityLevelID FROM dbo.tblUsers WHERE LANID = @userLanID";
                        cmd.Parameters.Add("@userLanID", SqlDbType.VarChar).Value = userLanID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                empID = reader.GetString(reader.GetOrdinal("EmpID"));
                                empName = reader.GetString(reader.GetOrdinal("EmpName"));
                                securityGroup = reader.GetInt32(reader.GetOrdinal("SecurityLevelID"));
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

        public void getCurrentUserTimesheets()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SET DATEFIRST 7 ; SELECT * FROM dbo.vwTimesheets WHERE EmployeeID = @empID ORDER BY TimesheetID DESC";
                    cmd.Parameters.Add("@empID", SqlDbType.VarChar).Value = empID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    bindingSourceTimeSheets.DataSource = dt;
                    advancedDataGridViewTimesheets.DataSource = bindingSourceTimeSheets;
                    advancedDataGridViewTimesheets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    advancedDataGridViewTimesheets.Columns["EmployeeID"].Visible = false;
                    textBoxTotal.Text = advancedDataGridViewTimesheets.RowCount.ToString();
                    conn.Close();
                }
            }
        }

        public void getCurrentUserVacationDates()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT * FROM dbo.vwVacations WHERE EmpID = @empID";
                    cmd.Parameters.Add("@empID", SqlDbType.VarChar).Value = empID;
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    bindingSourceVacation.DataSource = dt;
                    advancedDataGridViewVacation.DataSource = bindingSourceVacation;
                    advancedDataGridViewVacation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    advancedDataGridViewVacation.Columns["EmpID"].Visible = false;
                    advancedDataGridViewVacation.Columns["VacationID"].Visible = false;
                    conn.Close();
                }
            }
        }

        private void btnAddTimesheets_Click(object sender, EventArgs e)
        {
            FrmAddTimeSheet frmAddTimeSheet = new FrmAddTimeSheet(this,null);
            frmAddTimeSheet.Show();
        }

        private void btnAddVacation_Click(object sender, EventArgs e)
        {
            FrmAddVacation frmAddVacation = new FrmAddVacation(this,null,null);
            frmAddVacation.Show();           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmLoad();
        }

        private void advancedDataGridViewTimesheets_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Filter = advancedDataGridViewTimesheets.FilterString;
            textBoxTotal.Text = advancedDataGridViewTimesheets.RowCount.ToString();
        }

        private void advancedDataGridViewTimesheets_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Sort = advancedDataGridViewTimesheets.SortString;
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Filter = null;
            advancedDataGridViewTimesheets.ClearFilter();
            advancedDataGridViewTimesheets.ClearSort();
            frmLoad();
        }

        private void advancedDataGridViewTimesheets_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditTimesheet frmEditTimesheet = new FrmEditTimesheet(this,null,null);
            frmEditTimesheet.timeSheetID = Int32.Parse(advancedDataGridViewTimesheets.CurrentRow.Cells["TimesheetID"].Value.ToString());
            frmEditTimesheet.Show();
        }

        private void btnRefreshVacation_Click(object sender, EventArgs e)
        {
            getCurrentUserVacationDates();
        }

        private void advancedDataGridViewVacation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditVacation frmEditVacation = new FrmEditVacation(this,null);
            frmEditVacation.vacationID = Int32.Parse(advancedDataGridViewVacation.CurrentRow.Cells["VacationID"].Value.ToString());
            frmEditVacation.Show();
        }

        private void advancedDataGridViewVacation_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceVacation.Filter = advancedDataGridViewVacation.FilterString;
        }

        private void advancedDataGridViewVacation_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceVacation.Sort = advancedDataGridViewVacation.SortString;
        }
    }
}
