using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpManager
{
    //Структура содержит данные по пути бэкап папки с версией, имени для списка и даты
    [Serializable]
    public struct BackUpData
    {
        public string Date { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }

        public BackUpData(string path)
        {
            this.Date = DateTime.Now.ToString();
            this.Name = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.Path = $"{path}\\{Name}.zip";
        }
        
        public BackUpData(string date, string name, string path)
        {
            this.Date = date;
            this.Name = name;
            this.Path = path;
        }
    }

}
