namespace PassFace
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.secondImageBox = new Emgu.CV.UI.ImageBox();
            this.captureImageBox = new Emgu.CV.UI.ImageBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.faceRecog = new System.Windows.Forms.CheckBox();
            this.comboBoxCapture = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.addDatabaseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.workCorruptedImages = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxSplitChar = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eqHisChecked = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonFaceExtract = new System.Windows.Forms.Button();
            this.directoryFaceExtract = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.secondImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // secondImageBox
            // 
            this.secondImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondImageBox.Location = new System.Drawing.Point(753, 18);
            this.secondImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.secondImageBox.Name = "secondImageBox";
            this.secondImageBox.Size = new System.Drawing.Size(432, 288);
            this.secondImageBox.TabIndex = 9;
            this.secondImageBox.TabStop = false;
            // 
            // captureImageBox
            // 
            this.captureImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.captureImageBox.Location = new System.Drawing.Point(12, 18);
            this.captureImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.captureImageBox.Name = "captureImageBox";
            this.captureImageBox.Size = new System.Drawing.Size(707, 447);
            this.captureImageBox.TabIndex = 8;
            this.captureImageBox.TabStop = false;
            // 
            // captureButton
            // 
            this.captureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.captureButton.Location = new System.Drawing.Point(457, 103);
            this.captureButton.Margin = new System.Windows.Forms.Padding(4);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(167, 35);
            this.captureButton.TabIndex = 11;
            this.captureButton.Text = "Start Capture";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // faceRecog
            // 
            this.faceRecog.AutoSize = true;
            this.faceRecog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.faceRecog.Location = new System.Drawing.Point(457, 16);
            this.faceRecog.Margin = new System.Windows.Forms.Padding(4);
            this.faceRecog.Name = "faceRecog";
            this.faceRecog.Size = new System.Drawing.Size(231, 29);
            this.faceRecog.TabIndex = 13;
            this.faceRecog.Text = "Start Face Recognition\r\n";
            this.faceRecog.UseVisualStyleBackColor = true;
            this.faceRecog.CheckedChanged += new System.EventHandler(this.faceRecog_CheckedChanged);
            // 
            // comboBoxCapture
            // 
            this.comboBoxCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCapture.FormattingEnabled = true;
            this.comboBoxCapture.Items.AddRange(new object[] {
            "Camera",
            "Video",
            "Single Image",
            "Multi Image"});
            this.comboBoxCapture.Location = new System.Drawing.Point(11, 63);
            this.comboBoxCapture.Name = "comboBoxCapture";
            this.comboBoxCapture.Size = new System.Drawing.Size(167, 33);
            this.comboBoxCapture.TabIndex = 14;
            this.comboBoxCapture.SelectedIndexChanged += new System.EventHandler(this.comboBoxCapture_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1199, 792);
            this.panel1.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(998, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(172, 202);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Performance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Scan Time:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.addDatabaseButton);
            this.groupBox2.Location = new System.Drawing.Point(772, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 202);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Base";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(90, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 12;
            // 
            // addDatabaseButton
            // 
            this.addDatabaseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addDatabaseButton.Location = new System.Drawing.Point(23, 21);
            this.addDatabaseButton.Margin = new System.Windows.Forms.Padding(4);
            this.addDatabaseButton.Name = "addDatabaseButton";
            this.addDatabaseButton.Size = new System.Drawing.Size(167, 35);
            this.addDatabaseButton.TabIndex = 11;
            this.addDatabaseButton.Text = "Add Database";
            this.addDatabaseButton.UseVisualStyleBackColor = true;
            this.addDatabaseButton.Click += new System.EventHandler(this.addDatabaseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.workCorruptedImages);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.comboBoxSplitChar);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBoxAlgorithm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.eqHisChecked);
            this.groupBox1.Controls.Add(this.captureButton);
            this.groupBox1.Controls.Add(this.faceRecog);
            this.groupBox1.Controls.Add(this.comboBoxCapture);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(27, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 202);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // workCorruptedImages
            // 
            this.workCorruptedImages.AutoSize = true;
            this.workCorruptedImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.workCorruptedImages.Location = new System.Drawing.Point(457, 67);
            this.workCorruptedImages.Margin = new System.Windows.Forms.Padding(4);
            this.workCorruptedImages.Name = "workCorruptedImages";
            this.workCorruptedImages.Size = new System.Drawing.Size(281, 29);
            this.workCorruptedImages.TabIndex = 22;
            this.workCorruptedImages.Text = "Work with Corrupted Images";
            this.workCorruptedImages.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(196, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Splith with";
            // 
            // comboBoxSplitChar
            // 
            this.comboBoxSplitChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSplitChar.FormattingEnabled = true;
            this.comboBoxSplitChar.Items.AddRange(new object[] {
            "_",
            "0",
            "."});
            this.comboBoxSplitChar.Location = new System.Drawing.Point(304, 156);
            this.comboBoxSplitChar.Name = "comboBoxSplitChar";
            this.comboBoxSplitChar.Size = new System.Drawing.Size(111, 33);
            this.comboBoxSplitChar.TabIndex = 20;
            this.comboBoxSplitChar.Text = "_";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(322, 103);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 35);
            this.button2.TabIndex = 19;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(203, 103);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Train";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Items.AddRange(new object[] {
            "SURF Feature Extractor",
            "EigenFaces",
            "FisherFaces",
            "LBPHFaces"});
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(203, 63);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(212, 33);
            this.comboBoxAlgorithm.TabIndex = 17;
            this.comboBoxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgorithm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Select Capture";
            // 
            // eqHisChecked
            // 
            this.eqHisChecked.AutoSize = true;
            this.eqHisChecked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eqHisChecked.Location = new System.Drawing.Point(457, 42);
            this.eqHisChecked.Margin = new System.Windows.Forms.Padding(4);
            this.eqHisChecked.Name = "eqHisChecked";
            this.eqHisChecked.Size = new System.Drawing.Size(202, 29);
            this.eqHisChecked.TabIndex = 12;
            this.eqHisChecked.Text = "Equalize Histogram";
            this.eqHisChecked.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(198, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Select Algorithm";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.captureImageBox);
            this.panel2.Controls.Add(this.secondImageBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1199, 572);
            this.panel2.TabIndex = 16;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonFaceExtract);
            this.groupBox4.Controls.Add(this.directoryFaceExtract);
            this.groupBox4.Location = new System.Drawing.Point(753, 313);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(417, 152);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Face Extract Tool";
            // 
            // buttonFaceExtract
            // 
            this.buttonFaceExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonFaceExtract.Location = new System.Drawing.Point(21, 22);
            this.buttonFaceExtract.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFaceExtract.Name = "buttonFaceExtract";
            this.buttonFaceExtract.Size = new System.Drawing.Size(198, 35);
            this.buttonFaceExtract.TabIndex = 19;
            this.buttonFaceExtract.Text = "Face Extract Tool";
            this.buttonFaceExtract.UseVisualStyleBackColor = true;
            this.buttonFaceExtract.Click += new System.EventHandler(this.buttonFaceExtract_Click);
            // 
            // directoryFaceExtract
            // 
            this.directoryFaceExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directoryFaceExtract.Location = new System.Drawing.Point(21, 83);
            this.directoryFaceExtract.Name = "directoryFaceExtract";
            this.directoryFaceExtract.Size = new System.Drawing.Size(266, 30);
            this.directoryFaceExtract.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(753, 510);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 25);
            this.label7.TabIndex = 12;
            this.label7.Text = "noName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(753, 485);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "0";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 485);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(707, 122);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 792);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PassFace()";
            ((System.ComponentModel.ISupportInitialize)(this.secondImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox secondImageBox;
        private Emgu.CV.UI.ImageBox captureImageBox;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.CheckBox faceRecog;
        private System.Windows.Forms.ComboBox comboBoxCapture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button addDatabaseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox eqHisChecked;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxSplitChar;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonFaceExtract;
        private System.Windows.Forms.TextBox directoryFaceExtract;
        private System.Windows.Forms.CheckBox workCorruptedImages;

    }
}

