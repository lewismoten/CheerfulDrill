namespace LewisMoten.Spiders.CheerfulDrill.UI
{
    partial class ExtractorForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultValueTextBox = new System.Windows.Forms.TextBox();
            this.allowMultipleCheckBox = new System.Windows.Forms.CheckBox();
            this.patternTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.captureAllRadioButton = new System.Windows.Forms.RadioButton();
            this.captureGroupRadioButton = new System.Windows.Forms.RadioButton();
            this.captureNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.extractorListControl1 = new LewisMoten.Spiders.CheerfulDrill.UI.ExtractorListControl();
            ((System.ComponentModel.ISupportInitialize)(this.captureNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 25);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(160, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Default Value";
            // 
            // defaultValueTextBox
            // 
            this.defaultValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultValueTextBox.Location = new System.Drawing.Point(12, 64);
            this.defaultValueTextBox.Multiline = true;
            this.defaultValueTextBox.Name = "defaultValueTextBox";
            this.defaultValueTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.defaultValueTextBox.Size = new System.Drawing.Size(492, 54);
            this.defaultValueTextBox.TabIndex = 3;
            // 
            // allowMultipleCheckBox
            // 
            this.allowMultipleCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.allowMultipleCheckBox.AutoSize = true;
            this.allowMultipleCheckBox.Location = new System.Drawing.Point(6, 130);
            this.allowMultipleCheckBox.Name = "allowMultipleCheckBox";
            this.allowMultipleCheckBox.Size = new System.Drawing.Size(132, 17);
            this.allowMultipleCheckBox.TabIndex = 5;
            this.allowMultipleCheckBox.Text = "Extract first match only";
            this.allowMultipleCheckBox.UseVisualStyleBackColor = true;
            // 
            // patternTextBox
            // 
            this.patternTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.patternTextBox.Location = new System.Drawing.Point(6, 32);
            this.patternTextBox.Multiline = true;
            this.patternTextBox.Name = "patternTextBox";
            this.patternTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.patternTextBox.Size = new System.Drawing.Size(480, 56);
            this.patternTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pattern";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Capture";
            // 
            // captureAllRadioButton
            // 
            this.captureAllRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.captureAllRadioButton.AutoSize = true;
            this.captureAllRadioButton.Location = new System.Drawing.Point(6, 107);
            this.captureAllRadioButton.Name = "captureAllRadioButton";
            this.captureAllRadioButton.Size = new System.Drawing.Size(36, 17);
            this.captureAllRadioButton.TabIndex = 10;
            this.captureAllRadioButton.TabStop = true;
            this.captureAllRadioButton.Text = "All";
            this.captureAllRadioButton.UseVisualStyleBackColor = true;
            // 
            // captureGroupRadioButton
            // 
            this.captureGroupRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.captureGroupRadioButton.AutoSize = true;
            this.captureGroupRadioButton.Location = new System.Drawing.Point(48, 107);
            this.captureGroupRadioButton.Name = "captureGroupRadioButton";
            this.captureGroupRadioButton.Size = new System.Drawing.Size(54, 17);
            this.captureGroupRadioButton.TabIndex = 11;
            this.captureGroupRadioButton.TabStop = true;
            this.captureGroupRadioButton.Text = "Group";
            this.captureGroupRadioButton.UseVisualStyleBackColor = true;
            // 
            // captureNumericUpDown
            // 
            this.captureNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.captureNumericUpDown.Location = new System.Drawing.Point(114, 107);
            this.captureNumericUpDown.Name = "captureNumericUpDown";
            this.captureNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.captureNumericUpDown.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.captureNumericUpDown);
            this.groupBox1.Controls.Add(this.patternTextBox);
            this.groupBox1.Controls.Add(this.captureGroupRadioButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.captureAllRadioButton);
            this.groupBox1.Controls.Add(this.allowMultipleCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 156);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regular Expression";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(348, 474);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "Accept";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(429, 474);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // extractorListControl1
            // 
            this.extractorListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractorListControl1.Location = new System.Drawing.Point(12, 286);
            this.extractorListControl1.Name = "extractorListControl1";
            this.extractorListControl1.Size = new System.Drawing.Size(492, 182);
            this.extractorListControl1.TabIndex = 16;
            // 
            // ExtractorForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(516, 509);
            this.Controls.Add(this.extractorListControl1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.defaultValueTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ExtractorForm";
            this.Text = "Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.captureNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox defaultValueTextBox;
        private System.Windows.Forms.CheckBox allowMultipleCheckBox;
        private System.Windows.Forms.TextBox patternTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton captureAllRadioButton;
        private System.Windows.Forms.RadioButton captureGroupRadioButton;
        private System.Windows.Forms.NumericUpDown captureNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private ExtractorListControl extractorListControl1;
    }
}