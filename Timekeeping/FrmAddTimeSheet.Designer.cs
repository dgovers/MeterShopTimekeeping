namespace MeterShopTimekeeping
{
    partial class FrmAddTimeSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddTimeSheet));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.advancedDataGridViewExceptions = new ADGV.AdvancedDataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddException = new System.Windows.Forms.Button();
            this.advancedDataGridViewLunch = new ADGV.AdvancedDataGridView();
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.labelLunch = new System.Windows.Forms.Label();
            this.checkBoxLateLunch = new System.Windows.Forms.CheckBox();
            this.checkBoxLunchNotTaken = new System.Windows.Forms.CheckBox();
            this.comboBoxEmployeeName = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.bindingSourceUsers = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceLunches = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceExceptions = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAddLunch = new System.Windows.Forms.Button();
            this.textBoxLunchCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewLunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExceptions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(261, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Start Time: ";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(546, 12);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(71, 20);
            this.dateTimePickerStartTime.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(626, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "End Time: ";
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(690, 13);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(71, 20);
            this.dateTimePickerEndTime.TabIndex = 4;
            // 
            // advancedDataGridViewExceptions
            // 
            this.advancedDataGridViewExceptions.AllowUserToAddRows = false;
            this.advancedDataGridViewExceptions.AllowUserToDeleteRows = false;
            this.advancedDataGridViewExceptions.AutoGenerateContextFilters = true;
            this.advancedDataGridViewExceptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewExceptions.DateWithTime = false;
            this.advancedDataGridViewExceptions.Location = new System.Drawing.Point(8, 96);
            this.advancedDataGridViewExceptions.Name = "advancedDataGridViewExceptions";
            this.advancedDataGridViewExceptions.ReadOnly = true;
            this.advancedDataGridViewExceptions.Size = new System.Drawing.Size(405, 150);
            this.advancedDataGridViewExceptions.TabIndex = 5;
            this.advancedDataGridViewExceptions.TimeFilter = false;
            this.advancedDataGridViewExceptions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView1_CellMouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Exceptions:";
            // 
            // btnAddException
            // 
            this.btnAddException.Location = new System.Drawing.Point(329, 67);
            this.btnAddException.Name = "btnAddException";
            this.btnAddException.Size = new System.Drawing.Size(84, 23);
            this.btnAddException.TabIndex = 7;
            this.btnAddException.Text = "Add Exception";
            this.btnAddException.UseVisualStyleBackColor = true;
            this.btnAddException.Click += new System.EventHandler(this.btnAddException_Click);
            // 
            // advancedDataGridViewLunch
            // 
            this.advancedDataGridViewLunch.AllowUserToAddRows = false;
            this.advancedDataGridViewLunch.AllowUserToDeleteRows = false;
            this.advancedDataGridViewLunch.AutoGenerateContextFilters = true;
            this.advancedDataGridViewLunch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewLunch.DateWithTime = false;
            this.advancedDataGridViewLunch.Location = new System.Drawing.Point(428, 96);
            this.advancedDataGridViewLunch.Name = "advancedDataGridViewLunch";
            this.advancedDataGridViewLunch.ReadOnly = true;
            this.advancedDataGridViewLunch.Size = new System.Drawing.Size(437, 150);
            this.advancedDataGridViewLunch.TabIndex = 5;
            this.advancedDataGridViewLunch.TimeFilter = false;
            this.advancedDataGridViewLunch.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewLunch_CellMouseDoubleClick);
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Location = new System.Drawing.Point(8, 286);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.Size = new System.Drawing.Size(857, 96);
            this.richTextBoxNotes.TabIndex = 8;
            this.richTextBoxNotes.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Notes";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(628, 405);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(709, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(790, 405);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelLunch
            // 
            this.labelLunch.AutoSize = true;
            this.labelLunch.Location = new System.Drawing.Point(425, 77);
            this.labelLunch.Name = "labelLunch";
            this.labelLunch.Size = new System.Drawing.Size(51, 13);
            this.labelLunch.TabIndex = 6;
            this.labelLunch.Text = "Lunches:";
            // 
            // checkBoxLateLunch
            // 
            this.checkBoxLateLunch.AutoSize = true;
            this.checkBoxLateLunch.Location = new System.Drawing.Point(482, 76);
            this.checkBoxLateLunch.Name = "checkBoxLateLunch";
            this.checkBoxLateLunch.Size = new System.Drawing.Size(80, 17);
            this.checkBoxLateLunch.TabIndex = 11;
            this.checkBoxLateLunch.Text = "Late Lunch";
            this.checkBoxLateLunch.UseVisualStyleBackColor = true;
            // 
            // checkBoxLunchNotTaken
            // 
            this.checkBoxLunchNotTaken.AutoSize = true;
            this.checkBoxLunchNotTaken.Location = new System.Drawing.Point(574, 76);
            this.checkBoxLunchNotTaken.Name = "checkBoxLunchNotTaken";
            this.checkBoxLunchNotTaken.Size = new System.Drawing.Size(110, 17);
            this.checkBoxLunchNotTaken.TabIndex = 11;
            this.checkBoxLunchNotTaken.Text = "Lunch Not Taken";
            this.checkBoxLunchNotTaken.UseVisualStyleBackColor = true;
            // 
            // comboBoxEmployeeName
            // 
            this.comboBoxEmployeeName.FormattingEnabled = true;
            this.comboBoxEmployeeName.Location = new System.Drawing.Point(92, 12);
            this.comboBoxEmployeeName.Name = "comboBoxEmployeeName";
            this.comboBoxEmployeeName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEmployeeName.TabIndex = 12;
            this.comboBoxEmployeeName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxEmployeeName_SelectionChangeCommitted);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(790, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // buttonAddLunch
            // 
            this.buttonAddLunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddLunch.Location = new System.Drawing.Point(789, 67);
            this.buttonAddLunch.Name = "buttonAddLunch";
            this.buttonAddLunch.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLunch.TabIndex = 14;
            this.buttonAddLunch.Text = "Add Lunch";
            this.buttonAddLunch.UseVisualStyleBackColor = true;
            this.buttonAddLunch.Click += new System.EventHandler(this.buttonAddLunch_Click);
            // 
            // textBoxLunchCount
            // 
            this.textBoxLunchCount.Location = new System.Drawing.Point(428, 253);
            this.textBoxLunchCount.Name = "textBoxLunchCount";
            this.textBoxLunchCount.Size = new System.Drawing.Size(62, 20);
            this.textBoxLunchCount.TabIndex = 15;
            // 
            // FrmAddTimeSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 440);
            this.Controls.Add(this.textBoxLunchCount);
            this.Controls.Add(this.buttonAddLunch);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.comboBoxEmployeeName);
            this.Controls.Add(this.checkBoxLunchNotTaken);
            this.Controls.Add(this.checkBoxLateLunch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.btnAddException);
            this.Controls.Add(this.labelLunch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.advancedDataGridViewLunch);
            this.Controls.Add(this.advancedDataGridViewExceptions);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddTimeSheet";
            this.Text = "Add Timesheet";
            this.Load += new System.EventHandler(this.FrmAddTimeSheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewLunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExceptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private ADGV.AdvancedDataGridView advancedDataGridViewExceptions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddException;
        private ADGV.AdvancedDataGridView advancedDataGridViewLunch;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label labelLunch;
        private System.Windows.Forms.CheckBox checkBoxLateLunch;
        private System.Windows.Forms.CheckBox checkBoxLunchNotTaken;
        private System.Windows.Forms.ComboBox comboBoxEmployeeName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.BindingSource bindingSourceUsers;
        private System.Windows.Forms.BindingSource bindingSourceLunches;
        private System.Windows.Forms.BindingSource bindingSourceExceptions;
        private System.Windows.Forms.Button buttonAddLunch;
        private System.Windows.Forms.TextBox textBoxLunchCount;
    }
}