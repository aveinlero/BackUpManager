using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace BackUpManager
{
    public partial class MainForm : Form
    {
        internal List<BackUpObject> backUpObjects { get; set; }

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
            if (Directory.Exists(backUpObjects[index].PathOfBackUp))
            {
            //TODO Вернуть по готовности Directory.Delete(backUpObjects[index].pathOfBackUp, true);
            }
            backUpObjects.RemoveAt(index);
            UpdateBackUpList();
            listViewVersions.Clear();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateBackUpList();
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
            listViewBackUp.Clear();
            foreach (BackUpObject obj in backUpObjects)
            {
                listViewBackUp.Items.Add(obj.Name);
            }
        }
        //TODO Сделать кнопку Edit для изменения параметров копирования
        //TODO Сделать лист бэкапов с описаниями параметров копирования
        //TODO Сделать копирование при запуске программы, для этого проверить десерилизованный список по статусам и запустить копирование для каждого
        //TODO Сделать копирование по периоду в соответствии с указанным временем, здесь понадобится подписаться на событие и сделать таймеры для каждого объекта

    }
}
