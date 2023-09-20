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
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            frmLoad();
        }

        public void frmLoad()
        {

            getUsers();
        }

        public void getUsers()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(
                    @"SELECT * FROM dbo.vwUsers ORDER BY EmployeeNumber"
                    , conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceUsers.DataSource = dt;
                advancedDataGridViewUsers.DataSource = bindingSourceUsers;
                advancedDataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                textBoxCount.Text = advancedDataGridViewUsers.RowCount.ToString();
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddUser frmAddUser = new FrmAddUser(this);
            frmAddUser.ShowDialog();
        }

        private void advancedDataGridViewUsers_SortStringChanged(object sender, EventArgs e)
        {
            bindingSourceUsers.Sort = advancedDataGridViewUsers.SortString;
        }

        private void advancedDataGridViewUsers_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSourceUsers.Filter = advancedDataGridViewUsers.FilterString;
            textBoxCount.Text = advancedDataGridViewUsers.RowCount.ToString();
        }

        private void advancedDataGridViewUsers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FrmEditUser frmEditUser = new FrmEditUser(this);
            frmEditUser.empID = advancedDataGridViewUsers.CurrentRow.Cells["EmployeeNumber"].Value.ToString();
            frmEditUser.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            getUsers();
        }
    }
}
