namespace AE_ClusterCrack
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.logTabPage = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.previewTabPage = new System.Windows.Forms.TabPage();
            this.coloringComboBox = new System.Windows.Forms.ComboBox();
            this.coloringLabel = new System.Windows.Forms.Label();
            this.clusterCountLabel = new System.Windows.Forms.Label();
            this.dotCountLabel = new System.Windows.Forms.Label();
            this.dotSizeLabel = new System.Windows.Forms.Label();
            this.dotSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxDataset = new System.Windows.Forms.PictureBox();
            this.timeTrackBar = new System.Windows.Forms.TrackBar();
            this.runTestsButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.radiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.densityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.clusteringComboBox = new System.Windows.Forms.ComboBox();
            this.clusteringLabel = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tabControl.SuspendLayout();
            this.logTabPage.SuspendLayout();
            this.previewTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.logTabPage);
            this.tabControl.Controls.Add(this.previewTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 70);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 704);
            this.tabControl.TabIndex = 0;
            // 
            // logTabPage
            // 
            this.logTabPage.Controls.Add(this.richTextBoxLog);
            this.logTabPage.Location = new System.Drawing.Point(4, 22);
            this.logTabPage.Name = "logTabPage";
            this.logTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.logTabPage.Size = new System.Drawing.Size(768, 678);
            this.logTabPage.TabIndex = 0;
            this.logTabPage.Text = "Log";
            this.logTabPage.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(756, 666);
            this.richTextBoxLog.TabIndex = 1;
            this.richTextBoxLog.Text = "";
            // 
            // previewTabPage
            // 
            this.previewTabPage.Controls.Add(this.coloringComboBox);
            this.previewTabPage.Controls.Add(this.coloringLabel);
            this.previewTabPage.Controls.Add(this.clusterCountLabel);
            this.previewTabPage.Controls.Add(this.dotCountLabel);
            this.previewTabPage.Controls.Add(this.dotSizeLabel);
            this.previewTabPage.Controls.Add(this.dotSizeNumericUpDown);
            this.previewTabPage.Controls.Add(this.pictureBoxDataset);
            this.previewTabPage.Controls.Add(this.timeTrackBar);
            this.previewTabPage.Location = new System.Drawing.Point(4, 22);
            this.previewTabPage.Name = "previewTabPage";
            this.previewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.previewTabPage.Size = new System.Drawing.Size(768, 605);
            this.previewTabPage.TabIndex = 1;
            this.previewTabPage.Text = "Preview";
            this.previewTabPage.UseVisualStyleBackColor = true;
            // 
            // coloringComboBox
            // 
            this.coloringComboBox.FormattingEnabled = true;
            this.coloringComboBox.Location = new System.Drawing.Point(182, 53);
            this.coloringComboBox.Name = "coloringComboBox";
            this.coloringComboBox.Size = new System.Drawing.Size(121, 21);
            this.coloringComboBox.TabIndex = 7;
            this.coloringComboBox.SelectedIndexChanged += new System.EventHandler(this.coloringComboBox_SelectedIndexChanged);
            // 
            // coloringLabel
            // 
            this.coloringLabel.AutoSize = true;
            this.coloringLabel.Location = new System.Drawing.Point(127, 56);
            this.coloringLabel.Name = "coloringLabel";
            this.coloringLabel.Size = new System.Drawing.Size(48, 13);
            this.coloringLabel.TabIndex = 6;
            this.coloringLabel.Text = "Coloring:";
            // 
            // clusterCountLabel
            // 
            this.clusterCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clusterCountLabel.AutoSize = true;
            this.clusterCountLabel.Location = new System.Drawing.Point(120, 589);
            this.clusterCountLabel.Name = "clusterCountLabel";
            this.clusterCountLabel.Size = new System.Drawing.Size(84, 13);
            this.clusterCountLabel.TabIndex = 5;
            this.clusterCountLabel.Text = "Cluster count: -1";
            // 
            // dotCountLabel
            // 
            this.dotCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dotCountLabel.AutoSize = true;
            this.dotCountLabel.Location = new System.Drawing.Point(6, 589);
            this.dotCountLabel.Name = "dotCountLabel";
            this.dotCountLabel.Size = new System.Drawing.Size(69, 13);
            this.dotCountLabel.TabIndex = 4;
            this.dotCountLabel.Text = "Dot count: -1";
            // 
            // dotSizeLabel
            // 
            this.dotSizeLabel.AutoSize = true;
            this.dotSizeLabel.Location = new System.Drawing.Point(6, 56);
            this.dotSizeLabel.Name = "dotSizeLabel";
            this.dotSizeLabel.Size = new System.Drawing.Size(48, 13);
            this.dotSizeLabel.TabIndex = 3;
            this.dotSizeLabel.Text = "Dot size:";
            // 
            // dotSizeNumericUpDown
            // 
            this.dotSizeNumericUpDown.Enabled = false;
            this.dotSizeNumericUpDown.Location = new System.Drawing.Point(60, 54);
            this.dotSizeNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.dotSizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dotSizeNumericUpDown.Name = "dotSizeNumericUpDown";
            this.dotSizeNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.dotSizeNumericUpDown.TabIndex = 2;
            this.dotSizeNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.dotSizeNumericUpDown.ValueChanged += new System.EventHandler(this.dotSizeNumericUpDown_ValueChanged);
            // 
            // pictureBoxDataset
            // 
            this.pictureBoxDataset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDataset.BackColor = System.Drawing.Color.DimGray;
            this.pictureBoxDataset.Location = new System.Drawing.Point(6, 80);
            this.pictureBoxDataset.Name = "pictureBoxDataset";
            this.pictureBoxDataset.Size = new System.Drawing.Size(756, 506);
            this.pictureBoxDataset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDataset.TabIndex = 1;
            this.pictureBoxDataset.TabStop = false;
            // 
            // timeTrackBar
            // 
            this.timeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTrackBar.Enabled = false;
            this.timeTrackBar.Location = new System.Drawing.Point(6, 6);
            this.timeTrackBar.Name = "timeTrackBar";
            this.timeTrackBar.Size = new System.Drawing.Size(756, 45);
            this.timeTrackBar.TabIndex = 0;
            this.timeTrackBar.ValueChanged += new System.EventHandler(this.timeTrackBar_ValueChanged);
            // 
            // runTestsButton
            // 
            this.runTestsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runTestsButton.Location = new System.Drawing.Point(709, 41);
            this.runTestsButton.Name = "runTestsButton";
            this.runTestsButton.Size = new System.Drawing.Size(75, 23);
            this.runTestsButton.TabIndex = 0;
            this.runTestsButton.Text = "Run";
            this.runTestsButton.UseVisualStyleBackColor = true;
            this.runTestsButton.Click += new System.EventHandler(this.runTestsButton_Click);
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(709, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.Enabled = false;
            this.pathTextBox.Location = new System.Drawing.Point(12, 14);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(691, 20);
            this.pathTextBox.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(198, 42);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(43, 13);
            this.radiusLabel.TabIndex = 3;
            this.radiusLabel.Text = "Radius:";
            // 
            // radiusNumericUpDown
            // 
            this.radiusNumericUpDown.Location = new System.Drawing.Point(247, 39);
            this.radiusNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.radiusNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.radiusNumericUpDown.Name = "radiusNumericUpDown";
            this.radiusNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.radiusNumericUpDown.TabIndex = 4;
            this.radiusNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Density:";
            // 
            // densityNumericUpDown
            // 
            this.densityNumericUpDown.Location = new System.Drawing.Point(364, 39);
            this.densityNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.densityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.densityNumericUpDown.Name = "densityNumericUpDown";
            this.densityNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.densityNumericUpDown.TabIndex = 6;
            this.densityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // clusteringComboBox
            // 
            this.clusteringComboBox.FormattingEnabled = true;
            this.clusteringComboBox.Location = new System.Drawing.Point(71, 39);
            this.clusteringComboBox.Name = "clusteringComboBox";
            this.clusteringComboBox.Size = new System.Drawing.Size(121, 21);
            this.clusteringComboBox.TabIndex = 9;
            this.clusteringComboBox.SelectedIndexChanged += new System.EventHandler(this.clusteringComboBox_SelectedIndexChanged);
            // 
            // clusteringLabel
            // 
            this.clusteringLabel.AutoSize = true;
            this.clusteringLabel.Location = new System.Drawing.Point(9, 42);
            this.clusteringLabel.Name = "clusteringLabel";
            this.clusteringLabel.Size = new System.Drawing.Size(56, 13);
            this.clusteringLabel.TabIndex = 8;
            this.clusteringLabel.Text = "Clustering:";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(16, 780);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(768, 23);
            this.progressBar.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 815);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.clusteringComboBox);
            this.Controls.Add(this.densityNumericUpDown);
            this.Controls.Add(this.clusteringLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radiusNumericUpDown);
            this.Controls.Add(this.radiusLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.runTestsButton);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "AE Crack Clusterization";
            this.tabControl.ResumeLayout(false);
            this.logTabPage.ResumeLayout(false);
            this.previewTabPage.ResumeLayout(false);
            this.previewTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dotSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage logTabPage;
        private System.Windows.Forms.TabPage previewTabPage;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TrackBar timeTrackBar;
        private System.Windows.Forms.Button runTestsButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.PictureBox pictureBoxDataset;
        private System.Windows.Forms.Label dotSizeLabel;
        private System.Windows.Forms.NumericUpDown dotSizeNumericUpDown;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.NumericUpDown radiusNumericUpDown;
        private System.Windows.Forms.Label dotCountLabel;
        private System.Windows.Forms.Label clusterCountLabel;
        private System.Windows.Forms.ComboBox coloringComboBox;
        private System.Windows.Forms.Label coloringLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown densityNumericUpDown;
        private System.Windows.Forms.ComboBox clusteringComboBox;
        private System.Windows.Forms.Label clusteringLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

