namespace AlarmClock
{
    partial class GBRAlarmClock
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
            this.lblTime = new System.Windows.Forms.Label();
            this.lblErrors = new System.Windows.Forms.Label();
            this.btnStopAlarm = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.comboAmPm = new System.Windows.Forms.ComboBox();
            this.txtAlarmTimer = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTime.Location = new System.Drawing.Point(11, 24);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(190, 44);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "00:00 AM";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.ForeColor = System.Drawing.Color.Red;
            this.lblErrors.Location = new System.Drawing.Point(14, 135);
            this.lblErrors.Margin = new System.Windows.Forms.Padding(6);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(33, 13);
            this.lblErrors.TabIndex = 1;
            this.lblErrors.Text = "errors";
            // 
            // btnStopAlarm
            // 
            this.btnStopAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStopAlarm.FlatAppearance.BorderSize = 0;
            this.btnStopAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopAlarm.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnStopAlarm.Location = new System.Drawing.Point(226, 27);
            this.btnStopAlarm.Margin = new System.Windows.Forms.Padding(6);
            this.btnStopAlarm.Name = "btnStopAlarm";
            this.btnStopAlarm.Size = new System.Drawing.Size(75, 44);
            this.btnStopAlarm.TabIndex = 4;
            this.btnStopAlarm.Text = "STOP ALARM";
            this.btnStopAlarm.UseVisualStyleBackColor = false;
            this.btnStopAlarm.Click += new System.EventHandler(this.StopAlarm);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnAbout.Location = new System.Drawing.Point(226, 83);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(6);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "about";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkActive.Location = new System.Drawing.Point(14, 106);
            this.checkActive.Margin = new System.Windows.Forms.Padding(6);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(85, 17);
            this.checkActive.TabIndex = 3;
            this.checkActive.Text = "Alarm Active";
            this.checkActive.UseVisualStyleBackColor = true;
            this.checkActive.Click += new System.EventHandler(this.ChangeAlarmState);
            // 
            // comboAmPm
            // 
            this.comboAmPm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboAmPm.FormattingEnabled = true;
            this.comboAmPm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.comboAmPm.Location = new System.Drawing.Point(131, 73);
            this.comboAmPm.Margin = new System.Windows.Forms.Padding(6);
            this.comboAmPm.MaxDropDownItems = 2;
            this.comboAmPm.Name = "comboAmPm";
            this.comboAmPm.Size = new System.Drawing.Size(60, 21);
            this.comboAmPm.TabIndex = 2;
            this.comboAmPm.Leave += new System.EventHandler(this.ValidateTime);
            // 
            // txtAlarmTimer
            // 
            this.txtAlarmTimer.Location = new System.Drawing.Point(14, 74);
            this.txtAlarmTimer.Margin = new System.Windows.Forms.Padding(6);
            this.txtAlarmTimer.Mask = "90:00";
            this.txtAlarmTimer.Name = "txtAlarmTimer";
            this.txtAlarmTimer.Size = new System.Drawing.Size(100, 20);
            this.txtAlarmTimer.TabIndex = 1;
            this.txtAlarmTimer.ValidatingType = typeof(System.DateTime);
            this.txtAlarmTimer.Leave += new System.EventHandler(this.ValidateTime);
            // 
            // GBRAlarmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(312, 184);
            this.Controls.Add(this.txtAlarmTimer);
            this.Controls.Add(this.comboAmPm);
            this.Controls.Add(this.checkActive);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnStopAlarm);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.lblTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GBRAlarmClock";
            this.Padding = new System.Windows.Forms.Padding(8, 24, 8, 12);
            this.Text = "GBR Alarm Clock";
            this.Load += new System.EventHandler(this.GBRAlarmClock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Button btnStopAlarm;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.ComboBox comboAmPm;
        private System.Windows.Forms.MaskedTextBox txtAlarmTimer;
    }
}

