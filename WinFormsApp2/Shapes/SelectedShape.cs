using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2.Shapes
{
    public class SelectedShape
    {
        public SelectedShape(Shape c)
        {
            shape = c;
            shape.isSelected = true;
        }

        public Shape shape;
        public int dx;
        public int dy;

        public SelectedShape setDelta(int x, int y)
        {
            dx = x - shape.x;
            dy = y - shape.y;

            return this;
        }
        public void move(int x, int y)
        {
            shape.move(dx, dy, x, y);
        }
    }
}
