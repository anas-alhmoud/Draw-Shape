using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.Shapes;

namespace WinFormsApp2.ResizePoints
{
    public class TopLinePoint : ResizePoint
    {
        protected override Point Location { get { return new Point(shape.x - size / 2, shape.y - size / 2); } }

        public TopLinePoint(Shape shape, int size)
        {
            this.shape = shape;
            this.size = size;
        }
        public override void resize(int x, int y)
        {
            shape.y = y;
            shape.x = x;
        }
    }
}
