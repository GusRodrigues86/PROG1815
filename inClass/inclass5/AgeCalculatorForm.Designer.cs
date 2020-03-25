namespace inclass5
{
    partial class AgeCalculator
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(15, 15);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(81, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(150, 20);
            this.txtFirstName.TabIndex = 1;
            this.txtFirstName.Tag = "First name";
            this.txtFirstName.Leave += new System.EventHandler(this.LeaveValidation);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(81, 38);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(150, 20);
            this.txtLastName.TabIndex = 2;
            this.txtLastName.Tag = "Last name";
            this.txtLastName.Leave += new System.EventHandler(this.LeaveValidation);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(14, 41);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date of Birth:";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "dd-MMM-yyyy";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(81, 64);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(100, 20);
            this.datePicker.TabIndex = 3;
            this.datePicker.Tag = "Date of Birth";
            this.datePicker.Leave += new System.EventHandler(this.LeaveValidation);
            // 
            // btnCalculator
            // 
            this.btnCalculator.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalculator.Location = new System.Drawing.Point(67, 97);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(167, 23);
            this.btnCalculator.TabIndex = 7;
            this.btnCalculator.Text = "Calculate my Age";
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.ForeColor = System.Drawing.Color.Red;
            this.lblErrors.Location = new System.Drawing.Point(237, 15);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(33, 13);
            this.lblErrors.TabIndex = 10;
            this.lblErrors.Text = "errors";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(236, 97);
            this.lblAge.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(88, 20);
            this.lblAge.TabIndex = 11;
            this.lblAge.Text = "Age Result";
            // 
            // AgeCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 156);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.btnCalculator);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AgeCalculator";
            this.Text = "Age Calculator";
            this.Load += new System.EventHandler(this.AgeCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label lblAge;
    }
}

