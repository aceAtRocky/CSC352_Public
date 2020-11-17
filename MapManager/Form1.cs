namespace MapManager
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {

        Bitmap renderedMap = null;
        Bitmap overlayImage = null;
        Bitmap combinedImage = null;
        Point overlayLocation = new Point();
        bool IsEditingImage = false;
        bool IsModifyingLayer = false;
        int editingLayerIndex = -1;

        int overlayScale = 100;
        Bitmap originalOverlayImage = null;

        BindingList<Layer> layers = new BindingList<Layer>();

        decimal scalex;
        decimal scaley;


        public Form1()
        {
            InitializeComponent();
            layers.Add(new Layer() { Name = "Base", FileName = null, Current = new Bitmap(mapPictureBox.Image), Location = new Point(0, 0) });

            renderedMap = RenderLayers();
            mapPictureBox.Image = renderedMap;

            mapPictureBox_Resize(this, new EventArgs());

            // Bind the ComboBox to our Layers Structure
            BindingSource layersBindingSource = new BindingSource();
            layersBindingSource.DataSource = layers;
            layerSelectionComboBox.DataSource = layersBindingSource.DataSource;
            layerSelectionComboBox.DisplayMember = "Name";
            layerSelectionComboBox.ValueMember = "Current";

            // Bind the Mouse Wheel Events
            MouseWheel += Form1_MouseWheel;
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (IsEditingImage)
            {
                if (originalOverlayImage == null)
                {
                    originalOverlayImage = new Bitmap(overlayImage);
                }

                debugStatus.Text = $"Is in Edit Mode: {e.Delta} and Overlay Scale is {overlayScale}";

                int increaseScaleBy = 1;

                if (Control.ModifierKeys == Keys.Shift)
                {
                    increaseScaleBy = 10;
                }

                if (e.Delta > 1)
                {
                    // If Positive, Grow the Image
                    overlayScale = overlayScale + increaseScaleBy;
                }
                else
                {
                    // Negative, Shrink the Image
                    if (overlayScale - increaseScaleBy > 1)
                    {
                        overlayScale = overlayScale - increaseScaleBy;
                    }
                }

                double scale = overlayScale * .01;
                Size scaledSize = Renderer.Scale(originalOverlayImage.Size, scale);

                scaledImageLabel.Text = scaledSize.ToString();


                Bitmap scaledBitmap = new Bitmap(originalOverlayImage, scaledSize);

                overlayImage.Dispose();
                overlayImage = null;
                overlayImage = scaledBitmap;
            }
            else
            {
                debugStatus.Text = $"Is not in edit mode: {e.Delta}";
            }
        }

        private Bitmap RenderLayers()
        {
            return Renderer.RenderLayers(layers, mapPictureBox.Image.Width, mapPictureBox.Image.Height);
        }

        private void assetPictureBox_Click(object sender, EventArgs e)
        {
            overlayImage = new Bitmap(assetPictureBox.Image);
            mapPictureBox.Cursor = Cursors.Cross;
            IsEditingImage = true;
        }

        private void ShowCombinedImage()
        {
            if (renderedMap == null && overlayImage == null)
            {
                return;
            }

            mapPictureBox.Image = renderedMap;

            if (combinedImage != null)
            {
                combinedImage.Dispose();
                combinedImage = null;
            }

            combinedImage = new Bitmap(renderedMap);

            using (Graphics combiner = Graphics.FromImage(combinedImage))
            {
                combiner.DrawImage(overlayImage, overlayLocation);
            }

            mapPictureBox.Image = combinedImage;
        }


        private void mapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (overlayImage == null)
            {
                return;
            }

            overlayLocation = new Point(
                (int)(e.X * scalex) - overlayImage.Width / 2,
                (int)(e.Y * scaley) - overlayImage.Height / 2);

            if (IsModifyingLayer)
            {
                layers[editingLayerIndex].Location = overlayLocation;
                layers[editingLayerIndex].Current.Dispose();
                layers[editingLayerIndex].Current = new Bitmap(overlayImage);
                layers[editingLayerIndex].ShouldRender = true;
                Image previousImage = mapPictureBox.Image;
                mapPictureBox.Image = RenderLayers();
                previousImage.Dispose();
                layers[editingLayerIndex].ShouldRender = false;
            }
            else
            {
                ShowCombinedImage();
            }

            mousePosActual.Text = $"MousePosActual - X: {e.X}, Y: {e.Y}";
            mousePosScaled.Text = $"MousePosScaled - X: {overlayLocation.X}, Y: {overlayLocation.Y}";
        }

        private void mapPictureBox_Resize(object sender, EventArgs e)
        {
            scalex = Decimal.Divide(renderedMap.Width, mapPictureBox.Width);
            scaley = Decimal.Divide(renderedMap.Height, mapPictureBox.Height);
        }

        private void mapPictureBox_Click(object sender, EventArgs e)
        {
            if (overlayImage == null)
            {
                return;
            }

            if (IsModifyingLayer)
            {
                layers[editingLayerIndex].ShouldRender = true;
                editingLayerIndex = -1;
                IsModifyingLayer = false;
            }
            else
            {
                layers.Add(new Layer() { Current = new Bitmap(overlayImage), FileName = string.Empty, Location = overlayLocation });
            }

            mapPictureBox.Cursor = Cursors.Default;
            overlayImage.Dispose();
            overlayImage = null;

            renderedMap = RenderLayers();
            mapPictureBox.Image = renderedMap;
            overlayScale = 100;

            originalOverlayImage?.Dispose();
            originalOverlayImage = null;

            IsEditingImage = false;
        }

        private void layerSelectionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (layerSelectionComboBox.SelectedValue is Bitmap)
            {
                layerPreviewPictureBox.Image = layerSelectionComboBox.SelectedValue as Bitmap;
            }
            else if (layerSelectionComboBox.SelectedValue is Layer)
            {
                layerPreviewPictureBox.Image = (layerSelectionComboBox.SelectedValue as Layer).Current;
            }
            else
            {
                // Do Nothing
            }
        }

        private void editLayerButton_Click(object sender, EventArgs e)
        {
            overlayImage = new Bitmap(layerSelectionComboBox.SelectedValue as Bitmap);
            editingLayerIndex = layerSelectionComboBox.SelectedIndex;
            layers[editingLayerIndex].ShouldRender = false;
            renderedMap = RenderLayers();
            mapPictureBox.Cursor = Cursors.Cross;
            IsEditingImage = true;
            IsModifyingLayer = true;
        }
    }
}
