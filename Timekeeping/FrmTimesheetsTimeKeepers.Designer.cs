namespace MeterShopTimekeeping
{
    partial class FrmTimesheetsTimeKeepers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimesheetsTimeKeepers));
            this.advancedDataGridViewTimesheets = new ADGV.AdvancedDataGridView();
            this.txtBoxCount = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.checkBoxShowAll = new System.Windows.Forms.CheckBox();
            this.bindingSourceTimeSheets = new System.Windows.Forms.BindingSource(this.components);
            this.buttonClearFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTimesheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeSheets)).BeginInit();
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
            this.advancedDataGridViewTimesheets.Location = new System.Drawing.Point(12, 41);
            this.advancedDataGridViewTimesheets.Name = "advancedDataGridViewTimesheets";
            this.advancedDataGridViewTimesheets.ReadOnly = true;
            this.advancedDataGridViewTimesheets.Size = new System.Drawing.Size(1534, 586);
            this.advancedDataGridViewTimesheets.TabIndex = 0;
            this.advancedDataGridViewTimesheets.TimeFilter = false;
            this.advancedDataGridViewTimesheets.SortStringChanged += new System.EventHandler(this.advancedDataGridViewTimesheets_SortStringChanged);
            this.advancedDataGridViewTimesheets.FilterStringChanged += new System.EventHandler(this.advancedDataGridViewTimesheets_FilterStringChanged);
            this.advancedDataGridViewTimesheets.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewTimesheets_CellMouseDoubleClick);
            // 
            // txtBoxCount
            // 
            this.txtBoxCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxCount.Location = new System.Drawing.Point(56, 633);
            this.txtBoxCount.Name = "txtBoxCount";
            this.txtBoxCount.Size = new System.Drawing.Size(53, 20);
            this.txtBoxCount.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(1471, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 633);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Count:";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(155, 13);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerStartDate.TabIndex = 5;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(422, 13);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerEndDate.TabIndex = 6;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(91, 17);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
            this.labelStartDate.TabIndex = 7;
            this.labelStartDate.Text = "Start Date:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(361, 17);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(55, 13);
            this.labelEndDate.TabIndex = 7;
            this.labelEndDate.Text = "End Date:";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(628, 13);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 8;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // checkBoxShowAll
            // 
            this.checkBoxShowAll.AutoSize = true;
            this.checkBoxShowAll.Location = new System.Drawing.Point(18, 17);
            this.checkBoxShowAll.Name = "checkBoxShowAll";
            this.checkBoxShowAll.Size = new System.Drawing.Size(67, 17);
            this.checkBoxShowAll.TabIndex = 9;
            this.checkBoxShowAll.Text = "Show All";
            this.checkBoxShowAll.UseVisualStyleBackColor = true;
            this.checkBoxShowAll.CheckedChanged += new System.EventHandler(this.checkBoxShowAll_CheckedChanged);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearFilter.Location = new System.Drawing.Point(1390, 13);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFilter.TabIndex = 10;
            this.buttonClearFilter.Text = "Clear Filter";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // FrmTimesheetsTimeKeepers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 662);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClearFilter);
            this.Controls.Add(this.checkBoxShowAll);
            this.Controls.Add(this.buttonQuery);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtBoxCount);
            this.Controls.Add(this.advancedDataGridViewTimesheets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTimesheetsTimeKeepers";
            this.Text = "Timekeeper";
            this.Load += new System.EventHandler(this.FrmTimesheetsTimeKeepers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewTimesheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeSheets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ADGV.AdvancedDataGridView advancedDataGridViewTimesheets;
        private System.Windows.Forms.TextBox txtBoxCount;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.CheckBox checkBoxShowAll;
        private System.Windows.Forms.BindingSource bindingSourceTimeSheets;
        private System.Windows.Forms.Button buttonClearFilter;
    }
}