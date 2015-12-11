using System;
using System .IO;
using System .Collections .Generic;
using System .Linq;
using System .Text;
using System.Windows.Forms;

namespace ExcelDataAccumulator {
    class FileStorageFactory {

        private List<FileStorage> fileList;
        public delegate void fileListChangeDelgate();
        public event fileListChangeDelgate fileListHasChange;

        public FileStorageFactory(ref List<FileStorage> fileList) 
        { 
            this.fileList = fileList;
        }

        public void addFiles(string[] files)
        {
            foreach (string file in files) 
            {
                FileStorage fStorage = new FileStorage(Path .GetFileName(file) , file);
                fileList .Add(fStorage);                
            }
            this .fileListHasChange();
        }

        public int moveUp(int index) 
        {
            if (index - 1 < 0)
            {
                return index;
            }
            FileStorage fs = fileList[index];
            fileList.Remove(fs);
            fileList.Insert(index - 1, fs);
            this.fileListHasChange();

            return fileList .IndexOf(fs);
        }

        public int moveDawn(int index) 
        {             
            if (index + 1 > this .fileList .Count - 1)
            {
                return index;
            }
            FileStorage fs = fileList[index];
            fileList.Remove(fs);
            fileList.Insert(index + 1, fs);
            this.fileListHasChange();

            return fileList .IndexOf(fs);
        }

        public void removeFile(int index) 
        {
            this .fileList .RemoveAt(index);
            this .fileListHasChange();
        }

        public void removeAll() 
        {
            this .fileList .Clear();
            this .fileListHasChange();
        }
    }
}
