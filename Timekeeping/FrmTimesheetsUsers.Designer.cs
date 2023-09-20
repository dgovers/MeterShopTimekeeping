namespace MeterShopTimekeeping
{
    partial class FrmTimesheetsUsers
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTimesheets = new System.Windows.Forms.TabPage();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.advancedDataGridViewTimesheets = new ADGV.AdvancedDataGridView();
            this.btnAddTimesheets = new System.Windows.Forms.Button();
            this.tabPageVacation = new System.Windows.Forms.TabPage();
            this.btnRefreshVacation = new System.Windows.Forms.Button();
            this.btnAddVacation = new System.Windows.Forms.Button();
            this.advancedDataGridViewVacation = new ADGV.AdvancedDataGridView();
            this.bindingSourceTimeSheets = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceVacation = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageTimesheets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTimesheets)).BeginInit();
            this.tabPageVacation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewVacation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeSheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVacation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageTimesheets);
            this.tabControl1.Controls.Add(this.tabPageVacation);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 688);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTimesheets
            // 
            this.tabPageTimesheets.Controls.Add(this.btnClearFilter);
            this.tabPageTimesheets.Controls.Add(this.btnRefresh);
            this.tabPageTimesheets.Controls.Add(this.textBoxTotal);
            this.tabPageTimesheets.Controls.Add(this.lblCount);
            this.tabPageTimesheets.Controls.Add(this.advancedDataGridViewTimesheets);
            this.tabPageTimesheets.Controls.Add(this.btnAddTimesheets);
            this.tabPageTimesheets.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimesheets.Name = "tabPageTimesheets";
            this.tabPageTimesheets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimesheets.Size = new System.Drawing.Size(1092, 662);
            this.tabPageTimesheets.TabIndex = 0;
            this.tabPageTimesheets.Text = "Timesheets";
            this.tabPageTimesheets.UseVisualStyleBackColor = true;
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.Location = new System.Drawing.Point(1011, 7);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(75, 23);
            this.btnClearFilter.TabIndex = 5;
            this.btnClearFilter.Text = "Clear Filter";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(930, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTotal.Enabled = false;
            this.textBoxTotal.Location = new System.Drawing.Point(46, 636);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotal.TabIndex = 3;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(6, 636);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(34, 13);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "Total:";
            // 
            // advancedDataGridViewTimesheets
            // 
            this.advancedDataGridViewTimesheets.AllowUserToAddRows = false;
            this.advancedDataGridViewTimesheets.AllowUserToDeleteRows = false;
            this.advancedDataGridViewTimesheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridViewTimesheets.AutoGenerateContextFilters = true;
            this.advancedDataGridViewTimesheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewTimesheets.DateWithTime = false;
            this.advancedDataGridViewTimesheets.Location = new System.Drawing.Point(6, 36);
            this.advancedDataGridViewTimesheets.Name = "advancedDataGridViewTimesheets";
            this.advancedDataGridViewTimesheets.ReadOnly = true;
            this.advancedDataGridViewTimesheets.Size = new System.Drawing.Size(1080, 597);
            this.advancedDataGridViewTimesheets.TabIndex = 1;
            this.advancedDataGridViewTimesheets.TimeFilter = false;
            this.advancedDataGridViewTimesheets.SortStringChanged += new System.EventHandler(this.advancedDataGridViewTimesheets_SortStringChanged);
            this.advancedDataGridViewTimesheets.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewTimesheets_FilterStringChanged);
            this.advancedDataGridViewTimesheets.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewTimesheets_CellMouseDoubleClick);
            // 
            // btnAddTimesheets
            // 
            this.btnAddTimesheets.Location = new System.Drawing.Point(6, 7);
            this.btnAddTimesheets.Name = "btnAddTimesheets";
            this.btnAddTimesheets.Size = new System.Drawing.Size(100, 23);
            this.btnAddTimesheets.TabIndex = 0;
            this.btnAddTimesheets.Text = "Add Timesheet";
            this.btnAddTimesheets.UseVisualStyleBackColor = true;
            this.btnAddTimesheets.Click += new System.EventHandler(this.btnAddTimesheets_Click);
            // 
            // tabPageVacation
            // 
            this.tabPageVacation.Controls.Add(this.btnRefreshVacation);
            this.tabPageVacation.Controls.Add(this.btnAddVacation);
            this.tabPageVacation.Controls.Add(this.advancedDataGridViewVacation);
            this.tabPageVacation.Location = new System.Drawing.Point(4, 22);
            this.tabPageVacation.Name = "tabPageVacation";
            this.tabPageVacation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVacation.Size = new System.Drawing.Size(1092, 662);
            this.tabPageVacation.TabIndex = 1;
            this.tabPageVacation.Text = "Vacation";
            this.tabPageVacation.UseVisualStyleBackColor = true;
            // 
            // btnRefreshVacation
            // 
            this.btnRefreshVacation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshVacation.Location = new System.Drawing.Point(1011, 6);
            this.btnRefreshVacation.Name = "btnRefreshVacation";
            this.btnRefreshVacation.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshVacation.TabIndex = 2;
            this.btnRefreshVacation.Text = "Refresh";
            this.btnRefreshVacation.UseVisualStyleBackColor = true;
            this.btnRefreshVacation.Click += new System.EventHandler(this.btnRefreshVacation_Click);
            // 
            // btnAddVacation
            // 
            this.btnAddVacation.Location = new System.Drawing.Point(6, 6);
            this.btnAddVacation.Name = "btnAddVacation";
            this.btnAddVacation.Size = new System.Drawing.Size(113, 23);
            this.btnAddVacation.TabIndex = 1;
            this.btnAddVacation.Text = "Request Vacation";
            this.btnAddVacation.UseVisualStyleBackColor = true;
            this.btnAddVacation.Click += new System.EventHandler(this.btnAddVacation_Click);
            // 
            // advancedDataGridViewVacation
            // 
            this.advancedDataGridViewVacation.AllowUserToAddRows = false;
            this.advancedDataGridViewVacation.AllowUserToDeleteRows = false;
            this.advancedDataGridViewVacation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridViewVacation.AutoGenerateContextFilters = true;
            this.advancedDataGridViewVacation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewVacation.DateWithTime = false;
            this.advancedDataGridViewVacation.Location = new System.Drawing.Point(6, 34);
            this.advancedDataGridViewVacation.Name = "advancedDataGridViewVacation";
            this.advancedDataGridViewVacation.ReadOnly = true;
            this.advancedDataGridViewVacation.Size = new System.Drawing.Size(1080, 622);
            this.advancedDataGridViewVacation.TabIndex = 0;
            this.advancedDataGridViewVacation.TimeFilter = false;
            this.advancedDataGridViewVacation.SortStringChanged += new System.EventHandler(this.advancedDataGridViewVacation_SortStringChanged);
            this.advancedDataGridViewVacation.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewVacation_FilterStringChanged);
            this.advancedDataGridViewVacation.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewVacation_CellMouseDoubleClick);
            // 
            // FrmTimesheetsUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 713);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmTimesheetsUsers";
            this.Text = "Employee";
            this.Load += new System.EventHandler(this.FrmTimesheets_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageTimesheets.ResumeLayout(false);
            this.tabPageTimesheets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTimesheets)).EndInit();
            this.tabPageVacation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewVacation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeSheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVacation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTimesheets;
        private System.Windows.Forms.TabPage tabPageVacation;
        private ADGV.AdvancedDataGridView advancedDataGridViewTimesheets;
        private System.Windows.Forms.Button btnAddTimesheets;
        private System.Windows.Forms.Button btnAddVacation;
        private ADGV.AdvancedDataGridView advancedDataGridViewVacation;
        private System.Windows.Forms.BindingSource bindingSourceTimeSheets;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.BindingSource bindingSourceVacation;
        private System.Windows.Forms.Button btnRefreshVacation;
    }
}