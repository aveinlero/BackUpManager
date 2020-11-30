using System;
using System.Collections.Generic;
using System.IO;
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
        public List<BackUpData> ListOfVersion { get; private set; }     //Список последних версий

        //Следующие два свойства определяют автоматизацию создания бэкапов
        public bool CopyOnStartupStatus { get; set; }
        public CopyByPeriod CopyByPeriod { get; set; }

        public BackUpObject(string name, string pathOfSource, string pathOfBackUp, bool copyOnStartup, CopyByPeriod copyByPeriod)
        {
            this.Name = name;
            this.PathOfSource = pathOfSource;
            this.PathOfBackUp = pathOfBackUp;
            ListOfVersion = new List<BackUpData>();

            this.CopyOnStartupStatus = copyOnStartup;
            this.CopyByPeriod = copyByPeriod;

            AddVersion();
        }

        public void AddVersion()
        {
            //Этот метод предполагает копирование всех папок и файлов из папки источника в новую папку с именем-датой,
            //а также удаление неактуальных версий с жесткого диска

            BackUpData data = new BackUpData(PathOfBackUp);

            //Копирование файлов и папок в новую бэкап директорию и удаление старых директорий
            try
            {

                ListOfVersion.Add(data);
                //TODO Вернуть по готовности CopyDir(pathOfSource, folderPath);

                //TODO Здесь указан размер очереди для бэкапов, можно добавить регулируемый счетчик
                if (ListOfVersion.Count > 5)
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
            //Метод удаляет выбранную версию из списка версий и все соответсвующие ей папки
            string pathOfDelete = ListOfVersion[index].Path;
            ListOfVersion.RemoveAt(index);
            if (Directory.Exists(pathOfDelete))
            {
                //TODO Вернуть по готовности Directory.Delete(pathOfDelete, true);
            }
        }

        void CopyDir(string FromDir, string ToDir)
        {
            //Код нагло стырен из интернета https://ru.stackoverflow.com/questions/654232/Как-скопировать-папку-целиком-и-все-файлы-и-папки-в-ней
            Directory.CreateDirectory(ToDir);
            foreach (string s1 in Directory.GetFiles(FromDir))
            {
                string s2 = ToDir + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(FromDir))
            {
                CopyDir(s, ToDir + "\\" + Path.GetFileName(s));
            }

        }

        void Compress()
        {

        }

        void Decompress()
        {

        }
    }
}
