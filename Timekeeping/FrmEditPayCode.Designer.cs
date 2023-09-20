namespace MeterShopTimekeeping
{
    partial class FrmEditPayCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditPayCode));
            this.textBoxCC = new System.Windows.Forms.TextBox();
            this.textBoxIO = new System.Windows.Forms.TextBox();
            this.textBoxPCDescription = new System.Windows.Forms.TextBox();
            this.textBoxPCAbbreviation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPayCodeAbbreviation = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPayCodeID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxCC
            // 
            this.textBoxCC.Location = new System.Drawing.Point(154, 121);
            this.textBoxCC.Name = "textBoxCC";
            this.textBoxCC.Size = new System.Drawing.Size(161, 20);
            this.textBoxCC.TabIndex = 9;
            // 
            // textBoxIO
            // 
            this.textBoxIO.Location = new System.Drawing.Point(154, 90);
            this.textBoxIO.Name = "textBoxIO";
            this.textBoxIO.Size = new System.Drawing.Size(161, 20);
            this.textBoxIO.TabIndex = 10;
            // 
            // textBoxPCDescription
            // 
            this.textBoxPCDescription.Location = new System.Drawing.Point(154, 60);
            this.textBoxPCDescription.Name = "textBoxPCDescription";
            this.textBoxPCDescription.Size = new System.Drawing.Size(161, 20);
            this.textBoxPCDescription.TabIndex = 11;
            // 
            // textBoxPCAbbreviation
            // 
            this.textBoxPCAbbreviation.Location = new System.Drawing.Point(154, 33);
            this.textBoxPCAbbreviation.Name = "textBoxPCAbbreviation";
            this.textBoxPCAbbreviation.Size = new System.Drawing.Size(113, 20);
            this.textBoxPCAbbreviation.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Cost Center:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Internal Order Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "PayCode Description:";
            // 
            // labelPayCodeAbbreviation
            // 
            this.labelPayCodeAbbreviation.AutoSize = true;
            this.labelPayCodeAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayCodeAbbreviation.Location = new System.Drawing.Point(13, 36);
            this.labelPayCodeAbbreviation.Name = "labelPayCodeAbbreviation";
            this.labelPayCodeAbbreviation.Size = new System.Drawing.Size(136, 13);
            this.labelPayCodeAbbreviation.TabIndex = 8;
            this.labelPayCodeAbbreviation.Text = "PayCode Abbreviation:";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(141, 179);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(87, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(236, 179);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "PayCodeID:";
            // 
            // textBoxPayCodeID
            // 
            this.textBoxPayCodeID.Location = new System.Drawing.Point(155, 6);
            this.textBoxPayCodeID.Name = "textBoxPayCodeID";
            this.textBoxPayCodeID.Size = new System.Drawing.Size(113, 20);
            this.textBoxPayCodeID.TabIndex = 12;
            // 
            // FrmEditPayCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 213);
            this.Controls.Add(this.textBoxCC);
            this.Controls.Add(this.textBoxIO);
            this.Controls.Add(this.textBoxPCDescription);
            this.Controls.Add(this.textBoxPayCodeID);
            this.Controls.Add(this.textBoxPCAbbreviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPayCodeAbbreviation);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditPayCode";
            this.Text = "Edit PayCode";
            this.Load += new System.EventHandler(this.FrmEditPayCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCC;
        private System.Windows.Forms.TextBox textBoxIO;
        private System.Windows.Forms.TextBox textBoxPCDescription;
        private System.Windows.Forms.TextBox textBoxPCAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPayCodeAbbreviation;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPayCodeID;
    }
}