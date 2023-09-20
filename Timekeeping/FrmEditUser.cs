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
    public partial class FrmEditUser : Form
    {
        public string empID;
        public string empName;
        public string empTitle;
        public string LANID;
        public int securityLevelID;
        public string emailAddress;
        public DateTime defaultShiftStartTime;
        public DateTime defaultShiftEndTime;

        private readonly FrmUsers frmUsers;

        public FrmEditUser(FrmUsers formUsers)
        {
            InitializeComponent();
            frmUsers = formUsers;
        }

        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            getSecurityLevels();

            getEmployeeInfo();

            textBoxEmployeeID.Text = empID;
            textBoxEmployeeID.Enabled = false;
            textBoxEmployeeName.Text = empName;
            textBoxLANID.Text = LANID;
            textBoxEmailAddress.Text = emailAddress;
            comboBoxSecurityLevel.SelectedValue = securityLevelID;
            textBoxLANID.Enabled = false;
            textBoxEmailAddress.Enabled = false;

            dateTimePickerShiftStart.Value = defaultShiftStartTime;
            dateTimePickerShiftStart.Format = DateTimePickerFormat.Custom;
            dateTimePickerShiftStart.CustomFormat = "hh:mm tt";
            dateTimePickerShiftStart.ShowUpDown = true;

            dateTimePickerShiftEnd.Value = defaultShiftEndTime;
            dateTimePickerShiftEnd.Format = DateTimePickerFormat.Custom;
            dateTimePickerShiftEnd.CustomFormat = "hh:mm tt";
            dateTimePickerShiftEnd.ShowUpDown = true;

        }

        public void getEmployeeInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = "SELECT * FROM dbo.tblUsers WHERE EmpID = @empID";
                        cmd.Parameters.Add("@empID", SqlDbType.VarChar).Value = empID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                empName = reader.GetString(reader.GetOrdinal("EmpName"));
                                empTitle = reader.GetString(reader.GetOrdinal("EmpTitle"));
                                LANID = reader.GetString(reader.GetOrdinal("LanID"));
                                securityLevelID = reader.GetInt32(reader.GetOrdinal("SecurityLevelID"));
                                emailAddress = reader.GetString(reader.GetOrdinal("EmailAddress"));
                                defaultShiftStartTime = reader.GetDateTime(reader.GetOrdinal("DefaultStartTime"));
                                defaultShiftEndTime = reader.GetDateTime(reader.GetOrdinal("DefaultEndTime"));
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

        public void getSecurityLevels()
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                SqlDataAdapter sda = new SqlDataAdapter(@"select * from dbo.tblsecuritylevel", conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                bindingSourceSecurityLevels.DataSource = dt;
                comboBoxSecurityLevel.DataSource = bindingSourceSecurityLevels;
                comboBoxSecurityLevel.DisplayMember = "SecurityLevelDescription";
                comboBoxSecurityLevel.ValueMember = "SecurityLevelID";
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

                    cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblUsers] SET EmpName = @EmpName, SecurityLevelID = @SecurityLevelID , DefaultStartTime = @DefaultStartTime , DefaultEndTime = @DefaultEndTime WHERE EmpID = @EmpID";
                    cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = empID;
                    cmd.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = textBoxEmployeeName.Text.ToString();
                    cmd.Parameters.Add("@SecurityLevelID", SqlDbType.Int).Value = Int32.Parse(comboBoxSecurityLevel.SelectedValue.ToString());
                    cmd.Parameters.Add("@DefaultStartTime", SqlDbType.DateTime).Value = dateTimePickerShiftStart.Value;
                    cmd.Parameters.Add("@DefaultEndTime", SqlDbType.DateTime).Value = dateTimePickerShiftEnd.Value;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }

            frmUsers.getUsers();
            this.Dispose();
        }
    }
}
