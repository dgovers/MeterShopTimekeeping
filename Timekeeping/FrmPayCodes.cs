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
    public partial class FrmPayCodes : Form
    {
        public FrmPayCodes()
        {
            InitializeComponent();
        }

        private void FrmPayCodes_Load(object sender, EventArgs e)
        {
            getPayCodes();
        }

        public void getPayCodes()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = @"SELECT * FROM [MeterShopTimekeeping].[dbo].[tblPayCodes] ORDER BY PayCodeAbbreviation";
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    bindingSourcePayCodes.DataSource = dt;
                    advancedDataGridViewPayCodes.DataSource = bindingSourcePayCodes;
                    advancedDataGridViewPayCodes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;;
                    conn.Close();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FrmAddPayCode frmAddPayCode = new FrmAddPayCode(this);
            frmAddPayCode.Show();
        }

        private void advancedDataGridViewPayCodes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditPayCode frmEditPayCode = new FrmEditPayCode(this);
            frmEditPayCode.payCodeID = Int32.Parse(advancedDataGridViewPayCodes.CurrentRow.Cells["PayCodeID"].Value.ToString());
            frmEditPayCode.Show();
        }

        private void advancedDataGridViewPayCodes_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourcePayCodes.Filter = advancedDataGridViewPayCodes.FilterString;
        }

        private void advancedDataGridViewPayCodes_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourcePayCodes.Sort = advancedDataGridViewPayCodes.SortString;
        }
    }
}
