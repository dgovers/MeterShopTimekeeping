namespace MeterShopTimekeeping
{
    partial class FrmAddPayCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddPayCode));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPayCodeAbbreviation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPCAbbreviation = new System.Windows.Forms.TextBox();
            this.textBoxPCDescription = new System.Windows.Forms.TextBox();
            this.textBoxIO = new System.Windows.Forms.TextBox();
            this.textBoxCC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(236, 144);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(141, 144);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(87, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelPayCodeAbbreviation
            // 
            this.labelPayCodeAbbreviation.AutoSize = true;
            this.labelPayCodeAbbreviation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayCodeAbbreviation.Location = new System.Drawing.Point(15, 13);
            this.labelPayCodeAbbreviation.Name = "labelPayCodeAbbreviation";
            this.labelPayCodeAbbreviation.Size = new System.Drawing.Size(136, 13);
            this.labelPayCodeAbbreviation.TabIndex = 1;
            this.labelPayCodeAbbreviation.Text = "PayCode Abbreviation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PayCode Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Internal Order Number:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cost Center:";
            // 
            // textBoxPCAbbreviation
            // 
            this.textBoxPCAbbreviation.Location = new System.Drawing.Point(156, 10);
            this.textBoxPCAbbreviation.Name = "textBoxPCAbbreviation";
            this.textBoxPCAbbreviation.Size = new System.Drawing.Size(113, 20);
            this.textBoxPCAbbreviation.TabIndex = 2;
            // 
            // textBoxPCDescription
            // 
            this.textBoxPCDescription.Location = new System.Drawing.Point(156, 37);
            this.textBoxPCDescription.Name = "textBoxPCDescription";
            this.textBoxPCDescription.Size = new System.Drawing.Size(113, 20);
            this.textBoxPCDescription.TabIndex = 2;
            // 
            // textBoxIO
            // 
            this.textBoxIO.Location = new System.Drawing.Point(156, 67);
            this.textBoxIO.Name = "textBoxIO";
            this.textBoxIO.Size = new System.Drawing.Size(161, 20);
            this.textBoxIO.TabIndex = 2;
            // 
            // textBoxCC
            // 
            this.textBoxCC.Location = new System.Drawing.Point(156, 98);
            this.textBoxCC.Name = "textBoxCC";
            this.textBoxCC.Size = new System.Drawing.Size(161, 20);
            this.textBoxCC.TabIndex = 2;
            // 
            // FrmAddPayCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 179);
            this.Controls.Add(this.textBoxCC);
            this.Controls.Add(this.textBoxIO);
            this.Controls.Add(this.textBoxPCDescription);
            this.Controls.Add(this.textBoxPCAbbreviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPayCodeAbbreviation);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAddPayCode";
            this.Text = "Add PayCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelPayCodeAbbreviation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPCAbbreviation;
        private System.Windows.Forms.TextBox textBoxPCDescription;
        private System.Windows.Forms.TextBox textBoxIO;
        private System.Windows.Forms.TextBox textBoxCC;
    }
}