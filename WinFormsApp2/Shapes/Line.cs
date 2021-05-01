using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.ResizePoints;

namespace WinFormsApp2.Shapes
{
    public class Line : Shape
    {
        public Line(int x1, int y1, int x2, int y2)
        {
            this.x = x1;
            this.y = y1;
            this.width = x2;
            this.height = y2;

            this.ResizePoints = new ResizePoint[2] { new TopLinePoint(this, 10), new BottomLinePoint(this, 10) };
        }

        public override Shape draw(Graphics g)
        {
            g.DrawLine(new Pen(Brushes.Black, 3), x, y, width, height);

            if (isSelected)
            {
                foreach (var rp in ResizePoints)
                {
                    rp.draw(g);
                }
            }

            return this;
        }

        public override Shape move(int dx, int dy, int x, int y)
        {
            // calc shape position
            int dx2 = this.x - this.width;
            int dy2 = this.y - this.height;

            this.x = x - dx;
            this.y = y - dy;

            this.width = this.x - dx2;
            this.height = this.y - dy2;

            return this;
        }
    }
}
