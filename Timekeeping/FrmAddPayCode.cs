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
    public partial class FrmAddPayCode : Form
    {
        private readonly FrmPayCodes frmPayCodes;

        public FrmAddPayCode(FrmPayCodes formPayCodes)
        {
            InitializeComponent();
            frmPayCodes = formPayCodes;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxPCAbbreviation.TextLength > 3)
            {
                MessageBox.Show("PayCodeAbbreviation must be less than four characters");
            }
            //insert
            else
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

                        cmd.CommandText = @"INSERT INTO [MeterShopTimekeeping].[dbo].[tblPayCodes](PayCodeAbbreviation,PayCodeDescription,InternalOrderNumber,CostCenter)VALUES(@PayCodeAbbreviation,@PayCodeDescription,@InternalOrderNumber,@CostCenter)";
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
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
