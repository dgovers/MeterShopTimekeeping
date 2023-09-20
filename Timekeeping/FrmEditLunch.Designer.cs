namespace MeterShopTimekeeping
{
    partial class FrmEditLunch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditLunch));
            this.dateTimePickerLunchStart = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerLunchStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLunchEndTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.bindingSourceLunchInfo = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunchInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerLunchStart
            // 
            this.dateTimePickerLunchStart.AutoSize = true;
            this.dateTimePickerLunchStart.Location = new System.Drawing.Point(12, 23);
            this.dateTimePickerLunchStart.Name = "dateTimePickerLunchStart";
            this.dateTimePickerLunchStart.Size = new System.Drawing.Size(91, 13);
            this.dateTimePickerLunchStart.TabIndex = 0;
            this.dateTimePickerLunchStart.Text = "Lunch Start Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lunch End Time:";
            // 
            // dateTimePickerLunchStartTime
            // 
            this.dateTimePickerLunchStartTime.Location = new System.Drawing.Point(109, 17);
            this.dateTimePickerLunchStartTime.Name = "dateTimePickerLunchStartTime";
            this.dateTimePickerLunchStartTime.Size = new System.Drawing.Size(104, 20);
            this.dateTimePickerLunchStartTime.TabIndex = 1;
            // 
            // dateTimePickerLunchEndTime
            // 
            this.dateTimePickerLunchEndTime.Location = new System.Drawing.Point(331, 16);
            this.dateTimePickerLunchEndTime.Name = "dateTimePickerLunchEndTime";
            this.dateTimePickerLunchEndTime.Size = new System.Drawing.Size(101, 20);
            this.dateTimePickerLunchEndTime.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(281, 54);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(362, 54);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(15, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmEditLunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 89);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dateTimePickerLunchEndTime);
            this.Controls.Add(this.dateTimePickerLunchStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerLunchStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditLunch";
            this.Text = "Edit Lunch";
            this.Load += new System.EventHandler(this.FrmEditLunch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLunchInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateTimePickerLunchStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerLunchStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerLunchEndTime;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.BindingSource bindingSourceLunchInfo;
    }
}