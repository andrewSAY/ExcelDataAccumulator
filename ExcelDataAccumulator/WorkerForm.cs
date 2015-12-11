using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System .Drawing;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using System .Threading;
using Accumulator;

namespace ExcelDataAccumulator {
    public partial class WorkerForm : Form {
        private bool hasCancelPress = false;
        private Thread tr { get; set; }
        public delegate void stringDelegate(string value);
        public delegate void integerDelegate(int value);

        public WorkerForm() {
            InitializeComponent();
            this .FormClosing += new FormClosingEventHandler(WorkerForm_FormClosing);
            operationProgressVisualisator1 .buttonStyle = FlatStyle .Popup;
            operationProgressVisualisator1 .Enabled = false;
            operationProgressVisualisator1 .buttonCaption = "Break";
        }

        void WorkerForm_FormClosing(object sender , FormClosingEventArgs e) {
            if (e .CloseReason == CloseReason .UserClosing && !hasCancelPress) 
            {
                e .Cancel = true;
            }
        }        

        private void button3_Click(object sender , EventArgs e) 
        {
            hasCancelPress = true;
            Close();
        }

        private void button1_Click(object sender , EventArgs e) 
        {
            Form1 owner = (this .Owner as Form1);
            AccumulatorBase accumulator = null;
            List<string> files = new List<string>();
            foreach (FileStorage file in owner .getFileList()) 
            {
                files .Add(file .fileName);
            }

            switch (comboBox1 .SelectedIndex) 
            {
                case 0: accumulator = new TransposeToLineAndAccumulate(files, owner.profile.worksheetNumber, owner.profile.ranges, owner.getPathToSave(), checkBox1.Checked);
                    break;
                default: 
                    break;
            }

            if (accumulator == null) 
            {
                return;
            }

            operationProgressVisualisator1 .Enabled = true;
            button1 .Enabled = false;
            button3 .Enabled = false;

            tr = new Thread(accumulator.go);

            accumulator .operationNameChanged += new AccumulatorBase .stringDelegate(accumulator_operationNameChanged);
            accumulator .progressChanged += new AccumulatorBase .intDelegate(accumulator_progressChanged);
            accumulator .maxProgressValueChange += new AccumulatorBase .intDelegate(accumulator_maxProgressValueChange);
            accumulator .hasStoped += new AccumulatorBase .stringDelegate(accumulator_hasStoped);
            
            operationProgressVisualisator1 .isStop += new GiaManager .Controls .OperationProgressVisualisator .stoppedDelegate(operationProgressVisualisator1_isStop);

            tr .Start();
        }

        void accumulator_hasStoped(string value) {
            object[] params_ = new object[1];
            params_[0] = value;
            IAsyncResult res = this.BeginInvoke(new stringDelegate(operationStopedDelegate) , params_);
            this.EndInvoke(res);            
            tr .Abort();
        }

        void operationProgressVisualisator1_isStop() {
            tr .Abort();
            operationProgressVisualisator1 .operationCaption = "Завершение опереации";
            operationProgressVisualisator1 .currentValue = 0;
            while (tr .ThreadState != ThreadState .Stopped) {
            }
            operationStopedDelegate("Операция прервана пользователем");
        }

        void accumulator_maxProgressValueChange(int value) {
            object[] params_ = new object[1];
            params_[0] = value;
            operationProgressVisualisator1 .BeginInvoke(new integerDelegate(operationProgressVisualisator1 .maxProgressValueSet) , params_);
        }

        void accumulator_progressChanged(int value) {
            object[] params_ = new object[1];
            params_[0] = value;
            operationProgressVisualisator1 .BeginInvoke(new integerDelegate(operationProgressVisualisator1 .progressSet) , params_);
        }

        void accumulator_operationNameChanged(string value) {
            object[] params_ = new object[1];
            params_[0] = value;
            operationProgressVisualisator1 .BeginInvoke(new stringDelegate(operationProgressVisualisator1.operationNameSet) , params_);
        }

        void operationStopedDelegate(string value) {
            button1 .Enabled = true;
            button3 .Enabled = true;
            comboBox1 .Enabled = true;
            operationProgressVisualisator1 .operationCaption = value;
            operationProgressVisualisator1 .currentValue = 0;
            operationProgressVisualisator1 .Enabled = false;
        }

       
    }
}
