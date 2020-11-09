using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackUpManager
{
    class BackUpObject
    {
        private string name;
        private string pathOfSource;
        private string pathOfBackUp;
        private Queue<string> queueOfVersion;

        public BackUpObject(string name, string pathOfSource, string pathOfBackUp )
        {
            this.name = name;
            this.pathOfSource = pathOfSource;
            this.pathOfBackUp = pathOfBackUp;
            AddVersion();
        }

        void AddObject()
        {

        }
        
        void SaveObject()
        {

        }

        void SaveName()
        {

        }

        void AddVersion()
        {
            
        }
    }
}
