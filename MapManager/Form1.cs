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

        int overlayScale = 0;
        Bitmap originalOverlayImage = null;

        BindingList<Layer> layers = new BindingList<Layer>();

        decimal scalex;
        decimal scaley;


        public Form1()
        {
            InitializeComponent();
            layers.Add(new Layer() { FileName = "", Current = new Bitmap(mapPictureBox.Image), Location = new Point(0, 0) });

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

                if (e.Delta > 1)
                {
                    // If Positive, Grow the Image
                    overlayScale++;
                }
                else
                {
                    // Negative, Shrink the Image
                    overlayScale--;
                }

                double scale = overlayScale * .1;
                Size scaledSize = new Size((int)(originalOverlayImage.Width * scale), (int)(originalOverlayImage.Height * scale));

                scaledImageLabel.Text = scaledSize.ToString();


                Bitmap resized = new Bitmap(originalOverlayImage, scaledSize);

                overlayImage.Dispose();
                overlayImage = null;
                overlayImage = resized;

                //var brush = new SolidBrush(Color.White);

                //var scaleWidth = (int)(overlayImage.Width * scale);
                //var scaleHeight = (int)(overlayImage.Height * scale);
                //var scaledBitmap = new Bitmap(scaleWidth, scaleHeight);

                //Graphics graph = Graphics.FromImage(scaledBitmap);
                //graph.InterpolationMode = InterpolationMode.High;
                //graph.CompositingQuality = CompositingQuality.HighQuality;
                //graph.SmoothingMode = SmoothingMode.AntiAlias;
                //graph.FillRectangle(brush, new RectangleF(0, 0, mapPictureBox.Image.Width, mapPictureBox.Image.Width));
                //graph.DrawImage(overlayImage, new Rectangle(0, 0, scaleWidth, scaleHeight));


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
            ShowCombinedImage();

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

            layers.Add(new Layer() { Current = new Bitmap(overlayImage), FileName = string.Empty, Location = overlayLocation });

            mapPictureBox.Cursor = Cursors.Default;
            overlayImage.Dispose();
            overlayImage = null;

            renderedMap = RenderLayers();
            mapPictureBox.Image = renderedMap;
            overlayScale = 0;
            originalOverlayImage.Dispose();
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
    }
}
