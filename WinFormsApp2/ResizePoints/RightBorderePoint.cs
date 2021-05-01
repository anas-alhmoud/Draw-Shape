using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.Shapes;

namespace WinFormsApp2.ResizePoints
{
    public class RightBorderePoint : ResizePoint
    {
        protected override Point Location { get { return new Point((shape.x + shape.width) - size / 2, shape.y + shape.height / 2 - size / 2); } }

        public RightBorderePoint(Shape shape, int size)
        {
            this.shape = shape;
            this.size = size;
        }
        public override void resize(int x, int y)
        {
            shape.width = x - shape.x;
        }
    }
}
