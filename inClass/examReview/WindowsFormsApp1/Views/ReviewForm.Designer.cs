namespace WindowsFormsApp1
{
    partial class ReviewForm
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
            this.gboxPart1 = new System.Windows.Forms.GroupBox();
            this.btnSavePt1 = new System.Windows.Forms.Button();
            this.rtxtErrorsPt1 = new System.Windows.Forms.RichTextBox();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gboxPart2 = new System.Windows.Forms.GroupBox();
            this.txtInputThree = new System.Windows.Forms.TextBox();
            this.lblInputThree = new System.Windows.Forms.Label();
            this.txtInputTwo = new System.Windows.Forms.TextBox();
            this.lblInputTwo = new System.Windows.Forms.Label();
            this.txtInputOne = new System.Windows.Forms.TextBox();
            this.lblInputOne = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rtxtDisplay = new System.Windows.Forms.RichTextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gboxActions = new System.Windows.Forms.GroupBox();
            this.btnReverse = new System.Windows.Forms.Button();
            this.rtxtErrorsPt2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxPart1.SuspendLayout();
            this.gboxPart2.SuspendLayout();
            this.gboxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxPart1
            // 
            this.gboxPart1.Controls.Add(this.txtName);
            this.gboxPart1.Controls.Add(this.lblName);
            this.gboxPart1.Controls.Add(this.txtCode);
            this.gboxPart1.Controls.Add(this.lblCode);
            this.gboxPart1.Controls.Add(this.txtId);
            this.gboxPart1.Controls.Add(this.lblId);
            this.gboxPart1.Controls.Add(this.lblErrors);
            this.gboxPart1.Controls.Add(this.rtxtErrorsPt1);
            this.gboxPart1.Controls.Add(this.btnSavePt1);
            this.gboxPart1.Location = new System.Drawing.Point(8, 8);
            this.gboxPart1.Margin = new System.Windows.Forms.Padding(4);
            this.gboxPart1.Name = "gboxPart1";
            this.gboxPart1.Padding = new System.Windows.Forms.Padding(4);
            this.gboxPart1.Size = new System.Drawing.Size(366, 135);
            this.gboxPart1.TabIndex = 0;
            this.gboxPart1.TabStop = false;
            this.gboxPart1.Text = "Part 1";
            // 
            // btnSavePt1
            // 
            this.btnSavePt1.Location = new System.Drawing.Point(53, 97);
            this.btnSavePt1.Name = "btnSavePt1";
            this.btnSavePt1.Size = new System.Drawing.Size(100, 23);
            this.btnSavePt1.TabIndex = 3;
            this.btnSavePt1.Text = "Save";
            this.btnSavePt1.UseVisualStyleBackColor = true;
            this.btnSavePt1.Click += new System.EventHandler(this.btnSavePt1_Click);
            // 
            // rtxtErrorsPt1
            // 
            this.rtxtErrorsPt1.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtErrorsPt1.Location = new System.Drawing.Point(160, 33);
            this.rtxtErrorsPt1.Name = "rtxtErrorsPt1";
            this.rtxtErrorsPt1.ReadOnly = true;
            this.rtxtErrorsPt1.Size = new System.Drawing.Size(199, 87);
            this.rtxtErrorsPt1.TabIndex = 4;
            this.rtxtErrorsPt1.Text = "";
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(157, 14);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(34, 13);
            this.lblErrors.TabIndex = 5;
            this.lblErrors.Text = "Errors";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(24, 17);
            this.lblId.Margin = new System.Windows.Forms.Padding(4);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(53, 14);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.MaxLength = 2;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitsOnly);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(53, 42);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCode.MaxLength = 1;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 1;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(10, 45);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 13);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Code:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 70);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 73);
            this.lblName.Margin = new System.Windows.Forms.Padding(4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            // 
            // gboxPart2
            // 
            this.gboxPart2.Controls.Add(this.label1);
            this.gboxPart2.Controls.Add(this.rtxtErrorsPt2);
            this.gboxPart2.Controls.Add(this.gboxActions);
            this.gboxPart2.Controls.Add(this.txtInputThree);
            this.gboxPart2.Controls.Add(this.lblInputThree);
            this.gboxPart2.Controls.Add(this.txtInputTwo);
            this.gboxPart2.Controls.Add(this.lblInputTwo);
            this.gboxPart2.Controls.Add(this.txtInputOne);
            this.gboxPart2.Controls.Add(this.lblInputOne);
            this.gboxPart2.Controls.Add(this.label4);
            this.gboxPart2.Controls.Add(this.rtxtDisplay);
            this.gboxPart2.Location = new System.Drawing.Point(8, 151);
            this.gboxPart2.Margin = new System.Windows.Forms.Padding(4);
            this.gboxPart2.Name = "gboxPart2";
            this.gboxPart2.Padding = new System.Windows.Forms.Padding(4);
            this.gboxPart2.Size = new System.Drawing.Size(366, 226);
            this.gboxPart2.TabIndex = 6;
            this.gboxPart2.TabStop = false;
            this.gboxPart2.Text = "Part 2";
            // 
            // txtInputThree
            // 
            this.txtInputThree.Location = new System.Drawing.Point(66, 70);
            this.txtInputThree.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputThree.Name = "txtInputThree";
            this.txtInputThree.Size = new System.Drawing.Size(178, 20);
            this.txtInputThree.TabIndex = 2;
            // 
            // lblInputThree
            // 
            this.lblInputThree.AutoSize = true;
            this.lblInputThree.Location = new System.Drawing.Point(6, 73);
            this.lblInputThree.Margin = new System.Windows.Forms.Padding(4);
            this.lblInputThree.Name = "lblInputThree";
            this.lblInputThree.Size = new System.Drawing.Size(52, 13);
            this.lblInputThree.TabIndex = 3;
            this.lblInputThree.Text = "3rd Input:";
            // 
            // txtInputTwo
            // 
            this.txtInputTwo.Location = new System.Drawing.Point(66, 42);
            this.txtInputTwo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputTwo.Name = "txtInputTwo";
            this.txtInputTwo.Size = new System.Drawing.Size(178, 20);
            this.txtInputTwo.TabIndex = 1;
            // 
            // lblInputTwo
            // 
            this.lblInputTwo.AutoSize = true;
            this.lblInputTwo.Location = new System.Drawing.Point(3, 45);
            this.lblInputTwo.Margin = new System.Windows.Forms.Padding(4);
            this.lblInputTwo.Name = "lblInputTwo";
            this.lblInputTwo.Size = new System.Drawing.Size(55, 13);
            this.lblInputTwo.TabIndex = 2;
            this.lblInputTwo.Text = "2nd Input:";
            // 
            // txtInputOne
            // 
            this.txtInputOne.Location = new System.Drawing.Point(66, 14);
            this.txtInputOne.Margin = new System.Windows.Forms.Padding(4);
            this.txtInputOne.Name = "txtInputOne";
            this.txtInputOne.Size = new System.Drawing.Size(178, 20);
            this.txtInputOne.TabIndex = 0;
            // 
            // lblInputOne
            // 
            this.lblInputOne.AutoSize = true;
            this.lblInputOne.Location = new System.Drawing.Point(7, 17);
            this.lblInputOne.Margin = new System.Windows.Forms.Padding(4);
            this.lblInputOne.Name = "lblInputOne";
            this.lblInputOne.Size = new System.Drawing.Size(51, 13);
            this.lblInputOne.TabIndex = 1;
            this.lblInputOne.Text = "1st Input:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Errors";
            // 
            // rtxtDisplay
            // 
            this.rtxtDisplay.BackColor = System.Drawing.SystemColors.WindowText;
            this.rtxtDisplay.ForeColor = System.Drawing.SystemColors.Window;
            this.rtxtDisplay.Location = new System.Drawing.Point(7, 110);
            this.rtxtDisplay.Name = "rtxtDisplay";
            this.rtxtDisplay.ReadOnly = true;
            this.rtxtDisplay.Size = new System.Drawing.Size(178, 109);
            this.rtxtDisplay.TabIndex = 5;
            this.rtxtDisplay.Text = "";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add/Display";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gboxActions
            // 
            this.gboxActions.Controls.Add(this.btnReverse);
            this.gboxActions.Controls.Add(this.btnAdd);
            this.gboxActions.Location = new System.Drawing.Point(251, 14);
            this.gboxActions.Name = "gboxActions";
            this.gboxActions.Size = new System.Drawing.Size(108, 80);
            this.gboxActions.TabIndex = 6;
            this.gboxActions.TabStop = false;
            this.gboxActions.Text = "actions";
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(6, 49);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(96, 23);
            this.btnReverse.TabIndex = 4;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // rtxtErrorsPt2
            // 
            this.rtxtErrorsPt2.BackColor = System.Drawing.SystemColors.Window;
            this.rtxtErrorsPt2.Location = new System.Drawing.Point(191, 110);
            this.rtxtErrorsPt2.Name = "rtxtErrorsPt2";
            this.rtxtErrorsPt2.ReadOnly = true;
            this.rtxtErrorsPt2.Size = new System.Drawing.Size(168, 109);
            this.rtxtErrorsPt2.TabIndex = 6;
            this.rtxtErrorsPt2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Display";
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 385);
            this.Controls.Add(this.gboxPart2);
            this.Controls.Add(this.gboxPart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReviewForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "Exam Review";
            this.Load += new System.EventHandler(this.ReviewForm_Load);
            this.gboxPart1.ResumeLayout(false);
            this.gboxPart1.PerformLayout();
            this.gboxPart2.ResumeLayout(false);
            this.gboxPart2.PerformLayout();
            this.gboxActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxPart1;
        private System.Windows.Forms.Button btnSavePt1;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.RichTextBox rtxtErrorsPt1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.GroupBox gboxPart2;
        private System.Windows.Forms.TextBox txtInputThree;
        private System.Windows.Forms.Label lblInputThree;
        private System.Windows.Forms.TextBox txtInputTwo;
        private System.Windows.Forms.Label lblInputTwo;
        private System.Windows.Forms.TextBox txtInputOne;
        private System.Windows.Forms.Label lblInputOne;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtxtDisplay;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gboxActions;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.RichTextBox rtxtErrorsPt2;
        private System.Windows.Forms.Label label1;
    }
}

