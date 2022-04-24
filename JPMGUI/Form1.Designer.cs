namespace JPMGUI
{
    partial class Form1
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
            this.SelectBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selectionBox = new System.Windows.Forms.ComboBox();
            this.setPathBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectBtn
            // 
            this.SelectBtn.Location = new System.Drawing.Point(12, 12);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(491, 36);
            this.SelectBtn.TabIndex = 0;
            this.SelectBtn.Text = "Select \'Java\' Folder";
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
            // 
            // selectionBox
            // 
            this.selectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionBox.FormattingEnabled = true;
            this.selectionBox.Location = new System.Drawing.Point(12, 54);
            this.selectionBox.Name = "selectionBox";
            this.selectionBox.Size = new System.Drawing.Size(491, 21);
            this.selectionBox.TabIndex = 1;
            this.selectionBox.SelectedIndexChanged += new System.EventHandler(this.selectionBox_SelectedIndexChanged);
            // 
            // setPathBtn
            // 
            this.setPathBtn.Location = new System.Drawing.Point(356, 101);
            this.setPathBtn.Name = "setPathBtn";
            this.setPathBtn.Size = new System.Drawing.Size(138, 37);
            this.setPathBtn.TabIndex = 2;
            this.setPathBtn.Text = "Set Path";
            this.setPathBtn.UseVisualStyleBackColor = true;
            this.setPathBtn.Click += new System.EventHandler(this.setPathBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(506, 150);
            this.Controls.Add(this.setPathBtn);
            this.Controls.Add(this.selectionBox);
            this.Controls.Add(this.SelectBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Java Path Manager GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox selectionBox;
        private System.Windows.Forms.Button setPathBtn;
    }
}

