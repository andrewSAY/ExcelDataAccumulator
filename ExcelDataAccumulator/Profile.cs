using System;
using System .Collections .Generic;
using System .Linq;
using System .Text;
using Model;
using Accumulator;

namespace ExcelDataAccumulator{
    
    [Serializable]
    public class Profile: BinaryStorageAbstract
    {
        public int worksheetNumber { get; set; }
        public List<Range> ranges { get; set; }

        public Profile() 
        {
            worksheetNumber = 1;
            ranges = new List<Range>();
        }
    }
}
