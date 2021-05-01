using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.Shapes;

namespace WinFormsApp2.ResizePoints
{
    public class BottomLinePoint : ResizePoint
    {
        protected override Point Location { get { return new Point(shape.width - size / 2, shape.height - size / 2); } }

        public BottomLinePoint(Shape shape, int size)
        {
            this.shape = shape;
            this.size = size;
        }
        public override void resize(int x, int y)
        {
            shape.height = y;
            shape.width = x;
        }
    }
}
