using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Drawing;
using System .Data;
using System .Linq;
using System .Text;
using System .Windows .Forms;

namespace GiaManager .Controls {
    public partial class OperationProgressVisualisator : UserControl {

        public string operationCaption {
            get 
            {
                return this .label1.Text;
            }
            set 
            {
                this .label1 .Text = value;
            }
        }

        public int maxProgressValue {
            get 
            {
                return this .progressBar1.Maximum;
            }
            set 
            {
                this .progressBar1.Maximum = value;
            }
        }

        public int currentValue {
            get 
            {
                return this .progressBar1 .Value;
            }
            set 
            {
                this .progressBar1 .Value = value;
            }
        }

        public FlatStyle buttonStyle {
            get 
            {
                return this .button1.FlatStyle;
            }
            set 
            {
                this .button1.FlatStyle = value;
            }
        }

        public string buttonCaption {
            get 
            {
                return this .button1 .Text;
            }
            set 
            {
                this .button1 .Text = value;
            }
        }

        public delegate void stoppedDelegate();
        public event stoppedDelegate isStop;

        public OperationProgressVisualisator() {
            InitializeComponent();
            isStop = delegate { };
        }

        private void button1_Click(object sender , EventArgs e) {
            this .currentValue = 0;
            isStop();
        }

        private void splitContainer1_Panel1_Paint(object sender , PaintEventArgs e) {

        }

        public void operationNameSet(string value) {
            operationCaption = value;
            currentValue = 0;
        }

        public void progressSet(int value) {
            currentValue = value;
        }

        public void maxProgressValueSet(int value) {
            maxProgressValue = value;
        }
    }
}
