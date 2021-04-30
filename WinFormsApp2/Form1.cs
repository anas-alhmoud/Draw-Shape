using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public class Circle
        {
            public int x;
            public int y;
            public int width;
            public int height;

            public Circle(int x, int y, int width, int height)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }

            public Circle draw(Graphics g)
            {
                g.DrawEllipse(new Pen(Brushes.Black, 3), x, y, width, height);

                return this;
            }
            public Circle resize(string dir, int x, int y)
            {
                return this;
            }
            public Circle move(int dx, int dy, int x, int y)
            {
                // calc shape position
                this.x = x - dx;
                this.y = y - dy;

                return this;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        public Circle mainShape;
        public Circle selected;
        int dx;
        int dy;
        bool userIsHolding = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            mainShape = new Circle(100, 200, 300, 300);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            mainShape.draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            userIsHolding = true;
            // TODO: Implement resize

            // loop throw all shapes

            Rectangle rec = new Rectangle(mainShape.x, mainShape.y, mainShape.width, mainShape.height);

            if (rec.Contains(e.X, e.Y))
            {
                // calc d
                dx = e.X - rec.X;
                dy = e.Y - rec.Y;

                selected = mainShape;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            selected = null;
            userIsHolding = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(selected != null && userIsHolding)
            {
                selected.move(dx, dy, e.X, e.Y);

                Invalidate();
            }
        }
    }
}
