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
    public partial class RangeForm : Form {
        public RangeForm() {
            InitializeComponent();
        }

        private void button2_Click(object sender , EventArgs e) {
            Close();
        }

        private void button1_Click(object sender , EventArgs e) {
            try 
            {
                Form1 parent = this .Owner as Form1;
                string nameRange = String.Format("C {0}x{1} R {2}x{3}", regMaskTetxBox1.Text, regMaskTetxBox2.Text, regMaskTetxBox3.Text, regMaskTetxBox4.Text);
                if (checkBox1 .Checked)
                {
                    nameRange = nameRange + " Header";
                }
                Range range = new Range(Convert.ToInt32(regMaskTetxBox1.Text), Convert.ToInt32(regMaskTetxBox2.Text), Convert.ToInt32(regMaskTetxBox3.Text), Convert.ToInt32(regMaskTetxBox4.Text), nameRange, checkBox1.Checked);
                foreach (Range existingRange in parent .profile .ranges) 
                {
                    if (range .intersectionRange(existingRange)) 
                    {
                        throw new Exception(String.Format("New range crosses existing range '{0}'", existingRange.rangeName));
                    }
                }
                parent .addRange(range);
                Close();
            }
            catch (Exception exc) 
            {
                MessageBox .Show(this, exc .Message , "Error on create range" , MessageBoxButtons .OK , MessageBoxIcon .Error);
            }
        }   
    }
}
