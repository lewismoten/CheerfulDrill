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
            this.SuspendLayout();
            // 
            // chooseSourceButton
            // 
            this.chooseSourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseSourceButton.Location = new System.Drawing.Point(237, 23);
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location of Files";
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePathTextBox.Location = new System.Drawing.Point(12, 25);
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.Size = new System.Drawing.Size(219, 20);
            this.sourcePathTextBox.TabIndex = 2;
            this.sourcePathTextBox.Text = "D:\\_testData";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Name / Pattern";
            // 
            // sourcePatternTextBox
            // 
            this.sourcePatternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePatternTextBox.Location = new System.Drawing.Point(12, 64);
            this.sourcePatternTextBox.Name = "sourcePatternTextBox";
            this.sourcePatternTextBox.Size = new System.Drawing.Size(260, 20);
            this.sourcePatternTextBox.TabIndex = 4;
            this.sourcePatternTextBox.Text = "*.htm?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Save Data As...";
            // 
            // targetFileTextBox
            // 
            this.targetFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.targetFileTextBox.Location = new System.Drawing.Point(12, 103);
            this.targetFileTextBox.Name = "targetFileTextBox";
            this.targetFileTextBox.Size = new System.Drawing.Size(219, 20);
            this.targetFileTextBox.TabIndex = 6;
            this.targetFileTextBox.Text = "data.xml";
            // 
            // chooseTargetButton
            // 
            this.chooseTargetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseTargetButton.Location = new System.Drawing.Point(237, 101);
            this.chooseTargetButton.Name = "chooseTargetButton";
            this.chooseTargetButton.Size = new System.Drawing.Size(35, 23);
            this.chooseTargetButton.TabIndex = 7;
            this.chooseTargetButton.Text = "...";
            this.chooseTargetButton.UseVisualStyleBackColor = true;
            this.chooseTargetButton.Click += new System.EventHandler(this.ChooseTargetButtonClick);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 129);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(65, 23);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 373);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.chooseTargetButton);
            this.Controls.Add(this.targetFileTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sourcePatternTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sourcePathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseSourceButton);
            this.Name = "Form1";
            this.Text = "Cheerful Drill";
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
    }
}

