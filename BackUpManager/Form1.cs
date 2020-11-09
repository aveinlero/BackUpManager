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
    public partial class MainForm : Form
    {
        internal List<BackUpObject> backUpObjects { get; set; }

        public MainForm()
        {
            InitializeComponent();

            LoadList();

        }

        void LoadList()
        {
            //TODO загрузить список бэк апов, которые нужно получить десериализацией
        }

        private void buttonSavePath_Click(object sender, EventArgs e)
        {
            //string filename = saveFileDialog.FileName;
            
        }

        private void buttonAddBackUpObj_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings(this);
            formSettings.Show();
        }
    }
}
