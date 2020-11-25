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
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {      
            if ( textBoxName.Text == "" || textBoxSource.Text == "" || textBoxBackUp.Text == "" )
            {
                MessageBox.Show("Incorrect input", "Error");
            }
            else if (textBoxSource.Text == textBoxBackUp.Text)
            {
                MessageBox.Show("Incorrect Source or BackUp field", "Error");
            }
            else
            {
                //Добавление нового объекта в список бэкап объектов
                try
                {
                AddBackUpObject();
                this.Close();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message, "Error");
                    textBoxSetTime.Text = "1";
                }

            }
        }

        private void checkBoxTaskPlan_CheckedChanged(object sender, EventArgs e)
        {
            //При изменении включается и выключается доступность объектов для указания периодичности
            if (checkBoxTaskPlan.Checked == true)
            {
                checkBoxStartProgram.Enabled = true;
                checkBoxPeriod.Enabled = true;
                dateTimePickerSetTime.Enabled = true;
                labelSetTime.Enabled = true;
                textBoxSetTime.Enabled = true;
            }
            if (checkBoxTaskPlan.Checked == false)
            {
                checkBoxStartProgram.Enabled = false;
                checkBoxPeriod.Enabled = false;
                dateTimePickerSetTime.Enabled = false;
                labelSetTime.Enabled = false;
                textBoxSetTime.Enabled = false;
            }
        }

        void AddBackUpObject()
        {
            //TODO Сделать проверку на совпадение путей источников

            bool copyOnStartupStatus = checkBoxStartProgram.Checked;
            CopyByPeriod copyByPeriod = new CopyByPeriod();
            if (checkBoxTaskPlan.Checked == true)
            {
                copyByPeriod.Period = Int32.Parse(textBoxSetTime.Text);
                if (copyByPeriod.Period < 1) { MessageBox.Show("Incorrect period value. Set to 1.", "Error"); copyByPeriod.Period = 1; }
                copyByPeriod.Status = checkBoxPeriod.Checked;
                copyByPeriod.Time = dateTimePickerSetTime.Value;
                   
                BackUpObject obj = new BackUpObject(name, folderSource, folderBackUp, copyOnStartupStatus, copyByPeriod);
                mainForm.backUpObjects.Add(obj);
            }

        }
    }
}
