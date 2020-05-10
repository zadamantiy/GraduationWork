using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AE_Library;
using AE_Library.AE;

namespace AE_Analyzer
{
    public partial class MainForm : Form
    {
        private readonly AE_Library.AE.Dataset _dataset;
        private Image _curImage;

        private Image _dataImage;
        private Image _clusterImage;
        private Image _defectImage;

        private Point startMousePos;

        private WeldingParams _wp = new WeldingParams(2.4, 2.4, 34);

        private enum RenderType
        {
            Data,
            Clusters,
            Defects
        }

        //
        // Image Preview
        //
        private int _multiplier = 5;
        private PointF _imagePos = new Point(0, 0);

        public MainForm()
        {
            InitializeComponent();
            _dataset = new Dataset();
            _curImage = null;

            //Adding render types
            foreach (var type in Enum.GetValues(typeof(RenderType)))
                renderTypeComboBox.Items.Add(type);
            renderTypeComboBox.SelectedIndex = 0;

            //TODO: change on loading last
            //Settings for first ship
            horMultiplierTextBox.Text = "2.4";
            verMultiplierTextBox.Text = "2.5";
            maxDistanceTextBox.Text = "34";
            epsilonTextBox.Text = "5.01";
            minSamplesTextBox.Text = "20";

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        private void ResetPicture()
        {
            _imagePos = new PointF(0, 0);
            _multiplier = Math.Max(Math.Min(pictureBoxDataset.Height / _curImage.Height, pictureBoxDataset.Width / _curImage.Width), 1);
            pictureBoxDataset.Invalidate();
        }

        private void LoadFile()
        {
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            var sw = new Stopwatch();
            sw.Start();
            _dataset.LoadWeldingFromFile(openFileDialog.FileName);
            sw.Stop();
            Log($"Source number: {_dataset.Data.Count}");
            Log($"File {openFileDialog.FileName} loaded. {sw.ElapsedMilliseconds}ms elapsed.");
            fileNameTextBox.Text = openFileDialog.FileName;

            _curImage = _dataset.GetBitmap();
            _dataImage = _curImage;

            _clusterImage = null;
            _defectImage = null;

            //TODO: on load use Get Scaled one
            ResetPicture();
        }

        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void pictureBoxDataset_Resize(object sender, EventArgs e)
        {
            //pictureBox1.Invalidate();
        }

        private void pictureBoxDataset_Paint(object sender, PaintEventArgs e)
        {
            if (_curImage == null)
                return;

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            //e.Graphics.DrawImage(_curImage, GetScaledImageRect(_curImage, (Control) sender));

            var z = new RectangleF(0, 0, _curImage.Width * _multiplier, _curImage.Height * _multiplier);

            z.X += _imagePos.X;
            z.Y += _imagePos.Y;

            e.Graphics.DrawImage(_curImage, z);
        }

        private RectangleF GetScaledImageRect(Image image, Control canvas)
        {
            return GetScaledImageRect(image, canvas.ClientSize);
        }

        private RectangleF GetScaledImageRect(Image image, SizeF containerSize)
        {
            var imgRect = System.Drawing.RectangleF.Empty;
            var scaleFactor = Convert.ToSingle(image.Width / image.Height);
            var containerRatio = containerSize.Width / containerSize.Height;

            if (containerRatio >= scaleFactor)
            {
                imgRect.Size = new SizeF(containerSize.Height * scaleFactor, containerSize.Height);
                imgRect.Location = new PointF((containerSize.Width - imgRect.Width) / 2, 0);
            }
            else
            {
                imgRect.Size = new SizeF(containerSize.Width, containerSize.Width / scaleFactor);
                imgRect.Location = new PointF(0, (containerSize.Height - imgRect.Height) / 2);
            }

            imgRect.Location = containerRatio >= scaleFactor ? new PointF((containerSize.Width - imgRect.Width) / 2, 0) : new PointF(0, (containerSize.Height - imgRect.Height) / 2);

            return imgRect;
        }

        private void tabPreview_Scroll(object sender, ScrollEventArgs e)
        {
            var delta = e.NewValue - e.OldValue;
            _multiplier += delta;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            // Do not use MouseEventArgs.X, Y because they are relative!
            var ptMouseAbs = MousePosition;
            Control iCtrl = pictureBoxDataset;
            do
            {
                var rCtrl = iCtrl.RectangleToScreen(iCtrl.ClientRectangle);
                if (!rCtrl.Contains(ptMouseAbs))
                {
                    base.OnMouseWheel(e);
                    return; // mouse position is outside the picturebox or it's parents
                }
                iCtrl = iCtrl.Parent;
            }
            while (iCtrl != null && iCtrl != this);

            var ptMouseRel = pictureBoxDataset.PointToClient(ptMouseAbs);

            var delta = e.Delta / SystemInformation.MouseWheelScrollDelta;

            if (_multiplier > 1 && delta < 0 || delta > 0 && _multiplier < 30)
            {
                var tmpMultiplier = _multiplier + delta;
                var multiplierChange = (float) tmpMultiplier / _multiplier;
                _imagePos.X = ptMouseRel.X - (ptMouseRel.X - _imagePos.X) * multiplierChange;
                _imagePos.Y = ptMouseRel.Y - (ptMouseRel.Y - _imagePos.Y) * multiplierChange;
                _multiplier += delta;
                pictureBoxDataset.Invalidate();
            }
        }


        private bool _mouseDown;
        private void pictureBoxDataset_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            startMousePos = pictureBoxDataset.PointToClient(MousePosition);
        }

        private void pictureBoxDataset_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseDown) return;

            var mousePos = pictureBoxDataset.PointToClient(MousePosition);
            _imagePos.X += mousePos.X - startMousePos.X;
            _imagePos.Y += mousePos.Y - startMousePos.Y;
            startMousePos = mousePos;
            pictureBoxDataset.Invalidate();
        }

        private void pictureBoxDataset_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void buttonPosReset_Click(object sender, EventArgs e)
        {
            ResetPicture();
        }

        private void Log<T>(T s)
        {
            Invoke((MethodInvoker)delegate
            {
                richTextBoxLog.Text += $"[{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00}] {s}\n";
            });
        }

        private void clusterizeButton_Click(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();

            _wp.HorCoef = double.Parse(horMultiplierTextBox.Text);
            _wp.VerCoef = double.Parse(verMultiplierTextBox.Text);
            _wp.MaxDistanceBetweenDefects = int.Parse(maxDistanceTextBox.Text);

            AeAnalyzer.AnalyzeWelding(_dataset, double.Parse(epsilonTextBox.Text), int.Parse(minSamplesTextBox.Text), _wp);

            sw.Stop();
            Log($"Analysis proceeded. {sw.ElapsedMilliseconds}ms elapsed.");

            _clusterImage = _dataset.GetClassBitmap();
            _defectImage = _dataset.GetAnalysisBitmap();

            switch ((RenderType) renderTypeComboBox.SelectedItem)
            {
                case RenderType.Data:
                    _curImage = _dataImage;
                    break;
                case RenderType.Clusters:
                    _curImage = _clusterImage;
                    break;
                case RenderType.Defects:
                    _curImage = _defectImage;
                    break;
            }

            Log("Defects:");
            for (var i = 0; i < _dataset.Defects.Count; i++)
            {
                var defect = _dataset.Defects[i];
                Log($"> Defect #{i+1}: [{defect.Item1}, {defect.Item2}]");
            }

            pictureBoxDataset.Invalidate();
        }

        private void epsilonTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' 
                || e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void minSamplesTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maxDistanceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.'
                || e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void horMultiplierTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.'
                || e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void verMultiplierTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.'
                || e.KeyChar == '.' && ((TextBox)sender).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void renderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var renderType = (RenderType)renderTypeComboBox.SelectedItem;
            switch (renderType)
            {
                case RenderType.Data:
                    _curImage = _dataImage;
                    break;
                case RenderType.Clusters:
                    if (_clusterImage != null)
                        _curImage = _clusterImage;
                    else
                    {
                        renderTypeComboBox.SelectedIndex = 0;
                        MessageBox.Show("No data clusterize. Run clusterization first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case RenderType.Defects:
                    if (_defectImage != null)
                        _curImage = _defectImage;
                    else
                    {
                        renderTypeComboBox.SelectedIndex = 0;
                        MessageBox.Show("No analyzed data. Run analysis first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
            }
            pictureBoxDataset.Invalidate();
        }

        private void shipOneButton_Click(object sender, EventArgs e)
        {
            horMultiplierTextBox.Text = "2.4";
            verMultiplierTextBox.Text = "2.5";
            maxDistanceTextBox.Text = "34";
            epsilonTextBox.Text = "5.01";
            minSamplesTextBox.Text = "20";
        }

        private void shipTwoSettings_Click(object sender, EventArgs e)
        {
            horMultiplierTextBox.Text = "2.4";
            verMultiplierTextBox.Text = "2.5";
            maxDistanceTextBox.Text = "34";
            epsilonTextBox.Text = "5.01";
            minSamplesTextBox.Text = "75";
        }
    }
}
