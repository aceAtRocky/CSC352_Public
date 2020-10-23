using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            assetPictureBox.AllowDrop = true;
            mapPictureBox.AllowDrop = true;
        }

        private void assetPictureBox_DragLeave(object sender, EventArgs e)
        {
            Debug.WriteLine("Drag Leave Encountered");
        }

        private void assetPictureBox_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drag Drop Encountered");

        }

        private void assetPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drag Enter Encountered");

        }

        private void assetPictureBox_DragOver(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Drag Over Encountered");

        }

        private void assetPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            assetPictureBox.DoDragDrop(assetPictureBox.Image, DragDropEffects.Copy);
        }

        private void mapPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Map: Drag Enter Event Encountered");
        }

        private void mapPictureBox_DragDrop(object sender, DragEventArgs e)
        {
            Debug.WriteLine("Map: Drag Drop Operation Completed");
        }
    }
}
