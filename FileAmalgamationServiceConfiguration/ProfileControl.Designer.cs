namespace FileAmalgamationServiceConfiguration
{
    partial class ProfileControl
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
            System.Windows.Forms.Label label2;
            this.profileRootDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.profileRootText = new System.Windows.Forms.TextBox();
            this.browseProfileRoot = new System.Windows.Forms.Button();
            this.tableInputs = new System.Windows.Forms.TableLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 31);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 13);
            label1.TabIndex = 0;
            label1.Text = "Profile Root";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 74);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(36, 13);
            label2.TabIndex = 4;
            label2.Text = "Inputs";
            // 
            // profileRootDialog
            // 
            this.profileRootDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // profileRootText
            // 
            this.profileRootText.Location = new System.Drawing.Point(71, 28);
            this.profileRootText.Name = "profileRootText";
            this.profileRootText.ReadOnly = true;
            this.profileRootText.Size = new System.Drawing.Size(287, 20);
            this.profileRootText.TabIndex = 1;
            // 
            // browseProfileRoot
            // 
            this.browseProfileRoot.Location = new System.Drawing.Point(364, 26);
            this.browseProfileRoot.Name = "browseProfileRoot";
            this.browseProfileRoot.Size = new System.Drawing.Size(75, 23);
            this.browseProfileRoot.TabIndex = 2;
            this.browseProfileRoot.Text = "Browse...";
            this.browseProfileRoot.UseVisualStyleBackColor = true;
            this.browseProfileRoot.Click += new System.EventHandler(this.browseProfileRoot_Click);
            // 
            // tableInputs
            // 
            this.tableInputs.AutoSize = true;
            this.tableInputs.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableInputs.ColumnCount = 1;
            this.tableInputs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInputs.Location = new System.Drawing.Point(6, 90);
            this.tableInputs.Name = "tableInputs";
            this.tableInputs.RowCount = 1;
            this.tableInputs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableInputs.Size = new System.Drawing.Size(466, 10);
            this.tableInputs.TabIndex = 3;
            // 
            // ProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(label2);
            this.Controls.Add(this.tableInputs);
            this.Controls.Add(this.browseProfileRoot);
            this.Controls.Add(this.profileRootText);
            this.Controls.Add(label1);
            this.Name = "ProfileControl";
            this.Size = new System.Drawing.Size(475, 261);
            this.Load += new System.EventHandler(this.ProfileControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog profileRootDialog;
        private System.Windows.Forms.Button browseProfileRoot;
        private System.Windows.Forms.TableLayoutPanel tableInputs;
        internal System.Windows.Forms.TextBox profileRootText;
    }
}
