using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using WinFormsApp2.Shapes;

namespace WinFormsApp2.ResizePoints
{
    public class TopBorderePoint : ResizePoint
    {
        protected override Point Location { get { return new Point((shape.x + shape.width / 2) - size / 2, shape.y - size / 2); } }

        public TopBorderePoint(Shape shape, int size)
        {
            this.shape = shape;
            this.size = size;
        }
        public override void resize(int x, int y)
        {
            if (y < shape.y)
            {
                shape.height += shape.y - y;
            }
            else
            {
                shape.height -= y - shape.y;
            }

            shape.y = y;
        }
    }

}
