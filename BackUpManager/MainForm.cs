using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Windows.Forms.ListView;

namespace BackUpManager
{
    public partial class MainForm : Form
    {
        internal List<BackUpObject> backUpObjects { get; set; }
        private bool isCopyFinished = true;
        private bool firstRun = true;
        Queue<BackUpObject> updateList;

        public MainForm()
        {
            InitializeComponent();
            backUpObjects = new List<BackUpObject>();
        }


        private void buttonAddBackUpObj_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(this);
            formSettings.Show();
        }

        private void buttonDeleteBackUpObj_Click(object sender, EventArgs e)
        {
            //Удаление бэкапа из списка и удаление папок-бэкапов с диска
            int index = listViewBackUp.SelectedIndices[0];
            if (Directory.Exists(backUpObjects[index].BackupFolder))
            {
                Directory.Delete(backUpObjects[index].BackupFolder, true);
            }
            backUpObjects.RemoveAt(index);
            UpdateBackUpList();
            listViewVersions.Clear();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {

        }

        private void listViewBackUp_ItemActivate(object sender, EventArgs e)
        {
            int index = listViewBackUp.SelectedIndices[0];
            textBoxSource.Text = backUpObjects[index].PathOfSource;
            textBoxBackUp.Text = backUpObjects[index].PathOfBackUp;
            UpdateVersionList(backUpObjects[index]);
        }

        private void buttonAddVersion_Click(object sender, EventArgs e)
        {
            try
            {
                int index = listViewBackUp.SelectedIndices[0];
                backUpObjects[index].AddVersion();
                UpdateVersionList(backUpObjects[index]);
            }
            catch
            {
                MessageBox.Show("Invalid backup object", "Error");
            }
        }

        private void buttonDeleteVersion_Click(object sender, EventArgs e)
        {
            //Удаление выбранных версий в пределах одного бэкап объекта
            int indexBackUp = listViewBackUp.SelectedIndices[0];
            SelectedIndexCollection indexesVersion = listViewVersions.SelectedIndices;
            for (int index = indexesVersion.Count-1; index>=0; index--)
            {
                backUpObjects[indexBackUp].DeleteVersion(indexesVersion[index]);
            }
            UpdateVersionList(backUpObjects[indexBackUp]);
        }

        private void UpdateVersionList(BackUpObject obj)
        {
            listViewVersions.Clear();
            foreach (BackUpData version in obj.ListOfVersion)
            {
                listViewVersions.Items.Add(version.Date);
            }
        }
        
        public void UpdateBackUpList()
        {
            //Обновление списка бэкапов, запускается при запуске программы и добавлении/удалении элементов
            listViewBackUp.Items.Clear();
            foreach (BackUpObject obj in backUpObjects)
            {
                ListViewItem item = new ListViewItem();
                item.Text = obj.Name;
                item.SubItems.Add(obj.VersionCounter.ToString());
                item.SubItems.Add(obj.CopyOnStartupStatus.ToString());
                item.SubItems.Add(obj.CopyByPeriod.Status.ToString());
                if (obj.CopyByPeriod.Status) 
                { 
                    item.SubItems.Add(obj.CopyByPeriod.Period.ToString());
                    item.SubItems.Add(obj.CopyByPeriod.DateNextUpdate.TimeOfDay.ToString());
                }
                else 
                { 
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                }
                listViewBackUp.Items.Add(item);
            }
            listViewVersions.Clear();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Здесь происходит десериализация и запуск таймера (каждую минуту) на проверку списка бэкапов. Подходящие добавляются в очередь и копируются.

            //Десериализации при загрузки формы
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("backupobjects.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                List<BackUpObject> backUpObjects = (List<BackUpObject>)formatter.Deserialize(fs);
                this.backUpObjects = backUpObjects;
                }
            }
            
            //Создание таймера и метод для проверки и добавления новых версий
            object forTimer = new object();
            const int oneMinute = 60 * 1000;
            System.Threading.TimerCallback timerCallback = new System.Threading.TimerCallback(UpdateVersionsAsync);
            System.Threading.Timer timer = new System.Threading.Timer(timerCallback, null, 0, oneMinute);

            UpdateBackUpList();
        }

        //Проверка списка по датам, созданиe новых версий
        async void UpdateVersionsAsync(object forTimer)
        {
            if (firstRun)
            {
                if (isCopyFinished)
                {
                    firstRun = false;
                    isCopyFinished = false;
                    updateList = new Queue<BackUpObject>();

                    foreach (BackUpObject obj in backUpObjects)
                    {
                        if (obj.CopyOnStartupStatus)
                        {
                            updateList.Enqueue(obj);
                        }
                    }

                    await Task.Run(() => AddNewVersions(updateList));
                }
                return;
            }
            if (isCopyFinished)
            {
                isCopyFinished = false;
                Queue<BackUpObject> updateList = new Queue<BackUpObject>();

                foreach (BackUpObject obj in backUpObjects)
                {
                    if (obj.CopyByPeriod.DateNextUpdate < DateTime.Now && obj.CopyByPeriod.Status)
                    {
                        updateList.Enqueue(obj);
                    }
                }

                await Task.Run(()=>AddNewVersions(updateList));
            }
        }

        //Запуск копирования по созданной очереди(из асинхронного метода UpdateVersionsAsync)
        void AddNewVersions(Queue<BackUpObject> updateList)
        {
            string failedList = "Copy failed:";
            
            foreach (BackUpObject obj in updateList)
            {
                try
                {
                    CopyByPeriod copyByPeriod = new CopyByPeriod(obj.CopyByPeriod);
                    obj.AddVersion();
                    copyByPeriod.SetDateNextUpdate();
                    obj.CopyByPeriod = copyByPeriod;
                }
                catch
                {
                    failedList += $"\n {obj.Name}";
                }
            }
            if (failedList != "Copy failed:") { MessageBox.Show(failedList); }
            updateList.Clear();
            isCopyFinished = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Сериализация при закрытии приложения
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("backupobjects.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, backUpObjects);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listViewBackUp.SelectedItems.Count !=0)
            {
                int index = listViewBackUp.SelectedIndices[0];
                BackUpObject obj = backUpObjects[index];
                FormSettings formSettings = new FormSettings(this, obj);
                formSettings.Show();
            }
            else { MessageBox.Show("Select the backup object", "Warning"); }
        }

        private void buttonRecovery_Click(object sender, EventArgs e)
        {
            try
            {
                int indexOfBackup = listViewBackUp.SelectedIndices[0];
                int indexOfVersion = listViewVersions.SelectedIndices[0];

                BackUpObject obj = backUpObjects[indexOfBackup];
                obj.Decompress(indexOfVersion);
                MessageBox.Show("Recovery is complete", "Recovery");
            }
            catch
            {
                MessageBox.Show("Recovery is not possible", "Error");
            }
        }

        void VersionClear()
        {
            if (listViewBackUp.SelectedItems.Count == 0) { listViewVersions.Clear(); }
        }

        private void listViewBackUp_MouseUp(object sender, MouseEventArgs e)
        {
            VersionClear();
        }
    }
}
