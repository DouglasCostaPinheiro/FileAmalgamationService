using FileAmalgamationServiceConfiguration.FormUtils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileAmalgamationServiceConfiguration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, (int)(Screen.PrimaryScreen.Bounds.Height * 0.8));

            tableProfiles.Controls.Clear();
            tableProfiles.RowStyles.Clear();
            tableProfiles.RowCount = 0;

        }

        #region Events

        private void addProfile_Click(object sender, EventArgs e)
        {
            tableProfiles.AddRow(menuRow, new ProfileControl());
        }

        private void deleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var profileControl = ((System.Windows.Forms.ContextMenuStrip)((ToolStripMenuItem)sender).GetCurrentParent()).SourceControl;

            tableProfiles.RemoveRow(tableProfiles.GetRow(profileControl));
            // RemoveRowFromPanel(tableProfiles, tableProfiles.GetRow(profileControl));
        } 

        #endregion
    }

    
}
