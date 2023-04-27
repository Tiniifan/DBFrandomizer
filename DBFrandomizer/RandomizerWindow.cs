using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFrandomizer.Formats;
using DBFrandomizer.Tool;
using DBFrandomizer.Logic;
using DBFrandomizer.Common;
using DBFrandomizer.Randomizer;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace DBFrandomizer
{
    public partial class RandomizerWindow : Form
    {
        private Randomizer.Randomizer Randomizer;

        public RandomizerWindow()
        {
            InitializeComponent();
        }

        public Dictionary<string, bool> GetRandomierSetting(Control parentControl)
        {
            Dictionary<string, bool> checkedCheckBoxes = new Dictionary<string, bool>();

            // Loops through all the child controls.
            foreach (Control childControl in parentControl.Controls)
            {
                // Checks if the child control is a CheckBox.
                if (childControl is CheckBox checkBox)
                {
                    // Adds the name and Checked status of the CheckBox to the dictionary.
                    checkedCheckBoxes.Add(checkBox.Name, checkBox.Checked);
                }
                else if (childControl.HasChildren)
                {
                    // If the child control has child controls, recursively call this function.
                    checkedCheckBoxes = checkedCheckBoxes.Concat(GetRandomierSetting(childControl)).ToDictionary(x => x.Key, x => x.Value);
                }
            }

            return checkedCheckBoxes;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Randomizer = new Randomizer.Randomizer(dialog.FileName);
                Randomizer.Open();
                tabControl1.Enabled = true;
                randomizeToolStripMenuItem.Enabled = true;
            }
        }

        private void RandomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create save folder
            string saveFolder = Path.GetDirectoryName(Randomizer.DirectoryPath) + "/root_randomized_jarc";
            Randomizer.OutputPath = saveFolder;

            if (!Directory.Exists(saveFolder))
            {
                Directory.CreateDirectory(saveFolder);
            }

            Randomizer.RandomizeConfigureJarc(GetRandomierSetting(tabPage1));
            Randomizer.RandomizeBaseParamBin(GetRandomierSetting(tabPage2));
            Randomizer.RandomizeSkillLearnParamBin(GetRandomierSetting(tabPage3));

            MessageBox.Show("Randomized sucessfull! Check root_randomized_jarc folder");
        }

        private void SwapCharacterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (swapCharacterCheckBox.Checked)
            {
                styleCheckBox.Enabled = false;
                styleCheckBox.Checked = false;
                modelCheckBox.Enabled = false;
                modelCheckBox.Checked = false;
                nameCheckBox.Enabled = false;
                nameCheckBox.Checked = false;
                descriptionCheckBox.Enabled = false;
                descriptionCheckBox.Checked = false;
                voiceCheckBox.Enabled = false;
                voiceCheckBox.Checked = false;
                transformationCheckBox.Enabled = false;
                transformationCheckBox.Checked = false;
            } else
            {
                styleCheckBox.Enabled = true;
                modelCheckBox.Enabled = true;
                nameCheckBox.Enabled = true;
                descriptionCheckBox.Enabled = true;
                voiceCheckBox.Enabled = true;
                transformationCheckBox.Enabled = true;
            }
        }

        private void RestrictSwap(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            swapCharacterCheckBox.Checked = false;
            swapCharacterCheckBox.Enabled = !checkBox.Checked;
        }
    }
}
