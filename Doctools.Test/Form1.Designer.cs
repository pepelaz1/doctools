namespace Doctools.Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUsernameCompare = new System.Windows.Forms.TextBox();
            this.tbPasswordCompare = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCompareResult = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInputFile2 = new System.Windows.Forms.TextBox();
            this.tbInputFile1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbFileToConvert = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbOuputFormat = new System.Windows.Forms.ComboBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbUrlCompare = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbUrlConvert = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPasswordConvert = new System.Windows.Forms.TextBox();
            this.tbUsernameConvert = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbConvertResult = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // tbUsernameCompare
            // 
            this.tbUsernameCompare.Location = new System.Drawing.Point(72, 65);
            this.tbUsernameCompare.Name = "tbUsernameCompare";
            this.tbUsernameCompare.Size = new System.Drawing.Size(186, 20);
            this.tbUsernameCompare.TabIndex = 2;
            this.tbUsernameCompare.Text = "username";
            // 
            // tbPasswordCompare
            // 
            this.tbPasswordCompare.Location = new System.Drawing.Point(72, 94);
            this.tbPasswordCompare.Name = "tbPasswordCompare";
            this.tbPasswordCompare.Size = new System.Drawing.Size(186, 20);
            this.tbPasswordCompare.TabIndex = 3;
            this.tbPasswordCompare.Text = "password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUrlCompare);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbReportType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbPasswordCompare);
            this.groupBox1.Controls.Add(this.tbCompareResult);
            this.groupBox1.Controls.Add(this.tbUsernameCompare);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbInputFile2);
            this.groupBox1.Controls.Add(this.tbInputFile1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 377);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comparsion";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "all-in-one",
            "side-by-side"});
            this.cmbReportType.Location = new System.Drawing.Point(79, 205);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(121, 21);
            this.cmbReportType.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Report type";
            // 
            // tbCompareResult
            // 
            this.tbCompareResult.Location = new System.Drawing.Point(11, 258);
            this.tbCompareResult.Multiline = true;
            this.tbCompareResult.Name = "tbCompareResult";
            this.tbCompareResult.Size = new System.Drawing.Size(442, 112);
            this.tbCompareResult.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(378, 205);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Compare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Results";
            // 
            // tbInputFile2
            // 
            this.tbInputFile2.Location = new System.Drawing.Point(79, 173);
            this.tbInputFile2.Name = "tbInputFile2";
            this.tbInputFile2.Size = new System.Drawing.Size(347, 20);
            this.tbInputFile2.TabIndex = 7;
            this.tbInputFile2.Text = "c:\\in\\futurama modified.docx";
            // 
            // tbInputFile1
            // 
            this.tbInputFile1.Location = new System.Drawing.Point(79, 144);
            this.tbInputFile1.Name = "tbInputFile1";
            this.tbInputFile1.Size = new System.Drawing.Size(347, 20);
            this.tbInputFile1.TabIndex = 6;
            this.tbInputFile1.Text = "c:\\in\\futurama.docx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Document 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Document 1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files (*.*)|*.*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.tbConvertResult);
            this.groupBox2.Controls.Add(this.tbUrlConvert);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPasswordConvert);
            this.groupBox2.Controls.Add(this.tbUsernameConvert);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnConvert);
            this.groupBox2.Controls.Add(this.cmbOuputFormat);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.tbFileToConvert);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(495, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 377);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conversion";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "File";
            // 
            // tbFileToConvert
            // 
            this.tbFileToConvert.Location = new System.Drawing.Point(35, 147);
            this.tbFileToConvert.Name = "tbFileToConvert";
            this.tbFileToConvert.Size = new System.Drawing.Size(395, 20);
            this.tbFileToConvert.TabIndex = 7;
            this.tbFileToConvert.Text = "c:\\in\\futurama.docx";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(432, 146);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 22);
            this.button4.TabIndex = 10;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Output format";
            // 
            // cmbOuputFormat
            // 
            this.cmbOuputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOuputFormat.FormattingEnabled = true;
            this.cmbOuputFormat.Items.AddRange(new object[] {
            "html",
            "pdf",
            "docx"});
            this.cmbOuputFormat.Location = new System.Drawing.Point(83, 177);
            this.cmbOuputFormat.Name = "cmbOuputFormat";
            this.cmbOuputFormat.Size = new System.Drawing.Size(76, 21);
            this.cmbOuputFormat.TabIndex = 15;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(384, 180);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 16;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Results";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 22);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 22);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbUrlCompare
            // 
            this.tbUrlCompare.Location = new System.Drawing.Point(46, 19);
            this.tbUrlCompare.Name = "tbUrlCompare";
            this.tbUrlCompare.Size = new System.Drawing.Size(407, 20);
            this.tbUrlCompare.TabIndex = 16;
            this.tbUrlCompare.Text = "http://185.31.160.150/api/compare";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "URL";
            // 
            // tbUrlConvert
            // 
            this.tbUrlConvert.Location = new System.Drawing.Point(41, 23);
            this.tbUrlConvert.Name = "tbUrlConvert";
            this.tbUrlConvert.Size = new System.Drawing.Size(407, 20);
            this.tbUrlConvert.TabIndex = 23;
            this.tbUrlConvert.Text = "http://185.31.160.150/api/convert";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "URL";
            // 
            // tbPasswordConvert
            // 
            this.tbPasswordConvert.Location = new System.Drawing.Point(67, 98);
            this.tbPasswordConvert.Name = "tbPasswordConvert";
            this.tbPasswordConvert.Size = new System.Drawing.Size(186, 20);
            this.tbPasswordConvert.TabIndex = 21;
            this.tbPasswordConvert.Text = "password";
            // 
            // tbUsernameConvert
            // 
            this.tbUsernameConvert.Location = new System.Drawing.Point(67, 69);
            this.tbUsernameConvert.Name = "tbUsernameConvert";
            this.tbUsernameConvert.Size = new System.Drawing.Size(186, 20);
            this.tbUsernameConvert.TabIndex = 20;
            this.tbUsernameConvert.Text = "username";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Password";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Username";
            // 
            // tbConvertResult
            // 
            this.tbConvertResult.Location = new System.Drawing.Point(9, 259);
            this.tbConvertResult.Multiline = true;
            this.tbConvertResult.Name = "tbConvertResult";
            this.tbConvertResult.Size = new System.Drawing.Size(442, 112);
            this.tbConvertResult.TabIndex = 24;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 209);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(160, 17);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "Send as \'multipart/form-data\'";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 397);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUsernameCompare;
        private System.Windows.Forms.TextBox tbPasswordCompare;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCompareResult;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbInputFile2;
        private System.Windows.Forms.TextBox tbInputFile1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ComboBox cmbOuputFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbFileToConvert;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbUrlCompare;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbUrlConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPasswordConvert;
        private System.Windows.Forms.TextBox tbUsernameConvert;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbConvertResult;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

