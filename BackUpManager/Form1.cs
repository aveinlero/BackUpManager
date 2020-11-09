using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void RefreshBackUpList()
        {
            //Обновление списка бэкапов, запускается при запуске программы и добавлении новых элементов
            listViewBackUp.Clear();
            foreach (BackUpObject obj in backUpObjects)
            {
                listViewBackUp.Items.Add(obj.name);
            }
        }

        private void buttonAddBackUpObj_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(this);
            formSettings.Show();
        }

        private void buttonDeleteBackUpObj_Click(object sender, EventArgs e)
        {
            //TODO Удаление бэкапа из списка и удаление папок-бэкапов с диска
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            RefreshBackUpList();
        }

        private void listViewBackUp_ItemActivate(object sender, EventArgs e)
        {
            int index = listViewBackUp.SelectedIndices[0];
            textBoxSource.Text = backUpObjects[index].pathOfSource;
            textBoxBackUp.Text = backUpObjects[index].pathOfBackUp;
        }
    }
}
