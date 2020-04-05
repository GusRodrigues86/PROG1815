namespace IOTestinClass
{
    partial class IOinClass
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtDirectoryInput = new System.Windows.Forms.TextBox();
            this.lblErrors = new System.Windows.Forms.Label();
            this.checkDelete = new System.Windows.Forms.CheckBox();
            this.checkCreateFile = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(268, 12);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "CREATE";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtDirectoryInput
            // 
            this.txtDirectoryInput.Location = new System.Drawing.Point(12, 12);
            this.txtDirectoryInput.Name = "txtDirectoryInput";
            this.txtDirectoryInput.Size = new System.Drawing.Size(250, 20);
            this.txtDirectoryInput.TabIndex = 1;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.ForeColor = System.Drawing.Color.Red;
            this.lblErrors.Location = new System.Drawing.Point(12, 58);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(16, 13);
            this.lblErrors.TabIndex = 2;
            this.lblErrors.Text = "...";
            // 
            // checkDelete
            // 
            this.checkDelete.AutoSize = true;
            this.checkDelete.Location = new System.Drawing.Point(12, 38);
            this.checkDelete.Name = "checkDelete";
            this.checkDelete.Size = new System.Drawing.Size(76, 17);
            this.checkDelete.TabIndex = 3;
            this.checkDelete.Text = "Delete File";
            this.checkDelete.UseVisualStyleBackColor = true;
            // 
            // checkCreateFile
            // 
            this.checkCreateFile.AutoSize = true;
            this.checkCreateFile.Checked = true;
            this.checkCreateFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCreateFile.Location = new System.Drawing.Point(98, 38);
            this.checkCreateFile.Name = "checkCreateFile";
            this.checkCreateFile.Size = new System.Drawing.Size(76, 17);
            this.checkCreateFile.TabIndex = 4;
            this.checkCreateFile.Text = "Create File";
            this.checkCreateFile.UseVisualStyleBackColor = true;
            // 
            // IOinClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 129);
            this.Controls.Add(this.checkCreateFile);
            this.Controls.Add(this.checkDelete);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.txtDirectoryInput);
            this.Controls.Add(this.btnCreate);
            this.Name = "IOinClass";
            this.Text = "IO Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtDirectoryInput;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.CheckBox checkDelete;
        private System.Windows.Forms.CheckBox checkCreateFile;
    }
}

