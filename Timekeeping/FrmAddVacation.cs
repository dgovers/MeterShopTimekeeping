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
    public partial class FrmAddVacation : Form
    {
        public int currentUserSecurityLevelID;
        public string currentUserLanID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;
        public string currentUserEmpName;


        private readonly FrmTimesheetsUsers frmTimesheetsUsers;
        private readonly FrmEditTimesheet frmEditTimesheet;
        private readonly FrmTimesheetsApprovers frmTimesheetsApprovers;

        public FrmAddVacation(FrmTimesheetsUsers formTimesheetsUsers, FrmEditTimesheet formEditTimesheet, FrmTimesheetsApprovers formTimesheetsApprovers)
        {
            InitializeComponent();
            frmTimesheetsUsers = formTimesheetsUsers;
            frmEditTimesheet = formEditTimesheet;
            frmTimesheetsApprovers = formTimesheetsApprovers;
        }

        private void FrmAddVacation_Load(object sender, EventArgs e)
        {
            dateTimePickerStartDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartDate.CustomFormat = "MM/dd/yyyy";
            //dateTimePickerStartDate.ShowUpDown = true;

            dateTimePickerEndDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerEndDate.CustomFormat = "MM/dd/yyyy";
            //dateTimePickerEndDate.ShowUpDown = true;


            //used for form control logic
            getCurrentUserInfo();

            if (currentUserSecurityLevelID == 1)//users
            {
                //populates the employee drop-down menu
                getUsers();

                comboBoxEmployeeName.Enabled = false;
                comboBoxEmployeeName.SelectedValue = currentUserEmpID;

                getCurrentUserInfo();
            }
            else //approvers adn timekeepers
            {
                comboBoxEmployeeName.Enabled = true;

                //populates the employee drop-down menu
                getUsers();
                getCurrentUserInfo();

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
                        cmd.CommandText = "SELECT EmpID,EmpName,SecurityLevelID FROM dbo.tblUsers WHERE LANID = @userLanID";
                        cmd.Parameters.Add("@userLanID", SqlDbType.VarChar).Value = currentUserLanID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                currentUserEmpID = reader.GetString(reader.GetOrdinal("EmpID"));
                                currentUserEmpName = reader.GetString(reader.GetOrdinal("EmpName"));
                                    currentUserSecurityLevelID = reader.GetInt32(reader.GetOrdinal("SecurityLevelID"));
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

        public void getUsers()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM dbo.tblUsers WHERE SecurityLevelID = 1 ORDER BY EmpName", conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceUsers.DataSource = dt;
                comboBoxEmployeeName.DataSource = bindingSourceUsers;
                comboBoxEmployeeName.DisplayMember = "EmpName";
                comboBoxEmployeeName.ValueMember = "EmpID";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblVacation](EmpID,VacationStartDateTime,VacationEndDateTime,VacationStatus,Active)VALUES(@empID,@vacationStartDateTime,@vacationEndDateTime,1,1)";
                    cmd.Parameters.Add("@empID", SqlDbType.VarChar).Value = comboBoxEmployeeName.SelectedValue.ToString();
                    cmd.Parameters.Add("@vacationStartDateTime", SqlDbType.DateTime).Value = dateTimePickerStartDate.Value;
                    cmd.Parameters.Add("@vacationEndDateTime", SqlDbType.DateTime).Value = dateTimePickerEndDate.Value;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            if (frmTimesheetsUsers != null)
            {
                frmTimesheetsUsers.getCurrentUserVacationDates();
            }
            else
            {
                frmTimesheetsApprovers.getVacations();
            }
            this.Dispose();
        }
    }
}
