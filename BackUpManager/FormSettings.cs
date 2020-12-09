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
        public int VersionCounter { get; private set; }
        private MainForm mainForm;
        private bool reEdit = false;
        private BackUpObject currentObj;
        
        public FormSettings()
        {
            InitializeComponent();
        }

        public FormSettings(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        public FormSettings(MainForm mainForm, BackUpObject obj)
        {
            this.mainForm = mainForm;
            InitializeComponent();

            currentObj = obj;
            textBoxName.Text = obj.Name;
            textBoxSource.Text = obj.PathOfSource;
            textBoxBackUp.Text = obj.PathOfBackUp;
            checkBoxTaskPlan.Checked = (obj.CopyOnStartupStatus || obj.CopyByPeriod.Status);
            checkBoxPeriod.Checked = obj.CopyByPeriod.Status;
            checkBoxStartProgram.Checked = obj.CopyOnStartupStatus;
            textBoxSetTime.Text = obj.CopyByPeriod.Period.ToString();
            dateTimePickerSetTime.Value = obj.CopyByPeriod.DateNextUpdate;
            textBoxVersionCounter.Text = obj.VersionCounter.ToString();

            reEdit = true;
        }

        private void buttonSetPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            textBoxSource.Text = folderBrowserDialog.SelectedPath;
            folderSource = folderBrowserDialog.SelectedPath;

            // Проверка на совпадение путей источников
            if (mainForm.backUpObjects.Count > 0)
            {
                foreach (BackUpObject obj in mainForm.backUpObjects)
                {
                    if (obj.PathOfSource == folderSource)
                    {
                        MessageBox.Show($"The coincidence of the source with the object {obj.Name}", "Warning!");
                        return;
                    }
                }
            }
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
                    if (reEdit) { SaveSettings(currentObj); }
                    else { AddBackUpObject(); }
                    reEdit = false;
                    this.Close();
                    mainForm.Show();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message, "Error");
                    textBoxSetTime.Text = "1";
                }
                mainForm.UpdateBackUpList();
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
                return;
            }
            if (checkBoxTaskPlan.Checked == false)
            {
                checkBoxStartProgram.Enabled = false;
                checkBoxPeriod.Enabled = false;
                dateTimePickerSetTime.Enabled = false;
                labelSetTime.Enabled = false;
                textBoxSetTime.Enabled = false;
                checkBoxPeriod.Checked = false;
                checkBoxStartProgram.Checked = false;
                return;
            }
        }

        void AddBackUpObject()
        {
            bool copyOnStartupStatus = checkBoxStartProgram.Checked;
            VersionCounter = Int32.Parse(textBoxVersionCounter.Text);
            CopyByPeriod copyByPeriod = new CopyByPeriod();

            if (checkBoxPeriod.Checked == true)
            {
                #region Initialize_copyByPeriod_values
                copyByPeriod.Period = Int32.Parse(textBoxSetTime.Text);
                if (copyByPeriod.Period < 1) { MessageBox.Show("Incorrect period value. Set to 1.", "Error"); copyByPeriod.Period = 1; }
                copyByPeriod.Status = checkBoxPeriod.Checked;
                
                DateTime time = dateTimePickerSetTime.Value;
                int hours = time.Hour;
                int minutes = time.Minute;
                int seconds = time.Second;
                copyByPeriod.Time = DateTime.Now.Date.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
                copyByPeriod.SetDateNextUpdate();
                #endregion

                BackUpObject obj = new BackUpObject(name, folderSource, folderBackUp, VersionCounter,copyOnStartupStatus, copyByPeriod);
                mainForm.backUpObjects.Add(obj);
                return;
            }
            if (checkBoxPeriod.Checked == false)
            {
                copyByPeriod.Period = 0;
                copyByPeriod.Status = checkBoxPeriod.Checked;
                copyByPeriod.Time = DateTime.Now.Date;
                copyByPeriod.SetDateNextUpdate();

                BackUpObject obj = new BackUpObject(name, folderSource, folderBackUp, VersionCounter, copyOnStartupStatus, copyByPeriod);
                mainForm.backUpObjects.Add(obj);
                return;
            }

        }

        private void textBoxSource_TextChanged(object sender, EventArgs e)
        {

        }

        void SaveSettings(BackUpObject obj)
        {
            obj.Name = textBoxName.Text;
            obj.PathOfSource = textBoxSource.Text;
            obj.PathOfBackUp = textBoxBackUp.Text;
            obj.CopyOnStartupStatus = checkBoxStartProgram.Checked;
            obj.CopyOnStartupStatus = checkBoxStartProgram.Checked;
            obj.Name = textBoxName.Text;
            obj.PathOfSource = textBoxSource.Text;
            obj.PathOfBackUp = textBoxBackUp.Text;
            obj.VersionCounter = Int32.Parse(textBoxVersionCounter.Text);
            obj.BackupFolder = obj.SetBackupFolder();

            CopyByPeriod copyByPeriod = new CopyByPeriod();
            
            copyByPeriod.Status = checkBoxPeriod.Checked;
            copyByPeriod.Period = Int32.Parse(textBoxSetTime.Text);

            DateTime time = dateTimePickerSetTime.Value;
            int hours = time.Hour;
            int minutes = time.Minute;
            int seconds = time.Second;
            copyByPeriod.Time = DateTime.Now.Date.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);
            copyByPeriod.SetDateNextUpdate();

            obj.CopyByPeriod = copyByPeriod;
        }
    }
}
