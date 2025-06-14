﻿using System;
using System.Drawing;

namespace laba6_technology
{
    public class Particle
    {
        public int Radius;
        public float X;
        public float Y;
        public float SpeedX;
        public float SpeedY;
        public bool IsTeleported = false;
        public float Life;
        public static Random rand = new Random();
        public virtual void Draw(Graphics g)
        {
            
        }
    }
    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            var color = MixColor(ToColor, FromColor, k);
            using var b = new SolidBrush(color);
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
