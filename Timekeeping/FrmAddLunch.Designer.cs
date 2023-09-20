namespace MeterShopTimekeeping
{
    partial class FrmAddLunch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddLunch));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dateTimePickerLunchEndTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLunchStartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerLunchStart = new System.Windows.Forms.Label();
            this.bindingSourceLunchInfo = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunchInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(362, 52);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(281, 52);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dateTimePickerLunchEndTime
            // 
            this.dateTimePickerLunchEndTime.Location = new System.Drawing.Point(331, 14);
            this.dateTimePickerLunchEndTime.Name = "dateTimePickerLunchEndTime";
            this.dateTimePickerLunchEndTime.Size = new System.Drawing.Size(101, 20);
            this.dateTimePickerLunchEndTime.TabIndex = 6;
            // 
            // dateTimePickerLunchStartTime
            // 
            this.dateTimePickerLunchStartTime.Location = new System.Drawing.Point(109, 15);
            this.dateTimePickerLunchStartTime.Name = "dateTimePickerLunchStartTime";
            this.dateTimePickerLunchStartTime.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerLunchStartTime.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lunch End Time:";
            // 
            // dateTimePickerLunchStart
            // 
            this.dateTimePickerLunchStart.AutoSize = true;
            this.dateTimePickerLunchStart.Location = new System.Drawing.Point(12, 21);
            this.dateTimePickerLunchStart.Name = "dateTimePickerLunchStart";
            this.dateTimePickerLunchStart.Size = new System.Drawing.Size(91, 13);
            this.dateTimePickerLunchStart.TabIndex = 5;
            this.dateTimePickerLunchStart.Text = "Lunch Start Time:";
            // 
            // FrmAddLunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 89);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dateTimePickerLunchEndTime);
            this.Controls.Add(this.dateTimePickerLunchStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerLunchStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddLunch";
            this.Text = "Add Lunch";
            this.Load += new System.EventHandler(this.FrmAddLunch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunchInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerLunchEndTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerLunchStartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dateTimePickerLunchStart;
        private System.Windows.Forms.BindingSource bindingSourceLunchInfo;
    }
}