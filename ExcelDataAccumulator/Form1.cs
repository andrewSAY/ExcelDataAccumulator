using System;
using System .Collections .Generic;
using System .ComponentModel;
using System .Data;
using System .Drawing;
using System .Linq;
using System .Text;
using System .Windows .Forms;
using Accumulator;

namespace ExcelDataAccumulator {
    public partial class Form1 : Form {
        List<FileStorage> fileList;
        private FileStorageFactory fsFactory {get;set;}
        public Profile profile { get; private set; }
        public Form1() {
            profile = new Profile();
            InitializeComponent();
        }

        public void addRange(Range range)
        {
            profile .ranges .Add(range);
            listBox2Review();
        }        

        private void Form1_Load(object sender , EventArgs e) 
        {            
            int i = 0;
            while (i <= 25) 
            {
                comboBox4 .Items .Add(i);
                i++;
            }
            comboBox4 .SelectedIndex = 0;
            fileList = new List<FileStorage>();
            fsFactory = new FileStorageFactory(ref this .fileList);
            this .fsFactory .fileListHasChange += new FileStorageFactory .fileListChangeDelgate(listBoxReview);            
        }

        private void listBoxReview() {
            listBox1 .DataSource = null;
            listBox1 .DataSource = this .fileList;
            listBox1 .DisplayMember = "caption";
            label1 .Text = listBox1 .Items .Count.ToString();
        }

        private void listBox2Review() {
            listBox2 .DataSource = null;
            listBox2 .DataSource = this .profile.ranges;
            listBox2 .DisplayMember = "rangeName";
        }

        private void openFileDialog1_FileOk(object sender , CancelEventArgs e) {
            fsFactory .addFiles((sender as FileDialog) .FileNames);
        }

        private void button2_Click(object sender , EventArgs e) {
            this .fsFactory .removeAll();
            listBox1 .SelectedIndex = -1;
        }

        private void button1_Click(object sender , EventArgs e) {
            openFileDialog1 .ShowDialog();
        }

        private void button7_Click(object sender , EventArgs e) {
            saveFileDialog1 .ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender , CancelEventArgs e) {
            profile .saveToHardwareStorage((sender as SaveFileDialog) .FileName);
        }

        private void button8_Click(object sender , EventArgs e) {
            openFileDialog2 .ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender , CancelEventArgs e) {
            profile .loadFromHardwareStorage((sender as OpenFileDialog) .FileName);
            comboBox4 .SelectedItem = profile .worksheetNumber;
            listBox2Review();
        }

        private void button4_Click(object sender , EventArgs e) {
            RangeForm form = new RangeForm();
            form .ShowDialog(this);
        }

        private void button5_Click(object sender , EventArgs e) {
            if (listBox2 .SelectedItems .Count == 0) 
            {
                return;
            }

            foreach (Range item in listBox2 .SelectedItems) 
            {
                profile .ranges .Remove(item);
            }
            
            listBox2Review();
        }

        private void button6_Click(object sender , EventArgs e) {
            profile .ranges .Clear();
            listBox2Review();
        }

        private void button3_Click(object sender , EventArgs e) {
            (new WorkerForm()) .ShowDialog(this);
        }

        public List<FileStorage> getFileList()
        {           
            return fileList;
        }

        public string getPathToSave() 
        {
            return textBox1 .Text;
        }

        private void comboBox4_SelectedIndexChanged(object sender , EventArgs e) {
            profile .worksheetNumber = (int)(sender as ComboBox) .SelectedItem;
        }

        private void button9_Click(object sender , EventArgs e)
        {            
            int index = listBox2 .SelectedIndex;
            if (index - 1 < 0)
            {
                return;
            }
            Range range = profile.ranges[index];
            profile .ranges .Remove(range);
            profile .ranges .Insert(index - 1 , range);
            listBox2Review();
            listBox2 .SelectedIndex = index - 1;
        }

        private void button10_Click(object sender , EventArgs e)
        {
            int index = listBox2 .SelectedIndex;
            if (index + 1 > profile.ranges.Count - 1)
            {
                return;
            }
            Range range = profile .ranges[index];
            profile .ranges .Remove(range);
            profile .ranges .Insert(index + 1 , range);
            listBox2Review();
            listBox2 .SelectedIndex = index + 1;
        }

        private void button5_Click_1(object sender , EventArgs e)
        {
            if (listBox2 .SelectedIndex < 0)
            {
                return;
            }
            profile .ranges .Remove((Range)listBox2 .SelectedItem);
            listBox2Review();            
        }

        private void button6_Click_1(object sender , EventArgs e)
        {
            profile .ranges .Clear();
            listBox2Review();
        }
    }
}
