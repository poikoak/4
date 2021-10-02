using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.IO;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;




namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        class Figures
        {
            public Figures(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public int x1, y1, x2, y2;
        }

        int type = 1; //режим рисования
        Point old = new Point();
        bool flag = false;
        ArrayList all = new ArrayList();
        ArrayList current = new ArrayList();
        Color Color = Color.Blue;
        int baseSize = 5;
        int x1, y1;



        List<Figures> prim = new List<Figures>();
        GraphicsState img;


        public Form1()
        {
            InitializeComponent();
        }


        public void Line(Graphics gr, MouseEventArgs e)
        {
            Pen pen = new Pen(Color, baseSize);

            // задание формы концов линии
            pen.SetLineCap(LineCap.Round, LineCap.Square, DashCap.Flat);

            // Рисование линии
            //gr.DrawLine(Pens.DarkMagenta, e.X, e.Y, x1, y1);

            // Рисование линии
            gr.DrawLine(pen, e.X, e.Y, x1, y1);

            // Сохранение линии в списке
            prim.Add(new Figures(e.X, e.Y, x1, y1));

            // Поменять флаг
            flag = false;
        }

        public void Brush(Graphics gr, MouseEventArgs e)
        {
            Pen pen = new Pen(Color, baseSize);
            gr.DrawEllipse(pen, e.X, e.Y, 5, 5);
            gr.Dispose();
        }
        public void FilledTriangle(Graphics gr, MouseEventArgs e)
        {

            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            bitmap.SetResolution(gr.DpiX, gr.DpiY);
            using (Graphics G = Graphics.FromImage(bitmap))
            {
                Brush brush = new SolidBrush(Color);
                Pen pen = new Pen(brush);
                float xDiff = e.X - x1;
                float yDiff = e.Y - y1;
                float xMid = e.X + x1 / 2;
                float yMid = e.Y + y1 / 2;


                var path = new GraphicsPath();
                path.AddLines(new PointF[] {e.Location,new PointF(xMid + yDiff/2, yMid-xDiff/2),new PointF(x1,y1)});
                path.CloseFigure();               
                gr.FillPath(brush, path);              
                gr.DrawPath(pen, path);
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.CompositingMode = CompositingMode.SourceOver;
                gr.DrawPath(new Pen(Color.Red), path);
            }
            bitmap.Save(@"TEST1.jpg", ImageFormat.Jpeg);
        }


        public void Triangle(Graphics gr, MouseEventArgs e)
        {
            Brush brush = new SolidBrush(Color);
            Pen pen = new Pen(brush);
            float xDiff = e.X - x1;
            float yDiff = e.Y - y1;
            float xMid = e.X + x1 / 2;
            float yMid = e.Y + y1 / 2;            
            var path = new GraphicsPath();
            path.AddLines(new PointF[] { new PointF(e.X, e.Y), new PointF(xMid + yDiff / 2, yMid - xDiff / 2), new PointF(x1, y1)});
            path.CloseFigure();
            // рисуем треугол
            gr.DrawPath(pen, path);
        }


        public void FilledRectangle(Graphics gr, MouseEventArgs e)
        {
            Brush brush = new SolidBrush(Color);
            Pen pen = new Pen(brush);          
            var path = new GraphicsPath();
            path.AddLines(new PointF[] {new PointF(e.X, e.Y),new PointF(x1, e.Y),new PointF(x1,y1), new PointF(e.X, y1)});
            path.CloseFigure();
            gr.FillPath(brush, path);
            gr.DrawPath(pen, path);
        }

        public void NotFilledRectangle(Graphics gr, MouseEventArgs e)
        {
            Brush brush = new SolidBrush(Color);
            Pen pen = new Pen(brush);           
            var path = new GraphicsPath();
            path.AddLines(new PointF[] {new PointF(e.X, e.Y),new PointF(x1, e.Y),new PointF(x1,y1), new PointF(e.X, y1)});
            path.CloseFigure();           
            gr.DrawPath(pen, path);
        }
        private void lainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 1;
        }
        private void brushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 2;
        }
        private void yesTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 3;
        }
        private void yesRectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            type = 5;
        }
        private void noTriangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 4;
        }
        private void noRectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            type = 6;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Создание объекта для рисования в окне
            Graphics gr = CreateGraphics();

            if (!flag)
            {
                // Сохранить координаты первой точки
                x1 = e.X;
                y1 = e.Y;

                // Поменять флаг
                flag = true;
            }
            else
            {
                if (type == 1)
                {
                    Line(gr, e);
                }
                else if (type == 2)
                {
                    Brush(gr, e);
                }
                else if (type == 3)
                {
                    FilledTriangle(gr, e);
                }
                else if (type == 4) 
                {
                    Triangle(gr, e);
                }
                else if (type == 5)
                {
                    FilledRectangle(gr, e);
                }
                else if (type == 6) 
                {
                    NotFilledRectangle(gr, e);
                }
            }
            img = gr.Save();         
            gr.Dispose();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {           
            Graphics gr = e.Graphics;          
            foreach (Figures pr in prim)
            {
                Pen p = new Pen(Color.Blue, 3);
                gr.DrawLine(p, pr.x1, pr.y1, pr.x2, pr.y2);
            }
        }

       
        private void jPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new Form();
            myForm.StartPosition = FormStartPosition.Manual;
            myForm.Location = new Point(500, 500);
            myForm.Size = new Size(250, 250);
            Button myButton = new Button();
            myButton.Text = "Save";
            myForm.Controls.Add(myButton);
            TextBox filedir = new TextBox();
            filedir.Text = @"TEST.jpg";
            filedir.Location = new Point(100, 100);
            myForm.Controls.Add(filedir);
            myForm.Show();
            if (myButton.Enabled)
            {
                filedir.Text = filedir.Text;               
                Bitmap myBitmap = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(myBitmap, new Rectangle(Point.Empty, myBitmap.Size));
                myBitmap.Save(filedir.Text, ImageFormat.Jpeg);
                   myForm.Close();
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            dlg.ShowDialog();
            Color = dlg.Color;
        }


    }

}
