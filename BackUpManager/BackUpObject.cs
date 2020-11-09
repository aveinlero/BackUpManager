using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpManager
{
    class BackUpObject
    {
        public string name { get; private set; }
        public string pathOfSource { get; private set; }
        public string pathOfBackUp { get; private set; }
        private Queue<string> queueOfVersion; //список последних версий
        //TODO Возможно стоит добавить поле очереди дат версий для представления в списке версий

        public BackUpObject(string name, string pathOfSource, string pathOfBackUp )
        {
            this.name = name;
            this.pathOfSource = pathOfSource;
            this.pathOfBackUp = pathOfBackUp;
            queueOfVersion = new Queue<string>();
            AddVersion();
        }

        void AddVersion()
        {
            //Этот метод предполагает копирование всех папок и файлов из папки источника в новую папку с именем-датой,
            //а также удаление неактуальных версий с жесткого диска
            
            //Создание директории для копирования, имя - текущий момент
            DateTime date = DateTime.Now;
            string strDate = date.ToString("yyyyMMddHHmmss");
            string folderPath = $"{pathOfBackUp}\\{strDate}";

            //Копирование файлов и папок в новую бэкап директорию и удаление старых директорий
            try
            {
                //TODO Ниже закомментирован процесс копирования файлов, убрать комментарии по готовности программы
                //CopyDir(pathOfSource, folderPath);
                
                //TODO Здесь указан размер очереди для бэкапов, можно добавить регулируемый счетчик
                if (queueOfVersion.Count < 5)
                {
                    queueOfVersion.Enqueue(folderPath);
                }
                else
                {
                    string queueElement = queueOfVersion.Dequeue();
                    Directory.Delete(queueElement, true);
                }
            }
            catch
            {
                Directory.Delete(folderPath, true);
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
    }
}
