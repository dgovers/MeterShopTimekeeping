namespace MeterShopTimekeeping
{
    partial class FrmEditTimesheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditTimesheet));
            this.advancedDataGridViewComments = new ADGV.AdvancedDataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.bindingSourceExceptions = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceUsers = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxEmployeeName = new System.Windows.Forms.ComboBox();
            this.checkBoxLunchNotTaken = new System.Windows.Forms.CheckBox();
            this.checkBoxLateLunch = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bindingSourceLunches = new System.Windows.Forms.BindingSource(this.components);
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.btnAddException = new System.Windows.Forms.Button();
            this.labelLunch = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.advancedDataGridViewLunch = new ADGV.AdvancedDataGridView();
            this.advancedDataGridViewExceptions = new ADGV.AdvancedDataGridView();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerWorkDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bindingSourceComments = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxLunchCount = new System.Windows.Forms.TextBox();
            this.buttonAddLunch = new System.Windows.Forms.Button();
            this.buttonDeleteTimesheet = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewLunch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComments)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridViewComments
            // 
            this.advancedDataGridViewComments.AllowUserToAddRows = false;
            this.advancedDataGridViewComments.AllowUserToDeleteRows = false;
            this.advancedDataGridViewComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridViewComments.AutoGenerateContextFilters = true;
            this.advancedDataGridViewComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewComments.DateWithTime = false;
            this.advancedDataGridViewComments.Location = new System.Drawing.Point(21, 468);
            this.advancedDataGridViewComments.Name = "advancedDataGridViewComments";
            this.advancedDataGridViewComments.ReadOnly = true;
            this.advancedDataGridViewComments.Size = new System.Drawing.Size(1034, 127);
            this.advancedDataGridViewComments.TabIndex = 7;
            this.advancedDataGridViewComments.TimeFilter = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 449);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Comments";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(980, 610);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddComment.Location = new System.Drawing.Point(977, 439);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(75, 23);
            this.btnAddComment.TabIndex = 12;
            this.btnAddComment.Text = "Add";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 615);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "ID: ";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(165, 615);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Status:";
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxID.Location = new System.Drawing.Point(59, 612);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 14;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxStatus.Location = new System.Drawing.Point(211, 612);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(100, 20);
            this.textBoxStatus.TabIndex = 14;
            // 
            // comboBoxEmployeeName
            // 
            this.comboBoxEmployeeName.FormattingEnabled = true;
            this.comboBoxEmployeeName.Location = new System.Drawing.Point(95, 12);
            this.comboBoxEmployeeName.Name = "comboBoxEmployeeName";
            this.comboBoxEmployeeName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEmployeeName.TabIndex = 34;
            // 
            // checkBoxLunchNotTaken
            // 
            this.checkBoxLunchNotTaken.AutoSize = true;
            this.checkBoxLunchNotTaken.Location = new System.Drawing.Point(792, 73);
            this.checkBoxLunchNotTaken.Name = "checkBoxLunchNotTaken";
            this.checkBoxLunchNotTaken.Size = new System.Drawing.Size(110, 17);
            this.checkBoxLunchNotTaken.TabIndex = 33;
            this.checkBoxLunchNotTaken.Text = "Lunch Not Taken";
            this.checkBoxLunchNotTaken.UseVisualStyleBackColor = true;
            // 
            // checkBoxLateLunch
            // 
            this.checkBoxLateLunch.AutoSize = true;
            this.checkBoxLateLunch.Location = new System.Drawing.Point(706, 73);
            this.checkBoxLateLunch.Name = "checkBoxLateLunch";
            this.checkBoxLateLunch.Size = new System.Drawing.Size(80, 17);
            this.checkBoxLateLunch.TabIndex = 32;
            this.checkBoxLateLunch.Text = "Late Lunch";
            this.checkBoxLateLunch.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Notes";
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxNotes.Location = new System.Drawing.Point(11, 286);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.Size = new System.Drawing.Size(1024, 96);
            this.richTextBoxNotes.TabIndex = 27;
            this.richTextBoxNotes.Text = "";
            // 
            // btnAddException
            // 
            this.btnAddException.Location = new System.Drawing.Point(536, 69);
            this.btnAddException.Name = "btnAddException";
            this.btnAddException.Size = new System.Drawing.Size(84, 23);
            this.btnAddException.TabIndex = 26;
            this.btnAddException.Text = "Add Exception";
            this.btnAddException.UseVisualStyleBackColor = true;
            this.btnAddException.Click += new System.EventHandler(this.btnAddException_Click);
            // 
            // labelLunch
            // 
            this.labelLunch.AutoSize = true;
            this.labelLunch.Location = new System.Drawing.Point(649, 74);
            this.labelLunch.Name = "labelLunch";
            this.labelLunch.Size = new System.Drawing.Size(51, 13);
            this.labelLunch.TabIndex = 24;
            this.labelLunch.Text = "Lunches:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Exceptions:";
            // 
            // advancedDataGridViewLunch
            // 
            this.advancedDataGridViewLunch.AllowUserToAddRows = false;
            this.advancedDataGridViewLunch.AllowUserToDeleteRows = false;
            this.advancedDataGridViewLunch.AutoGenerateContextFilters = true;
            this.advancedDataGridViewLunch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewLunch.DateWithTime = false;
            this.advancedDataGridViewLunch.Location = new System.Drawing.Point(648, 96);
            this.advancedDataGridViewLunch.Name = "advancedDataGridViewLunch";
            this.advancedDataGridViewLunch.ReadOnly = true;
            this.advancedDataGridViewLunch.Size = new System.Drawing.Size(387, 150);
            this.advancedDataGridViewLunch.TabIndex = 23;
            this.advancedDataGridViewLunch.TimeFilter = false;
            this.advancedDataGridViewLunch.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewLunch_CellMouseDoubleClick);
            // 
            // advancedDataGridViewExceptions
            // 
            this.advancedDataGridViewExceptions.AllowUserToAddRows = false;
            this.advancedDataGridViewExceptions.AllowUserToDeleteRows = false;
            this.advancedDataGridViewExceptions.AutoGenerateContextFilters = true;
            this.advancedDataGridViewExceptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridViewExceptions.DateWithTime = false;
            this.advancedDataGridViewExceptions.Location = new System.Drawing.Point(11, 96);
            this.advancedDataGridViewExceptions.Name = "advancedDataGridViewExceptions";
            this.advancedDataGridViewExceptions.ReadOnly = true;
            this.advancedDataGridViewExceptions.Size = new System.Drawing.Size(609, 150);
            this.advancedDataGridViewExceptions.TabIndex = 22;
            this.advancedDataGridViewExceptions.TimeFilter = false;
            this.advancedDataGridViewExceptions.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridViewExceptions_CellMouseDoubleClick);
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(693, 13);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(71, 20);
            this.dateTimePickerEndTime.TabIndex = 21;
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(549, 12);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(71, 20);
            this.dateTimePickerStartTime.TabIndex = 20;
            // 
            // dateTimePickerWorkDate
            // 
            this.dateTimePickerWorkDate.Location = new System.Drawing.Point(264, 13);
            this.dateTimePickerWorkDate.Name = "dateTimePickerWorkDate";
            this.dateTimePickerWorkDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerWorkDate.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(629, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "End Time: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(482, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Start Time: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Date: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Employee Name:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(899, 609);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 35;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(818, 609);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 35;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBoxLunchCount
            // 
            this.textBoxLunchCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLunchCount.Location = new System.Drawing.Point(652, 252);
            this.textBoxLunchCount.Name = "textBoxLunchCount";
            this.textBoxLunchCount.Size = new System.Drawing.Size(48, 20);
            this.textBoxLunchCount.TabIndex = 36;
            // 
            // buttonAddLunch
            // 
            this.buttonAddLunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddLunch.Location = new System.Drawing.Point(960, 67);
            this.buttonAddLunch.Name = "buttonAddLunch";
            this.buttonAddLunch.Size = new System.Drawing.Size(75, 23);
            this.buttonAddLunch.TabIndex = 37;
            this.buttonAddLunch.Text = "Add Lunch";
            this.buttonAddLunch.UseVisualStyleBackColor = true;
            this.buttonAddLunch.Click += new System.EventHandler(this.buttonAddLunch_Click);
            // 
            // buttonDeleteTimesheet
            // 
            this.buttonDeleteTimesheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteTimesheet.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteTimesheet.ForeColor = System.Drawing.Color.White;
            this.buttonDeleteTimesheet.Location = new System.Drawing.Point(977, 14);
            this.buttonDeleteTimesheet.Name = "buttonDeleteTimesheet";
            this.buttonDeleteTimesheet.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteTimesheet.TabIndex = 37;
            this.buttonDeleteTimesheet.Text = "Delete";
            this.buttonDeleteTimesheet.UseVisualStyleBackColor = false;
            this.buttonDeleteTimesheet.Click += new System.EventHandler(this.buttonDeleteTimesheet_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(737, 609);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 38;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // FrmEditTimesheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 644);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonDeleteTimesheet);
            this.Controls.Add(this.buttonAddLunch);
            this.Controls.Add(this.textBoxLunchCount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxEmployeeName);
            this.Controls.Add(this.checkBoxLunchNotTaken);
            this.Controls.Add(this.checkBoxLateLunch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.btnAddException);
            this.Controls.Add(this.labelLunch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.advancedDataGridViewLunch);
            this.Controls.Add(this.advancedDataGridViewExceptions);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.dateTimePickerWorkDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAddComment);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.advancedDataGridViewComments);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditTimesheet";
            this.Text = "Edit Timesheet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditTimesheet_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditTimesheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewLunch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridViewExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ADGV.AdvancedDataGridView advancedDataGridViewComments;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.BindingSource bindingSourceExceptions;
        private System.Windows.Forms.BindingSource bindingSourceUsers;
        private System.Windows.Forms.ComboBox comboBoxEmployeeName;
        private System.Windows.Forms.CheckBox checkBoxLunchNotTaken;
        private System.Windows.Forms.CheckBox checkBoxLateLunch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource bindingSourceLunches;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.Button btnAddException;
        private System.Windows.Forms.Label labelLunch;
        private System.Windows.Forms.Label label6;
        private ADGV.AdvancedDataGridView advancedDataGridViewLunch;
        private ADGV.AdvancedDataGridView advancedDataGridViewExceptions;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dateTimePickerWorkDate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.BindingSource bindingSourceComments;
        private System.Windows.Forms.TextBox textBoxLunchCount;
        private System.Windows.Forms.Button buttonAddLunch;
        private System.Windows.Forms.Button buttonDeleteTimesheet;
        private System.Windows.Forms.Button button4;
    }
}