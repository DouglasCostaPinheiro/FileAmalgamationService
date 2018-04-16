using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileAmalgamationServiceConfiguration
{
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
        }

        private void InputControl_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((this.Parent.Parent as ProfileControl).profileRootText.Text))
                subFolderDialog.SelectedPath = (this.Parent as ProfileControl).profileRootText.Text;
        }

        private void browseSubFolder_Click(object sender, EventArgs e)
        {

        }
    }
}
