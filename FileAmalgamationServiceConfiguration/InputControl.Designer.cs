namespace FileAmalgamationServiceConfiguration
{
    partial class InputControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label lblValue;
            System.Windows.Forms.Label label2;
            this.inputType = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.subFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.subFolderText = new System.Windows.Forms.TextBox();
            this.browseSubFolder = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            lblValue = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 13);
            label1.TabIndex = 0;
            label1.Text = "Type";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new System.Drawing.Point(205, 17);
            lblValue.Name = "lblValue";
            lblValue.Size = new System.Drawing.Size(34, 13);
            lblValue.TabIndex = 2;
            lblValue.Text = "Value";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 56);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 13);
            label2.TabIndex = 4;
            label2.Text = "Subfolder";
            // 
            // inputType
            // 
            this.inputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputType.FormattingEnabled = true;
            this.inputType.Items.AddRange(new object[] {
            "Text",
            "FileSearchExpressionFilter",
            "FileSearchExpressionRegex"});
            this.inputType.Location = new System.Drawing.Point(61, 13);
            this.inputType.Name = "inputType";
            this.inputType.Size = new System.Drawing.Size(138, 21);
            this.inputType.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(242, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(187, 20);
            this.textBox1.TabIndex = 3;
            // 
            // subFolderDialog
            // 
            this.subFolderDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // subFolderText
            // 
            this.subFolderText.Location = new System.Drawing.Point(61, 53);
            this.subFolderText.Name = "subFolderText";
            this.subFolderText.ReadOnly = true;
            this.subFolderText.Size = new System.Drawing.Size(138, 20);
            this.subFolderText.TabIndex = 5;
            // 
            // browseSubFolder
            // 
            this.browseSubFolder.Location = new System.Drawing.Point(208, 51);
            this.browseSubFolder.Name = "browseSubFolder";
            this.browseSubFolder.Size = new System.Drawing.Size(75, 23);
            this.browseSubFolder.TabIndex = 6;
            this.browseSubFolder.Text = "Browse...";
            this.browseSubFolder.UseVisualStyleBackColor = true;
            this.browseSubFolder.Click += new System.EventHandler(this.browseSubFolder_Click);
            // 
            // InputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.browseSubFolder);
            this.Controls.Add(this.subFolderText);
            this.Controls.Add(label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(lblValue);
            this.Controls.Add(this.inputType);
            this.Controls.Add(label1);
            this.Name = "InputControl";
            this.Size = new System.Drawing.Size(441, 106);
            this.Load += new System.EventHandler(this.InputControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox inputType;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox subFolderText;
        internal System.Windows.Forms.FolderBrowserDialog subFolderDialog;
        private System.Windows.Forms.Button browseSubFolder;
    }
}
