namespace MeterShopTimekeeping
{
    partial class FrmTimesheetsApprovers
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
            this.advancedDataGridViewTimesheets = new ADGV.AdvancedDataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTimesheets = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.checkBoxShowAll = new System.Windows.Forms.CheckBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnAddTimesheets = new System.Windows.Forms.Button();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.advancedDataGridViewSickManagement = new ADGV.AdvancedDataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSickDay = new System.Windows.Forms.Button();
            this.tabPageVacation = new System.Windows.Forms.TabPage();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.btnAddVacation = new System.Windows.Forms.Button();
            this.advancedDataGridViewVacation = new ADGV.AdvancedDataGridView();
            this.bindingSourceTimeSheets = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceSickDays = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceVacations = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTimesheets)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageTimesheets.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewSickManagement)).BeginInit();
            this.tabPageVacation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewVacation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeSheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSickDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVacations)).BeginInit();
            this.SuspendLayout();
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
            this.advancedDataGridViewTimesheets.Location = new System.Drawing.Point(6, 34);
            this.advancedDataGridViewTimesheets.Name = "advancedDataGridViewTimesheets";
            this.advancedDataGridViewTimesheets.ReadOnly = true;
            this.advancedDataGridViewTimesheets.Size = new System.Drawing.Size(1238, 621);
            this.advancedDataGridViewTimesheets.TabIndex = 1;
            this.advancedDataGridViewTimesheets.TimeFilter = false;
            this.advancedDataGridViewTimesheets.SortStringChanged += new System.EventHandler(this.advancedDataGridViewTimesheets_SortStringChanged);
            this.advancedDataGridViewTimesheets.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewTimesheets_FilterStringChanged);
            this.advancedDataGridViewTimesheets.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewTimesheets_CellMouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageTimesheets);
            this.tabControl1.Controls.Add(this.tabPageVacation);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1621, 710);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageTimesheets
            // 
            this.tabPageTimesheets.Controls.Add(this.panel2);
            this.tabPageTimesheets.Controls.Add(this.panel1);
            this.tabPageTimesheets.Location = new System.Drawing.Point(4, 22);
            this.tabPageTimesheets.Name = "tabPageTimesheets";
            this.tabPageTimesheets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTimesheets.Size = new System.Drawing.Size(1613, 684);
            this.tabPageTimesheets.TabIndex = 0;
            this.tabPageTimesheets.Text = "Timesheets";
            this.tabPageTimesheets.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonClearFilter);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.advancedDataGridViewTimesheets);
            this.panel2.Controls.Add(this.dateTimePickerStartDate);
            this.panel2.Controls.Add(this.checkBoxShowAll);
            this.panel2.Controls.Add(this.btnQuery);
            this.panel2.Controls.Add(this.btnAddTimesheets);
            this.panel2.Controls.Add(this.lblEndDate);
            this.panel2.Controls.Add(this.dateTimePickerEndDate);
            this.panel2.Controls.Add(this.lblStartDate);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1259, 669);
            this.panel2.TabIndex = 9;
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearFilter.Location = new System.Drawing.Point(1088, 4);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFilter.TabIndex = 6;
            this.buttonClearFilter.Text = "Clear Filter";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(1169, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(248, 7);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 2;
            // 
            // checkBoxShowAll
            // 
            this.checkBoxShowAll.AutoSize = true;
            this.checkBoxShowAll.Location = new System.Drawing.Point(117, 10);
            this.checkBoxShowAll.Name = "checkBoxShowAll";
            this.checkBoxShowAll.Size = new System.Drawing.Size(67, 17);
            this.checkBoxShowAll.TabIndex = 4;
            this.checkBoxShowAll.Text = "Show All";
            this.checkBoxShowAll.UseVisualStyleBackColor = true;
            this.checkBoxShowAll.CheckStateChanged += new System.EventHandler(this.checkBoxShowAll_CheckStateChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(719, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnAddTimesheets
            // 
            this.btnAddTimesheets.Location = new System.Drawing.Point(6, 8);
            this.btnAddTimesheets.Name = "btnAddTimesheets";
            this.btnAddTimesheets.Size = new System.Drawing.Size(105, 23);
            this.btnAddTimesheets.TabIndex = 0;
            this.btnAddTimesheets.Text = "Add Timesheet";
            this.btnAddTimesheets.UseVisualStyleBackColor = true;
            this.btnAddTimesheets.Click += new System.EventHandler(this.btnAddTimesheets_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(452, 10);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(55, 13);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "End Date:";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(513, 7);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 2;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(184, 9);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 3;
            this.lblStartDate.Text = "Start Date:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.advancedDataGridViewSickManagement);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnAddSickDay);
            this.panel1.Location = new System.Drawing.Point(1271, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 669);
            this.panel1.TabIndex = 8;
            // 
            // advancedDataGridViewSickManagement
            // 
            this.advancedDataGridViewSickManagement.AllowUserToAddRows = false;
            this.advancedDataGridViewSickManagement.AllowUserToDeleteRows = false;
            this.advancedDataGridViewSickManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridViewSickManagement.AutoGenerateContextFilters = true;
            this.advancedDataGridViewSickManagement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewSickManagement.DateWithTime = false;
            this.advancedDataGridViewSickManagement.Location = new System.Drawing.Point(13, 33);
            this.advancedDataGridViewSickManagement.Name = "advancedDataGridViewSickManagement";
            this.advancedDataGridViewSickManagement.ReadOnly = true;
            this.advancedDataGridViewSickManagement.Size = new System.Drawing.Size(320, 619);
            this.advancedDataGridViewSickManagement.TabIndex = 5;
            this.advancedDataGridViewSickManagement.TimeFilter = false;
            this.advancedDataGridViewSickManagement.SortStringChanged += new System.EventHandler(this.advancedDataGridViewSickManagement_SortStringChanged);
            this.advancedDataGridViewSickManagement.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewSickManagement_FilterStringChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sick Management:";
            // 
            // btnAddSickDay
            // 
            this.btnAddSickDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSickDay.Location = new System.Drawing.Point(258, 4);
            this.btnAddSickDay.Name = "btnAddSickDay";
            this.btnAddSickDay.Size = new System.Drawing.Size(75, 23);
            this.btnAddSickDay.TabIndex = 7;
            this.btnAddSickDay.Text = "Add";
            this.btnAddSickDay.UseVisualStyleBackColor = true;
            this.btnAddSickDay.Click += new System.EventHandler(this.btnAddSickDay_Click);
            // 
            // tabPageVacation
            // 
            this.tabPageVacation.Controls.Add(this.buttonRefresh);
            this.tabPageVacation.Controls.Add(this.btnAddVacation);
            this.tabPageVacation.Controls.Add(this.advancedDataGridViewVacation);
            this.tabPageVacation.Location = new System.Drawing.Point(4, 22);
            this.tabPageVacation.Name = "tabPageVacation";
            this.tabPageVacation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVacation.Size = new System.Drawing.Size(1613, 684);
            this.tabPageVacation.TabIndex = 1;
            this.tabPageVacation.Text = "Vacation";
            this.tabPageVacation.UseVisualStyleBackColor = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Location = new System.Drawing.Point(1532, 5);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // btnAddVacation
            // 
            this.btnAddVacation.Location = new System.Drawing.Point(6, 6);
            this.btnAddVacation.Name = "btnAddVacation";
            this.btnAddVacation.Size = new System.Drawing.Size(123, 23);
            this.btnAddVacation.TabIndex = 1;
            this.btnAddVacation.Text = "Add Vacation";
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
            this.advancedDataGridViewVacation.Size = new System.Drawing.Size(1601, 622);
            this.advancedDataGridViewVacation.TabIndex = 0;
            this.advancedDataGridViewVacation.TimeFilter = false;
            this.advancedDataGridViewVacation.SortStringChanged += new System.EventHandler(this.advancedDataGridViewVacation_SortStringChanged);
            this.advancedDataGridViewVacation.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewVacation_FilterStringChanged);
            this.advancedDataGridViewVacation.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewVacation_CellMouseDoubleClick);
            // 
            // FrmTimesheetsApprovers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1645, 734);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmTimesheetsApprovers";
            this.Text = "Approver";
            this.Load += new System.EventHandler(this.FrmTimesheetsElevated_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTimesheets)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTimesheets.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewSickManagement)).EndInit();
            this.tabPageVacation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewVacation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeSheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSickDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVacations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ADGV.AdvancedDataGridView advancedDataGridViewTimesheets;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTimesheets;
        private System.Windows.Forms.Label label3;
        private ADGV.AdvancedDataGridView advancedDataGridViewSickManagement;
        private System.Windows.Forms.CheckBox checkBoxShowAll;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnAddTimesheets;
        private System.Windows.Forms.TabPage tabPageVacation;
        private System.Windows.Forms.Button btnAddVacation;
        private ADGV.AdvancedDataGridView advancedDataGridViewVacation;
        private System.Windows.Forms.Button btnAddSickDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.BindingSource bindingSourceTimeSheets;
        private System.Windows.Forms.BindingSource bindingSourceSickDays;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.BindingSource bindingSourceVacations;
        private System.Windows.Forms.Button buttonRefresh;
    }
}