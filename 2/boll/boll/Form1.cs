using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boll
{
    public partial class Form1 : Form
    {
        private Unit boll;
        public Form1()
        {
            InitializeComponent();
            //размер окна
            MinimumSize = MaximumSize = new Size(800, 800);
            //подгружаем картинку
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            FileStream fs = new FileStream(@"1.png", System.IO.FileMode.Open);
            Image img = Image.FromStream(fs);
            fs.Close();
        
            boll = new Unit() { Sprite = img };

            new Timer { Interval = 30, Enabled = true }.Tick += delegate
            {
                boll.Update(0.1f);
                Invalidate();
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            boll.Draw(e.Graphics);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            boll.Target = e.Location;
        }
    }

    class Unit
    {
        public Image Sprite;
        public PointF Position;
        public PointF Direction;
        public PointF Target;
        public float Speed = 3f;//скорость движения картинки
        

        public void Update(float dt)
        {
            var dirToTarget = new PointF(Target.X - Position.X, Target.Y - Position.Y);

            if (Math.Abs(dirToTarget.X) < 1 && Math.Abs(dirToTarget.Y) < 1)
                return;

            var len = (float)Math.Sqrt(dirToTarget.X * dirToTarget.X + dirToTarget.Y * dirToTarget.Y);
            dirToTarget = new PointF(dirToTarget.X / len, dirToTarget.Y / len);

            var speed = len < Speed ? 1 : Speed;

            Direction = new PointF((Direction.X  * dirToTarget.X), (Direction.Y  * dirToTarget.Y) );
            Position = new PointF(Position.X + speed * dirToTarget.X, Position.Y + speed * dirToTarget.Y);
        }

        public void Draw(Graphics gr)
        {          
            //передает движение
            gr.TranslateTransform(Position.X, Position.Y);
            //размер рисунка меньше больше
            gr.ScaleTransform(0.7f, 0.7f);
            //отрисовка спрайта
            gr.DrawImage(Sprite, -Sprite.Width / 50, -Sprite.Height / 50);
            
        }
    }


}

