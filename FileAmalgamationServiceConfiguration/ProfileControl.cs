using FileAmalgamationServiceConfiguration.FormUtils;
using System;
using System.Windows.Forms;

namespace FileAmalgamationServiceConfiguration
{
    public partial class ProfileControl : UserControl
    {
        public ProfileControl()
        {
            InitializeComponent();
        }

        private void browseProfileRoot_Click(object sender, EventArgs e)
        {
            profileRootDialog.ShowDialog();

            profileRootText.Text = profileRootDialog.SelectedPath;
        }

        private void ProfileControl_Load(object sender, EventArgs e)
        {
            profileRootText.TextChanged += (tSender, tE) =>
            {
                foreach (var item in tableInputs.Controls)
                {
                    if (item is InputControl)
                    {
                        (item as InputControl).subFolderDialog.SelectedPath = profileRootText.Text;
                    }
                }
            };

            for (int i = 0; i < 3; i++)
            {
                tableInputs.AddRow(null, new InputControl());
            }
        }
    }
}
