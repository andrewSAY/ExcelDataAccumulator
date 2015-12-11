namespace ExcelDataAccumulator {
    partial class RangeForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System .ComponentModel .IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components .Dispose();
            }
            base .Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.regMaskTetxBox2 = new ExcelDataAccumulator.RegMaskTetxBox();
            this.regMaskTetxBox1 = new ExcelDataAccumulator.RegMaskTetxBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.regMaskTetxBox3 = new ExcelDataAccumulator.RegMaskTetxBox();
            this.regMaskTetxBox4 = new ExcelDataAccumulator.RegMaskTetxBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.regMaskTetxBox2);
            this.groupBox1.Controls.Add(this.regMaskTetxBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Columns";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // regMaskTetxBox2
            // 
            this.regMaskTetxBox2.Location = new System.Drawing.Point(157, 19);
            this.regMaskTetxBox2.Name = "regMaskTetxBox2";
            this.regMaskTetxBox2.regMask = "[0-9]";
            this.regMaskTetxBox2.Size = new System.Drawing.Size(88, 20);
            this.regMaskTetxBox2.TabIndex = 1;
            // 
            // regMaskTetxBox1
            // 
            this.regMaskTetxBox1.Location = new System.Drawing.Point(38, 19);
            this.regMaskTetxBox1.Name = "regMaskTetxBox1";
            this.regMaskTetxBox1.regMask = "[0-9]";
            this.regMaskTetxBox1.Size = new System.Drawing.Size(88, 20);
            this.regMaskTetxBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.regMaskTetxBox3);
            this.groupBox2.Controls.Add(this.regMaskTetxBox4);
            this.groupBox2.Location = new System.Drawing.Point(12, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rows";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "From";
            // 
            // regMaskTetxBox3
            // 
            this.regMaskTetxBox3.Location = new System.Drawing.Point(39, 32);
            this.regMaskTetxBox3.Name = "regMaskTetxBox3";
            this.regMaskTetxBox3.regMask = "[0-9]";
            this.regMaskTetxBox3.Size = new System.Drawing.Size(88, 20);
            this.regMaskTetxBox3.TabIndex = 2;
            // 
            // regMaskTetxBox4
            // 
            this.regMaskTetxBox4.Location = new System.Drawing.Point(158, 32);
            this.regMaskTetxBox4.Name = "regMaskTetxBox4";
            this.regMaskTetxBox4.regMask = "[0-9]";
            this.regMaskTetxBox4.Size = new System.Drawing.Size(88, 20);
            this.regMaskTetxBox4.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(172, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(251, 177);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "It include headers";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // RangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(348, 215);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RangeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Range";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System .Windows .Forms .GroupBox groupBox1;
        private System .Windows .Forms .GroupBox groupBox2;
        private System .Windows .Forms .Button button1;
        private System .Windows .Forms .Button button2;
        private System .Windows .Forms .Label label2;
        private System .Windows .Forms .Label label1;
        private RegMaskTetxBox regMaskTetxBox2;
        private RegMaskTetxBox regMaskTetxBox1;
        private System .Windows .Forms .Label label3;
        private System .Windows .Forms .Label label4;
        private RegMaskTetxBox regMaskTetxBox3;
        private RegMaskTetxBox regMaskTetxBox4;
        private System .Windows .Forms .CheckBox checkBox1;
    }
}