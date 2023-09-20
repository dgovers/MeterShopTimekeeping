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
    public partial class FrmTimesheetsTimeKeepers : Form
    {
        public FrmTimesheetsTimeKeepers()
        {
            InitializeComponent();
        }

        private void FrmTimesheetsTimeKeepers_Load(object sender, EventArgs e)
        {
            frmLoad();
        }

        public void frmLoad()
        {
            if(checkBoxShowAll.Checked == true)
            {
                labelStartDate.Visible = true;
                dateTimePickerStartDate.Visible = true;
                labelEndDate.Visible = true;
                dateTimePickerEndDate.Visible = true;
                buttonQuery.Visible = true;

                getAllTimesheets();
            }
            else
            {
                labelStartDate.Visible = false;
                dateTimePickerStartDate.Visible = false;
                labelEndDate.Visible = false;
                dateTimePickerEndDate.Visible = false;
                buttonQuery.Visible = false;
                getApprovedTimesheets();
            }
        }

        private void checkBoxShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowAll.Checked == true)
            {
                labelStartDate.Visible = true;
                dateTimePickerStartDate.Visible = true;
                labelEndDate.Visible = true;
                dateTimePickerEndDate.Visible = true;
                buttonQuery.Visible = true;

                //getAllTimesheets();
            }
            else
            {
                labelStartDate.Visible = false;
                dateTimePickerStartDate.Visible = false;
                labelEndDate.Visible = false;
                dateTimePickerEndDate.Visible = false;
                buttonQuery.Visible = false;

                getApprovedTimesheets();
            }
        }

        public void getApprovedTimesheets()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SET DATEFIRST 7;  SELECT * FROM [MeterShopTimekeeping].[dbo].[vwTimesheets] WHERE Status IN('APPROVED') ORDER BY WorkDate DESC";
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    bindingSourceTimeSheets.DataSource = dt;
                    advancedDataGridViewTimesheets.DataSource = bindingSourceTimeSheets;
                    advancedDataGridViewTimesheets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    txtBoxCount.Text = advancedDataGridViewTimesheets.RowCount.ToString();
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
                        cmd.CommandText = @"SET DATEFIRST 7; SELECT * FROM [MeterShopTimekeeping].[dbo].[vwTimesheets] WHERE CAST(WorkDate as date) BETWEEN CAST(@startDate as date) AND CAST(@endtDate as date) ORDER BY WorkDate DESC";
                        cmd.Parameters.Add("@startDate", SqlDbType.VarChar).Value = dateTimePickerStartDate.Value;
                        cmd.Parameters.Add("@endtDate", SqlDbType.VarChar).Value = dateTimePickerEndDate.Value;
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        bindingSourceTimeSheets.DataSource = dt;
                        advancedDataGridViewTimesheets.DataSource = bindingSourceTimeSheets;
                        advancedDataGridViewTimesheets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        txtBoxCount.Text = advancedDataGridViewTimesheets.RowCount.ToString();
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Start date must be before or equal to end date.");
            }
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            getAllTimesheets();
        }

        private void advancedDataGridViewTimesheets_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditTimesheet frmEditTimesheet = new FrmEditTimesheet(null,null,this);
            frmEditTimesheet.timeSheetID = Int32.Parse(advancedDataGridViewTimesheets.CurrentRow.Cells["TimesheetID"].Value.ToString());
            frmEditTimesheet.Show();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.frmLoad();
        }

        private void advancedDataGridViewTimesheets_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Filter = advancedDataGridViewTimesheets.FilterString;
            txtBoxCount.Text = advancedDataGridViewTimesheets.RowCount.ToString();
        }

        private void advancedDataGridViewTimesheets_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Sort = advancedDataGridViewTimesheets.SortString;
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            bindingSourceTimeSheets.Filter = null;
            advancedDataGridViewTimesheets.ClearFilter();
            advancedDataGridViewTimesheets.ClearSort();
            this.frmLoad();
        }
    }
}
