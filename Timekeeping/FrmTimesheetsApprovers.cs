
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
    public partial class FrmTimesheetsApprovers : Form
    {
        public FrmTimesheetsApprovers()
        {
            InitializeComponent();
        }

        private void FrmTimesheetsElevated_Load(object sender, EventArgs e)
        {
            lblStartDate.Visible = false;
            dateTimePickerStartDate.Visible = false;
            lblEndDate.Visible = false;
            dateTimePickerEndDate.Visible = false;
            btnQuery.Visible = false;

            frmLoad();
        }


        public void frmLoad()
        {
            if (checkBoxShowAll.Checked == true)
            {
                lblStartDate.Visible = true;
                dateTimePickerStartDate.Visible = true;
                lblEndDate.Visible = true;
                dateTimePickerEndDate.Visible = true;
                btnQuery.Visible = true;

                getAllTimesheets();
            }
            else
            {
                lblStartDate.Visible = false;
                dateTimePickerStartDate.Visible = false;
                lblEndDate.Visible = false;
                dateTimePickerEndDate.Visible = false;
                btnQuery.Visible = false;

                getPendingApprovalTimesheets();
            }

            getSickDays();

            getVacations();
        }

        public void getPendingApprovalTimesheets()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SET DATEFIRST 7; SELECT * FROM [MeterShopTimekeeping].[dbo].[vwTimesheets] WHERE Status IN('PENDING APPROVAL','RECALL REQUESTED') ORDER BY WorkDate DESC";
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    bindingSourceTimeSheets.DataSource = dt;
                    advancedDataGridViewTimesheets.DataSource = bindingSourceTimeSheets;
                    advancedDataGridViewTimesheets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //txtBoxCount.Text = advancedDataGridViewTimesheets.RowCount.ToString();
                    conn.Close();
                }
            }
        }

        public void getAllTimesheets()
        {
            if (dateTimePickerStartDate.Value <= dateTimePickerEndDate.Value)
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = @"SELECT * FROM [MeterShopTimekeeping].[dbo].[vwTimesheets] WHERE CAST(WorkDate as date) BETWEEN CAST(@startDate as date) AND CAST(@endtDate as date) ORDER BY WorkDate DESC";
                        cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = dateTimePickerStartDate.Value;
                        cmd.Parameters.Add("@endtDate", SqlDbType.VarChar).Value = dateTimePickerEndDate.Value;
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        bindingSourceTimeSheets.DataSource = dt;
                        advancedDataGridViewTimesheets.DataSource = bindingSourceTimeSheets;
                        advancedDataGridViewTimesheets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        //txtBoxCount.Text = advancedDataGridViewTimesheets.RowCount.ToString();
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Start date must be before or equal to end date.");
            }
        }

        public void getSickDays()
        {
            if (dateTimePickerStartDate.Value <= dateTimePickerEndDate.Value)
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = @"SELECT * FROM vwSickDays ORDER BY WorkDate DESC";
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        bindingSourceSickDays.DataSource = dt;
                        advancedDataGridViewSickManagement.DataSource = bindingSourceSickDays;
                        advancedDataGridViewSickManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        //txtBoxCount.Text = advancedDataGridViewTimesheets.RowCount.ToString();
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Start date must be before or equal to end date.");
            }
        }

        public void getVacations()
        {
            if (dateTimePickerStartDate.Value <= dateTimePickerEndDate.Value)
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = @"SELECT * FROM vwVacations";
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        bindingSourceVacations.DataSource = dt;
                        advancedDataGridViewVacation.DataSource = bindingSourceVacations;
                        advancedDataGridViewVacation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        //txtBoxCount.Text = advancedDataGridViewTimesheets.RowCount.ToString();
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Start date must be before or equal to end date.");
            }
        }

        private void checkBoxShowAll_CheckStateChanged(object sender, EventArgs e)
        {

            if (checkBoxShowAll.Checked == true)
            {
                lblStartDate.Visible = true;
                dateTimePickerStartDate.Visible = true;
                lblEndDate.Visible = true;
                dateTimePickerEndDate.Visible = true;
                btnQuery.Visible = true;

                getAllTimesheets();
            }
            else
            {
                lblStartDate.Visible = false;
                dateTimePickerStartDate.Visible = false;
                lblEndDate.Visible = false;
                dateTimePickerEndDate.Visible = false;
                btnQuery.Visible = false;

                getPendingApprovalTimesheets();
            }

        }

        private void btnAddTimesheets_Click(object sender, EventArgs e)
        {
            FrmAddTimeSheet frmAddTimeSheet = new FrmAddTimeSheet(null,this);
            frmAddTimeSheet.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmLoad();
        }

        private void advancedDataGridViewTimesheets_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditTimesheet frmEditTimesheet = new FrmEditTimesheet(null,this,null);
            frmEditTimesheet.timeSheetID = Int32.Parse(advancedDataGridViewTimesheets.CurrentRow.Cells["TimesheetID"].Value.ToString());
            frmEditTimesheet.Show();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            getAllTimesheets();
        }

        private void btnAddSickDay_Click(object sender, EventArgs e)
        {
            FrmApproverAddSickDay frmApproverAddSickDay = new FrmApproverAddSickDay(this);
            frmApproverAddSickDay.Show();
        }

        private void advancedDataGridViewTimesheets_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Sort = advancedDataGridViewTimesheets.SortString;
        }

        private void advancedDataGridViewTimesheets_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Filter = advancedDataGridViewTimesheets.FilterString;
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Filter = null;
            advancedDataGridViewTimesheets.ClearFilter();
            advancedDataGridViewTimesheets.ClearSort();
            frmLoad();
        }

        private void advancedDataGridViewSickManagement_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceSickDays.Filter = advancedDataGridViewSickManagement.FilterString;
        }

        private void advancedDataGridViewSickManagement_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceSickDays.Sort = advancedDataGridViewSickManagement.SortString;
        }

        private void btnAddVacation_Click(object sender, EventArgs e)
        {
            FrmAddVacation frmAddVacation = new FrmAddVacation(null,null,this);
            frmAddVacation.Show();
        }

        private void advancedDataGridViewVacation_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditVacation frmEditVacation = new FrmEditVacation(null,this);
            frmEditVacation.vacationID = Int32.Parse(advancedDataGridViewVacation.CurrentRow.Cells["VacationID"].Value.ToString());
            frmEditVacation.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.getVacations();
        }

        private void advancedDataGridViewVacation_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceVacations.Filter = advancedDataGridViewVacation.FilterString;
        }

        private void advancedDataGridViewVacation_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceVacations.Sort = advancedDataGridViewVacation.SortString;
        }
    }
}
