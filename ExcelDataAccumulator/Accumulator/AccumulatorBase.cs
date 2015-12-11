using System;
using System .Collections .Generic;
using System .Linq;
using System .Text;
using ExcelLibrary .SpreadSheet;

namespace Accumulator {
    public abstract class AccumulatorBase 
    {
        public delegate void stringDelegate(string value);
        public delegate void intDelegate(int value);

        public event intDelegate progressChanged;
        public event intDelegate maxProgressValueChange;
        public event stringDelegate hasStoped;
        public event stringDelegate operationNameChanged;

        protected List<string> fileList { get; set; }
        protected bool detectedEmptyRows { get; set; }
        protected string pathToSave {get;set;}
        protected Workbook workbook { get; set; } 
        protected int worksheetNumber {get;set;}
        protected List<Range> rangeList { get; set; }
        protected int headersHasUsed {get;set;}

        protected AccumulatorBase(List<string> fileList, int worksheetNumber, List<Range> rangeList, string pathToSave, bool datectedEmptyRows)
        {
            this .detectedEmptyRows = detectedEmptyRows;
            this .fileList = fileList;
            this.pathToSave = pathToSave;
            this .worksheetNumber = worksheetNumber;
            this .rangeList = rangeList;
            workbook = new Workbook();
            workbook.Worksheets.Add(new Worksheet("AccumulatedData"));
            for (int i = 0; i <= 100; i++) 
            {
                workbook .Worksheets[0] .Cells[i , 0] = new Cell(String.Empty);
            }
        }

        public void go() 
        {
            headersHasUsed = 0;
            maxProgressValueChange(fileList .Count);
            operationNameChanged("Обход файлов");
            for (int i = 0; i < fileList .Count; i++ )
            {
                handle(i);
                progressChanged(i);
            }
            operationNameChanged("Формирование и сохранение итогового файла");
            progressChanged(0);
            workbook .Save(pathToSave);
            hasStoped("Операция завершена");
        }

        protected void breakSelf(string cause)
        {
            hasStoped(cause);
            return;
        }

        protected List<List<Cell>> getRows(Range range, Worksheet worksheet) 
        {
            List<List<Cell>> rows = new List<List<Cell>>();           
            for (int y = range .minY; y <= range .maxY; y++) 
            {
                List<Cell> row = new List<Cell>();
                int emptyCellsCount = 0;
                for (int x = range .minX; x <= range .maxX; x++) 
                {
                    Cell cell = worksheet .Cells[y , x];
                    row .Add(cell);
                    if (cell .IsEmpty) 
                    {
                        emptyCellsCount++;
                    }
                }
                if (detectedEmptyRows && isEmptyRow(row)) 
                {
                    continue;
                }
                rows .Add(row);
            }

            return rows;
        }

        protected bool isEmptyRow(List<Cell> row) 
        {
            int emptyCellsCount = 0;
            foreach(Cell cell in row)
            {
                if (cell .IsEmpty) 
                {
                    emptyCellsCount++;
                }
            }

            if (emptyCellsCount == row .Count) 
            {
                return true;
            }

            return false;
        }

        abstract protected void handle(int fileNumber);           
    }
}
