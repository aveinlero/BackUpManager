using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackUpManager
{
    public partial class FormSettings : Form
    {
        public string name { get; private set; }
        public string folderSource { get; private set; }
        public string folderBackUp { get; private set; }
        private MainForm mainForm;
        
        public FormSettings()
        {
            InitializeComponent();
        }

        public FormSettings(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void buttonSetPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            textBoxSource.Text = folderBrowserDialog.SelectedPath;
            folderSource = folderBrowserDialog.SelectedPath;
        }

        private void buttonSetBackUpFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            textBoxBackUp.Text = folderBrowserDialog.SelectedPath;
            folderBackUp = folderBrowserDialog.SelectedPath;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            //TODO Сделать проверку на корректное имя
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {      
            if ( textBoxName.Text == "" || textBoxSource.Text == "" || textBoxBackUp.Text == "" )
            {
                MessageBox.Show("Incorrect input");
            }
            else
            {
                mainForm.backUpObjects.Add(new BackUpObject(name, folderSource, folderBackUp));
                this.Close();
            }   
        }
    }
}
