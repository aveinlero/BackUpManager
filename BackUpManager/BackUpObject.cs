using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpManager
{
    [Serializable]
    public class BackUpObject
    {
        public string Name { get; set; }
        public string PathOfSource { get; set; }
        public string PathOfBackUp { get; set; }
        public string BackupFolder { get; set; }
        public List<BackUpData> ListOfVersion { get; private set; }     //Список последних версий
        private int versionCounter;
        public int VersionCounter 
        { 
            get { return versionCounter; }
            set { if (value < 1) { versionCounter = 1; } else versionCounter = value; } 
        }

        //Следующие два свойства определяют автоматизацию создания бэкапов
        public bool CopyOnStartupStatus { get; set; }
        public CopyByPeriod CopyByPeriod { get; set; }

        public BackUpObject(string name, string pathOfSource, string pathOfBackUp, int versionCounter, bool copyOnStartup, CopyByPeriod copyByPeriod)
        {
            this.Name = name;
            this.PathOfSource = pathOfSource;
            this.PathOfBackUp = pathOfBackUp;
            this.BackupFolder = SetBackupFolder();
            this.ListOfVersion = new List<BackUpData>();
            this.versionCounter = versionCounter;

            this.CopyOnStartupStatus = copyOnStartup;
            this.CopyByPeriod = copyByPeriod;

            AddVersion();
        }

        public void AddVersion()
        {
            //Этот метод предполагает копирование всех папок и файлов из папки источника в новую папку с именем-датой,
            //а также удаление неактуальных версий с жесткого диска

            BackUpData data = new BackUpData(BackupFolder);
            if (BackupFolder == null) { BackupFolder = SetBackupFolder(); }
            //Копирование файлов и папок в новую бэкап директорию и удаление старых директорий
            try
            {

                ListOfVersion.Add(data);
                this.Compress(data);

                if (ListOfVersion.Count > versionCounter)
                {
                    DeleteVersion(0);
                }
            }
            catch
            {
                DeleteVersion(ListOfVersion.Count - 1);
            }

        }

        public void DeleteVersion(int index)
        {
            //Метод удаляет выбранную версию из списка версий
            string pathOfDelete = ListOfVersion[index].Path;
            ListOfVersion.RemoveAt(index);
            if (File.Exists(pathOfDelete)) { File.Delete(pathOfDelete); }

            if (ListOfVersion.Count > versionCounter) { DeleteVersion(0); }
        }

        void Compress(BackUpData data)
        {
            if (!Directory.Exists(BackupFolder)) { Directory.CreateDirectory(BackupFolder); }
            string zipFile = data.Path;
            ZipFile.CreateFromDirectory(PathOfSource, zipFile);
        }

        public void Decompress(int index)
        {
            if (Directory.Exists(PathOfSource)) { Directory.Delete(PathOfSource, true); }

            string zipFile = ListOfVersion[index].Path;
            ZipFile.ExtractToDirectory(zipFile, PathOfSource);
        }

        public string SetBackupFolder()
        {
            string folder = $"{PathOfBackUp}\\{Name}";
            return folder;
        }
    }
}
