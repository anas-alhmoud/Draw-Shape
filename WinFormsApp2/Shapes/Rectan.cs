using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.ResizePoints;

namespace WinFormsApp2.Shapes
{
    public class Rectan : Shape
    {
        public Rectan(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;

            this.ResizePoints = new ResizePoint[4] { new TopBorderePoint(this, 10), new BottomBorderePoint(this, 10), new RightBorderePoint(this, 10), new LeftBorderePoint(this, 10) };
        }

        public override Shape draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Brushes.Black, 3), x, y, width, height);

            if (isSelected)
            {
                foreach (var rp in ResizePoints)
                {
                    rp.draw(g);
                }
            }

            return this;
        }
    }
}
