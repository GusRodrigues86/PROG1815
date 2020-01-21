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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.textBox1);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 20);
            this.textBox1.TabIndex = 5;
            this.toolTipSeatStatus.SetToolTip(this.textBox1, "The Status of the selected seat");
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
            // 
            // btnWaitList
            // 
            this.btnWaitList.Location = new System.Drawing.Point(19, 167);
            this.btnWaitList.Name = "btnWaitList";
            this.btnWaitList.Size = new System.Drawing.Size(156, 23);
            this.btnWaitList.TabIndex = 8;
            this.btnWaitList.Text = "Add to Wait List";
            this.btnWaitList.UseVisualStyleBackColor = true;
            this.btnWaitList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAddToWaitlist);
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
            this.btn1a.Location = new System.Drawing.Point(32, 41);
            this.btn1a.Name = "btn1a";
            this.btn1a.Size = new System.Drawing.Size(23, 23);
            this.btn1a.TabIndex = 6;
            this.btn1a.TabStop = false;
            this.btn1a.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 7;
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 9;
            this.button2.TabStop = false;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(113, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 8;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(146, 70);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 14;
            this.button4.TabStop = false;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(113, 70);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 13;
            this.button5.TabStop = false;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(61, 70);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 23);
            this.button6.TabIndex = 12;
            this.button6.TabStop = false;
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(32, 70);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 23);
            this.button7.TabIndex = 11;
            this.button7.TabStop = false;
            this.button7.UseVisualStyleBackColor = true;
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
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(146, 99);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(23, 23);
            this.button8.TabIndex = 19;
            this.button8.TabStop = false;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(113, 99);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(23, 23);
            this.button9.TabIndex = 18;
            this.button9.TabStop = false;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(61, 99);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(23, 23);
            this.button10.TabIndex = 17;
            this.button10.TabStop = false;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(32, 99);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(23, 23);
            this.button11.TabIndex = 16;
            this.button11.TabStop = false;
            this.button11.UseVisualStyleBackColor = true;
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
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(146, 143);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(23, 23);
            this.button12.TabIndex = 24;
            this.button12.TabStop = false;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(113, 143);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(23, 23);
            this.button13.TabIndex = 23;
            this.button13.TabStop = false;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(61, 143);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(23, 23);
            this.button14.TabIndex = 22;
            this.button14.TabStop = false;
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(32, 143);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(23, 23);
            this.button15.TabIndex = 21;
            this.button15.TabStop = false;
            this.button15.UseVisualStyleBackColor = true;
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
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(146, 172);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(23, 23);
            this.button16.TabIndex = 29;
            this.button16.TabStop = false;
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(113, 172);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(23, 23);
            this.button17.TabIndex = 28;
            this.button17.TabStop = false;
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(61, 172);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(23, 23);
            this.button18.TabIndex = 27;
            this.button18.TabStop = false;
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(32, 172);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(23, 23);
            this.button19.TabIndex = 26;
            this.button19.TabStop = false;
            this.button19.UseVisualStyleBackColor = true;
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
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(236, 246);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(105, 23);
            this.button20.TabIndex = 30;
            this.button20.Text = "Show Waiting List";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnShowWaitingList);
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
            this.lblMessages.Enabled = false;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.ForeColor = System.Drawing.Color.DarkRed;
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
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.TextBox textBox1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnAllSeats;
        private System.Windows.Forms.ToolTip toolTipSeatStatus;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.RichTextBox rtxtboxSeated;
        private System.Windows.Forms.RichTextBox rtxtWaitlist;
        private System.Windows.Forms.Label lblMessages;
    }
}