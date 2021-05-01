using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.Shapes;

namespace WinFormsApp2.ResizePoints
{
    public abstract class ResizePoint
    {
        protected Shape shape;
        protected abstract Point Location { get; }
        protected int size;

        public bool contains(int x, int y)
        {
            Rectangle rec = new Rectangle(Location.X, Location.Y, size, size);
            return rec.Contains(x, y);
        }

        public void draw(Graphics g)
        {
            Rectangle r = new Rectangle(Location.X, Location.Y, size, size);
            g.DrawEllipse(new Pen(Brushes.Black, 3), r);
            g.FillEllipse(Brushes.Red, r);
        }

        public abstract void resize(int x, int y);
    }

}
