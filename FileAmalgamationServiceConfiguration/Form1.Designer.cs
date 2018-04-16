namespace FileAmalgamationServiceConfiguration
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
            this.components = new System.ComponentModel.Container();
            this.tableProfiles = new System.Windows.Forms.TableLayoutPanel();
            this.addProfile = new System.Windows.Forms.Button();
            this.menuRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableProfiles
            // 
            this.tableProfiles.AutoSize = true;
            this.tableProfiles.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableProfiles.ColumnCount = 1;
            this.tableProfiles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableProfiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableProfiles.Location = new System.Drawing.Point(0, 23);
            this.tableProfiles.Name = "tableProfiles";
            this.tableProfiles.RowCount = 1;
            this.tableProfiles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableProfiles.Size = new System.Drawing.Size(497, 4);
            this.tableProfiles.TabIndex = 1;
            // 
            // addProfile
            // 
            this.addProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.addProfile.Location = new System.Drawing.Point(0, 0);
            this.addProfile.Name = "addProfile";
            this.addProfile.Size = new System.Drawing.Size(497, 23);
            this.addProfile.TabIndex = 0;
            this.addProfile.Text = "Add Profile...";
            this.addProfile.UseVisualStyleBackColor = true;
            this.addProfile.Click += new System.EventHandler(this.addProfile_Click);
            // 
            // menuRow
            // 
            this.menuRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteProfileToolStripMenuItem});
            this.menuRow.Name = "menuRow";
            this.menuRow.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteProfileToolStripMenuItem
            // 
            this.deleteProfileToolStripMenuItem.Name = "deleteProfileToolStripMenuItem";
            this.deleteProfileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteProfileToolStripMenuItem.Text = "Delete Profile";
            this.deleteProfileToolStripMenuItem.Click += new System.EventHandler(this.deleteProfileToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(497, 461);
            this.Controls.Add(this.tableProfiles);
            this.Controls.Add(this.addProfile);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuRow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableProfiles;
        private System.Windows.Forms.Button addProfile;
        private System.Windows.Forms.ContextMenuStrip menuRow;
        private System.Windows.Forms.ToolStripMenuItem deleteProfileToolStripMenuItem;
    }
}

