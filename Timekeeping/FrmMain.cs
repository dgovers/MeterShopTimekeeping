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
    public partial class FrmMain : Form
    {

        public int securityLevel;
        public string lanID;
        public string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string empID;
        public string empName;

        public int timeSheetID;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            frmLoad();
        }

        public void frmLoad()
        {
            getCurrentUserInfo();


            if(securityLevel == 1) //user
            {
                usersToolStripMenuItem.Visible = false;
                timesheetsToolStripMenuItem.Visible = false;
                payCodesToolStripMenuItem.Visible = false;

                FrmTimesheetsUsers frmTimesheets = new FrmTimesheetsUsers();
                frmTimesheets.MdiParent = this;
                frmTimesheets.WindowState = FormWindowState.Maximized;
                frmTimesheets.Show();

            }

            else if (securityLevel == 2) //approver
            {
                FrmTimesheetsApprovers frmTimesheetsApprovers = new FrmTimesheetsApprovers();
                frmTimesheetsApprovers.MdiParent = this;
                frmTimesheetsApprovers.WindowState = FormWindowState.Maximized;
                frmTimesheetsApprovers.Show();
            }

            else //timekeeper
            {
                usersToolStripMenuItem.Visible = false;
                timesheetsToolStripMenuItem.Visible = false;
                payCodesToolStripMenuItem.Visible = false;

                FrmTimesheetsTimeKeepers frmTimesheetsTimeKeepers = new FrmTimesheetsTimeKeepers();
                frmTimesheetsTimeKeepers.MdiParent = this;
                frmTimesheetsTimeKeepers.WindowState = FormWindowState.Maximized;
                frmTimesheetsTimeKeepers.Show();

            }

        }

        public void getCurrentUserInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT EmpID,EmpName,SecurityLevelID FROM dbo.tblUsers WHERE LANID = @user";
                        cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                empID = reader.GetString(reader.GetOrdinal("EmpID"));
                                empName = reader.GetString(reader.GetOrdinal("EmpName"));
                                securityLevel = reader.GetInt32(reader.GetOrdinal("SecurityLevelID"));
                            }
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("Permission Denied. Please contact your system administrator for access.");
                            System.Windows.Forms.Application.Exit();
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Permission Denied. Please contact your system administrator for access.", MessageBoxButtons.OK, MessageBoxIcon.Error);//display error message with exception 
            }

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmAddTimeSheet frmAddTimeSheet = new FrmAddTimeSheet(null,);
            //frmAddTimeSheet.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.MdiParent = this;
            frmUsers.WindowState = FormWindowState.Maximized;
            frmUsers.Show();  
        }

        private void timesheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoad();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void payCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPayCodes frmPayCodes = new FrmPayCodes();
            frmPayCodes.Show();
        }
    }
}
