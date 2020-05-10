namespace AE_Analyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadFile = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.tabPreview = new System.Windows.Forms.TabPage();
            this.renderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBoxDataset = new System.Windows.Forms.PictureBox();
            this.buttonPosReset = new System.Windows.Forms.Button();
            this.tapPageSettings = new System.Windows.Forms.TabPage();
            this.shipTwoSettings = new System.Windows.Forms.Button();
            this.shipOneButton = new System.Windows.Forms.Button();
            this.analyzeSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.hyperparamsGroupBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.verMultiplierTextBox = new System.Windows.Forms.TextBox();
            this.horMultiplierTextBox = new System.Windows.Forms.TextBox();
            this.maxDistanceTextBox = new System.Windows.Forms.TextBox();
            this.maxUnionDistanceLabel = new System.Windows.Forms.Label();
            this.dbscanGroupBox = new System.Windows.Forms.GroupBox();
            this.minSamplesTextBox = new System.Windows.Forms.TextBox();
            this.minSamplesLabel = new System.Windows.Forms.Label();
            this.epsilonLabel = new System.Windows.Forms.Label();
            this.epsilonTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.clusterizeButton = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDataset)).BeginInit();
            this.tapPageSettings.SuspendLayout();
            this.analyzeSettingsGroupBox.SuspendLayout();
            this.hyperparamsGroupBox.SuspendLayout();
            this.dbscanGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadFile.Location = new System.Drawing.Point(516, 12);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFile.TabIndex = 0;
            this.buttonLoadFile.Text = "Load File";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Controls.Add(this.tabPreview);
            this.tabControl.Controls.Add(this.tapPageSettings);
            this.tabControl.Location = new System.Drawing.Point(12, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(660, 508);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.richTextBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(652, 482);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(640, 473);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // tabPreview
            // 
            this.tabPreview.Controls.Add(this.renderTypeComboBox);
            this.tabPreview.Controls.Add(this.pictureBoxDataset);
            this.tabPreview.Controls.Add(this.buttonPosReset);
            this.tabPreview.Location = new System.Drawing.Point(4, 22);
            this.tabPreview.Name = "tabPreview";
            this.tabPreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPreview.Size = new System.Drawing.Size(652, 482);
            this.tabPreview.TabIndex = 0;
            this.tabPreview.Text = "Preview";
            this.tabPreview.UseVisualStyleBackColor = true;
            this.tabPreview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.tabPreview_Scroll);
            // 
            // renderTypeComboBox
            // 
            this.renderTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.renderTypeComboBox.FormattingEnabled = true;
            this.renderTypeComboBox.Location = new System.Drawing.Point(444, 8);
            this.renderTypeComboBox.Name = "renderTypeComboBox";
            this.renderTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.renderTypeComboBox.TabIndex = 3;
            this.renderTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.renderTypeComboBox_SelectedIndexChanged);
            // 
            // pictureBoxDataset
            // 
            this.pictureBoxDataset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDataset.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxDataset.Location = new System.Drawing.Point(6, 35);
            this.pictureBoxDataset.Name = "pictureBoxDataset";
            this.pictureBoxDataset.Size = new System.Drawing.Size(640, 444);
            this.pictureBoxDataset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDataset.TabIndex = 0;
            this.pictureBoxDataset.TabStop = false;
            this.pictureBoxDataset.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxDataset_Paint);
            this.pictureBoxDataset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDataset_MouseDown);
            this.pictureBoxDataset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDataset_MouseMove);
            this.pictureBoxDataset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxDataset_MouseUp);
            this.pictureBoxDataset.Resize += new System.EventHandler(this.pictureBoxDataset_Resize);
            // 
            // buttonPosReset
            // 
            this.buttonPosReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPosReset.Location = new System.Drawing.Point(571, 6);
            this.buttonPosReset.Name = "buttonPosReset";
            this.buttonPosReset.Size = new System.Drawing.Size(75, 23);
            this.buttonPosReset.TabIndex = 1;
            this.buttonPosReset.Text = "Reset pos";
            this.buttonPosReset.UseVisualStyleBackColor = true;
            this.buttonPosReset.Click += new System.EventHandler(this.buttonPosReset_Click);
            // 
            // tapPageSettings
            // 
            this.tapPageSettings.Controls.Add(this.shipTwoSettings);
            this.tapPageSettings.Controls.Add(this.shipOneButton);
            this.tapPageSettings.Controls.Add(this.analyzeSettingsGroupBox);
            this.tapPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tapPageSettings.Name = "tapPageSettings";
            this.tapPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tapPageSettings.Size = new System.Drawing.Size(652, 482);
            this.tapPageSettings.TabIndex = 2;
            this.tapPageSettings.Text = "Settings";
            this.tapPageSettings.UseVisualStyleBackColor = true;
            // 
            // shipTwoSettings
            // 
            this.shipTwoSettings.Location = new System.Drawing.Point(130, 6);
            this.shipTwoSettings.Name = "shipTwoSettings";
            this.shipTwoSettings.Size = new System.Drawing.Size(116, 23);
            this.shipTwoSettings.TabIndex = 11;
            this.shipTwoSettings.Text = "Set \"Ship 2\" Settings";
            this.shipTwoSettings.UseVisualStyleBackColor = true;
            this.shipTwoSettings.Click += new System.EventHandler(this.shipTwoSettings_Click);
            // 
            // shipOneButton
            // 
            this.shipOneButton.Location = new System.Drawing.Point(9, 6);
            this.shipOneButton.Name = "shipOneButton";
            this.shipOneButton.Size = new System.Drawing.Size(115, 23);
            this.shipOneButton.TabIndex = 10;
            this.shipOneButton.Text = "Set \"Ship 1\" Settings";
            this.shipOneButton.UseVisualStyleBackColor = true;
            this.shipOneButton.Click += new System.EventHandler(this.shipOneButton_Click);
            // 
            // analyzeSettingsGroupBox
            // 
            this.analyzeSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.analyzeSettingsGroupBox.Controls.Add(this.hyperparamsGroupBox);
            this.analyzeSettingsGroupBox.Controls.Add(this.dbscanGroupBox);
            this.analyzeSettingsGroupBox.Location = new System.Drawing.Point(3, 35);
            this.analyzeSettingsGroupBox.Name = "analyzeSettingsGroupBox";
            this.analyzeSettingsGroupBox.Size = new System.Drawing.Size(640, 441);
            this.analyzeSettingsGroupBox.TabIndex = 9;
            this.analyzeSettingsGroupBox.TabStop = false;
            this.analyzeSettingsGroupBox.Text = "Analysis settings";
            // 
            // hyperparamsGroupBox
            // 
            this.hyperparamsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hyperparamsGroupBox.Controls.Add(this.label2);
            this.hyperparamsGroupBox.Controls.Add(this.label1);
            this.hyperparamsGroupBox.Controls.Add(this.verMultiplierTextBox);
            this.hyperparamsGroupBox.Controls.Add(this.horMultiplierTextBox);
            this.hyperparamsGroupBox.Controls.Add(this.maxDistanceTextBox);
            this.hyperparamsGroupBox.Controls.Add(this.maxUnionDistanceLabel);
            this.hyperparamsGroupBox.Location = new System.Drawing.Point(6, 81);
            this.hyperparamsGroupBox.Name = "hyperparamsGroupBox";
            this.hyperparamsGroupBox.Size = new System.Drawing.Size(628, 61);
            this.hyperparamsGroupBox.TabIndex = 7;
            this.hyperparamsGroupBox.TabStop = false;
            this.hyperparamsGroupBox.Text = "Hyperparamethers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Vertical Multiplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Horizontal Multiplier";
            // 
            // verMultiplierTextBox
            // 
            this.verMultiplierTextBox.Location = new System.Drawing.Point(519, 29);
            this.verMultiplierTextBox.Name = "verMultiplierTextBox";
            this.verMultiplierTextBox.Size = new System.Drawing.Size(100, 20);
            this.verMultiplierTextBox.TabIndex = 10;
            this.verMultiplierTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.verMultiplierTextBox_KeyPress);
            // 
            // horMultiplierTextBox
            // 
            this.horMultiplierTextBox.Location = new System.Drawing.Point(321, 29);
            this.horMultiplierTextBox.Name = "horMultiplierTextBox";
            this.horMultiplierTextBox.Size = new System.Drawing.Size(100, 20);
            this.horMultiplierTextBox.TabIndex = 9;
            this.horMultiplierTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.horMultiplierTextBox_KeyPress);
            // 
            // maxDistanceTextBox
            // 
            this.maxDistanceTextBox.Location = new System.Drawing.Point(111, 29);
            this.maxDistanceTextBox.Name = "maxDistanceTextBox";
            this.maxDistanceTextBox.Size = new System.Drawing.Size(100, 20);
            this.maxDistanceTextBox.TabIndex = 8;
            this.maxDistanceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maxDistanceTextBox_KeyPress);
            // 
            // maxUnionDistanceLabel
            // 
            this.maxUnionDistanceLabel.AutoSize = true;
            this.maxUnionDistanceLabel.Location = new System.Drawing.Point(6, 32);
            this.maxUnionDistanceLabel.Name = "maxUnionDistanceLabel";
            this.maxUnionDistanceLabel.Size = new System.Drawing.Size(99, 13);
            this.maxUnionDistanceLabel.TabIndex = 0;
            this.maxUnionDistanceLabel.Text = "Max union distance";
            // 
            // dbscanGroupBox
            // 
            this.dbscanGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbscanGroupBox.Controls.Add(this.minSamplesTextBox);
            this.dbscanGroupBox.Controls.Add(this.minSamplesLabel);
            this.dbscanGroupBox.Controls.Add(this.epsilonLabel);
            this.dbscanGroupBox.Controls.Add(this.epsilonTextBox);
            this.dbscanGroupBox.Location = new System.Drawing.Point(6, 19);
            this.dbscanGroupBox.Name = "dbscanGroupBox";
            this.dbscanGroupBox.Size = new System.Drawing.Size(628, 56);
            this.dbscanGroupBox.TabIndex = 6;
            this.dbscanGroupBox.TabStop = false;
            this.dbscanGroupBox.Text = "DBSCAN";
            // 
            // minSamplesTextBox
            // 
            this.minSamplesTextBox.Location = new System.Drawing.Point(232, 23);
            this.minSamplesTextBox.Name = "minSamplesTextBox";
            this.minSamplesTextBox.Size = new System.Drawing.Size(100, 20);
            this.minSamplesTextBox.TabIndex = 7;
            this.minSamplesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.minSamplesTextBox_KeyPress);
            // 
            // minSamplesLabel
            // 
            this.minSamplesLabel.AutoSize = true;
            this.minSamplesLabel.Location = new System.Drawing.Point(159, 26);
            this.minSamplesLabel.Name = "minSamplesLabel";
            this.minSamplesLabel.Size = new System.Drawing.Size(67, 13);
            this.minSamplesLabel.TabIndex = 6;
            this.minSamplesLabel.Text = "Min Samples";
            // 
            // epsilonLabel
            // 
            this.epsilonLabel.AutoSize = true;
            this.epsilonLabel.Location = new System.Drawing.Point(6, 26);
            this.epsilonLabel.Name = "epsilonLabel";
            this.epsilonLabel.Size = new System.Drawing.Size(41, 13);
            this.epsilonLabel.TabIndex = 3;
            this.epsilonLabel.Text = "Epsilon";
            // 
            // epsilonTextBox
            // 
            this.epsilonTextBox.Location = new System.Drawing.Point(53, 23);
            this.epsilonTextBox.Name = "epsilonTextBox";
            this.epsilonTextBox.Size = new System.Drawing.Size(100, 20);
            this.epsilonTextBox.TabIndex = 5;
            this.epsilonTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.epsilonTextBox_KeyPress);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameTextBox.Enabled = false;
            this.fileNameTextBox.Location = new System.Drawing.Point(16, 14);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(494, 20);
            this.fileNameTextBox.TabIndex = 2;
            // 
            // clusterizeButton
            // 
            this.clusterizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clusterizeButton.Location = new System.Drawing.Point(597, 12);
            this.clusterizeButton.Name = "clusterizeButton";
            this.clusterizeButton.Size = new System.Drawing.Size(75, 23);
            this.clusterizeButton.TabIndex = 4;
            this.clusterizeButton.Text = "Clusterize";
            this.clusterizeButton.UseVisualStyleBackColor = true;
            this.clusterizeButton.Click += new System.EventHandler(this.clusterizeButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.clusterizeButton);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonLoadFile);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "MainForm";
            this.Text = "AE Analyzer";
            this.tabControl.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDataset)).EndInit();
            this.tapPageSettings.ResumeLayout(false);
            this.analyzeSettingsGroupBox.ResumeLayout(false);
            this.hyperparamsGroupBox.ResumeLayout(false);
            this.hyperparamsGroupBox.PerformLayout();
            this.dbscanGroupBox.ResumeLayout(false);
            this.dbscanGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadFile;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPreview;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.PictureBox pictureBoxDataset;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonPosReset;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Label epsilonLabel;
        private System.Windows.Forms.Button clusterizeButton;
        private System.Windows.Forms.ComboBox renderTypeComboBox;
        private System.Windows.Forms.TextBox epsilonTextBox;
        private System.Windows.Forms.TabPage tapPageSettings;
        private System.Windows.Forms.GroupBox dbscanGroupBox;
        private System.Windows.Forms.Label minSamplesLabel;
        private System.Windows.Forms.TextBox minSamplesTextBox;
        private System.Windows.Forms.GroupBox analyzeSettingsGroupBox;
        private System.Windows.Forms.GroupBox hyperparamsGroupBox;
        private System.Windows.Forms.Label maxUnionDistanceLabel;
        private System.Windows.Forms.TextBox maxDistanceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox verMultiplierTextBox;
        private System.Windows.Forms.TextBox horMultiplierTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button shipTwoSettings;
        private System.Windows.Forms.Button shipOneButton;
    }
}

