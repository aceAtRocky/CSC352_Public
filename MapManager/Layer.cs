﻿namespace MapManager
{
    using System;
    using System.Drawing;

    public class Layer
    {
        public Layer()
        {
            Name = Guid.NewGuid().ToString("D");
            ShouldRender = true;
        }

        public Layer(string filePath)
        {
            Current = new Bitmap(filePath);
            FileName = filePath;
            Location = new Point(0, 0);
            Name = Guid.NewGuid().ToString("D");
            ShouldRender = true;
        }

        public Bitmap Current { get; set; }

        public string FileName { get; set; }

        public Point Location { get; set; }

        public string Name { get; set; }

        public Size RenderSize { get; set; }

        public bool ShouldRender { get; set; }
    }
}
