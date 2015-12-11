using System;
using System .Collections .Generic;
using System .Linq;
using System .Text;

namespace ExcelDataAccumulator {
   public class FileStorage {
        public string caption {  get; private set; }
        public string fileName { get; private set; }

        public FileStorage(string caption, string fileName)
        {
            this .caption = caption;
            this .fileName = fileName;
        }
    }
}
