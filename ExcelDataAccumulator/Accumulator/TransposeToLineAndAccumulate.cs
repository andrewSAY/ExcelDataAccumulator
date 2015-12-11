using System;
using System .Collections .Generic;
using System .Linq;
using System .Text;
using ExcelLibrary .SpreadSheet;
using ExcelLibrary .CompoundDocumentFormat;

namespace Accumulator {
    class TransposeToLineAndAccumulate : AccumulatorBase
    {
       public TransposeToLineAndAccumulate(List<string> fileList , int worksheetNumber , List<Range> rangeList , string pathToSave , bool datectedEmptyRows) :
            base(fileList , worksheetNumber, rangeList, pathToSave , datectedEmptyRows) { }

        protected override void handle(int fileNumber) 
        {
            Workbook file = null;
            try
            {
                file = Workbook .Load(fileList[fileNumber]);
            }
            catch (Exception exc)
            {
                this .breakSelf(fileList[fileNumber] + " " + exc.Message);
                file = null;
            }
            Worksheet worksheet = this.workbook.Worksheets[0];
            int rowNumber = fileNumber;
            int colunmNumber = 0;            
            
            foreach (Range range in this .rangeList) 
            {
                List<Cell> stackHeaders = new List<Cell>();
                List<Cell> stackRows = new List<Cell>();

                if (range .minX != range .maxX)
                {
                    this .breakSelf(String .Format("В диапозоне {0} обнаружено более одного столбца" , range .rangeName));
                }
                if (range .isHeader && fileNumber > 0) 
                {
                    continue;
                }
                
                List<List<Cell>> rows = this .getRows(range , file.Worksheets[this.worksheetNumber]);
                foreach (List<Cell> row in rows) 
                {
                    if (range .isHeader)
                    {
                        stackHeaders .Add(row[0]);
                        continue;
                    }
                    stackRows .Add(row[0]);
                }

                colunmNumber = this .headersHasUsed;
                foreach (Cell cell in stackHeaders)
                {
                    worksheet .Cells[rowNumber , colunmNumber] = cell;
                    this .headersHasUsed++;
                    colunmNumber++;
                }

                colunmNumber = 0;                
                if (this .headersHasUsed > 0 && !range.isHeader)
                {
                    rowNumber ++;
                }

                foreach (Cell cell in stackRows)
                {
                    worksheet .Cells[rowNumber , colunmNumber] = cell;
                    colunmNumber++;
                }

            }            
        }
    }
}
