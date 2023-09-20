namespace MeterShopTimekeeping
{
    partial class FrmEditVacation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditVacation));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEmployeeName = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUniversal2 = new System.Windows.Forms.Button();
            this.btnUniversal1 = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVacationID = new System.Windows.Forms.Label();
            this.textBoxVacationID = new System.Windows.Forms.TextBox();
            this.bindingSourceUsers = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceComments = new System.Windows.Forms.BindingSource(this.components);
            this.btnUniversal3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComments)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "End Date:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Start Date:";
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(298, 72);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(137, 20);
            this.dateTimePickerEndDate.TabIndex = 9;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(84, 72);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(137, 20);
            this.dateTimePickerStartDate.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Employee Name:";
            // 
            // comboBoxEmployeeName
            // 
            this.comboBoxEmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEmployeeName.FormattingEnabled = true;
            this.comboBoxEmployeeName.Location = new System.Drawing.Point(106, 36);
            this.comboBoxEmployeeName.Name = "comboBoxEmployeeName";
            this.comboBoxEmployeeName.Size = new System.Drawing.Size(235, 21);
            this.comboBoxEmployeeName.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(403, 149);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUniversal2
            // 
            this.btnUniversal2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUniversal2.Location = new System.Drawing.Point(322, 149);
            this.btnUniversal2.Name = "btnUniversal2";
            this.btnUniversal2.Size = new System.Drawing.Size(75, 23);
            this.btnUniversal2.TabIndex = 6;
            this.btnUniversal2.UseVisualStyleBackColor = true;
            this.btnUniversal2.Click += new System.EventHandler(this.btnUniversal2_Click);
            // 
            // btnUniversal1
            // 
            this.btnUniversal1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUniversal1.Location = new System.Drawing.Point(241, 149);
            this.btnUniversal1.Name = "btnUniversal1";
            this.btnUniversal1.Size = new System.Drawing.Size(75, 23);
            this.btnUniversal1.TabIndex = 6;
            this.btnUniversal1.UseVisualStyleBackColor = true;
            this.btnUniversal1.Click += new System.EventHandler(this.btnUniversal1_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(240, 6);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(100, 20);
            this.textBoxStatus.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Status:";
            // 
            // lblVacationID
            // 
            this.lblVacationID.AutoSize = true;
            this.lblVacationID.Location = new System.Drawing.Point(12, 9);
            this.lblVacationID.Name = "lblVacationID";
            this.lblVacationID.Size = new System.Drawing.Size(66, 13);
            this.lblVacationID.TabIndex = 19;
            this.lblVacationID.Text = "Vacation ID:";
            // 
            // textBoxVacationID
            // 
            this.textBoxVacationID.Location = new System.Drawing.Point(84, 7);
            this.textBoxVacationID.Name = "textBoxVacationID";
            this.textBoxVacationID.Size = new System.Drawing.Size(100, 20);
            this.textBoxVacationID.TabIndex = 20;
            // 
            // btnUniversal3
            // 
            this.btnUniversal3.Location = new System.Drawing.Point(472, 309);
            this.btnUniversal3.Name = "btnUniversal3";
            this.btnUniversal3.Size = new System.Drawing.Size(75, 23);
            this.btnUniversal3.TabIndex = 21;
            this.btnUniversal3.UseVisualStyleBackColor = true;
            this.btnUniversal3.Click += new System.EventHandler(this.btnUniversal3_Click_1);
            // 
            // FrmEditVacation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 184);
            this.Controls.Add(this.btnUniversal3);
            this.Controls.Add(this.textBoxVacationID);
            this.Controls.Add(this.lblVacationID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEmployeeName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUniversal1);
            this.Controls.Add(this.btnUniversal2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditVacation";
            this.Text = "Edit Vacation";
            this.Load += new System.EventHandler(this.FrmEditVacation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEmployeeName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUniversal2;
        private System.Windows.Forms.Button btnUniversal1;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblVacationID;
        private System.Windows.Forms.TextBox textBoxVacationID;
        private System.Windows.Forms.BindingSource bindingSourceUsers;
        private System.Windows.Forms.BindingSource bindingSourceComments;
        private System.Windows.Forms.Button btnUniversal3;
    }
}