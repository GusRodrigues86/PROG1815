namespace AirlineReservation
{
    partial class AirlineReservation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lstBoxSeat = new System.Windows.Forms.ListBox();
            this.lstBoxRow = new System.Windows.Forms.ListBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnWaitList = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTipName = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn1a = new System.Windows.Forms.Button();
            this.btn1b = new System.Windows.Forms.Button();
            this.btn1d = new System.Windows.Forms.Button();
            this.btn1c = new System.Windows.Forms.Button();
            this.btn2d = new System.Windows.Forms.Button();
            this.btn2c = new System.Windows.Forms.Button();
            this.btn2b = new System.Windows.Forms.Button();
            this.btn2a = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btn3d = new System.Windows.Forms.Button();
            this.btn3c = new System.Windows.Forms.Button();
            this.btn3b = new System.Windows.Forms.Button();
            this.btn3a = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btn4d = new System.Windows.Forms.Button();
            this.btn4c = new System.Windows.Forms.Button();
            this.btn4b = new System.Windows.Forms.Button();
            this.btn4a = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btn5d = new System.Windows.Forms.Button();
            this.btn5c = new System.Windows.Forms.Button();
            this.btn5B = new System.Windows.Forms.Button();
            this.btn5a = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAllSeats = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.toolTipSeatStatus = new System.Windows.Forms.ToolTip(this.components);
            this.rtxtboxSeated = new System.Windows.Forms.RichTextBox();
            this.rtxtWaitlist = new System.Windows.Forms.RichTextBox();
            this.lblMessages = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.lstBoxSeat);
            this.groupBox1.Controls.Add(this.lstBoxRow);
            this.groupBox1.Controls.Add(this.btnStatus);
            this.groupBox1.Controls.Add(this.btnWaitList);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnBook);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(217, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 214);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Booking and Cancelation";
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.Location = new System.Drawing.Point(128, 89);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(209, 20);
            this.txtStatus.TabIndex = 5;
            this.toolTipSeatStatus.SetToolTip(this.txtStatus, "The Status of the selected seat");
            // 
            // lstBoxSeat
            // 
            this.lstBoxSeat.FormattingEnabled = true;
            this.lstBoxSeat.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.lstBoxSeat.Location = new System.Drawing.Point(63, 61);
            this.lstBoxSeat.Name = "lstBoxSeat";
            this.lstBoxSeat.Size = new System.Drawing.Size(35, 69);
            this.lstBoxSeat.Sorted = true;
            this.lstBoxSeat.TabIndex = 3;
            // 
            // lstBoxRow
            // 
            this.lstBoxRow.FormattingEnabled = true;
            this.lstBoxRow.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.lstBoxRow.Location = new System.Drawing.Point(19, 61);
            this.lstBoxRow.Name = "lstBoxRow";
            this.lstBoxRow.Size = new System.Drawing.Size(35, 69);
            this.lstBoxRow.Sorted = true;
            this.lstBoxRow.TabIndex = 2;
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(128, 61);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnSeatStatus);
            // 
            // btnWaitList
            // 
            this.btnWaitList.Location = new System.Drawing.Point(19, 167);
            this.btnWaitList.Name = "btnWaitList";
            this.btnWaitList.Size = new System.Drawing.Size(156, 23);
            this.btnWaitList.TabIndex = 8;
            this.btnWaitList.Text = "Add to Wait List";
            this.btnWaitList.UseVisualStyleBackColor = true;
            this.btnWaitList.Click += new System.EventHandler(this.btnAddToWaitlist);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(100, 138);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBook
            // 
            this.btnBook.Location = new System.Drawing.Point(19, 138);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(75, 23);
            this.btnBook.TabIndex = 6;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = true;
            this.btnBook.Click += new System.EventHandler(this.btnBookSeat);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Seat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Row";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(60, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(277, 20);
            this.txtName.TabIndex = 1;
            this.toolTipName.SetToolTip(this.txtName, "Type the customer name");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // toolTipName
            // 
            this.toolTipName.IsBalloon = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "B";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(150, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "D";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(117, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "C";
            // 
            // btn1a
            // 
            this.btn1a.ForeColor = System.Drawing.SystemColors.Control;
            this.btn1a.Location = new System.Drawing.Point(32, 41);
            this.btn1a.Name = "btn1a";
            this.btn1a.Size = new System.Drawing.Size(23, 23);
            this.btn1a.TabIndex = 6;
            this.btn1a.TabStop = false;
            this.btn1a.Tag = "1A";
            this.btn1a.UseVisualStyleBackColor = true;
            this.btn1a.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn1b
            // 
            this.btn1b.Location = new System.Drawing.Point(61, 41);
            this.btn1b.Name = "btn1b";
            this.btn1b.Size = new System.Drawing.Size(23, 23);
            this.btn1b.TabIndex = 7;
            this.btn1b.TabStop = false;
            this.btn1b.Tag = "1B";
            this.btn1b.UseVisualStyleBackColor = true;
            this.btn1b.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn1d
            // 
            this.btn1d.Location = new System.Drawing.Point(146, 41);
            this.btn1d.Name = "btn1d";
            this.btn1d.Size = new System.Drawing.Size(23, 23);
            this.btn1d.TabIndex = 9;
            this.btn1d.TabStop = false;
            this.btn1d.Tag = "1D";
            this.btn1d.UseVisualStyleBackColor = true;
            this.btn1d.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn1c
            // 
            this.btn1c.Location = new System.Drawing.Point(113, 41);
            this.btn1c.Name = "btn1c";
            this.btn1c.Size = new System.Drawing.Size(23, 23);
            this.btn1c.TabIndex = 8;
            this.btn1c.TabStop = false;
            this.btn1c.Tag = "1C";
            this.btn1c.UseVisualStyleBackColor = true;
            this.btn1c.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn2d
            // 
            this.btn2d.Location = new System.Drawing.Point(146, 70);
            this.btn2d.Name = "btn2d";
            this.btn2d.Size = new System.Drawing.Size(23, 23);
            this.btn2d.TabIndex = 14;
            this.btn2d.TabStop = false;
            this.btn2d.Tag = "2D";
            this.btn2d.UseVisualStyleBackColor = true;
            this.btn2d.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn2c
            // 
            this.btn2c.Location = new System.Drawing.Point(113, 70);
            this.btn2c.Name = "btn2c";
            this.btn2c.Size = new System.Drawing.Size(23, 23);
            this.btn2c.TabIndex = 13;
            this.btn2c.TabStop = false;
            this.btn2c.Tag = "2C";
            this.btn2c.UseVisualStyleBackColor = true;
            this.btn2c.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn2b
            // 
            this.btn2b.Location = new System.Drawing.Point(61, 70);
            this.btn2b.Name = "btn2b";
            this.btn2b.Size = new System.Drawing.Size(23, 23);
            this.btn2b.TabIndex = 12;
            this.btn2b.TabStop = false;
            this.btn2b.Tag = "2B";
            this.btn2b.UseVisualStyleBackColor = true;
            this.btn2b.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn2a
            // 
            this.btn2a.Location = new System.Drawing.Point(32, 70);
            this.btn2a.Name = "btn2a";
            this.btn2a.Size = new System.Drawing.Size(23, 23);
            this.btn2a.TabIndex = 11;
            this.btn2a.TabStop = false;
            this.btn2a.Tag = "2A";
            this.btn2a.UseVisualStyleBackColor = true;
            this.btn2a.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "2";
            // 
            // btn3d
            // 
            this.btn3d.Location = new System.Drawing.Point(146, 99);
            this.btn3d.Name = "btn3d";
            this.btn3d.Size = new System.Drawing.Size(23, 23);
            this.btn3d.TabIndex = 19;
            this.btn3d.TabStop = false;
            this.btn3d.Tag = "3D";
            this.btn3d.UseVisualStyleBackColor = true;
            this.btn3d.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn3c
            // 
            this.btn3c.Location = new System.Drawing.Point(113, 99);
            this.btn3c.Name = "btn3c";
            this.btn3c.Size = new System.Drawing.Size(23, 23);
            this.btn3c.TabIndex = 18;
            this.btn3c.TabStop = false;
            this.btn3c.Tag = "3C";
            this.btn3c.UseVisualStyleBackColor = true;
            this.btn3c.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn3b
            // 
            this.btn3b.Location = new System.Drawing.Point(61, 99);
            this.btn3b.Name = "btn3b";
            this.btn3b.Size = new System.Drawing.Size(23, 23);
            this.btn3b.TabIndex = 17;
            this.btn3b.TabStop = false;
            this.btn3b.Tag = "3B";
            this.btn3b.UseVisualStyleBackColor = true;
            this.btn3b.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn3a
            // 
            this.btn3a.Location = new System.Drawing.Point(32, 99);
            this.btn3a.Name = "btn3a";
            this.btn3a.Size = new System.Drawing.Size(23, 23);
            this.btn3a.TabIndex = 16;
            this.btn3a.TabStop = false;
            this.btn3a.Tag = "3A";
            this.btn3a.UseVisualStyleBackColor = true;
            this.btn3a.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "3";
            // 
            // btn4d
            // 
            this.btn4d.Location = new System.Drawing.Point(146, 143);
            this.btn4d.Name = "btn4d";
            this.btn4d.Size = new System.Drawing.Size(23, 23);
            this.btn4d.TabIndex = 24;
            this.btn4d.TabStop = false;
            this.btn4d.Tag = "4D";
            this.btn4d.UseVisualStyleBackColor = true;
            this.btn4d.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn4c
            // 
            this.btn4c.Location = new System.Drawing.Point(113, 143);
            this.btn4c.Name = "btn4c";
            this.btn4c.Size = new System.Drawing.Size(23, 23);
            this.btn4c.TabIndex = 23;
            this.btn4c.TabStop = false;
            this.btn4c.Tag = "4C";
            this.btn4c.UseVisualStyleBackColor = true;
            this.btn4c.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn4b
            // 
            this.btn4b.Location = new System.Drawing.Point(61, 143);
            this.btn4b.Name = "btn4b";
            this.btn4b.Size = new System.Drawing.Size(23, 23);
            this.btn4b.TabIndex = 22;
            this.btn4b.TabStop = false;
            this.btn4b.Tag = "4B";
            this.btn4b.UseVisualStyleBackColor = true;
            this.btn4b.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn4a
            // 
            this.btn4a.Location = new System.Drawing.Point(32, 143);
            this.btn4a.Name = "btn4a";
            this.btn4a.Size = new System.Drawing.Size(23, 23);
            this.btn4a.TabIndex = 21;
            this.btn4a.TabStop = false;
            this.btn4a.Tag = "4A";
            this.btn4a.UseVisualStyleBackColor = true;
            this.btn4a.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "4";
            // 
            // btn5d
            // 
            this.btn5d.Location = new System.Drawing.Point(146, 172);
            this.btn5d.Name = "btn5d";
            this.btn5d.Size = new System.Drawing.Size(23, 23);
            this.btn5d.TabIndex = 29;
            this.btn5d.TabStop = false;
            this.btn5d.Tag = "5D";
            this.btn5d.UseVisualStyleBackColor = true;
            this.btn5d.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn5c
            // 
            this.btn5c.Location = new System.Drawing.Point(113, 172);
            this.btn5c.Name = "btn5c";
            this.btn5c.Size = new System.Drawing.Size(23, 23);
            this.btn5c.TabIndex = 28;
            this.btn5c.TabStop = false;
            this.btn5c.Tag = "5C";
            this.btn5c.UseVisualStyleBackColor = true;
            this.btn5c.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn5B
            // 
            this.btn5B.Location = new System.Drawing.Point(61, 172);
            this.btn5B.Name = "btn5B";
            this.btn5B.Size = new System.Drawing.Size(23, 23);
            this.btn5B.TabIndex = 27;
            this.btn5B.TabStop = false;
            this.btn5B.Tag = "5B";
            this.btn5B.UseVisualStyleBackColor = true;
            this.btn5B.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // btn5a
            // 
            this.btn5a.Location = new System.Drawing.Point(32, 172);
            this.btn5a.Name = "btn5a";
            this.btn5a.Size = new System.Drawing.Size(23, 23);
            this.btn5a.TabIndex = 26;
            this.btn5a.TabStop = false;
            this.btn5a.Tag = "5A";
            this.btn5a.UseVisualStyleBackColor = true;
            this.btn5a.Click += new System.EventHandler(this.btnSelectSeat);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 177);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "5";
            // 
            // btnAllSeats
            // 
            this.btnAllSeats.Location = new System.Drawing.Point(94, 246);
            this.btnAllSeats.Name = "btnAllSeats";
            this.btnAllSeats.Size = new System.Drawing.Size(105, 23);
            this.btnAllSeats.TabIndex = 9;
            this.btnAllSeats.Text = "Show All Seats";
            this.btnAllSeats.UseVisualStyleBackColor = true;
            this.btnAllSeats.Click += new System.EventHandler(this.btnShowAllSeats);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(236, 246);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(105, 23);
            this.button20.TabIndex = 30;
            this.button20.Text = "Show Waiting List";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.btnShowWaitingList);
            // 
            // toolTipSeatStatus
            // 
            this.toolTipSeatStatus.IsBalloon = true;
            // 
            // rtxtboxSeated
            // 
            this.rtxtboxSeated.Location = new System.Drawing.Point(94, 275);
            this.rtxtboxSeated.Name = "rtxtboxSeated";
            this.rtxtboxSeated.Size = new System.Drawing.Size(105, 174);
            this.rtxtboxSeated.TabIndex = 31;
            this.rtxtboxSeated.Text = "";
            // 
            // rtxtWaitlist
            // 
            this.rtxtWaitlist.Location = new System.Drawing.Point(236, 275);
            this.rtxtWaitlist.Name = "rtxtWaitlist";
            this.rtxtWaitlist.Size = new System.Drawing.Size(105, 174);
            this.rtxtWaitlist.TabIndex = 32;
            this.rtxtWaitlist.Text = "";
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.BackColor = System.Drawing.SystemColors.Control;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.ForeColor = System.Drawing.Color.Red;
            this.lblMessages.Location = new System.Drawing.Point(353, 248);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(19, 13);
            this.lblMessages.TabIndex = 33;
            this.lblMessages.Text = "...";
            // 
            // AirlineReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 461);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.rtxtWaitlist);
            this.Controls.Add(this.rtxtboxSeated);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.btnAllSeats);
            this.Controls.Add(this.btn5d);
            this.Controls.Add(this.btn5c);
            this.Controls.Add(this.btn5B);
            this.Controls.Add(this.btn5a);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn4d);
            this.Controls.Add(this.btn4c);
            this.Controls.Add(this.btn4b);
            this.Controls.Add(this.btn4a);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn3d);
            this.Controls.Add(this.btn3c);
            this.Controls.Add(this.btn3b);
            this.Controls.Add(this.btn3a);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn2d);
            this.Controls.Add(this.btn2c);
            this.Controls.Add(this.btn2b);
            this.Controls.Add(this.btn2a);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn1d);
            this.Controls.Add(this.btn1c);
            this.Controls.Add(this.btn1b);
            this.Controls.Add(this.btn1a);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AirlineReservation";
            this.Text = "Airline Reservation";
            this.Load += new System.EventHandler(this.AirlineReservation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ListBox lstBoxSeat;
        private System.Windows.Forms.ListBox lstBoxRow;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnWaitList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.ToolTip toolTipName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn1a;
        private System.Windows.Forms.Button btn1b;
        private System.Windows.Forms.Button btn1d;
        private System.Windows.Forms.Button btn1c;
        private System.Windows.Forms.Button btn2d;
        private System.Windows.Forms.Button btn2c;
        private System.Windows.Forms.Button btn2b;
        private System.Windows.Forms.Button btn2a;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn3d;
        private System.Windows.Forms.Button btn3c;
        private System.Windows.Forms.Button btn3b;
        private System.Windows.Forms.Button btn3a;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn4d;
        private System.Windows.Forms.Button btn4c;
        private System.Windows.Forms.Button btn4b;
        private System.Windows.Forms.Button btn4a;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn5d;
        private System.Windows.Forms.Button btn5c;
        private System.Windows.Forms.Button btn5B;
        private System.Windows.Forms.Button btn5a;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAllSeats;
        private System.Windows.Forms.ToolTip toolTipSeatStatus;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.RichTextBox rtxtboxSeated;
        private System.Windows.Forms.RichTextBox rtxtWaitlist;
        private System.Windows.Forms.Label lblMessages;
    }
}