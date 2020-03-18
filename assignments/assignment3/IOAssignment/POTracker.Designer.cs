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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POTrackerForm));
            this.rtextErrors = new System.Windows.Forms.RichTextBox();
            this.gBoxDelete = new System.Windows.Forms.GroupBox();
            this.btnDeletePO = new System.Windows.Forms.Button();
            this.txtDeleteNumber = new System.Windows.Forms.TextBox();
            this.lblNumberDelete = new System.Windows.Forms.Label();
            this.gBoxInsert = new System.Windows.Forms.GroupBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.comboUnit = new System.Windows.Forms.ComboBox();
            this.datePickerPurchase = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtOrdered = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
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
            this.btnDisplayOrders = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEmptyFile = new System.Windows.Forms.Button();
            this.listPurchaseData = new System.Windows.Forms.ListView();
            this.chNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrdered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAmmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gBoxDelete.SuspendLayout();
            this.gBoxInsert.SuspendLayout();
            this.gBoxOpenFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtextErrors
            // 
            resources.ApplyResources(this.rtextErrors, "rtextErrors");
            this.rtextErrors.Name = "rtextErrors";
            // 
            // gBoxDelete
            // 
            this.gBoxDelete.Controls.Add(this.btnDeletePO);
            this.gBoxDelete.Controls.Add(this.txtDeleteNumber);
            this.gBoxDelete.Controls.Add(this.lblNumberDelete);
            resources.ApplyResources(this.gBoxDelete, "gBoxDelete");
            this.gBoxDelete.Name = "gBoxDelete";
            this.gBoxDelete.TabStop = false;
            // 
            // btnDeletePO
            // 
            resources.ApplyResources(this.btnDeletePO, "btnDeletePO");
            this.btnDeletePO.Name = "btnDeletePO";
            this.btnDeletePO.UseVisualStyleBackColor = true;
            // 
            // txtDeleteNumber
            // 
            resources.ApplyResources(this.txtDeleteNumber, "txtDeleteNumber");
            this.txtDeleteNumber.Name = "txtDeleteNumber";
            // 
            // lblNumberDelete
            // 
            resources.ApplyResources(this.lblNumberDelete, "lblNumberDelete");
            this.lblNumberDelete.Name = "lblNumberDelete";
            // 
            // gBoxInsert
            // 
            this.gBoxInsert.Controls.Add(this.btnInsert);
            this.gBoxInsert.Controls.Add(this.comboUnit);
            this.gBoxInsert.Controls.Add(this.datePickerPurchase);
            this.gBoxInsert.Controls.Add(this.txtPrice);
            this.gBoxInsert.Controls.Add(this.txtOrdered);
            this.gBoxInsert.Controls.Add(this.txtDescription);
            this.gBoxInsert.Controls.Add(this.txtTo);
            this.gBoxInsert.Controls.Add(this.txtFrom);
            this.gBoxInsert.Controls.Add(this.txtIdNumber);
            this.gBoxInsert.Controls.Add(this.label7);
            this.gBoxInsert.Controls.Add(this.label6);
            this.gBoxInsert.Controls.Add(this.label5);
            this.gBoxInsert.Controls.Add(this.label4);
            this.gBoxInsert.Controls.Add(this.label3);
            this.gBoxInsert.Controls.Add(this.label2);
            this.gBoxInsert.Controls.Add(this.lblDate);
            this.gBoxInsert.Controls.Add(this.lblNumberInsert);
            resources.ApplyResources(this.gBoxInsert, "gBoxInsert");
            this.gBoxInsert.Name = "gBoxInsert";
            this.gBoxInsert.TabStop = false;
            // 
            // btnInsert
            // 
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // comboUnit
            // 
            this.comboUnit.FormattingEnabled = true;
            this.comboUnit.Items.AddRange(new object[] {
            resources.GetString("comboUnit.Items")});
            resources.ApplyResources(this.comboUnit, "comboUnit");
            this.comboUnit.Name = "comboUnit";
            // 
            // datePickerPurchase
            // 
            resources.ApplyResources(this.datePickerPurchase, "datePickerPurchase");
            this.datePickerPurchase.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerPurchase.Name = "datePickerPurchase";
            this.datePickerPurchase.Value = new System.DateTime(2020, 3, 9, 0, 0, 0, 0);
            // 
            // txtPrice
            // 
            resources.ApplyResources(this.txtPrice, "txtPrice");
            this.txtPrice.Name = "txtPrice";
            // 
            // txtOrdered
            // 
            resources.ApplyResources(this.txtOrdered, "txtOrdered");
            this.txtOrdered.Name = "txtOrdered";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            // 
            // txtTo
            // 
            resources.ApplyResources(this.txtTo, "txtTo");
            this.txtTo.Name = "txtTo";
            // 
            // txtFrom
            // 
            resources.ApplyResources(this.txtFrom, "txtFrom");
            this.txtFrom.Name = "txtFrom";
            // 
            // txtIdNumber
            // 
            resources.ApplyResources(this.txtIdNumber, "txtIdNumber");
            this.txtIdNumber.Name = "txtIdNumber";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // lblNumberInsert
            // 
            resources.ApplyResources(this.lblNumberInsert, "lblNumberInsert");
            this.lblNumberInsert.Name = "lblNumberInsert";
            // 
            // gBoxOpenFile
            // 
            this.gBoxOpenFile.Controls.Add(this.btnCreateOpen);
            this.gBoxOpenFile.Controls.Add(this.radioOpenExisting);
            this.gBoxOpenFile.Controls.Add(this.radioCreateNew);
            resources.ApplyResources(this.gBoxOpenFile, "gBoxOpenFile");
            this.gBoxOpenFile.Name = "gBoxOpenFile";
            this.gBoxOpenFile.TabStop = false;
            // 
            // btnCreateOpen
            // 
            resources.ApplyResources(this.btnCreateOpen, "btnCreateOpen");
            this.btnCreateOpen.Name = "btnCreateOpen";
            this.btnCreateOpen.UseVisualStyleBackColor = true;
            this.btnCreateOpen.Click += new System.EventHandler(this.CreateOpenClick);
            // 
            // radioOpenExisting
            // 
            resources.ApplyResources(this.radioOpenExisting, "radioOpenExisting");
            this.radioOpenExisting.Checked = true;
            this.radioOpenExisting.Name = "radioOpenExisting";
            this.radioOpenExisting.TabStop = true;
            this.radioOpenExisting.UseVisualStyleBackColor = true;
            // 
            // radioCreateNew
            // 
            resources.ApplyResources(this.radioCreateNew, "radioCreateNew");
            this.radioCreateNew.Name = "radioCreateNew";
            this.radioCreateNew.UseVisualStyleBackColor = true;
            // 
            // lblFilenameAndPath
            // 
            resources.ApplyResources(this.lblFilenameAndPath, "lblFilenameAndPath");
            this.lblFilenameAndPath.Name = "lblFilenameAndPath";
            // 
            // txtFilenameAndPath
            // 
            resources.ApplyResources(this.txtFilenameAndPath, "txtFilenameAndPath");
            this.txtFilenameAndPath.Name = "txtFilenameAndPath";
            // 
            // btnDisplayOrders
            // 
            resources.ApplyResources(this.btnDisplayOrders, "btnDisplayOrders");
            this.btnDisplayOrders.Name = "btnDisplayOrders";
            this.btnDisplayOrders.UseVisualStyleBackColor = true;
            this.btnDisplayOrders.Click += new System.EventHandler(this.btnDisplayOrders_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEmptyFile
            // 
            resources.ApplyResources(this.btnEmptyFile, "btnEmptyFile");
            this.btnEmptyFile.Name = "btnEmptyFile";
            this.btnEmptyFile.Tag = "empty";
            this.btnEmptyFile.UseVisualStyleBackColor = true;
            this.btnEmptyFile.Click += new System.EventHandler(this.CreateOpenClick);
            // 
            // listPurchaseData
            // 
            this.listPurchaseData.BackColor = System.Drawing.SystemColors.Window;
            this.listPurchaseData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listPurchaseData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNumber,
            this.chDate,
            this.chFrom,
            this.chTo,
            this.chOrdered,
            this.chUnit,
            this.chUnitPrice,
            this.chAmmount,
            this.chTotal});
            resources.ApplyResources(this.listPurchaseData, "listPurchaseData");
            this.listPurchaseData.FullRowSelect = true;
            this.listPurchaseData.GridLines = true;
            this.listPurchaseData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listPurchaseData.HideSelection = false;
            this.listPurchaseData.MultiSelect = false;
            this.listPurchaseData.Name = "listPurchaseData";
            this.listPurchaseData.UseCompatibleStateImageBehavior = false;
            this.listPurchaseData.View = System.Windows.Forms.View.Details;
            this.listPurchaseData.SelectedIndexChanged += new System.EventHandler(this.listPurchaseData_SelectedIndexChanged);
            // 
            // chNumber
            // 
            resources.ApplyResources(this.chNumber, "chNumber");
            // 
            // chDate
            // 
            resources.ApplyResources(this.chDate, "chDate");
            // 
            // chFrom
            // 
            resources.ApplyResources(this.chFrom, "chFrom");
            // 
            // chTo
            // 
            resources.ApplyResources(this.chTo, "chTo");
            // 
            // chOrdered
            // 
            resources.ApplyResources(this.chOrdered, "chOrdered");
            // 
            // chUnit
            // 
            resources.ApplyResources(this.chUnit, "chUnit");
            // 
            // chUnitPrice
            // 
            resources.ApplyResources(this.chUnitPrice, "chUnitPrice");
            // 
            // chAmmount
            // 
            resources.ApplyResources(this.chAmmount, "chAmmount");
            // 
            // chTotal
            // 
            resources.ApplyResources(this.chTotal, "chTotal");
            // 
            // POTrackerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listPurchaseData);
            this.Controls.Add(this.btnEmptyFile);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDisplayOrders);
            this.Controls.Add(this.txtFilenameAndPath);
            this.Controls.Add(this.lblFilenameAndPath);
            this.Controls.Add(this.gBoxOpenFile);
            this.Controls.Add(this.gBoxInsert);
            this.Controls.Add(this.gBoxDelete);
            this.Controls.Add(this.rtextErrors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "POTrackerForm";
            this.Load += new System.EventHandler(this.POTrackerForm_Load);
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
        private System.Windows.Forms.DateTimePicker datePickerPurchase;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtOrdered;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtIdNumber;
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
        private System.Windows.Forms.ComboBox comboUnit;
        private System.Windows.Forms.RadioButton radioOpenExisting;
        private System.Windows.Forms.RadioButton radioCreateNew;
        private System.Windows.Forms.TextBox txtFilenameAndPath;
        private System.Windows.Forms.Button btnDeletePO;
        private System.Windows.Forms.TextBox txtDeleteNumber;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnCreateOpen;
        private System.Windows.Forms.Button btnDisplayOrders;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEmptyFile;
        private System.Windows.Forms.ListView listPurchaseData;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chFrom;
        private System.Windows.Forms.ColumnHeader chTo;
        private System.Windows.Forms.ColumnHeader chOrdered;
        private System.Windows.Forms.ColumnHeader chUnit;
        private System.Windows.Forms.ColumnHeader chUnitPrice;
        private System.Windows.Forms.ColumnHeader chAmmount;
        private System.Windows.Forms.ColumnHeader chTotal;
    }
}

