namespace MeterShopTimekeeping
{
    partial class FrmPayCodes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPayCodes));
            this.advancedDataGridViewPayCodes = new ADGV.AdvancedDataGridView();
            this.bindingSourcePayCodes = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewPayCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePayCodes)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridViewPayCodes
            // 
            this.advancedDataGridViewPayCodes.AllowUserToAddRows = false;
            this.advancedDataGridViewPayCodes.AllowUserToDeleteRows = false;
            this.advancedDataGridViewPayCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridViewPayCodes.AutoGenerateContextFilters = true;
            this.advancedDataGridViewPayCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewPayCodes.DateWithTime = false;
            this.advancedDataGridViewPayCodes.Location = new System.Drawing.Point(12, 46);
            this.advancedDataGridViewPayCodes.Name = "advancedDataGridViewPayCodes";
            this.advancedDataGridViewPayCodes.ReadOnly = true;
            this.advancedDataGridViewPayCodes.Size = new System.Drawing.Size(776, 392);
            this.advancedDataGridViewPayCodes.TabIndex = 0;
            this.advancedDataGridViewPayCodes.TimeFilter = false;
            this.advancedDataGridViewPayCodes.SortStringChanged += new System.EventHandler(this.advancedDataGridViewPayCodes_SortStringChanged);
            this.advancedDataGridViewPayCodes.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewPayCodes_FilterStringChanged);
            this.advancedDataGridViewPayCodes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewPayCodes_CellMouseDoubleClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(713, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // FrmPayCodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.advancedDataGridViewPayCodes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPayCodes";
            this.Text = "Pay Codes";
            this.Load += new System.EventHandler(this.FrmPayCodes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewPayCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcePayCodes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView advancedDataGridViewPayCodes;
        private System.Windows.Forms.BindingSource bindingSourcePayCodes;
        private System.Windows.Forms.Button buttonAdd;
    }
}