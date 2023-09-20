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
    public partial class FrmAddVacationComment : Form
    {
        public int vacationID;

        //current user variables
        public string currentUserNameLANID = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public string currentUserEmpID;

        private readonly FrmEditVacation frmEditVacation;

        public FrmAddVacationComment(FrmEditVacation formEditVacation)
        {
            InitializeComponent();
            frmEditVacation = formEditVacation;
        }

        private void FrmAddVacationComment_Load(object sender, EventArgs e)
        {
            getCurrentUserInfo();
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
                        cmd.CommandText = "SELECT EmpID FROM dbo.tblUsers WHERE LANID = @userLanID";
                        cmd.Parameters.Add("@userLanID", SqlDbType.VarChar).Value = currentUserNameLANID;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                currentUserEmpID = reader.GetString(reader.GetOrdinal("EmpID"));
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

                    cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblVacationComments](VacationCommentsTimestamp,VacationID,EmpID,Comment)VALUES(getdate(),@vacationID,@empID,@comment)";
                    cmd.Parameters.Add("@vacationID", SqlDbType.Int).Value = vacationID;
                    cmd.Parameters.Add("@empID", SqlDbType.VarChar).Value = currentUserEmpID.ToString();
                    cmd.Parameters.Add("@comment", SqlDbType.Text).Value = richTextBoxComment.Text.ToString();
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            this.Dispose();
        }
    }
}
