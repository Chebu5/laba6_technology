using System;
using System.Drawing;
using System.Windows.Forms;

namespace laba6_technology
{
    public partial class Form1 : Form
    {
        private Emitter emitter = new Emitter();
        private Teleporter teleporter;

        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            var center = new Point(picDisplay.Width / 2, picDisplay.Height / 2);
            teleporter = new Teleporter(center, new Point(center.X + 100, center.Y));
            emitter.Teleporter = teleporter;
            emitter.ParticleSpawnPoint = new PointF(250, 140);

            
            timer1.Tick += timer1_Tick;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            picDisplay.Invalidate();

        }
        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None)
            {
                teleporter.Entry = e.Location;
                picDisplay.Invalidate();
            }
            else if (e.Button == MouseButtons.Right && Control.ModifierKeys == Keys.None)
            {
                teleporter.Exit = e.Location;
                picDisplay.Invalidate();
            }
        }
    }
}
