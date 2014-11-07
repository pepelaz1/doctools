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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCompareResult = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbInputFile2 = new System.Windows.Forms.TextBox();
            this.tbInputFile1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(73, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(73, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(186, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "URL";
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(49, 12);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(577, 20);
            this.tbURL.TabIndex = 5;
            this.tbURL.Text = "http://185.31.160.150/api/compare";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCompareResult);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbInputFile2);
            this.groupBox1.Controls.Add(this.tbInputFile1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(15, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 196);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comparsion";
            // 
            // tbCompareResult
            // 
            this.tbCompareResult.Location = new System.Drawing.Point(9, 116);
            this.tbCompareResult.Multiline = true;
            this.tbCompareResult.Name = "tbCompareResult";
            this.tbCompareResult.Size = new System.Drawing.Size(586, 74);
            this.tbCompareResult.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(519, 84);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Compare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 51);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 22);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 22);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Results";
            // 
            // tbInputFile2
            // 
            this.tbInputFile2.Location = new System.Drawing.Point(77, 52);
            this.tbInputFile2.Name = "tbInputFile2";
            this.tbInputFile2.Size = new System.Drawing.Size(491, 20);
            this.tbInputFile2.TabIndex = 7;
            this.tbInputFile2.Text = "c:\\in\\test2.txt";
            // 
            // tbInputFile1
            // 
            this.tbInputFile1.Location = new System.Drawing.Point(77, 23);
            this.tbInputFile1.Name = "tbInputFile1";
            this.tbInputFile1.Size = new System.Drawing.Size(491, 20);
            this.tbInputFile1.TabIndex = 6;
            this.tbInputFile1.Text = "c:\\in\\test1.txt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Document 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Document 1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All Files (*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 365);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCompareResult;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbInputFile2;
        private System.Windows.Forms.TextBox tbInputFile1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

