using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.ResizePoints;

namespace WinFormsApp2.Shapes
{
    public abstract class Shape
    {
        public int x;
        public int y;
        public int width;
        public int height;

        public bool isSelected = false;

        protected ResizePoint[] ResizePoints;
        public ResizePoint resizePoint;

        public abstract Shape draw(Graphics g);
        public Shape resize(int x, int y)
        {
            resizePoint.resize(x, y);

            return this;
        }
        public virtual Shape move(int dx, int dy, int x, int y)
        {
            // calc shape position
            this.x = x - dx;
            this.y = y - dy;

            return this;
        }

        public bool onResize(int x, int y)
        {
            foreach (ResizePoint rp in ResizePoints)
            {
                if (rp.contains(x, y))
                {
                    this.resizePoint = rp;
                    return true;
                }
            }

            return false;
        }

    }
}
