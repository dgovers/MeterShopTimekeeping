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
    public partial class FrmEditPayCode : Form
    {
        public int payCodeID;
        public string payCodeAbbreviation;
        public string payCodeDescription;
        public string internalOrderNumber;
        public string costCenter;


        private readonly FrmPayCodes frmPayCodes;

        public FrmEditPayCode(FrmPayCodes formPayCodes)
        {
            InitializeComponent();
            frmPayCodes = formPayCodes;
        }

        private void FrmEditPayCode_Load(object sender, EventArgs e)
        {
            getPayCodeInfo();

            textBoxPayCodeID.Text = payCodeID.ToString();
            textBoxPayCodeID.Enabled = false;

            if (String.IsNullOrEmpty(payCodeAbbreviation) == true)
            {
                textBoxPCAbbreviation.Text = null;
            }
            else
            {
                textBoxPCAbbreviation.Text = payCodeAbbreviation.ToString();
            }

            if (String.IsNullOrEmpty(payCodeDescription) == true)
            {
                textBoxPCDescription.Text = null;
            }
            else
            {
                textBoxPCDescription.Text = payCodeDescription.ToString();
            }

            if (String.IsNullOrEmpty(internalOrderNumber) == true)
            {
                textBoxIO.Text = null;
            }
            else
            {
                textBoxIO.Text = internalOrderNumber.ToString();
            }

            if (String.IsNullOrEmpty(costCenter) == true)
            {
                textBoxCC.Text = null;
            }
            else
            {
                textBoxCC.Text = costCenter.ToString();
            }
        }

        public void getPayCodeInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();

                        cmd.CommandText = "SELECT * FROM dbo.tblPayCodes WHERE PayCodeID = @PayCodeID";
                        cmd.Parameters.Add("@PayCodeID", SqlDbType.Int).Value = payCodeID;
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader["PayCodeAbbreviation"] != DBNull.Value)
                                {
                                    payCodeAbbreviation = reader.GetString(reader.GetOrdinal("PayCodeAbbreviation"));
                                }
                                else
                                {
                                    payCodeAbbreviation = null;
                                }

                                if (reader["PayCodeDescription"] != DBNull.Value)
                                {
                                    payCodeDescription = reader.GetString(reader.GetOrdinal("PayCodeDescription"));
                                }
                                else
                                {
                                    payCodeDescription = null;
                                }

                                if (reader["InternalOrderNumber"] != DBNull.Value)
                                {
                                    internalOrderNumber = reader.GetString(reader.GetOrdinal("InternalOrderNumber"));
                                }
                                else
                                {
                                    internalOrderNumber = null;
                                }

                                if (reader["CostCenter"] != DBNull.Value)
                                {
                                    costCenter = reader.GetString(reader.GetOrdinal("CostCenter"));
                                }
                                else
                                {
                                    costCenter = null;
                                }
                            }
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(dbHandler.GetConnectionString()))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();

                    string paycodeAbbr = textBoxPCAbbreviation.Text.ToString();
                    string payCodeDescription = textBoxPCDescription.Text.ToString();
                    string internalOrderNumber = textBoxIO.Text.ToString();
                    string costCenter = textBoxCC.Text.ToString();

                    cmd.CommandText = @"UPDATE [MeterShopTimekeeping].[dbo].[tblPayCodes] SET PayCodeAbbreviation = @PayCodeAbbreviation, PayCodeDescription = @PayCodeDescription, InternalOrderNumber = @InternalOrderNumber, CostCenter = @CostCenter  WHERE PayCodeID = @PayCodeID";
                    cmd.Parameters.Add("@PayCodeID", SqlDbType.Int).Value = payCodeID;
                    cmd.Parameters.Add("@PayCodeAbbreviation", SqlDbType.VarChar).Value = paycodeAbbr;
                    cmd.Parameters.Add("@PayCodeDescription", SqlDbType.VarChar).Value = payCodeDescription;
                    cmd.Parameters.Add("@InternalOrderNumber", SqlDbType.VarChar).Value = internalOrderNumber;
                    cmd.Parameters.Add("@CostCenter", SqlDbType.VarChar).Value = costCenter;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }
            }
            frmPayCodes.getPayCodes();
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
