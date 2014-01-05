namespace LewisMoten.Spiders.CheerfulDrill.UI
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
            this.components = new System.ComponentModel.Container();
            this.chooseSourceButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.sourcePathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sourcePatternTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.targetFileTextBox = new System.Windows.Forms.TextBox();
            this.chooseTargetButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.stopButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.taskStatusLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.extractorListControl1 = new LewisMoten.Spiders.CheerfulDrill.UI.ExtractorListControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadExtractorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveExtractorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseSourceButton
            // 
            this.chooseSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseSourceButton.Location = new System.Drawing.Point(425, 38);
            this.chooseSourceButton.Name = "chooseSourceButton";
            this.chooseSourceButton.Size = new System.Drawing.Size(35, 23);
            this.chooseSourceButton.TabIndex = 0;
            this.chooseSourceButton.Text = "...";
            this.chooseSourceButton.UseVisualStyleBackColor = true;
            this.chooseSourceButton.Click += new System.EventHandler(this.ChooseSourceButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location of Files";
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePathTextBox.Location = new System.Drawing.Point(12, 40);
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.Size = new System.Drawing.Size(407, 20);
            this.sourcePathTextBox.TabIndex = 2;
            this.sourcePathTextBox.Text = "D:\\_testData";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Name / Pattern";
            // 
            // sourcePatternTextBox
            // 
            this.sourcePatternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePatternTextBox.Location = new System.Drawing.Point(12, 79);
            this.sourcePatternTextBox.Name = "sourcePatternTextBox";
            this.sourcePatternTextBox.Size = new System.Drawing.Size(448, 20);
            this.sourcePatternTextBox.TabIndex = 4;
            this.sourcePatternTextBox.Text = "*.htm?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Save Data As...";
            // 
            // targetFileTextBox
            // 
            this.targetFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFileTextBox.Location = new System.Drawing.Point(12, 118);
            this.targetFileTextBox.Name = "targetFileTextBox";
            this.targetFileTextBox.Size = new System.Drawing.Size(407, 20);
            this.targetFileTextBox.TabIndex = 6;
            this.targetFileTextBox.Text = "data.xml";
            // 
            // chooseTargetButton
            // 
            this.chooseTargetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseTargetButton.Location = new System.Drawing.Point(425, 116);
            this.chooseTargetButton.Name = "chooseTargetButton";
            this.chooseTargetButton.Size = new System.Drawing.Size(35, 23);
            this.chooseTargetButton.TabIndex = 7;
            this.chooseTargetButton.Text = "...";
            this.chooseTargetButton.UseVisualStyleBackColor = true;
            this.chooseTargetButton.Click += new System.EventHandler(this.ChooseTargetButtonClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 144);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(65, 23);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(395, 145);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(65, 23);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Status:";
            // 
            // taskStatusLabel
            // 
            this.taskStatusLabel.AutoSize = true;
            this.taskStatusLabel.Location = new System.Drawing.Point(126, 171);
            this.taskStatusLabel.Name = "taskStatusLabel";
            this.taskStatusLabel.Size = new System.Drawing.Size(33, 13);
            this.taskStatusLabel.TabIndex = 11;
            this.taskStatusLabel.Text = "None";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(83, 145);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(306, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // extractorListControl1
            // 
            this.extractorListControl1.Location = new System.Drawing.Point(12, 187);
            this.extractorListControl1.Name = "extractorListControl1";
            this.extractorListControl1.Size = new System.Drawing.Size(448, 224);
            this.extractorListControl1.TabIndex = 14;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.extractorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(472, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.StopApplication);
            // 
            // extractorsToolStripMenuItem
            // 
            this.extractorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadExtractorsToolStripMenuItem1,
            this.saveExtractorsToolStripMenuItem});
            this.extractorsToolStripMenuItem.Name = "extractorsToolStripMenuItem";
            this.extractorsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.extractorsToolStripMenuItem.Text = "Extractors";
            // 
            // loadExtractorsToolStripMenuItem1
            // 
            this.loadExtractorsToolStripMenuItem1.Name = "loadExtractorsToolStripMenuItem1";
            this.loadExtractorsToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.loadExtractorsToolStripMenuItem1.Text = "Load...";
            this.loadExtractorsToolStripMenuItem1.Click += new System.EventHandler(this.LoadExtractors);
            // 
            // saveExtractorsToolStripMenuItem
            // 
            this.saveExtractorsToolStripMenuItem.Name = "saveExtractorsToolStripMenuItem";
            this.saveExtractorsToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveExtractorsToolStripMenuItem.Text = "Save..";
            this.saveExtractorsToolStripMenuItem.Click += new System.EventHandler(this.SaveExtractors);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 423);
            this.Controls.Add(this.extractorListControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.taskStatusLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.chooseTargetButton);
            this.Controls.Add(this.targetFileTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sourcePatternTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sourcePathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseSourceButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cheerful Drill";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseSourceButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sourcePathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourcePatternTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox targetFileTextBox;
        private System.Windows.Forms.Button chooseTargetButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label taskStatusLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar1;
        private ExtractorListControl extractorListControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadExtractorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveExtractorsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

