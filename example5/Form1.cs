using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace example5
{
    public sealed partial class Form1 : Form
    {
        //Изобразить на форме отрезок, цвет которого плавно меняется.
        public Form1()
        {
            InitializeComponent();

            _graphics = CreateGraphics();
            _originalColor = Color.Blue;
            DoubleBuffered = true;
        }

        private readonly Graphics _graphics;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _graphics.DrawLine(new Pen(FadeToColor(_originalColor, _targetColor, _percent), 40), new Point(100, 50),
                new Point(100, 400));
            _percent += 0.01f;
            if (!(_percent >= 1)) return;
            
            _originalColor = _targetColor;
            var r = new Random();
            _targetColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            _percent = 0;
        }

        private Color _targetColor = Color.Red;
        private Color _originalColor;
        private float _percent = 0;

        private static Color FadeToColor(Color first, Color second, float percent)
        {
            var r = (int) (second.R * percent + first.R * (1f - percent));
            var g = (int) (second.G * percent + first.G * (1f - percent));
            var b = (int) (second.B * percent + first.B * (1f - percent));
            return Color.FromArgb(r, g, b);
        }
    }
}