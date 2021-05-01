using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormsApp2.Shapes;
using WinFormsApp2.ResizePoints;

namespace WinFormsApp2
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
        }

        public List<Shape> shapeList;

        public SelectedShape selected;

        bool userIsHolding = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            shapeList = new List<Shape>();

            shapeList.Add(new Rectan(100, 200, 100, 100));
            shapeList.Add(new Circle(300, 200, 100, 100));
            shapeList.Add(new Line(400, 200, 420, 240));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            foreach (var shape in shapeList)
                shape.draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            userIsHolding = true;

            if (selected != null)
            {
                if(selected.shape.onResize(e.X, e.Y))
                {
                    return;
                }

                selected.shape.isSelected = false;
                Invalidate();
            }

            foreach (var shape in shapeList)
            {
                Rectangle rec = new Rectangle(shape.x, shape.y, shape.width, shape.height);

                if (rec.Contains(e.X, e.Y))
                {
                    selected = new SelectedShape(shape);

                    selected.setDelta(e.X, e.Y);

                    return;
                }
            }

            selected = null;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selected != null)
            {
                selected.shape.resizePoint = null;
            }

            userIsHolding = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(selected != null && userIsHolding)
            {
                if (selected.shape.resizePoint != null)
                {
                   selected.shape.resize(e.X, e.Y);
                } else
                {
                    selected.move(e.X, e.Y);
                }

                Invalidate();
            }
        }
    }
}
