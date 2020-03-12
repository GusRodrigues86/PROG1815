namespace IOAssignment
{
    partial class POTrackerForm
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
            this.rtextErrors = new System.Windows.Forms.RichTextBox();
            this.gBoxDelete = new System.Windows.Forms.GroupBox();
            this.btnDeletePO = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.lblNumberDelete = new System.Windows.Forms.Label();
            this.gBoxInsert = new System.Windows.Forms.GroupBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.datePickerInsert = new System.Windows.Forms.DateTimePicker();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNumberInsert = new System.Windows.Forms.Label();
            this.gBoxOpenFile = new System.Windows.Forms.GroupBox();
            this.btnCreateOpen = new System.Windows.Forms.Button();
            this.radioOpenExisting = new System.Windows.Forms.RadioButton();
            this.radioCreateNew = new System.Windows.Forms.RadioButton();
            this.lblFilenameAndPath = new System.Windows.Forms.Label();
            this.txtFilenameAndPath = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.gBoxDelete.SuspendLayout();
            this.gBoxInsert.SuspendLayout();
            this.gBoxOpenFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtextErrors
            // 
            this.rtextErrors.Location = new System.Drawing.Point(645, 372);
            this.rtextErrors.Name = "rtextErrors";
            this.rtextErrors.Size = new System.Drawing.Size(320, 90);
            this.rtextErrors.TabIndex = 0;
            this.rtextErrors.Text = "";
            // 
            // gBoxDelete
            // 
            this.gBoxDelete.Controls.Add(this.btnDeletePO);
            this.gBoxDelete.Controls.Add(this.textBox8);
            this.gBoxDelete.Controls.Add(this.lblNumberDelete);
            this.gBoxDelete.Location = new System.Drawing.Point(16, 386);
            this.gBoxDelete.Name = "gBoxDelete";
            this.gBoxDelete.Size = new System.Drawing.Size(237, 76);
            this.gBoxDelete.TabIndex = 1;
            this.gBoxDelete.TabStop = false;
            this.gBoxDelete.Text = "Delete Purchase Order";
            // 
            // btnDeletePO
            // 
            this.btnDeletePO.Location = new System.Drawing.Point(101, 45);
            this.btnDeletePO.Name = "btnDeletePO";
            this.btnDeletePO.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePO.TabIndex = 12;
            this.btnDeletePO.Text = "Delete";
            this.btnDeletePO.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(101, 19);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(115, 20);
            this.textBox8.TabIndex = 11;
            // 
            // lblNumberDelete
            // 
            this.lblNumberDelete.AutoSize = true;
            this.lblNumberDelete.Location = new System.Drawing.Point(48, 22);
            this.lblNumberDelete.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.lblNumberDelete.Name = "lblNumberDelete";
            this.lblNumberDelete.Size = new System.Drawing.Size(47, 13);
            this.lblNumberDelete.TabIndex = 6;
            this.lblNumberDelete.Text = "Number:";
            // 
            // gBoxInsert
            // 
            this.gBoxInsert.Controls.Add(this.btnInsert);
            this.gBoxInsert.Controls.Add(this.comboBox1);
            this.gBoxInsert.Controls.Add(this.datePickerInsert);
            this.gBoxInsert.Controls.Add(this.textBox6);
            this.gBoxInsert.Controls.Add(this.textBox5);
            this.gBoxInsert.Controls.Add(this.textBox4);
            this.gBoxInsert.Controls.Add(this.textBox3);
            this.gBoxInsert.Controls.Add(this.textBox2);
            this.gBoxInsert.Controls.Add(this.textBox1);
            this.gBoxInsert.Controls.Add(this.label7);
            this.gBoxInsert.Controls.Add(this.label6);
            this.gBoxInsert.Controls.Add(this.label5);
            this.gBoxInsert.Controls.Add(this.label4);
            this.gBoxInsert.Controls.Add(this.label3);
            this.gBoxInsert.Controls.Add(this.label2);
            this.gBoxInsert.Controls.Add(this.lblDate);
            this.gBoxInsert.Controls.Add(this.lblNumberInsert);
            this.gBoxInsert.Location = new System.Drawing.Point(16, 63);
            this.gBoxInsert.Margin = new System.Windows.Forms.Padding(8);
            this.gBoxInsert.Name = "gBoxInsert";
            this.gBoxInsert.Size = new System.Drawing.Size(222, 312);
            this.gBoxInsert.TabIndex = 2;
            this.gBoxInsert.TabStop = false;
            this.gBoxInsert.Text = "Insert Purchase Order";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(104, 272);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 10;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 217);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(112, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // datePickerInsert
            // 
            this.datePickerInsert.CustomFormat = "yyyy-MM-dd";
            this.datePickerInsert.Location = new System.Drawing.Point(104, 47);
            this.datePickerInsert.Name = "datePickerInsert";
            this.datePickerInsert.Size = new System.Drawing.Size(112, 20);
            this.datePickerInsert.TabIndex = 3;
            this.datePickerInsert.Value = new System.DateTime(2020, 3, 9, 0, 0, 0, 0);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(104, 246);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(112, 20);
            this.textBox6.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(104, 188);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(112, 20);
            this.textBox5.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(104, 140);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(112, 42);
            this.textBox4.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(104, 108);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(104, 79);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 249);
            this.label7.Margin = new System.Windows.Forms.Padding(8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Unit Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 220);
            this.label6.Margin = new System.Windows.Forms.Padding(8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Unit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 191);
            this.label5.Margin = new System.Windows.Forms.Padding(8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ordered:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ship to:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Purchased From:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(65, 53);
            this.lblDate.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date:";
            // 
            // lblNumberInsert
            // 
            this.lblNumberInsert.AutoSize = true;
            this.lblNumberInsert.Location = new System.Drawing.Point(51, 24);
            this.lblNumberInsert.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.lblNumberInsert.Name = "lblNumberInsert";
            this.lblNumberInsert.Size = new System.Drawing.Size(47, 13);
            this.lblNumberInsert.TabIndex = 5;
            this.lblNumberInsert.Text = "Number:";
            // 
            // gBoxOpenFile
            // 
            this.gBoxOpenFile.Controls.Add(this.btnCreateOpen);
            this.gBoxOpenFile.Controls.Add(this.radioOpenExisting);
            this.gBoxOpenFile.Controls.Add(this.radioCreateNew);
            this.gBoxOpenFile.Location = new System.Drawing.Point(320, 16);
            this.gBoxOpenFile.Name = "gBoxOpenFile";
            this.gBoxOpenFile.Size = new System.Drawing.Size(347, 55);
            this.gBoxOpenFile.TabIndex = 3;
            this.gBoxOpenFile.TabStop = false;
            this.gBoxOpenFile.Text = "File Open Options";
            // 
            // btnCreateOpen
            // 
            this.btnCreateOpen.Location = new System.Drawing.Point(191, 14);
            this.btnCreateOpen.Name = "btnCreateOpen";
            this.btnCreateOpen.Size = new System.Drawing.Size(150, 23);
            this.btnCreateOpen.TabIndex = 22;
            this.btnCreateOpen.Text = "Create / Open File";
            this.btnCreateOpen.UseVisualStyleBackColor = true;
            // 
            // radioOpenExisting
            // 
            this.radioOpenExisting.AutoSize = true;
            this.radioOpenExisting.Location = new System.Drawing.Point(95, 19);
            this.radioOpenExisting.Name = "radioOpenExisting";
            this.radioOpenExisting.Size = new System.Drawing.Size(90, 17);
            this.radioOpenExisting.TabIndex = 1;
            this.radioOpenExisting.TabStop = true;
            this.radioOpenExisting.Text = "Open Existing";
            this.radioOpenExisting.UseVisualStyleBackColor = true;
            // 
            // radioCreateNew
            // 
            this.radioCreateNew.AutoSize = true;
            this.radioCreateNew.Location = new System.Drawing.Point(6, 19);
            this.radioCreateNew.Name = "radioCreateNew";
            this.radioCreateNew.Size = new System.Drawing.Size(81, 17);
            this.radioCreateNew.TabIndex = 0;
            this.radioCreateNew.TabStop = true;
            this.radioCreateNew.Text = "Create New";
            this.radioCreateNew.UseVisualStyleBackColor = true;
            // 
            // lblFilenameAndPath
            // 
            this.lblFilenameAndPath.AutoSize = true;
            this.lblFilenameAndPath.Location = new System.Drawing.Point(16, 16);
            this.lblFilenameAndPath.Name = "lblFilenameAndPath";
            this.lblFilenameAndPath.Size = new System.Drawing.Size(95, 13);
            this.lblFilenameAndPath.TabIndex = 4;
            this.lblFilenameAndPath.Text = "Filename and Path";
            // 
            // txtFilenameAndPath
            // 
            this.txtFilenameAndPath.Location = new System.Drawing.Point(16, 32);
            this.txtFilenameAndPath.Name = "txtFilenameAndPath";
            this.txtFilenameAndPath.Size = new System.Drawing.Size(278, 20);
            this.txtFilenameAndPath.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(259, 408);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.button3.Size = new System.Drawing.Size(148, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Display Purchase Order";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(423, 408);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 24;
            this.button4.Text = "Close Form";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(539, 408);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 25;
            this.button5.Text = "Empty File";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // POTrackerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 481);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtFilenameAndPath);
            this.Controls.Add(this.lblFilenameAndPath);
            this.Controls.Add(this.gBoxOpenFile);
            this.Controls.Add(this.gBoxInsert);
            this.Controls.Add(this.gBoxDelete);
            this.Controls.Add(this.rtextErrors);
            this.Name = "POTrackerForm";
            this.Padding = new System.Windows.Forms.Padding(16);
            this.Text = "Purchase Order Tracker";
            this.gBoxDelete.ResumeLayout(false);
            this.gBoxDelete.PerformLayout();
            this.gBoxInsert.ResumeLayout(false);
            this.gBoxInsert.PerformLayout();
            this.gBoxOpenFile.ResumeLayout(false);
            this.gBoxOpenFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtextErrors;
        private System.Windows.Forms.GroupBox gBoxDelete;
        private System.Windows.Forms.Label lblNumberDelete;
        private System.Windows.Forms.GroupBox gBoxInsert;
        private System.Windows.Forms.DateTimePicker datePickerInsert;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblNumberInsert;
        private System.Windows.Forms.GroupBox gBoxOpenFile;
        private System.Windows.Forms.Label lblFilenameAndPath;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioOpenExisting;
        private System.Windows.Forms.RadioButton radioCreateNew;
        private System.Windows.Forms.TextBox txtFilenameAndPath;
        private System.Windows.Forms.Button btnDeletePO;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnCreateOpen;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

