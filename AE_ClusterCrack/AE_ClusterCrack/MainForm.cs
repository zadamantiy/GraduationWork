using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AE_ClusterCrack.Additional;
using AE_ClusterCrackLib;
using AE_ClusterCrackLib.AeDbscanClustering;
using AE_ClusterCrackLib.AeDistanceClustering;

namespace AE_ClusterCrack
{
    public partial class MainForm : Form
    {
        private AeClusterField _field;
        private AeDbscanClusterField _dbscanField;

        private int _clusterCount = -1;
        //private int _ellipseSize = 1;

        private enum ColorClusterType
        {
            ByGlobalMaxAmount,
            ByCurrentAmount,
            ById
        }

        private enum ClusteringType
        {
            Distance,
            Density
        }

        public MainForm()
        {
            InitializeComponent();

            coloringComboBox.Items.Add("Global max amount");
            coloringComboBox.Items.Add("Current amount");
            coloringComboBox.Items.Add("Cluster id");
            coloringComboBox.SelectedIndex = 0;

            foreach (var type in Enum.GetValues(typeof(ClusteringType)))
                clusteringComboBox.Items.Add(type);
            clusteringComboBox.SelectedIndex = 0;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) 
                return;
            pathTextBox.Text = openFileDialog.FileName;
        }

        private void Log<T>(T s)
        {
            Invoke((MethodInvoker)delegate
            {
                richTextBoxLog.Text += $"[{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00}] {s}\n";
            });
        }

        private void runTestsButton_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private Bitmap GetCurrentBmp(int pointCount, int ellipseSize)
        {
            if (_field == null)
                return null;

            int sizeX = pictureBoxDataset.Width, sizeY = pictureBoxDataset.Height;
            int sizeFieldX = _field.BotRightPoint.X - _field.TopLeftPoint.X, sizeFieldY = _field.BotRightPoint.Y - _field.TopLeftPoint.Y;

            var bmp = new Bitmap(sizeX, sizeY);
            var halfSize = ellipseSize / 2;
                
            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, sizeX, sizeY);
                var list = _field.GetClustersByPointCount(pointCount);

                var clusterMaxNumber = _field.MaxClusterCount - 1;
                if ((ColorClusterType) coloringComboBox.SelectedIndex == ColorClusterType.ByCurrentAmount)
                    clusterMaxNumber = list.Count - 1;

                for (var i = 0; i < list.Count; i++)
                {
                    var cluster = list[i];
                    _clusterCount = list.Count;

                    var clusterI = i;
                    if ((ColorClusterType)coloringComboBox.SelectedIndex == ColorClusterType.ById)
                    {
                        clusterI = cluster.ClusterId;
                        clusterMaxNumber = _field.CurrentClusterId;
                    }

                    var color = Colorer.GetColorByClass(clusterI, clusterMaxNumber);
                    using (var brush = new SolidBrush(color))
                    {
                        foreach (var point in cluster)
                        {
                            //normalizing point
                            var normPoint = new PointF((float) point.X - _field.TopLeftPoint.X, (float) point.Y - _field.TopLeftPoint.Y);
                            normPoint.X = normPoint.X / sizeFieldX * sizeX;
                            normPoint.Y = normPoint.Y / sizeFieldY * sizeY;

                            graphics.FillEllipse(brush, normPoint.X - halfSize, normPoint.Y - halfSize, ellipseSize, ellipseSize);
                        }
                    }
                }
            }

            return bmp;
        }

        private Bitmap GetCurrentDbscanBmp(int pointCount, int ellipseSize)
        {
            if (_dbscanField == null)
                return null;

            int sizeX = pictureBoxDataset.Width, sizeY = pictureBoxDataset.Height;
            int sizeFieldX = _dbscanField.BotRightPoint.X - _dbscanField.TopLeftPoint.X, sizeFieldY = _dbscanField.BotRightPoint.Y - _dbscanField.TopLeftPoint.Y;

            var bmp = new Bitmap(sizeX, sizeY);
            var halfSize = ellipseSize / 2;
            _clusterCount = 0;

            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, sizeX, sizeY);
                var list = _dbscanField.GetClustersByPointCount(pointCount, out var unclusterized);
                
                var clusterMaxNumber = _dbscanField.MaxClusterCount - 1;
                if ((ColorClusterType)coloringComboBox.SelectedIndex == ColorClusterType.ByCurrentAmount)
                    clusterMaxNumber = list.Count - 1;

                for (var i = 0; i < list.Count; i++)
                {
                    var cluster = list[i];
                    _clusterCount = list.Count;

                    var clusterI = i;
                    if ((ColorClusterType)coloringComboBox.SelectedIndex == ColorClusterType.ById)
                    {
                        clusterI = cluster.ClusterId;
                        clusterMaxNumber = _dbscanField.CurrentClusterId;
                    }

                    var color = Colorer.GetColorByClass(clusterI, clusterMaxNumber);
                    using (var brush = new SolidBrush(color))
                    {
                        foreach (var point in cluster)
                        {
                            var normPoint = new PointF((float)point.X - _dbscanField.TopLeftPoint.X, (float)point.Y - _dbscanField.TopLeftPoint.Y);
                            normPoint.X = normPoint.X / sizeFieldX * sizeX;
                            normPoint.Y = normPoint.Y / sizeFieldY * sizeY;

                            graphics.FillEllipse(brush, normPoint.X - halfSize, normPoint.Y - halfSize, ellipseSize, ellipseSize);
                        }
                    }
                }

                var noClusterColor = Color.LightGray;
                using (var brush = new SolidBrush(noClusterColor))
                {
                    foreach (var point in unclusterized)
                    {
                        var normPoint = new PointF((float)point.X - _dbscanField.TopLeftPoint.X, (float)point.Y - _dbscanField.TopLeftPoint.Y);
                        normPoint.X = normPoint.X / sizeFieldX * sizeX;
                        normPoint.Y = normPoint.Y / sizeFieldY * sizeY;

                        graphics.FillEllipse(brush, normPoint.X - halfSize, normPoint.Y - halfSize, ellipseSize, ellipseSize);
                    }
                }
            }

            return bmp;
        }

        private void UpdatePreview()
        {
            if (clusteringComboBox.SelectedItem == null)
                return;
            if ((ClusteringType) clusteringComboBox.SelectedItem == ClusteringType.Distance)
                UpdateDistancePreview();
            else
                UpdateDbscanPreview();
        }

        private void UpdateDistancePreview()
        {
            var bmp = GetCurrentBmp(timeTrackBar.Value, (int)dotSizeNumericUpDown.Value);
            pictureBoxDataset.Image = bmp;
            pictureBoxDataset.Invalidate();

            dotCountLabel.Text = "Dot count: " + timeTrackBar.Value;
            clusterCountLabel.Text = "Cluster count: " + _clusterCount;
        }

        private void UpdateDbscanPreview()
        {
            var bmp = GetCurrentDbscanBmp(timeTrackBar.Value, (int)dotSizeNumericUpDown.Value);
            pictureBoxDataset.Image = bmp;
            pictureBoxDataset.Invalidate();

            dotCountLabel.Text = "Dot count: " + timeTrackBar.Value;
            clusterCountLabel.Text = "Cluster count: " + _clusterCount;
        }

        private void timeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void dotSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void coloringComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void clusteringComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            densityNumericUpDown.Enabled = (ClusteringType)clusteringComboBox.SelectedItem != ClusteringType.Distance;
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();
            if (!File.Exists(pathTextBox.Text))
                return;

            var isDistance = false;
            Invoke((MethodInvoker) delegate
            {
                isDistance = (ClusteringType) clusteringComboBox.SelectedItem == ClusteringType.Distance;
            });

            var sr = new StreamReader(pathTextBox.Text);
            _field = new AeClusterField((int)radiusNumericUpDown.Value);
            _dbscanField = new AeDbscanClusterField((int)radiusNumericUpDown.Value, (int)densityNumericUpDown.Value);

            try
            {
                //Getting string count
                var lineCount = File.ReadLines(pathTextBox.Text).Count();
                var curAmount = 0;

                var reportPeriod = lineCount / 99;
                if (reportPeriod == 0)
                    reportPeriod = 1;

                if (isDistance)
                {
                    while (!sr.EndOfStream)
                    {
                        var newPair =
                            Array.ConvertAll(
                                sr.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) ??
                                throw new InvalidOperationException(),
                                s => Convert.ToDouble(s, CultureInfo.InvariantCulture));
                        _field.AddPoint(new AePoint(newPair[0], newPair[1]));
                        curAmount++;

                        if (curAmount % reportPeriod == 0)
                        {
                            backgroundWorker.ReportProgress(curAmount / reportPeriod);
                        }
                    }
                }
                else
                {
                    while (!sr.EndOfStream)
                    {
                        var newPair =
                            Array.ConvertAll(
                                sr.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) ??
                                throw new InvalidOperationException(),
                                s => Convert.ToDouble(s, CultureInfo.InvariantCulture));
                        _dbscanField.AddPoint(new AeDbscanBasePoint(newPair[0], newPair[1], _dbscanField.PointCount + 1));
                        curAmount++;

                        if (curAmount % reportPeriod == 0)
                        {
                            backgroundWorker.ReportProgress(curAmount / reportPeriod);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Invoke((MethodInvoker) delegate
                {
                    _field = null;
                    timeTrackBar.Enabled = false;
                    dotSizeNumericUpDown.Enabled = false;
                    MessageBox.Show("Wrong file format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log("Error: " + exception.Message);
                });
                return;
            }
            
            var tmpPointCount = isDistance ? _field.PointCount : _dbscanField.PointCount;
            Invoke((MethodInvoker) delegate
            {
                Log($"File \"{pathTextBox.Text}\" successfully proceeded.");

                if (tmpPointCount > 0)
                {
                    timeTrackBar.Minimum = 1;
                    timeTrackBar.Maximum = tmpPointCount;
                    timeTrackBar.Enabled = true;
                    dotSizeNumericUpDown.Enabled = true;
                }
                else
                {
                    timeTrackBar.Minimum = 0;
                    timeTrackBar.Maximum = 0;
                    timeTrackBar.Enabled = false;
                    dotSizeNumericUpDown.Enabled = false;
                }

                timeTrackBar.Value = timeTrackBar.Maximum;
            });

            sw.Stop();
            Invoke((MethodInvoker) delegate
            {
                Log($"Points clusterized: {tmpPointCount}");
                Log($"Time elapsed: {sw.ElapsedMilliseconds}ms");
                UpdatePreview();
            });

            backgroundWorker.ReportProgress(100);

        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
